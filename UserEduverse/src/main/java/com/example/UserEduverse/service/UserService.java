package com.example.UserEduverse.service;

import com.example.UserEduverse.dto.UserDto;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.dao.UserDao;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

@Service
public class UserService  {

	private static final Logger logger = LoggerFactory.getLogger(UserService.class);

    @Autowired
    private UserDao userDao;

    //private final PasswordEncoder passwordEncoder;

//    @Autowired
//    public UserService(PasswordEncoder passwordEncoder) {
//        this.passwordEncoder = passwordEncoder;
//    }

    
//    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
//    	Optional<User> user = userDao.findByEmail(username);
//		if(user==null) {
//			throw new UsernameNotFoundException("User Not Found with email"+username);
//		}
//		//USER_ROLE role = user.getRole();
//		
//		List<GrantedAuthority> authorities = new ArrayList<>();
//		//authorities.add(new SimpleGrantedAuthority(role.toString()));
//		return new org.springframework.security.core.userdetails.User(user.get().getEmail(), user.get().getPassword(), authorities);
//    }

    public void addUser(UserDto userDto) {
        if (userDto.getEmail() == null || userDto.getEmail().isEmpty()) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Email is required");
        }
        
        User user = new User();
        user.setUserId(userDto.getUserId());
        user.setFirstName(userDto.getFirstName());
        user.setMiddleName(userDto.getMiddleName());
        user.setLastName(userDto.getLastName());
        user.setRole(userDto.getRole());
        user.setMobileNo(userDto.getMobileNo());
        user.setEmail(userDto.getEmail());
        user.setCourseId(userDto.getCourseId());
        user.setPassword(userDto.getPassword()); 
        user.setActive(true);

        try {
            userDao.save(user);
            logger.info("User saved successfully: {}", user.getEmail());
        } catch (Exception e) {
            logger.error("Error saving user: {}", e.getMessage());
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error saving user");
        }
    }

    public void deleteUser(int userId) {
        try {
            userDao.deleteById(userId);
            logger.info("User with ID {} deleted successfully", userId);
        } catch (Exception e) {
            logger.error("Error deleting user: {}", e.getMessage());
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error deleting user");
        }
    }

    public void updateUser(int userId, UserDto userDto) {
        User user = userDao.findById(userId).orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "User not found"));
        user.setFirstName(userDto.getFirstName());
        user.setMiddleName(userDto.getMiddleName());
        user.setLastName(userDto.getLastName());
        user.setRole(userDto.getRole());
        user.setMobileNo(userDto.getMobileNo());
        user.setEmail(userDto.getEmail());
        user.setCourseId(userDto.getCourseId());
        user.setPassword(userDto.getPassword());  
        user.setActive(userDto.isActive());

        try {
            userDao.save(user);
            logger.info("User with ID {} updated successfully", userId);
        } catch (Exception e) {
            logger.error("Error updating user: {}", e.getMessage());
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error updating user");
        }
    }

    public List<User> getAllUsers() {
        return userDao.findAll();
    }
    
    public Optional<User> getUserByIdd(Integer userId) {
        return userDao.findById(userId);
    }

    public User getUserById(Integer id) {
        return userDao.findById(id).orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "User not found"));
    }

//    public boolean checkPassword(String rawPassword, String encodedPassword) {
//        return passwordEncoder.matches(rawPassword, encodedPassword);  
//    }
    
    public User findByEmail(String email) {
        return userDao.findByEmail(email);
    }

    public boolean existsByEmail(String email) {
        return userDao.existsByEmail(email);
    }
}
