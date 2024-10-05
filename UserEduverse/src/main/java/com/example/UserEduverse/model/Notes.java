package com.example.UserEduverse.model;


import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.Lob;
import jakarta.persistence.ManyToOne;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
public class Notes {
	
	
	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	private Integer noteId;
	@ManyToOne
	@JoinColumn(name = "userId")
    private User user;
	
	@ManyToOne(cascade = CascadeType.ALL)
	@JoinColumn(name = "course_id")
    private Course course;
    private String title;
    
    private String file;

    
    
	public Integer getNoteId() {
		return noteId;
	}

	public void setNoteId(Integer noteId) {
		this.noteId = noteId;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public Course getCourse() {
		return course;
	}

	public void setCourse(Course course) {
		this.course = course;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getFile() {
		return file;
	}

	public void setFile(String file) {
		this.file = file;
	}

	@Override
	public String toString() {
		return "Notes [noteId=" + noteId + ", user=" + user + ", course=" + course + ", title=" + title + ", file="
				+ file + "]";
	}
    
    
	}