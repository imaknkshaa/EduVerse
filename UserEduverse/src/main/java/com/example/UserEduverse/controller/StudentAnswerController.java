package com.example.UserEduverse.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.example.UserEduverse.model.StudentAnswer;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.JUserService;
import com.example.UserEduverse.service.StudentAnswerService;

@RestController
@RequestMapping("/api/answers")
@CrossOrigin(origins = "http://localhost:3000")
public class StudentAnswerController {

    @Autowired
    private StudentAnswerService studentAnswerService;

    @Autowired
    private JUserService jUserService;

    @PostMapping
    public ResponseEntity<StudentAnswer> submitAnswer(@RequestBody StudentAnswer studentAnswer,
                                                      @RequestHeader("Authorization") String jwt) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);
        
        StudentAnswer submittedAnswer = studentAnswerService.submitAnswer(studentAnswer, user);
        return new ResponseEntity<>(submittedAnswer, HttpStatus.CREATED);
    }

    @GetMapping("/{studentId}/quiz/{quizId}")
    public ResponseEntity<List<StudentAnswer>> getStudentAnswers(@RequestHeader("Authorization") String jwt,
                                                                 @PathVariable int quizId) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);

        int studentId = user.getUserId();
        List<StudentAnswer> answers = studentAnswerService.getStudentAnswers(studentId, quizId);
        return new ResponseEntity<>(answers, HttpStatus.OK);
    }

    @GetMapping("/marks")
    public ResponseEntity<Integer> getMarks(@RequestHeader("Authorization") String jwt,
                                            @RequestParam int quizId) throws Exception {
        User user = jUserService.findUserProfileByJwt(jwt);

        int studentId = user.getUserId();
        int marks = studentAnswerService.calculateMarks(studentId, quizId);
        return new ResponseEntity<>(marks, HttpStatus.OK);
    }
}

