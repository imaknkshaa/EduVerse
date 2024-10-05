using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    role = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    mobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    courseId = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    password = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    assignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.assignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    noteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.noteId);
                    table.ForeignKey(
                        name: "FK_Notes_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    quizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.quizId);
                    table.ForeignKey(
                        name: "FK_Quizzes_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    submissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    grades = table.Column<int>(type: "int", nullable: false),
                    isSubmitted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.submissionId);
                    table.ForeignKey(
                        name: "FK_Submissions_Assignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "Assignments",
                        principalColumn: "assignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    questionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quizId = table.Column<int>(type: "int", nullable: false),
                    questionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    option1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    option2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    option3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    option4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    answer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.questionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_quizId",
                        column: x => x.quizId,
                        principalTable: "Quizzes",
                        principalColumn: "quizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    StudentAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    questionId = table.Column<int>(type: "int", nullable: false),
                    quizId = table.Column<int>(type: "int", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    isCorrected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.StudentAnswerId);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Questions_questionId",
                        column: x => x.questionId,
                        principalTable: "Questions",
                        principalColumn: "questionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Quizzes_quizId",
                        column: x => x.quizId,
                        principalTable: "Quizzes",
                        principalColumn: "quizId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_courseId",
                table: "Assignments",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_userId",
                table: "Assignments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_courseId",
                table: "Notes",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_userId",
                table: "Notes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_quizId",
                table: "Questions",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_courseId",
                table: "Quizzes",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_userId",
                table: "Quizzes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_questionId",
                table: "StudentAnswers",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_quizId",
                table: "StudentAnswers",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_userId",
                table: "StudentAnswers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_assignmentId",
                table: "Submissions",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_userId",
                table: "Submissions",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_courseId",
                table: "Users",
                column: "courseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
