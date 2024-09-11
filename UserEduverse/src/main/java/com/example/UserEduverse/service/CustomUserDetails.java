package com.example.UserEduverse.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import com.example.UserEduverse.dao.UserDao;
import com.example.UserEduverse.model.USER_ROLE;
import com.example.UserEduverse.model.User;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Optional;
@Service
public class CustomUserDetails implements UserDetailsService {

	
	
		@Autowired
		private UserDao userRepository;
		
		@Autowired
		private UserService userService;

		@Override
		public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {

		    User user = userService.findByEmail(username);
		    if (user == null) {
		        throw new UsernameNotFoundException("User Not Found with email: " + username);
		    }

		    USER_ROLE role = user.getRole();
		    System.out.println(role.name());

		    List<GrantedAuthority> authorities = new ArrayList<>();
		    authorities.add(new SimpleGrantedAuthority(role.name())); // Use role.name() to get the string representation

		    return new org.springframework.security.core.userdetails.User(user.getEmail(), user.getPassword(), authorities);
		}




		
//    private final String username;
//    private final String password;
//    private final Collection<? extends GrantedAuthority> authorities;
//    private final String role; // Add role field
//
//    // Update constructor to include role
//    public CustomUserDetails(String username, String password, Collection<? extends GrantedAuthority> authorities, String role) {
//        this.username = username;
//        this.password = password;
//        this.authorities = authorities;
//        this.role = role;
//    }
//
//    @Override
//    public Collection<? extends GrantedAuthority> getAuthorities() {
//        return authorities;
//    }
//
//    @Override
//    public String getPassword() {
//        return password;
//    }
//
//    @Override
//    public String getUsername() {
//        return username;
//    }
//
//    @Override
//    public boolean isAccountNonExpired() {
//        return true;
//    }
//
//    @Override
//    public boolean isAccountNonLocked() {
//        return true;
//    }
//
//    @Override
//    public boolean isCredentialsNonExpired() {
//        return true;
//    }
//
//    @Override
//    public boolean isEnabled() {
//        return true;
//    }
//
//    // Getter for role
//    public String getRole() {
//        return role;
//    }
}
