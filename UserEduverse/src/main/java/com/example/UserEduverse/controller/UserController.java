package com.example.UserEduverse.controller;

import com.example.UserEduverse.config.JwtProvider;
import com.example.UserEduverse.dto.LoginDto;
import com.example.UserEduverse.dto.UserDto;
import com.example.UserEduverse.model.User;
import com.example.UserEduverse.service.CustomUserDetails;
import com.example.UserEduverse.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/user")
public class UserController {

    @Autowired
    private UserService userService;
    
    @Autowired
    private CustomUserDetails customUserDetails;

    @Autowired
    private JwtProvider jwtProvider;
    
//    @Autowired
//    private JwtService jwtService;

    @Autowired
    private PasswordEncoder passwordEncoder;
    
    
    @GetMapping("/hello")
	public String print() {
		return "HEllo";
	}
    
    @PostMapping("/register")
    public ResponseEntity<String> addUser( @RequestBody UserDto userDto) {
    	userDto.setPassword(passwordEncoder.encode(userDto.getPassword()));
        userService.addUser(userDto);
        return ResponseEntity.status(HttpStatus.CREATED).body("User created successfully");
    }

    @DeleteMapping("/users/{userId}")
    public ResponseEntity<String> deleteUser(@PathVariable int userId) {
        userService.deleteUser(userId);
        return ResponseEntity.status(HttpStatus.OK).body("User deleted successfully");
    }

    @PutMapping("/users/{userId}")
    public ResponseEntity<String> updateUser(@PathVariable("userId") int userId, @RequestBody UserDto userDto) {
        userDto.setUserId(userId);
        userDto.setPassword(passwordEncoder.encode(userDto.getPassword()));
        userService.updateUser(userId, userDto);
        return ResponseEntity.status(HttpStatus.OK).body("User updated successfully");
    }


    @GetMapping
    public ResponseEntity<List<User>> getAllUsers() {
        List<User> users = userService.getAllUsers();
        return ResponseEntity.status(HttpStatus.OK).body(users);
    }

    @GetMapping("/users/{userId}")
    public ResponseEntity<User> getUserById(@PathVariable int userId) {
        User user = userService.getUserById(userId);
        return ResponseEntity.status(HttpStatus.OK).body(user);
    }
    
    @PostMapping("/login")
  public ResponseEntity<Map<String, Object>> loginUser(@RequestBody LoginDto userDto) {
      try {
          UserDetails userDetails = customUserDetails.loadUserByUsername(userDto.getEmail());

          Authentication authentication = authenticate(userDto.getEmail(), userDto.getPassword());

          String jwt = jwtProvider.generateToken(authentication);

          String role = authentication.getAuthorities().stream()
                                      .map(GrantedAuthority::getAuthority)
                                      .findFirst()
                                      .orElse("");

          User user = userService.findByEmail(userDto.getEmail());
          if (user.isActive()) {
        	  Map<String, Object> response = new HashMap<>();
              response.put("token", jwt);
              response.put("role", role);

              return ResponseEntity.ok(response); 
          }
          throw new Exception("User is not activated");
         
      } catch (UsernameNotFoundException e) {
          return ResponseEntity.status(HttpStatus.UNAUTHORIZED).body(Map.of("error", "Invalid credentials"));
      } catch (Exception e) {
          return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(Map.of("error", "An error occurred during login"));
      }
  }
    
    private Authentication authenticate(String mail, String password) {
		UserDetails userDetails = customUserDetails.loadUserByUsername(mail);
		if(userDetails==null) {
			throw new BadCredentialsException("invalid username");
		}
		
		if(!passwordEncoder.matches(password, userDetails.getPassword())) {
			throw new BadCredentialsException("Invalid Password");
		}
		return new UsernamePasswordAuthenticationToken(userDetails,null, userDetails.getAuthorities());
	}
}
