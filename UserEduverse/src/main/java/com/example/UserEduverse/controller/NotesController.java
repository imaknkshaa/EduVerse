package com.example.UserEduverse.controller;
//
//import java.io.IOException;
//import java.util.concurrent.ExecutionException;
//import org.springframework.web.multipart.MultipartFile;
//
//import com.example.UserEduverse.model.Notes;
//import com.example.UserEduverse.model.User;
//import com.example.UserEduverse.service.JUserService;
//import com.example.UserEduverse.service.NotesService;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.http.HttpStatus;
//import org.springframework.http.ResponseEntity;
//import org.springframework.web.bind.annotation.DeleteMapping;
//import org.springframework.web.bind.annotation.GetMapping;
//import org.springframework.web.bind.annotation.PathVariable;
//import org.springframework.web.bind.annotation.PostMapping;
//import org.springframework.web.bind.annotation.PutMapping;
//import org.springframework.web.bind.annotation.RequestBody;
//import org.springframework.web.bind.annotation.RequestHeader;
//import org.springframework.web.bind.annotation.RequestMapping;
//import org.springframework.web.bind.annotation.RequestParam;
//import org.springframework.web.bind.annotation.RestController;
//
//
//
//@RestController
//@RequestMapping("/notes")
//public class NotesController {
//
//	@Autowired
//    private NotesService notesService;
//    
//    @Autowired
//    private JUserService jUserService;  
//
//    @PostMapping("/save")
//    public ResponseEntity<Notes> createNotes(@RequestBody Notes notes,
//                                             @RequestHeader("Authorization") String jwt) throws Exception {
//        // Extract the user from the JWT token
//        User user = jUserService.findUserProfileByJwt(jwt);
//        
//        // Save the notes and associate them with the authenticated user
//        return new ResponseEntity<>(notesService.saveNotes(notes, user), HttpStatus.CREATED);
//    }
//
//    @GetMapping("/get/{id}")
//    public ResponseEntity<Notes> getNotes(@PathVariable int id,
//                                          @RequestHeader("Authorization") String jwt) throws Exception {
//        // Extract the user from the JWT token
//        User user = jUserService.findUserProfileByJwt(jwt);
//        
//        // Retrieve the notes if the user is authorized
//        return new ResponseEntity<>(notesService.getNotes(id, user), HttpStatus.OK);
//    }
//

//}

//
//import java.io.IOException;
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
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

import com.example.UserEduverse.model.Course;
import com.example.UserEduverse.model.Notes;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.CourseService;
import com.example.UserEduverse.service.JUserService;
import com.example.UserEduverse.service.NotesService;
import com.example.UserEduverse.service.UserService;

@RestController
@RequestMapping("/api/notes")
public class NotesController {

    @Autowired
    private NotesService notesService;

    @Autowired
    private JUserService userService; 

    @Autowired
    private CourseService courseService; 

    private final String noteDirectory = System.getProperty("user.dir") + "/files/notes/";

    public NotesController() {
        File directory = new File(noteDirectory);
        if (!directory.exists()) {
            directory.mkdirs();
        }
    }

    @GetMapping
    public ResponseEntity<List<Notes>> getAllNotes(@RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);

        if (user != null) {
        	// Fetch and return notes for authenticated user
            return ResponseEntity.ok(notesService.getAllNotes(user));
        }
        throw new Exception("notes not present");
        
    }

    @GetMapping("/{noteId}")
    public ResponseEntity<Notes> getNoteById(@PathVariable Integer noteId,
                                             @RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);

        if (user != null) {
        	Optional<Notes> note = notesService.getNoteById(noteId);

            if (note.isPresent() && note.get().getUser().equals(user)) {
                return ResponseEntity.ok(note.get());
            } 
        }
        throw new Exception("Unauthorized ");
        // Retrieve the note by ID, ensuring the user is authorized
        
    }

    @PostMapping
    public ResponseEntity<Notes> createNote(@RequestParam("file") MultipartFile file,
                                            @RequestParam("title") String title,
                                            @RequestParam("courseId") Integer courseId,
                                            @RequestHeader("Authorization") String jwt) throws IOException, Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);

        if (user != null) {
        	// Validate the course
            Optional<Course> courseOpt = courseService.getCourseById(courseId);  
            if (courseOpt.isEmpty()) {
                return ResponseEntity.badRequest().build(); 
            }

            // Save the file locally
            String fileName = file.getOriginalFilename();
            String filePath = noteDirectory + fileName;
            try (FileOutputStream fos = new FileOutputStream(filePath)) {
                fos.write(file.getBytes());
            }

            // Create and save the note
            Notes note = new Notes();
            note.setTitle(title);
            note.setFile(fileName);
            note.setUser(user);
            note.setCourse(courseOpt.get());

            Notes savedNote = notesService.saveNote(note);
            return new ResponseEntity<>(savedNote, HttpStatus.CREATED);
        }
        throw new Exception("Unauthorized");
        
    }

    @DeleteMapping("/{noteId}")
    public ResponseEntity<Void> deleteNoteById(@PathVariable Integer noteId,
                                               @RequestHeader("Authorization") String jwt) throws Exception {
        // Extract and validate the user from the JWT token
        User user = userService.findUserProfileByJwt(jwt);

        if (user != null) {
        	// Retrieve the note and ensure the user is authorized to delete it
            Optional<Notes> note = notesService.getNoteById(noteId);
        	if (note.isPresent() && note.get().getUser().equals(user)) {
                notesService.deleteNoteById(noteId);
                return ResponseEntity.noContent().build();
            }
        }
        throw new Exception("Unauthorized");
        

         
    }
}
