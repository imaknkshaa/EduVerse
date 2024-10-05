package com.example.UserEduverse.service;

import java.util.Optional;

import com.example.UserEduverse.model.User;

public interface JUserService {

	public User findUserProfileByJwt(String jwt) throws Exception;
}
