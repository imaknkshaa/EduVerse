package com.example.UserEduverse.model;

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
import lombok.Data;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;  

@Getter
@Setter
@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
public class Quiz {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int quizId;

    
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "userId")
    private User user;

    
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "course_Id")
    private Course course;

    @Column(nullable = false)
    private String title;

	public int getQuizId() {
		return quizId;
	}

	public void setQuizId(int quizId) {
		this.quizId = quizId;
	}
      
}