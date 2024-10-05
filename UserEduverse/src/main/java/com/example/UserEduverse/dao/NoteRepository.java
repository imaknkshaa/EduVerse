package com.example.UserEduverse.dao;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.UserEduverse.model.Notes;



@Repository
public interface NoteRepository extends JpaRepository<Notes, Integer> {
}
