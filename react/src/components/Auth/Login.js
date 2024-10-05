import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
// import { login } from '../../store/actions/authActions'
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';
import { LOGIN_SUCCESS } from '../../store/types/authTypes';
import axios from "axios"
import { AUTH_LOGIN } from '../../constants/apiConstants';
import { REGISTER_STUDENT } from '../../constants/appConstants';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errors, setErrors] = useState({ email: '', password: '' });
  const [showPassword, setShowPassword] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(()=>sessionStorage.clear())

  const handleSubmit = async e => {
    e.preventDefault();

    try {
      const response = await axios.post(`${AUTH_LOGIN}/`, { email, password });

      const { token, userId, role } = response.data;
      
      sessionStorage.setItem('token', token);
      sessionStorage.setItem('userId', userId);
      sessionStorage.setItem('role', role);

      dispatch({
        type: LOGIN_SUCCESS,
        payload: { token, userId, role }
      });

      navigate('/dashboard');

    } catch (error) {
      console.error('Login failed:', error);
      setErrors({ ...errors, general: 'Login failed. Please try again.' });
     }


  }

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="w-full max-w-md bg-white p-8 rounded-lg shadow-md">
        <h2 className="text-2xl font-bold mb-6 text-center">Login</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="email" className="block text-sm font-medium text-gray-700">Email</label>
            <input
              type="email"
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
            />
            {errors.email && <p className="text-red-500 text-xs mt-1">{errors.email}</p>}
          </div>
          <div className="mb-6 relative">
            <label htmlFor="password" className="block text-sm font-medium text-gray-700">Password</label>
            <input
              type={showPassword ? 'text' : 'password'}
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
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
            {errors.password && <p className="text-red-500 text-xs mt-1">{errors.password}</p>}
          </div>
          {errors.general && <p className="text-red-500 text-xs mb-4">{errors.general}</p>}
          <div className="mb-4 text-center">
            <button
              type="submit"
              className="w-fit mx-auto text-white bg-[#28425a] px-4 py-2 rounded-md hover:bg-white hover:text-[#28425a] hover:border-[#1e3a8a] border-2 border-transparent focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-[#1e3a8a] transition-transform transform hover:scale-105"
            >
              Login
            </button>
          </div>
          <div className="text-center">
            <p className="text-sm text-gray-600">
              Don't have an account? {' '}
              <Link to={REGISTER_STUDENT} className="text-indigo-600 hover:text-indigo-800">
                Sign Up
              </Link>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;
