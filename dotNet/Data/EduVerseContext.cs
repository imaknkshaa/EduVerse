using EduVerseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduVerseApi.Data
{
    public class EduVerseContext : DbContext
    {
        public EduVerseContext(DbContextOptions<EduVerseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.user)
                .WithMany(u=> u.assignments)
                .HasForeignKey(a => a.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assignment>()
                .HasOne(a=>a.course)
                .WithMany(c=>c.assignments)
                .HasForeignKey(a=>a.courseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Note>()
                .HasOne(n=>n.user)
                .WithMany(u=>u.notes)
                .HasForeignKey(n=> n.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Note>()
                .HasOne(n=>n.course)
                .WithMany(c=>c.notes)
                .HasForeignKey(n=> n.courseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quiz>()
                .HasOne(q=>q.user)
                .WithMany(u=>u.quizzes)
                .HasForeignKey(q=>q.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentAnswer>()
                .HasOne(sa=>sa.quiz)
                .WithMany(q=>q.studentAnswers)
                .HasForeignKey(sa=>sa.quizId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentAnswer>()
                .HasOne(sa => sa.user)
                .WithMany(u => u.studentAnswers)
                .HasForeignKey(sa => sa.userId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.emailId)
            .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.mobileNumber)
                .IsUnique();
        }
    }
}
