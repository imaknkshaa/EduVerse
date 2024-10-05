//package com.example.UserEduverse.config;
//
//import com.example.UserEduverse.service.JwtService;
//import com.example.UserEduverse.service.UserService;
//
//import jakarta.servlet.http.HttpServletResponse;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.context.annotation.Bean;
//import org.springframework.context.annotation.Configuration;
//import org.springframework.security.config.annotation.web.builders.HttpSecurity;
//import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
//import org.springframework.security.config.http.SessionCreationPolicy;
//import org.springframework.security.core.userdetails.UserDetailsService;
//import org.springframework.security.core.userdetails.UsernameNotFoundException;
//import org.springframework.security.web.SecurityFilterChain;
//import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
//
//@Configuration
//@EnableWebSecurity
//public class SecurityConfig {
//
//    private final UserService userService;
//    private final JwtService jwtService;
//
//    @Autowired
//    public SecurityConfig(UserService userService, JwtService jwtService) {
//        this.userService = userService;
//        this.jwtService = jwtService;
//    }
//
//    @Bean
//    SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
//
//        http.sessionManagement(management -> management.sessionCreationPolicy(SessionCreationPolicy.STATELESS))
//                .authorizeHttpRequests(Authorize -> Authorize
//                		.requestMatchers("/api/admin/**").hasAnyRole("RESTAURANT_OWNER","ADMIN")
//                                .requestMatchers("/api/**").authenticated()
//                                
//                                .anyRequest().permitAll()
//                )
//                .addFilterBefore(new JwtAuthenticationFilter(jwtService, userService), UsernamePasswordAuthenticationFilter.class);
//                
//		
//		return http.build();
//    }
////    @Bean
////    public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
////        http.csrf().disable()
////            .authorizeRequests()
////            //.requestMatchers("/api/register", "/api/login","/api").permitAll()
////            .requestMatchers("/admin/**").hasRole("ADMIN")
////            .requestMatchers("/users/**").hasRole("USER")
////            .anyRequest().authenticated()
////            .anyRequest().permitAll()
////            .and()
////            .exceptionHandling()
////            .authenticationEntryPoint((request, response, authException) -> {
////                response.sendError(HttpServletResponse.SC_UNAUTHORIZED, "Authentication is required.");
////            })
////            .and()
////            .addFilterBefore(new JwtAuthenticationFilter(jwtService, userService), UsernamePasswordAuthenticationFilter.class);
////
////        return http.build();
////    }
//
//    @Bean
//    public UserDetailsService userDetailsService() {
//        return username -> userService.loadUserByUsername(username);
//    }
//}
