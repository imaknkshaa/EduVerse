package com.example.UserEduverse.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.QuestionRepository;
import com.example.UserEduverse.model.Questions;
import com.example.UserEduverse.model.User;

@Service
public class QuestionService {

    @Autowired
    private QuestionRepository questionRepository;

    public Questions createQuestion(Questions question, User user) throws Exception {
        // Logic to verify user role (if necessary) and save question
        if (user != null && user.getRole().equals("TEACHER")) {
            return questionRepository.save(question);
        }
        throw new Exception("Unauthorized to create questions");
    }

    public Questions updateQuestion(int questionId, Questions question, User user) throws Exception {
        // Logic to verify user role (if necessary) and update question
        if (user != null && user.getRole().equals("TEACHER")) {
            question.setQuestionId(questionId);
            return questionRepository.save(question);
        }
        throw new Exception("Unauthorized to update questions");
    }

    public void deleteQuestion(int questionId, User user) throws Exception {
        // Logic to verify user role (if necessary) and delete question
        if (user != null) {
            questionRepository.deleteById(questionId);
        } else {
            throw new Exception("Unauthorized to delete questions");
        }
    }

    public List<Questions> getQuestionsByQuiz(int quizId, User user) throws Exception {
        // Logic to verify user role (if necessary) and retrieve questions
        if (user != null) {
            return questionRepository.findByQuiz_QuizId(quizId);
        }
        throw new Exception("Unauthorized to view questions");
    }
}
