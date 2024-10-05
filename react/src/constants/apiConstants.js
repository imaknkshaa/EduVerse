// Base URL
export const BASE_API_URL = "http://localhost:5183/api";

// Authentication
export const AUTH_LOGIN = `${BASE_API_URL}/Authentication/login`;

// Courses
export const GET_COURSES = `${BASE_API_URL}/Courses`;
export const POST_COURSES = `${BASE_API_URL}/Courses`;
export const GET_COURSE_BY_ID = `${BASE_API_URL}/Courses`;
export const PUT_COURSE_BY_ID = `${BASE_API_URL}/Courses`;
export const DELETE_COURSE_BY_ID = `${BASE_API_URL}/Courses`;

// Notes
export const GET_NOTES = `${BASE_API_URL}/Notes`;
export const POST_NOTES = `${BASE_API_URL}/Notes`;
export const GET_NOTE_BY_ID = `${BASE_API_URL}/Notes`;
export const GET_NOTE_BY_COURSE_ID = `${BASE_API_URL}/Notes/course`;
export const PUT_NOTE_BY_ID = `BASE_API_URL}/Notes`;
export const DELETE_NOTE_BY_ID = `${BASE_API_URL}/Notes`;
export const GET_NOTE_FILE_BY_ID = `${BASE_API_URL}/Notes/file`;

// Questions
export const GET_QUESTIONS_BY_QUIZ = `${BASE_API_URL}/Questions`;
export const GET_QUESTION_BY_ID = `${BASE_API_URL}/Questions`;
export const PUT_QUESTION_BY_ID = `${BASE_API_URL}/Questions`;
export const DELETE_QUESTION_BY_ID =  `${BASE_API_URL}/Questions`;
export const POST_QUESTIONS = `${BASE_API_URL}/Questions`;

// Quizs
export const GET_QUIZZES = `${BASE_API_URL}/Quizs`;
export const POST_QUIZZES = `${BASE_API_URL}/Quizs`;
export const GET_QUIZ_BY_ID = `${BASE_API_URL}/Quizs`;
export const PUT_QUIZ_BY_ID = `${BASE_API_URL}/Quizs/`;
export const DELETE_QUIZ_BY_ID = `${BASE_API_URL}/Quizs`;

// StudentAnswers
export const GET_STUDENT_ANSWERS = `${BASE_API_URL}/StudentAnswers`;
export const PUT_STUDENT_ANSWER_BY_ID = `${BASE_API_URL}/StudentAnswers`;
export const DELETE_STUDENT_ANSWER_BY_ID = `${BASE_API_URL}/StudentAnswers`;
export const POST_STUDENT_ANSWERS = `${BASE_API_URL}/StudentAnswers`;

// Submissions
export const GET_SUBMISSIONS = `${BASE_API_URL}/Submissions`;
export const POST_SUBMISSIONS = `${BASE_API_URL}/Submissions`;
export const GET_SUBMISSION_BY_ID = `${BASE_API_URL}/Submissions`;
export const PUT_SUBMISSION_BY_ID = `${BASE_API_URL}/Submissions`;
export const DELETE_SUBMISSION_BY_ID = `${BASE_API_URL}/Submissions`;
export const GET_SUBMISSION_FILE_BY_ID = `${BASE_API_URL}/Submissions/file`;

// User
export const GET_USERS = `${BASE_API_URL}/User`;
export const POST_USERS = `${BASE_API_URL}/User`;
export const GET_USER_BY_ID =`${BASE_API_URL}/User`;
export const PUT_USER_BY_ID =`${BASE_API_URL}/User`;
export const DELETE_USER_BY_ID =`${BASE_API_URL}/User`;
