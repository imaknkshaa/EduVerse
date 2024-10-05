package com.example.UserEduverse.service;
//
//import java.io.IOException;
//import java.util.concurrent.ExecutionException;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.stereotype.Service;
//import org.springframework.web.multipart.MultipartFile;
//
//import com.app.dao.NotesDao;
//import com.app.model.Notes;
//import com.google.cloud.storage.Blob;
//import com.google.firebase.cloud.StorageClient;
//
//@Service
//public class NotesService {
//
//    @Autowired
//    private NotesDao notesDAO;
//
//    public String saveNotes(Notes notes) throws ExecutionException, InterruptedException {
//        return notesDAO.save(notes);
//    }
//
//    public Notes getNotes(String noteId) throws ExecutionException, InterruptedException {
//        return notesDAO.get(noteId);
//    }
//
//    public String updateNotes(Notes notes) throws ExecutionException, InterruptedException {
//        return notesDAO.update(notes);
//    }
//
//    public String deleteNotes(String noteId) {
//        return notesDAO.delete(noteId);
//    }
//
//    public String uploadFile(MultipartFile file) throws IOException {
//        String fileName = file.getOriginalFilename();
//        Blob blob = StorageClient.getInstance().bucket().create(fileName, file.getInputStream(), file.getContentType());
//        return blob.getMediaLink();
//    }
//
//    public byte[] downloadFile(String fileName) throws IOException {
//        Blob blob = StorageClient.getInstance().bucket().get(fileName);
//        return blob.getContent();
//    }
//
//    public String deleteFile(String fileName) {
//        boolean deleted = StorageClient.getInstance().bucket().get(fileName).delete();
//        return deleted ? "File deleted successfully" : "File deletion failed";
//    }
//}
//
//import java.util.Optional;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.stereotype.Service;
//
//import com.example.UserEduverse.dao.NotesRepository;
//import com.example.UserEduverse.model.Notes;
//import com.example.UserEduverse.model.User;
//
//
//@Service
//public class NotesService {
//	
//    @Autowired
//    private NotesRepository notesRepository;
//
//    public Notes saveNotes(Notes notes, User user) throws Exception {
//        if (notes != null) {
//            // Associate notes with the authenticated user (if required)
//            notes.setUser(user);  // Assuming Notes entity has a `user` field
//            return notesRepository.save(notes);
//        }
//        throw new Exception("Invalid notes data");
//    }
//    
//    public Notes getNotes(int id, User user) throws Exception {
//        Optional<Notes> notes = notesRepository.findById(id);
//        if (notes.isPresent()) {
//            Notes retrievedNotes = notes.get();
//            // Ensure the user is authorized to access the notes (ownership check)
//            if (retrievedNotes.getUser().getUserId() == user.getUserId()) {
//                return retrievedNotes;
//            } else {
//                throw new Exception("Unauthorized access");
//            }
//        }
//        throw new Exception("Notes not available");
//    }
//}
//


import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.NoteRepository;
import com.example.UserEduverse.model.Notes;
import com.example.UserEduverse.model.User;



@Service
public class NotesService {

    @Autowired
    private NoteRepository noteRepository;

    public List<Notes> getAllNotes(User user ) {
        return noteRepository.findAll();
    }

    public Optional<Notes> getNoteById(int noteId) {
        return noteRepository.findById(noteId);
    }

    public Notes saveNote(Notes note) {
        return noteRepository.save(note);
    }

    public void deleteNoteById(int noteId) {
        noteRepository.deleteById(noteId);
    }
}

