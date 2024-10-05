import React from "react";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import Login from "./components/auth/Login"
import StudentDashboard from "./components/students/StudentDashboard";
// import TeacherDashboard from "./components/pages/TeacherDashboard";
// import AdminDashboard from "./components/pages/AdminDashboard";
import { useSelector } from "react-redux";
import Navbar from "./components/common/Navbar";
import Footer from "./components/common/Footer";
import About from './components/pages/About'
import Contact from './components/pages/Contact'
import { ABOUT_US, CONTACT_US, REGISTER_STUDENT } from "./constants/appConstants";
import RegisterUser from "./components/auth/RegisterUser";

const App = () => {
  const { token, role } = useSelector((state) => state.auth);

  return (
    <Router>

      <Navbar />

      <Routes>
        <Route path="/login" element={token ? <Navigate to={`/${role.toLowerCase()}/dashboard`} /> : <Login />} />
        <Route path="/login" element={<Login />} />
        <Route path={ABOUT_US} element={<About />} />
        <Route path={CONTACT_US} element={<Contact />} />
        <Route path={REGISTER_STUDENT} element={<RegisterUser />} />

        <Route
          path="/student/dashboard"
          element={
            token && role === "Student" ? (
              <StudentDashboard />
            ) : (
              <Navigate to="/login" />
            )
          }
        />

        {/* <Route
            path="/teacher/dashboard"
            element={
              token && role === "Teacher" ? (
                <TeacherDashboard />
              ) : (
                <Navigate to="/login" />
              )
            }
          /> */}

        {/* <Route
            path="/admin/dashboard"
            element={
              token && role === "Admin" ? (
                <AdminDashboard />
              ) : (
                <Navigate to="/login" />
              )
            }
          /> */}

        {/* Catch-all route to redirect to login */}
        <Route path="*" element={<Navigate to="/login" />} />
      </Routes>
      <Footer />
    </Router>
  );
};

export default App;