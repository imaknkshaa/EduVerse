package com.example.UserEduverse.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.CourseRepository;
import com.example.UserEduverse.model.Course;

@Service
public class CourseService {

    @Autowired
    private CourseRepository courseRepository;

    public Optional<Course> getCourseById(Integer courseId) {
        return courseRepository.findById(courseId);
    }

    public Course saveCourse(Course course) {
        return courseRepository.save(course);
    }

    public void deleteCourse(Integer courseId) {
        courseRepository.deleteById(courseId);
    }

    public List<Course> getAllCourses() {
        return courseRepository.findAll();
    }
}
