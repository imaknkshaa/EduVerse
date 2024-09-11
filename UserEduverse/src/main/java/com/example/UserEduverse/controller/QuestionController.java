package com.example.UserEduverse.controller;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.UserEduverse.model.Questions;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.JUserService;
import com.example.UserEduverse.service.QuestionService;


@RestController
@RequestMapping("/api/questions")
@CrossOrigin(origins = "http://localhost:3000")
public class QuestionController {

    @Autowired
    private QuestionService questionService;

    @Autowired
    private JUserService jUserService;  // Service to retrieve the user from JWT

    @PostMapping
    public ResponseEntity<Questions> createQuestion(@RequestBody Questions question,
                                                    @RequestHeader("Authorization") String jwt) throws Exception {
        // Verify user through JWT
        User user = jUserService.findUserProfileByJwt(jwt);
        
        // Only authenticated users can create questions
        Questions createdQuestion = questionService.createQuestion(question, user);
        return new ResponseEntity<>(createdQuestion, HttpStatus.CREATED);
    }

    @PutMapping("/{questionId}")
    public ResponseEntity<Questions> updateQuestion(@PathVariable int questionId,
                                                    @RequestBody Questions question,
                                                    @RequestHeader("Authorization") String jwt) throws Exception {
        // Verify user through JWT
        User user = jUserService.findUserProfileByJwt(jwt);
        
        // Only authenticated users can update questions
        Questions updatedQuestion = questionService.updateQuestion(questionId, question, user);
        return new ResponseEntity<>(updatedQuestion, HttpStatus.OK);
    }

    @DeleteMapping("/{questionId}")
    public ResponseEntity<Void> deleteQuestion(@PathVariable int questionId,
                                               @RequestHeader("Authorization") String jwt) throws Exception {
        // Verify user through JWT
        User user = jUserService.findUserProfileByJwt(jwt);
        
        // Only authenticated users can delete questions
        questionService.deleteQuestion(questionId, user);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }

    @GetMapping("/{quizId}")
    public ResponseEntity<List<Questions>> getQuestionsByQuiz(@PathVariable int quizId,
                                                              @RequestHeader("Authorization") String jwt) throws Exception {
        // Verify user through JWT
        User user = jUserService.findUserProfileByJwt(jwt);
        
        // Retrieve questions related to the quiz (auth users)
        List<Questions> questions = questionService.getQuestionsByQuiz(quizId, user);
        return new ResponseEntity<>(questions, HttpStatus.OK);
    }
}
