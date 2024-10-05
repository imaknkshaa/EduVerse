package com.example.UserEduverse.service;

import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.config.JwtProvider;
import com.example.UserEduverse.dao.UserDao;
import com.example.UserEduverse.model.User;

@Service
public class JUserServiceImpl implements JUserService {

    @Autowired
    private UserDao userRepository;
    
    @Autowired
    private JwtProvider jwtProvider;

    @Override
    public User findUserProfileByJwt(String jwt) throws Exception {
        String email = jwtProvider.getEmailFromJwtToken(jwt);
        User user = userRepository.findByEmail(email);
        
        if (user == null) {
            throw new Exception("User not found with email " + email);
        }
        return user;
    }
}
