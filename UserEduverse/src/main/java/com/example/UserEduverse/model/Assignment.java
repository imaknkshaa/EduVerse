package com.example.UserEduverse.model;


import java.util.Date;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor

@Entity
public class Assignment {

	    @Id
	    @GeneratedValue(strategy = GenerationType.IDENTITY)
	    private Integer assignmentId;

	    
	    @ManyToOne(cascade = CascadeType.ALL)
	    @JoinColumn(name = "course_Id")
	    private Course course;

	    @Column(nullable = false)
	    private int teacherId;

	    @Column(nullable = false)
	    private String title;

	    @Column(nullable = false)
	    private Date dueDate;

	    private String filePath;
	    
	    
	    
	    
		public String getFilePath() {
			return filePath;
		}

		public void setFilePath(String filePath) {
			this.filePath = filePath;
		}

		public int getAssignmentId() {
			return assignmentId;
		}

		public void setAssignmentId(int assignmentId) {
			this.assignmentId = assignmentId;
		}

		public Course getCourse() {
			return course;
		}

		public void setCourse(Course course) {
			this.course = course;
		}

		public int getTeacherId() {
			return teacherId;
		}

		public void setTeacherId(int teacherId) {
			this.teacherId = teacherId;
		}

		public String getTitle() {
			return title;
		}

		public void setTitle(String title) {
			this.title = title;
		}

		public Date getDueDate() {
			return dueDate;
		}

		public void setDueDate(Date dueDate) {
			this.dueDate = dueDate;
		}

		@Override
		public String toString() {
			return "Assignment [assignmentId=" + assignmentId + ", course=" + course + ", teacherId=" + teacherId
					+ ", title=" + title + ", dueDate=" + dueDate + ", filePath=" + filePath + "]";
		}

		
		
}