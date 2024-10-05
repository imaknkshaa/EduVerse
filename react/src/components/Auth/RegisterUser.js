import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { registerStudent } from "../../services/authServices";
import { BASE_ROUTE } from "../../constants/appConstants";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';

const RegisterUser = () => {
  const [userData, setUserData] = useState({
    firstName: "",
    middleName: "",
    lastName: "",
    emailId: "",
    mobileNumber: "",
    password: "",
    courseId: "",
  });

  const [confirmPassword, setConfirmPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);
  const [error, setError] = useState({});
  const navigate = useNavigate();

  const togglePasswordVisibility = () => setShowPassword(!showPassword);
  const toggleConfirmPasswordVisibility = () => setShowConfirmPassword(!showConfirmPassword);

  const handleChange = (e) => {
    setUserData((prevData) => ({
      ...prevData,
      [e.target.name]: e.target.value,
    }));
  };

  // Validation Functions
  const handleFirstName = () => {
    if (userData.firstName.trim() === "") {
      setError((prevError) => ({
        ...prevError,
        firstNameErr: "First Name is required",
      }));
    } else {
      setError((prevError) => ({
        ...prevError,
        firstNameErr: "",
      }));
    }
  };

  const handleLastName = () => {
    if (userData.lastName.trim() === "") {
      setError((prevError) => ({
        ...prevError,
        lastNameErr: "Last Name is required",
      }));
    } else {
      setError((prevError) => ({
        ...prevError,
        lastNameErr: "",
      }));
    }
  };

  const handleEmail = () => {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if (!emailPattern.test(userData.emailId)) {
      setError((prevError) => ({
        ...prevError,
        emailErr: "Please enter a valid email",
      }));
    } else {
      setError((prevError) => ({
        ...prevError,
        emailErr: "",
      }));
    }
  };

  const handlePassword = () => {
    if (userData.password.length < 8) {
      setError((prevError) => ({
        ...prevError,
        passwordErr: "Password must be at least 8 characters long",
      }));
    } else {
      setError((prevError) => ({
        ...prevError,
        passwordErr: "",
      }));
    }
  };

  const handleConfirmPassword = () => {
    if (userData.password !== confirmPassword) {
      setError((prevError) => ({
        ...prevError,
        confirmPasswordErr: "Passwords do not match",
      }));
    } else {
      setError((prevError) => ({
        ...prevError,
        confirmPasswordErr: "",
      }));
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (userData.password !== confirmPassword) {
      setError((prevError) => ({
        ...prevError,
        confirmPasswordErr: "Passwords do not match",
      }));
      return;
    }

    try {
      const response = await registerStudent(userData);

      if (response && response.status === 201) {
        navigate(BASE_ROUTE);
      }
    } catch (error) {
      setError((prevError) => ({
        ...prevError,
        generalErr: "Failed to register. Please check your data and try again.",
      }));
    }
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gray-100 px-4 py-8">
      <div className="w-full max-w-md bg-white p-8 rounded-lg shadow-md sm:w-11/12 md:w-8/12 lg:w-6/12 xl:w-5/12">
        <h2 className="text-2xl font-bold mb-6 text-center">Register</h2>
        {error.generalErr && (
          <p className="text-red-500 text-xs mb-4 text-center">{error.generalErr}</p>
        )}
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="firstName" className="block text-sm font-medium text-gray-700">First Name</label>
            <input
              type="text"
              id="firstName"
              name="firstName"
              value={userData.firstName}
              onChange={handleChange}
              onBlur={handleFirstName}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
            <p className="text-red-500 text-xs mt-1">{error.firstNameErr}</p>
          </div>
          <div className="mb-4">
            <label htmlFor="middleName" className="block text-sm font-medium text-gray-700">Middle Name</label>
            <input
              type="text"
              id="middleName"
              name="middleName"
              value={userData.middleName}
              onChange={handleChange}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
            />
          </div>
          <div className="mb-4">
            <label htmlFor="lastName" className="block text-sm font-medium text-gray-700">Last Name</label>
            <input
              type="text"
              id="lastName"
              name="lastName"
              value={userData.lastName}
              onChange={handleChange}
              onBlur={handleLastName}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
            <p className="text-red-500 text-xs mt-1">{error.lastNameErr}</p>
          </div>
          <div className="mb-4">
            <label htmlFor="emailId" className="block text-sm font-medium text-gray-700">Email</label>
            <input
              type="email"
              id="emailId"
              name="emailId"
              value={userData.emailId}
              onChange={handleChange}
              onBlur={handleEmail}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
            <p className="text-red-500 text-xs mt-1">{error.emailErr}</p>
          </div>
          <div className="mb-4">
            <label htmlFor="mobileNumber" className="block text-sm font-medium text-gray-700">Mobile Number</label>
            <input
              type="tel"
              id="mobileNumber"
              name="mobileNumber"
              value={userData.mobileNumber}
              onChange={handleChange}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
          </div>
          <div className="mb-6 relative">
            <label htmlFor="password" className="block text-sm font-medium text-gray-700">Password</label>
            <input
              type={showPassword ? 'text' : 'password'}
              id="password"
              name="password"
              value={userData.password}
              onChange={handleChange}
              onBlur={handlePassword}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
            <button
              type="button"
              onClick={togglePasswordVisibility}
              className="absolute inset-y-0 right-0 flex items-center px-3 py-2 text-gray-500"
            >
              <FontAwesomeIcon
                icon={showPassword ? faEyeSlash : faEye}
                className="h-8 w-6 mt-6"
                aria-hidden="true"
              />
            </button>
            <p className="text-red-500 text-xs mt-1">{error.passwordErr}</p>
          </div>
          <div className="mb-6 relative">
            <label htmlFor="confirmPassword" className="block text-sm font-medium text-gray-700">Confirm Password</label>
            <input
              type={showConfirmPassword ? 'text' : 'password'}
              id="confirmPassword"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              onBlur={handleConfirmPassword}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
            <button
              type="button"
              onClick={toggleConfirmPasswordVisibility}
              className="absolute inset-y-0 right-0 flex items-center px-3 py-2 text-gray-500"
            >
              <FontAwesomeIcon
                icon={showConfirmPassword ? faEyeSlash : faEye}
                className="h-8 w-6 mt-6"
                aria-hidden="true"
              />
            </button>
            <p className="text-red-500 text-xs mt-1">{error.confirmPasswordErr}</p>
          </div>
          
        <div className="mb-4">
          <label className="block text-gray-700 mb-2">Select Course</label>
          <select
            name="courseId"
            value={userData.courseId}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded"
            required
          >
            <option value="" disabled>
              Select your course
            </option>
            <option value="1">DAC</option>
            <option value="2">DBDA</option>
          </select>
        </div>
          <div className="mb-4 text-center">
            <button
              type="submit"
              className="w-fit mx-auto text-white bg-[#28425a] px-4 py-2 rounded-md hover:bg-white hover:text-[#28425a] hover:border-[#1e3a8a] border-2 border-transparent focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-[#1e3a8a] transition-transform transform hover:scale-105"
            >
              Register
            </button>
          </div>
          <div className="text-center">
            <p className="text-sm text-gray-600">
              Already have an account?{' '}
              <Link to="/login" className="text-indigo-600 hover:text-indigo-800">
                Login
              </Link>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default RegisterUser;
