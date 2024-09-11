package com.example.UserEduverse.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.QuestionRepository;
import com.example.UserEduverse.dao.StudentAnswerRepository;
import com.example.UserEduverse.model.Questions;
import com.example.UserEduverse.model.StudentAnswer;
import com.example.UserEduverse.model.User;


@Service
public class StudentAnswerService {

    @Autowired
    private StudentAnswerRepository studentAnswerRepository;

    @Autowired
    private QuestionRepository questionRepository;

    public StudentAnswer submitAnswer(StudentAnswer studentAnswer,User userOptional) {
        // Fetch the question from the repository
        Questions question = questionRepository.findById(studentAnswer.getQuestionId()).orElse(null);

        // Check if the question exists and mark the answer as correct or incorrect
        if (question != null) {
            studentAnswer.setCorrected(question.getAnswer().equals(studentAnswer.getAnswer()));
        } else {
            studentAnswer.setCorrected(false); 
        }
        
       
         studentAnswer.setUser(userOptional); // Extract userId from User object
       
        // Save the student answer in the repository and return the saved entity
        return studentAnswerRepository.save(studentAnswer);
    }


    public List<StudentAnswer> getStudentAnswers(int studentId, int quizId) {
        return studentAnswerRepository.findByStudentIdAndQuizId(studentId, quizId);
    }

    public int calculateMarks(int studentId, int quizId) {
        List<StudentAnswer> answers = studentAnswerRepository.findByStudentIdAndQuizId(studentId, quizId);
        return (int) answers.stream().filter(StudentAnswer::isCorrected).count();
    }
}

