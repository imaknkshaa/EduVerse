package com.example.UserEduverse.model;


import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.ManyToOne;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class StudentAnswer {
    
    @Id
    private int studentId;

	@Column(nullable = false)
    private int questionId;

	@Column(nullable = false)
    private int quizId;

	@Column(nullable = false)
    private String answer;

	@Column(nullable = false)
    private boolean isCorrected;
	
	@JsonIgnore
	@ManyToOne
	private User user;

	public int getStudentId() {
		return studentId;
	}

	public void setStudentId(int studentId) {
		this.studentId = studentId;
	}

	public int getQuestionId() {
		return questionId;
	}

	public void setQuestionId(int questionId) {
		this.questionId = questionId;
	}

	public int getQuizId() {
		return quizId;
	}

	public void setQuizId(int quizId) {
		this.quizId = quizId;
	}

	public String getAnswer() {
		return answer;
	}

	public void setAnswer(String answer) {
		this.answer = answer;
	}

	public boolean isCorrected() {
		return isCorrected;
	}

	public void setCorrected(boolean isCorrected) {
		this.isCorrected = isCorrected;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	
}
