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

import com.example.UserEduverse.model.Quiz;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.JUserService;
import com.example.UserEduverse.service.QuizService;

@RestController
@RequestMapping("/api/quizzes")
@CrossOrigin(origins = "http://localhost:3000")
public class QuizController {

    @Autowired
    private QuizService quizService;

    @Autowired
    private JUserService jUserService;

    @PostMapping
    public ResponseEntity<Quiz> createQuiz(@RequestBody Quiz quiz, @RequestHeader("Authorization") String jwt) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);
        Quiz createdQuiz = quizService.createQuiz(quiz, user);
        return new ResponseEntity<>(createdQuiz, HttpStatus.CREATED);
    }

    @PutMapping("/{quizId}")
    public ResponseEntity<Quiz> updateQuiz(@PathVariable int quizId, @RequestBody Quiz quiz, @RequestHeader("Authorization") String jwt) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);
        Quiz updatedQuiz = quizService.updateQuiz(quizId, quiz, user);
        return new ResponseEntity<>(updatedQuiz, HttpStatus.OK);
    }

    @DeleteMapping("/{quizId}")
    public ResponseEntity<Void> deleteQuiz(@PathVariable int quizId, @RequestHeader("Authorization") String jwt) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);
        quizService.deleteQuiz(quizId, user);
        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }

    @GetMapping
    public ResponseEntity<List<Quiz>> getAllQuizzes(@RequestHeader("Authorization") String jwt) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);
        List<Quiz> quizzes = quizService.getAllQuizzes(user);
        return new ResponseEntity<>(quizzes, HttpStatus.OK);
    }
}
