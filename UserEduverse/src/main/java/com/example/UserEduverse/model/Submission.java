package com.example.UserEduverse.model;


import javax.validation.constraints.Pattern;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
public class Submission {

	 @Id
	 @GeneratedValue(strategy = GenerationType.AUTO)
	private Integer submissionId;
	 
	 
	 @ManyToOne
	 @JoinColumn(name = "assignment_id")
    private Assignment assignment;
    private int studentId;
    private String file;
    private String remark;
    private String grades;
    
    @Pattern(regexp = "Submitted|Not Submitted")
    private String status;

	public Integer getSubmissionId() {
		return submissionId;
	}

	public void setSubmissionId(Integer submissionId) {
		this.submissionId = submissionId;
	}

	public Assignment getAssignment() {
		return assignment;
	}

	public void setAssignment(Assignment assignment) {
		this.assignment = assignment;
	}

	public int getStudentId() {
		return studentId;
	}

	public void setStudentId(int studentId) {
		this.studentId = studentId;
	}

	public String getFile() {
		return file;
	}

	public void setFile(String file) {
		this.file = file;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	public String getGrades() {
		return grades;
	}

	public void setGrades(String grades) {
		this.grades = grades;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}
	
    
}


