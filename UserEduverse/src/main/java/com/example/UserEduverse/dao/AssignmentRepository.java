package com.example.UserEduverse.dao;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.UserEduverse.model.Assignment;
import com.example.UserEduverse.model.Course;

@Repository
public interface AssignmentRepository extends JpaRepository<Assignment, Integer> {
    List<Assignment> findByCourse(Course course);
}

