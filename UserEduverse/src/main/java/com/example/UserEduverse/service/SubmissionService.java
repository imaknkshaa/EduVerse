package com.example.UserEduverse.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.SubmissionRepository;
import com.example.UserEduverse.model.Submission;

@Service
public class SubmissionService {

    @Autowired
    private SubmissionRepository submissionRepository;

    public List<Submission> getSubmissionsByAssignmentId(int assignmentId) {
        return submissionRepository.findByAssignment_AssignmentId(assignmentId);
    }

    public Optional<Submission> getSubmissionById(int submissionId) {
        return submissionRepository.findById(submissionId);
    }

    public Submission saveSubmission(Submission submission) {
        return submissionRepository.save(submission);
    }

    public void deleteSubmissionById(int submissionId) {
       
        if (submissionRepository.existsById(submissionId)) {
            submissionRepository.deleteById(submissionId);
        } else {
           
            throw new IllegalArgumentException("Submission with id " + submissionId + " does not exist.");
        }
    }
}