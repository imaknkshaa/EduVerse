package com.example.UserEduverse.dao;

import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;

import com.example.UserEduverse.model.User;


public interface UserDao extends JpaRepository<User, Integer>{
	
	 User  findByEmail(String email);
	
	public boolean existsByEmail(String email);
}
