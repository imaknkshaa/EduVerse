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
import com.example.UserEduverse.dao.CourseRepository;
import com.example.UserEduverse.model.Assignment;
import com.example.UserEduverse.model.Course;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.JUserService;
import com.example.UserEduverse.service.UserService;

@RestController
@RequestMapping("/api/assignments")
public class AssignmentsController {

    @Autowired
    private AssignmentRepository assignmentRepository;

    @Autowired
    private CourseRepository courseRepository;
    
    @Autowired
    private JUserService userService; // Inject UserService for JWT token verification

    private final String assignmentDirectory = System.getProperty("user.dir") + "/files/assignments/";

    public AssignmentsController() {
        File directory = new File(assignmentDirectory);
        if (!directory.exists()) {
            directory.mkdirs();
        }
    }

    @GetMapping("/{courseId}")
    public ResponseEntity<List<Assignment>> getAssignments(@PathVariable int courseId,
                                                           @RequestHeader("Authorization") String jwt) throws Exception {
        // Validate the JWT and retrieve the user
        User user = userService.findUserProfileByJwt(jwt);
        if (user == null) {
        	// Retrieve the course and assignments
            Optional<Course> courseOpt = courseRepository.findById(courseId);
            if (courseOpt.isPresent()) {
                List<Assignment> assignments = assignmentRepository.findByCourse(courseOpt.get());
                return ResponseEntity.ok(assignments);
            } else {
                return ResponseEntity.notFound().build();
            }
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }

    @GetMapping("/{assignmentId}")
    public ResponseEntity<Assignment> getAssignment(@PathVariable int assignmentId,
                                                    @RequestHeader("Authorization") String jwt) throws Exception {
        // Validate the JWT and retrieve the user
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	// Retrieve the assignment
            return assignmentRepository.findById(assignmentId)
                    .map(ResponseEntity::ok)
                    .orElse(ResponseEntity.notFound().build());
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }

    @PutMapping("/{assignmentId}")
    public ResponseEntity<Void> updateAssignment(@PathVariable int assignmentId,
                                                 @RequestBody Assignment assignment,
                                                 @RequestHeader("Authorization") String jwt) throws Exception {
        // Validate the JWT and retrieve the user
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	// Verify the assignment ID and update the assignment
            if (assignmentId != assignment.getAssignmentId()) {
                return ResponseEntity.badRequest().build();
            }
            assignmentRepository.save(assignment);
            return ResponseEntity.noContent().build();
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }

    @PostMapping
    public ResponseEntity<Assignment> createAssignment(@RequestBody Assignment assignment,
                                                       @RequestParam("file") MultipartFile file,
                                                       @RequestHeader("Authorization") String jwt) throws IOException, Exception {
        // Validate the JWT and retrieve the user
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	// Handle file upload and save the assignment
            if (!file.isEmpty()) {
                String fileName = file.getOriginalFilename();
                String filePath = assignmentDirectory + fileName;
                try (FileOutputStream fos = new FileOutputStream(filePath)) {
                    fos.write(file.getBytes());
                }
                assignment.setFilePath(fileName);
            }
            Assignment savedAssignment = assignmentRepository.save(assignment);
            return new ResponseEntity<>(savedAssignment, HttpStatus.CREATED);
        }
        throw new Exception("Unauthorized to update quizzes");
        
    }

    @DeleteMapping("/{assignmentId}")
    public ResponseEntity<Void> deleteAssignment(@PathVariable int assignmentId,
                                                 @RequestHeader("Authorization") String jwt) throws Exception {
        // Validate the JWT and retrieve the user
        User user = userService.findUserProfileByJwt(jwt);
        if (user != null) {
        	 // Delete the assignment if the user is authorized
            assignmentRepository.deleteById(assignmentId);
            return ResponseEntity.noContent().build();
        }
        throw new Exception("Unauthorized to update quizzes");
       
    }
}
