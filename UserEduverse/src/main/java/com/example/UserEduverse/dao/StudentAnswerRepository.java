package com.example.UserEduverse.dao;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.UserEduverse.model.StudentAnswer;



public interface StudentAnswerRepository extends JpaRepository<StudentAnswer, Integer> {
    List<StudentAnswer> findByStudentIdAndQuizId(int studentId, int quizId);
}
