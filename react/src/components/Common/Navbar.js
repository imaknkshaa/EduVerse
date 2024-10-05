import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { logout } from "../../store/actions/authActions";
import {
  BASE_ROUTE,
  ABOUT_US,
  CONTACT_US,
  STUDENT_DASHBOARD,
  TEACHER_DASHBOARD,
  ADMIN_DASHBOARD,
  STUDENT_NOTES,
  STUDENT_ASSIGNMENTS,
  STUDENT_QUIZZES,
  STUDENT_PROFILE,
  TEACHER_NOTES,
  TEACHER_ASSIGNMENTS,
  TEACHER_QUIZZES,
  TEACHER_PROFILE,
  ADD_USER,
  MANAGE_USER,
} from "../../constants/appConstants";

const Navbar = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { token, role } = useSelector((state) => state.auth);

  // let token =sessionStorage.getItem('token')
  // let role = sessionStorage.getItem('role')

  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);

  const handleLogout = () => {
    dispatch(logout());
    navigate(BASE_ROUTE);
    sessionStorage.clear()
  };

  const getDashboardRoute = () => {
    if (role === "Student") return STUDENT_DASHBOARD;
    if (role === "Teacher") return TEACHER_DASHBOARD;
    if (role === "Admin") return ADMIN_DASHBOARD;
    return BASE_ROUTE;
  };

  const handleLogoClick = () => {
    if (token) {
      navigate(getDashboardRoute());
    } else {
      navigate(BASE_ROUTE);
    }
  };

  const toggleMobileMenu = () => {
    setIsMobileMenuOpen(!isMobileMenuOpen);
  };

  const renderNavLinks = () => {
    if (token) {
      if (role === "Student") {
        return (
          <>
            <Link to={STUDENT_NOTES} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Notes
            </Link>
            <Link to={STUDENT_ASSIGNMENTS} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Assignments
            </Link>
            <Link to={STUDENT_QUIZZES} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Quizzes
            </Link>
            <Link to={STUDENT_PROFILE} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Profile
            </Link>
          </>
        );
      }

      if (role === "Teacher") {
        return (
          <>
            <Link to={TEACHER_NOTES} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Manage Notes
            </Link>
            <Link to={TEACHER_ASSIGNMENTS} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Manage Assignments
            </Link>
            <Link to={TEACHER_QUIZZES} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Manage Quizzes
            </Link>
            <Link to={TEACHER_PROFILE} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Profile
            </Link>
          </>
        );
      }

      if (role === "Admin") {
        return (
          <>
            <Link to={ADD_USER} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Add User
            </Link>
            <Link to={MANAGE_USER} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Manage Users
            </Link>
          </>
        );
      }

      return null;
    } else {
      return (
        <>
          <Link to={ABOUT_US} className="block px-4 py-2 text-white hover:bg-[#9CBAC0] hover:rounded-lg">
            About
          </Link>
          <Link to={CONTACT_US} className="block px-4 py-2 text-white hover:bg-[#9CBAC0] hover:rounded-lg">
            Contact
          </Link>
        </>
      );
    }
  };

  return (
    <nav className="bg-[#28425A] text-white p-4 flex items-center justify-between">
      <div className="flex items-center">
        <button onClick={handleLogoClick} className="text-lg font-bold text-white hover:text-[#9DF6EE]">
          EduVerse
        </button>
        <button
          onClick={toggleMobileMenu}
          className="ml-4 inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-white hover:bg-[#24394D] focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white sm:hidden"
        >
          <svg
            className={`h-6 w-6 ${isMobileMenuOpen ? 'hidden' : 'block'}`}
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            aria-hidden="true"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth="2"
              d="M4 6h16M4 12h16m-7 6h7"
            />
          </svg>
          <svg
            className={`h-6 w-6 ${isMobileMenuOpen ? 'block' : 'hidden'}`}
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            aria-hidden="true"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth="2"
              d="M6 18L18 6M6 6l12 12"
            />
          </svg>
        </button>
      </div>
      <ul className={`flex space-x-4 sm:flex ${isMobileMenuOpen ? 'block' : 'hidden'} sm:block`}>
        {/* {renderNavLinks()} */}
        {token && (
          <li>
            <button onClick={handleLogout} className="block px-4 py-2 text-white hover:bg-[#9CBAC0]">
              Logout
            </button>
          </li>
        )}
      </ul>
    </nav>
  );
};

export default Navbar;
