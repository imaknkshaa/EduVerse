package com.example.UserEduverse.controller;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

import com.example.UserEduverse.dao.AssignmentRepository;
import com.example.UserEduverse.dao.SubmissionRepository;
import com.example.UserEduverse.model.Assignment;
import com.example.UserEduverse.model.Submission;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.JUserService;
import com.example.UserEduverse.service.UserService;

@RestController
@RequestMapping("/api/submissions")
public class SubmissionsController {

    @Autowired
    private SubmissionRepository submissionRepository;

    @Autowired
    private AssignmentRepository assignmentRepository;

    @Autowired
    private JUserService userService;

    private final String submissionDirectory = System.getProperty("user.dir") + "/files/submissions/";

    public SubmissionsController() {
        File directory = new File(submissionDirectory);
        if (!directory.exists()) {
            directory.mkdirs();
        }
    }

    @GetMapping
    public ResponseEntity<List<Submission>> getSubmissions(@RequestParam int assignmentId,
                                                           @RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {

            // Return submissions for the specified assignment
            return ResponseEntity.ok(submissionRepository.findByAssignment_AssignmentId(assignmentId));
        }
        throw new Exception("Unauthorized");

    }

    @GetMapping("/{submissionId}")
    public ResponseEntity<Submission> getSubmission(@PathVariable Integer submissionId,
                                                    @RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	// Retrieve the submission by ID
        	Optional<Submission> submissionOpt = submissionRepository.findById(submissionId);
            if (submissionOpt.isPresent()) {
                // Optionally, you can check if the user is authorized to view this submission
                return ResponseEntity.ok(submissionOpt.get());
            } else {
                return ResponseEntity.notFound().build();
            }
        }
        throw new Exception("Unauthorized to update quizzes");
        
        
    }

    @PutMapping("/{submissionId}")
    public ResponseEntity<Void> updateSubmission(@PathVariable Integer submissionId,
                                                 @RequestBody Submission submission,
                                                 @RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	if (!submission.getSubmissionId().equals(submissionId)) {
                return ResponseEntity.badRequest().build();
            }

            // Optionally, you can check if the user is authorized to update this submission

            submissionRepository.save(submission);
            return ResponseEntity.noContent().build();
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }

    @PostMapping
    public ResponseEntity<Submission> createSubmission(@RequestParam("file") MultipartFile file,
                                                       @RequestParam("assignmentId") int assignmentId,
                                                       @RequestParam("studentId") int studentId,
                                                       @RequestHeader("Authorization") String jwt) throws IOException, Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	// Ensure the authenticated user matches the studentId (optional validation)
            if (user.getUserId()!=(studentId)) {
                return ResponseEntity.status(HttpStatus.FORBIDDEN).build();
            }

            // Retrieve the Assignment entity
            Optional<Assignment> assignmentOpt = assignmentRepository.findById(assignmentId);
            if (!assignmentOpt.isPresent()) {
                return ResponseEntity.notFound().build();
            }

            String fileName = file.getOriginalFilename();
            String filePath = submissionDirectory + fileName;
            try (FileOutputStream fos = new FileOutputStream(filePath)) {
                fos.write(file.getBytes());
            }

            Submission submission = new Submission();
            submission.setFile(fileName);
            submission.setAssignment(assignmentOpt.get());
            submission.setStudentId(studentId);
            submission.setStatus("Submitted");

            Submission savedSubmission = submissionRepository.save(submission);
            return new ResponseEntity<>(savedSubmission, HttpStatus.CREATED);
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }

    @DeleteMapping("/{submissionId}")
    public ResponseEntity<Void> deleteSubmission(@PathVariable Integer submissionId,
                                                 @RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	// Retrieve the submission and ensure the user is authorized to delete it
            Optional<Submission> submissionOpt = submissionRepository.findById(submissionId);

            if (submissionOpt.isPresent() && submissionOpt.get().getStudentId()==(user.getUserId())) {
                submissionRepository.deleteById(submissionId);
                return ResponseEntity.noContent().build();
            } 
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }
}
