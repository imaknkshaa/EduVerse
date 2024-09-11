package com.example.UserEduverse.config;
//
//import java.util.Arrays;
//import java.util.Collections;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.context.annotation.Bean;
//import org.springframework.context.annotation.Configuration;
//import org.springframework.security.authentication.AuthenticationProvider;
//import org.springframework.security.authentication.dao.DaoAuthenticationProvider;
//import org.springframework.security.config.annotation.authentication.configuration.EnableGlobalAuthentication;
//import org.springframework.security.config.annotation.web.builders.HttpSecurity;
//import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
//import org.springframework.security.config.http.SessionCreationPolicy;
//import org.springframework.security.core.userdetails.UserDetailsService;
//import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
//import org.springframework.security.crypto.password.PasswordEncoder;
//import org.springframework.security.web.SecurityFilterChain;
//import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
//import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;
//import org.springframework.web.cors.CorsConfiguration;
//import org.springframework.web.cors.CorsConfigurationSource;
//
//import com.zaika.service.CustomerUserDetailsService;
//
//import jakarta.servlet.http.HttpServletRequest;
//@Configuration
//@EnableWebSecurity
//public class AppConfig {
//	
//	
////	@Bean
////	SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
////		// TODO Auto-generated method stub
////		http.sessionManagement(management -> management.sessionCreationPolicy(SessionCreationPolicy.STATELESS))
////		.authorizeHttpRequests(Authorize -> Authorize.requestMatchers("/api/admin/**").hasAnyRole("RESTAURANT_OWNER","ADMIN")
////		.requestMatchers("/api/**").authenticated()
////		.anyRequest().permitAll()
////		).addFilterBefore(new JwtTokenValidator(), BasicAuthenticationFilter.class)
////		.csrf(csrf -> csrf.disable())
////		.cors(cors-> cors.configurationSource(corsConfigurationSource()));
////		
////		return http.build();
////
////	} 
////	
//	
//	@Bean
//	public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception
//	{
//	         return http    
//	             .cors().and()
//	         .csrf().disable()
//	         .authorizeHttpRequests()
//	         .requestMatchers("/api/admin/**").hasRole("RESTAURANT_OWNER")
//             .requestMatchers("/api/admin/**").hasRole("ADMIN")
//	         .requestMatchers("/api/**").authenticated()
//	               .requestMatchers("/**").permitAll()
//	         .anyRequest().authenticated()
//	         .and().sessionManagement()
//	         .sessionCreationPolicy(SessionCreationPolicy.STATELESS)
//	         .and()
//	         .authenticationProvider(authenticationProvider())
//	         .addFilterBefore(new JwtTokenValidator(), UsernamePasswordAuthenticationFilter.class).build();
//	        
//	}
////	private CorsConfigurationSource corsConfigurationSource() {
////		return new CorsConfigurationSource() {
////			
////			@Override
////			public CorsConfiguration getCorsConfiguration(HttpServletRequest request) {
////				// TODO Auto-generated method stub
////				CorsConfiguration cfg = new CorsConfiguration();
////				
////				cfg.setAllowedOrigins(Arrays.asList("http://localhost:3000"));
////				
////				cfg.setAllowedMethods(Collections.singletonList("*"));
////				cfg.setAllowCredentials(true);
////				cfg.setAllowedHeaders(Collections.singletonList("*"));
////				cfg.setExposedHeaders(Arrays.asList("Authorization"));
////				cfg.setMaxAge(3600L);
////				return cfg;
////			}
////		};
////	} 
//	
//	@Bean
//	public AuthenticationProvider authenticationProvider() {
//	   DaoAuthenticationProvider authenticationProvider = new DaoAuthenticationProvider();
//	   authenticationProvider.setUserDetailsService(userDetailsService());
//	   authenticationProvider.setPasswordEncoder(passwordEncoder());
//	   return authenticationProvider;
//	}
//	
//	@Bean
//	public UserDetailsService userDetailsService() {
//	   return new CustomerUserDetailsService();
//	}
//	
//	@Bean
//	PasswordEncoder passwordEncoder() {
//		return new BCryptPasswordEncoder();
//	}
//}
//

import java.util.Arrays;
import java.util.Collections;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.CorsConfigurationSource;

import jakarta.servlet.http.HttpServletRequest;

@Configuration
@EnableWebSecurity
public class AppConfig {

    @Bean
    SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {

        http.sessionManagement(management -> management.sessionCreationPolicy(SessionCreationPolicy.STATELESS))
                .authorizeHttpRequests(Authorize -> Authorize
                		.requestMatchers("/api/admin/**").hasAnyRole("HOD","ADMIN")
                                .requestMatchers("/api/**").authenticated()
                                
                                .anyRequest().permitAll()
                )
                .addFilterBefore(new JwtTokenValidator(), BasicAuthenticationFilter.class)
                .csrf(csrf -> csrf.disable())
                .cors(cors -> cors.configurationSource(corsConfigurationSource()));
               
		
		return http.build();
		
	}
	
    // CORS Configuration
    private CorsConfigurationSource corsConfigurationSource() {
        return new CorsConfigurationSource() {
            @Override
            public CorsConfiguration getCorsConfiguration(HttpServletRequest request) {
                CorsConfiguration cfg = new CorsConfiguration();
                cfg.setAllowedOrigins(Arrays.asList(
                    "http://localhost:3000",
                    "http://localhost:4200"
                ));
                cfg.setAllowedMethods(Collections.singletonList("*"));
                cfg.setAllowCredentials(true);
                cfg.setAllowedHeaders(Collections.singletonList("*"));
                cfg.setExposedHeaders(Arrays.asList("Authorization"));
                cfg.setMaxAge(3600L);
                return cfg;
            }
        };
    }

    @Bean
    PasswordEncoder passwordEncoder() {
		return new BCryptPasswordEncoder();
	}

}
