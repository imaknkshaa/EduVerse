package com.example.UserEduverse.dao;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.UserEduverse.model.Submission;


@Repository
public interface SubmissionRepository extends JpaRepository<Submission, Integer> {
    List<Submission> findByAssignment_AssignmentId(Integer assignmentId);
}