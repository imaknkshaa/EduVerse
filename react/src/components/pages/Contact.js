import React from 'react';
// import {MailIcon, PhoneIcon} from '@heroicons/react/outline'
import Team from '../subComponents/about/Team';
// import { faEnvelope, faPhone } from '@fortawesome/free-solid-svg-icons';
import { faEnvelope, faPhone } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import '@fortawesome/fontawesome-free/css/all.min.css';

const ContactUs = () => {
  return (
    <>
      <Team />
      <div className="min-h-screen bg-gray-100 flex flex-col items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
        <div className="max-w-md w-full space-y-8 bg-white p-8 rounded-lg shadow-md">
          <div className="text-center">
            <h2 className="text-3xl font-bold text-[#28425a]">
              Get in Touch
            </h2>
            <p className="mt-2 text-sm text-gray-600">
              We'd love to hear from you! Please fill out the form below or reach out directly via email or phone.
            </p>
          </div>
          <div className="flex justify-center space-x-6 mb-8">
            <a href="mailto:support@eduverse.com" className="text-[#28425a] hover:text-[#1e3a8a] flex items-center">
              <FontAwesomeIcon icon={faEnvelope} className="h-6 w-6 mr-2" />
              Email
            </a>
            <a href="tel:+1234567890" className="text-[#28425a] hover:text-[#1e3a8a] flex items-center">
              <FontAwesomeIcon icon={faPhone} className="h-6 w-6 mr-2" />
              Phone
            </a>
          </div>
          <form className="space-y-6">
            <div className="grid grid-cols-1 gap-6 sm:grid-cols-2">
              <div>
                <label htmlFor="name" className="sr-only">Full Name</label>
                <input
                  id="name"
                  name="name"
                  type="text"
                  required
                  className="appearance-none rounded-md block w-full px-4 py-3 border border-[#28425a] placeholder-[#7c9ac2] text-[#28425a] focus:outline-none focus:ring-[#28425a] focus:border-[#1e3a8a] sm:text-md transition duration-150 ease-in-out"
                  placeholder="Full Name"
                />
              </div>
              <div>
                <label htmlFor="email" className="sr-only">Email Address</label>
                <input
                  id="email"
                  name="email"
                  type="email"
                  required
                  className="appearance-none rounded-md block w-full px-4 py-3 border border-[#28425a] placeholder-[#7c9ac2] text-[#28425a] focus:outline-none focus:ring-[#28425a] focus:border-[#1e3a8a] sm:text-md transition duration-150 ease-in-out"
                  placeholder="Email Address"
                />
              </div>
            </div>
            <div>
              <label htmlFor="message" className="sr-only">Message</label>
              <textarea
                id="message"
                name="message"
                rows="4"
                required
                className="appearance-none rounded-md block w-full px-4 py-3 border border-[#28425a] placeholder-[#7c9ac2] text-[#28425a] focus:outline-none focus:ring-[#28425a] focus:border-[#1e3a8a] sm:text-md transition duration-150 ease-in-out"
                placeholder="Your Message"
              />
            </div>
            <div className='text-center'>
              <button
                type="submit"
              className="w-fit mx-auto text-white bg-[#28425a] px-4 py-2 rounded-md hover:bg-white hover:text-[#28425a] hover:border-[#1e3a8a] border-2 border-transparent focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-[#1e3a8a] transition-transform transform hover:scale-105"
              >
                Send Message
              </button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
};

export default ContactUs;
