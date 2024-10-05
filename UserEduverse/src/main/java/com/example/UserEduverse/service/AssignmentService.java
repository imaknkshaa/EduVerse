package com.example.UserEduverse.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.AssignmentRepository;
import com.example.UserEduverse.dao.CourseRepository;
import com.example.UserEduverse.model.Assignment;
import com.example.UserEduverse.model.Course;


@Service
public class AssignmentService {

    @Autowired
    private AssignmentRepository assignmentRepository;

    @Autowired
    private CourseRepository courseRepository; 
    public List<Assignment> getAssignmentsByCourseId(int courseId) {
        Optional<Course> courseOpt = courseRepository.findById(courseId);
        if (courseOpt.isPresent()) {
            return assignmentRepository.findByCourse(courseOpt.get());
        } else {
          
            return List.of(); 
        }
    }

    public Optional<Assignment> getAssignmentById(int assignmentId) {
        return assignmentRepository.findById(assignmentId);
    }

    public Assignment saveAssignment(Assignment assignment) {
        return assignmentRepository.save(assignment);
    }

    public void deleteAssignment(int assignmentId) {
        assignmentRepository.deleteById(assignmentId);
    }
}