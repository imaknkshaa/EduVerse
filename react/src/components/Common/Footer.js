import React from 'react';
import { Link } from 'react-router-dom';
import { BASE_ROUTE, ABOUT_US, CONTACT_US } from '../../constants/appConstants';
import '@fortawesome/fontawesome-free/css/all.min.css';

const Footer = () => {
  return (
    <footer className="bg-[#28425A] text-white p-8">
      <div className="container mx-auto flex flex-col sm:flex-row justify-between items-center">
        {/* Logo and Important Links */}
        <div className="flex flex-col items-center sm:items-start mb-6 sm:mb-0">
          <Link to={BASE_ROUTE} className="text-2xl font-bold text-[#66A0AD] hover:text-[#9DF6EE]">
            EduVerse
          </Link>
          <ul className="mt-4">
            <li>
              <Link to={ABOUT_US} className="block py-1 text-white hover:text-[#9CBAC0]">About Us</Link>
            </li>
            <li>
              <Link to={CONTACT_US} className="block py-1 text-white hover:text-[#9CBAC0]">Contact Us</Link>
            </li>
          </ul>
        </div>

        {/* Social Media Icons */}
        <div className="flex space-x-4 mb-6 sm:mb-0">
          <a href="https://www.linkedin.com" target="_blank" rel="noopener noreferrer" className="text-white hover:text-[#9CBAC0]">
            <i className="fab fa-linkedin-in fa-2x"></i>
          </a>
          <a href="https://wa.me/" target="_blank" rel="noopener noreferrer" className="text-white hover:text-[#9CBAC0]">
            <i className="fab fa-whatsapp fa-2x"></i>
          </a>
          <a href="https://www.facebook.com" target="_blank" rel="noopener noreferrer" className="text-white hover:text-[#9CBAC0]">
            <i className="fab fa-facebook-f fa-2x"></i>
          </a>
          <a href="https://www.instagram.com" target="_blank" rel="noopener noreferrer" className="text-white hover:text-[#9CBAC0]">
            <i className="fab fa-instagram fa-2x"></i>
          </a>
        </div>

        {/* Address and Contact */}
        <div className="text-center sm:text-right">
          <p className="mb-2">123 EduVerse Lane</p>
          <p className="mb-2">Education City, ED 45678</p>
          <p className="mb-2">Phone: (123) 456-7890</p>
          <p>Email: <a href="mailto:info@eduverse.com" className="text-[#9CBAC0] hover:underline">info@eduverse.com</a></p>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
