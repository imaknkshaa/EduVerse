package com.example.UserEduverse.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.QuizRepository;
import com.example.UserEduverse.model.Quiz;
import com.example.UserEduverse.model.User;


@Service
public class QuizService {

    @Autowired
    private QuizRepository quizRepository;

    public Quiz createQuiz(Quiz quiz, User user) throws Exception {
        // Check if the user is authorized to create quizzes (e.g., instructor or admin role)
        if (user != null && (user.getRole().equals("INSTRUCTOR") || user.getRole().equals("ADMIN"))) {
            return quizRepository.save(quiz);
        }
        throw new Exception("Unauthorized to create quizzes");
    }

    public Quiz updateQuiz(int quizId, Quiz quiz, User user) throws Exception {
        // Check if the user is authorized to update the quiz
        if (user != null && (user.getRole().equals("INSTRUCTOR") || user.getRole().equals("ADMIN"))) {
            quiz.setQuizId(quizId);
            return quizRepository.save(quiz);
        }
        throw new Exception("Unauthorized to update quizzes");
    }

    public void deleteQuiz(int quizId, User user) throws Exception {
        // Check if the user is authorized to delete the quiz
        if (user != null && (user.getRole().equals("ADMIN"))) {
            quizRepository.deleteById(quizId);
        } else {
            throw new Exception("Unauthorized to delete quizzes");
        }
    }

    public List<Quiz> getAllQuizzes(User user) throws Exception {
        // Allow only authenticated users to retrieve quizzes
        if (user != null) {
            return quizRepository.findAll();
        }
        throw new Exception("Unauthorized to view quizzes");
    }
}

