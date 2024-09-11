package com.example.UserEduverse.dao;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.UserEduverse.model.Questions;


public interface QuestionRepository extends JpaRepository<Questions, Integer> {
    List<Questions> findByQuiz_QuizId(int quizId);
}
