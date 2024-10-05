//package com.example.UserEduverse.config;
//
//import com.example.UserEduverse.service.JwtService;
//import com.example.UserEduverse.service.UserService;
//
//import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
//import org.springframework.security.core.context.SecurityContextHolder;
//import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
//
//import jakarta.servlet.FilterChain;
//import jakarta.servlet.ServletException;
//import jakarta.servlet.http.HttpServletRequest;
//import jakarta.servlet.http.HttpServletResponse;
//
//import java.io.IOException;
//
//public class JwtAuthenticationFilter extends UsernamePasswordAuthenticationFilter {
//
//    private final JwtService jwtService;
//    private final UserService userService;
//
//    public JwtAuthenticationFilter(JwtService jwtService, UserService userService) {
//        this.jwtService = jwtService;
//        this.userService = userService;
//    }
//
//    
//    protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, FilterChain chain)
//            throws IOException, ServletException {
//        final String authorizationHeader = request.getHeader("Authorization");
//
//        if (authorizationHeader != null && authorizationHeader.startsWith("Bearer ")) {
//            final String token = authorizationHeader.substring(7);
//            final String username = jwtService.extractUsername(token);
//
//            if (username != null && SecurityContextHolder.getContext().getAuthentication() == null) {
//                var userDetails = userService.loadUserByUsername(username);
//
//                if (jwtService.validateToken(token, userDetails)) {
//                    var auth = new UsernamePasswordAuthenticationToken(userDetails, null, userDetails.getAuthorities());
//                    SecurityContextHolder.getContext().setAuthentication(auth);
//                }
//            }
//        }
//
//        chain.doFilter(request, response);
//    }
//}
