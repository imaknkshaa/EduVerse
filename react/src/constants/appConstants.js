// Base and Common Routes
export const BASE_ROUTE = "/";
export const ABOUT_US = "/about";
export const CONTACT_US = "/contact";

// Student Routes
export const STUDENT = '/student';
export const REGISTER_STUDENT = `${STUDENT}/register`;
export const STUDENT_DASHBOARD = `${STUDENT}/dashboard`;
export const STUDENT_NOTES = `${STUDENT_DASHBOARD}/notes`;
export const STUDENT_ASSIGNMENTS = `${STUDENT_DASHBOARD}/assignments`;
export const STUDENT_SUBMISSIONS = `${STUDENT_DASHBOARD}/submissions`;
export const STUDENT_QUIZZES = `${STUDENT_DASHBOARD}/quizzes`;
export const STUDENT_PROFILE = `${STUDENT_DASHBOARD}/profile`;

// Teacher Routes
export const TEACHER = '/teacher';
export const TEACHER_DASHBOARD = `${TEACHER}/dashboard`;
export const TEACHER_NOTES = `${TEACHER_DASHBOARD}/notes`;
export const TEACHER_ASSIGNMENTS = `${TEACHER_DASHBOARD}/assignments`;
export const TEACHER_SUBMISSIONS = `${TEACHER_DASHBOARD}/submissions`;
export const TEACHER_QUIZZES = `${TEACHER_DASHBOARD}/quizzes`;
export const TEACHER_PROFILE = `${TEACHER_DASHBOARD}/profile`;

// Admin Routes
export const ADMIN = '/admin';
export const ADMIN_DASHBOARD = `${ADMIN}/dashboard`;
export const ADD_USER = `${ADMIN_DASHBOARD}/addUser`;
export const MANAGE_USER = `${ADMIN_DASHBOARD}/manageUser`;
