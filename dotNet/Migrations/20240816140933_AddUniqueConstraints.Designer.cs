﻿// <auto-generated />
using System;
using EduVerseApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduVerseApi.Migrations
{
    [DbContext(typeof(EduVerseContext))]
    [Migration("20240816140933_AddUniqueConstraints")]
    partial class AddUniqueConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EduVerseApi.Models.Assignment", b =>
                {
                    b.Property<int>("assignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("assignmentId"));

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("assignmentId");

                    b.HasIndex("courseId");

                    b.HasIndex("userId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("EduVerseApi.Models.Course", b =>
                {
                    b.Property<int>("courseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseId"));

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("courseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EduVerseApi.Models.Note", b =>
                {
                    b.Property<int>("noteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("noteId"));

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("noteId");

                    b.HasIndex("courseId");

                    b.HasIndex("userId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("EduVerseApi.Models.Question", b =>
                {
                    b.Property<int>("questionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("questionId"));

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("option1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("option2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("option3")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("option4")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("questionText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("quizId")
                        .HasColumnType("int");

                    b.HasKey("questionId");

                    b.HasIndex("quizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EduVerseApi.Models.Quiz", b =>
                {
                    b.Property<int>("quizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("quizId"));

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("quizId");

                    b.HasIndex("courseId");

                    b.HasIndex("userId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("EduVerseApi.Models.StudentAnswer", b =>
                {
                    b.Property<int>("StudentAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentAnswerId"));

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("isCorrected")
                        .HasColumnType("bit");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.Property<int>("quizId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("StudentAnswerId");

                    b.HasIndex("questionId");

                    b.HasIndex("quizId");

                    b.HasIndex("userId");

                    b.ToTable("StudentAnswers");
                });

            modelBuilder.Entity("EduVerseApi.Models.Submission", b =>
                {
                    b.Property<int>("submissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("submissionId"));

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("grades")
                        .HasColumnType("int");

                    b.Property<bool>("isSubmitted")
                        .HasColumnType("bit");

                    b.Property<string>("remark")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("submissionId");

                    b.HasIndex("assignmentId");

                    b.HasIndex("userId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("EduVerseApi.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<int>("courseId")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("emailId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("mobileNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("userId");

                    b.HasIndex("courseId");

                    b.HasIndex("emailId")
                        .IsUnique();

                    b.HasIndex("mobileNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EduVerseApi.Models.Assignment", b =>
                {
                    b.HasOne("EduVerseApi.Models.Course", "course")
                        .WithMany("assignments")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EduVerseApi.Models.User", "user")
                        .WithMany("assignments")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EduVerseApi.Models.Note", b =>
                {
                    b.HasOne("EduVerseApi.Models.Course", "course")
                        .WithMany("notes")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EduVerseApi.Models.User", "user")
                        .WithMany("notes")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EduVerseApi.Models.Question", b =>
                {
                    b.HasOne("EduVerseApi.Models.Quiz", "quiz")
                        .WithMany()
                        .HasForeignKey("quizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quiz");
                });

            modelBuilder.Entity("EduVerseApi.Models.Quiz", b =>
                {
                    b.HasOne("EduVerseApi.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduVerseApi.Models.User", "user")
                        .WithMany("quizzes")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EduVerseApi.Models.StudentAnswer", b =>
                {
                    b.HasOne("EduVerseApi.Models.Question", "question")
                        .WithMany()
                        .HasForeignKey("questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduVerseApi.Models.Quiz", "quiz")
                        .WithMany("studentAnswers")
                        .HasForeignKey("quizId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EduVerseApi.Models.User", "user")
                        .WithMany("studentAnswers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("question");

                    b.Navigation("quiz");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EduVerseApi.Models.Submission", b =>
                {
                    b.HasOne("EduVerseApi.Models.Assignment", "assignment")
                        .WithMany()
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduVerseApi.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignment");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EduVerseApi.Models.User", b =>
                {
                    b.HasOne("EduVerseApi.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("EduVerseApi.Models.Course", b =>
                {
                    b.Navigation("assignments");

                    b.Navigation("notes");
                });

            modelBuilder.Entity("EduVerseApi.Models.Quiz", b =>
                {
                    b.Navigation("studentAnswers");
                });

            modelBuilder.Entity("EduVerseApi.Models.User", b =>
                {
                    b.Navigation("assignments");

                    b.Navigation("notes");

                    b.Navigation("quizzes");

                    b.Navigation("studentAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
