package com.example.UserEduverse.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.UserEduverse.model.User;



@Repository
public interface UserRepository extends JpaRepository<User, Integer> {
}
