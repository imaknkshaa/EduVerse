package com.example.UserEduverse.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.UserEduverse.model.Course;


@Repository
public interface CourseRepository extends JpaRepository<Course, Integer> {
}
