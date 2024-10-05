package com.example.UserEduverse.dao;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.UserEduverse.model.Quiz;



public interface QuizRepository extends JpaRepository<Quiz, Integer> {
}
