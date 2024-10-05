//package com.example.UserEduverse.service;
//
//import java.security.Key;
//import java.util.Date;
//import java.util.HashMap;
//import java.util.Map;
//import java.util.function.Function;
//
//import org.springframework.security.core.userdetails.UserDetails;
//import org.springframework.stereotype.Component;
//
//import io.jsonwebtoken.Claims;
//import io.jsonwebtoken.Jwts;
//import io.jsonwebtoken.SignatureAlgorithm;
//import io.jsonwebtoken.io.Decoders;
//import io.jsonwebtoken.security.Keys;
//
//@Component
//public class JwtService {
//
//    private static final String SECRET_KEY = "743677397A24432646294A404E635266556A586E5A7234753778214125442A47"; // Use a secure key in production
//
//    // Generates a JWT token with username and role
//    public String generateToken(String username, String role) {
//        Map<String, Object> claims = new HashMap<>();
//        claims.put("role", role); // Add role to claims
//        return createToken(claims, username);
//    }
//
//    // Creates a JWT token with the specified claims and username
//    public String createToken(Map<String, Object> claims, String username) {
//        return Jwts.builder()
//                .setClaims(claims)
//                .setSubject(username)
//                .setIssuedAt(new Date(System.currentTimeMillis()))
//                .setExpiration(new Date(System.currentTimeMillis() + 1000 * 60 * 30)) // 30 minutes expiration
//                .signWith(getSignKey(), SignatureAlgorithm.HS256)
//                .compact();
//    }
//
//    // Retrieves the signing key for JWT
//    private Key getSignKey() {
//        byte[] keyBytes = Decoders.BASE64.decode(SECRET_KEY);
//        return Keys.hmacShaKeyFor(keyBytes);
//    }
//
//    // Extracts the username from the JWT token
//    public String extractUsername(String token) {
//        return extractClaim(token, Claims::getSubject);
//    }
//
//    // Extracts the expiration date from the JWT token
//    public Date extractExpiration(String token) {
//        return extractClaim(token, Claims::getExpiration);
//    }
//
//    // Extracts a specific claim from the JWT token
//    public <T> T extractClaim(String token, Function<Claims, T> claimsResolver) {
//        final Claims claims = extractAllClaims(token);
//        return claimsResolver.apply(claims);
//    }
//
//    // Extracts all claims from the JWT token
//    private Claims extractAllClaims(String token) {
//        return Jwts.parserBuilder()
//                .setSigningKey(getSignKey())
//                .build()
//                .parseClaimsJws(token)
//                .getBody();
//    }
//
//    // Checks if the JWT token is expired
//    public Boolean isTokenExpired(String token) {
//        return extractExpiration(token).before(new Date());
//    }
//
//    // Validates the JWT token against the user details
//    public Boolean validateToken(String token, UserDetails userDetails) {
//        final String username = extractUsername(token);
//        return (username.equals(userDetails.getUsername()) && !isTokenExpired(token));
//    }
//}
