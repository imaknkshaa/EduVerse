import React from "react";

const About = () => {
  return (
    <div className="min-h-screen p-4 flex justify-center items-center mb-14 bg-blue-50">
      <div className="p-6 sm:p-8 bg-white rounded-lg shadow-lg max-w-4xl w-full">
        <h1 className="text-2xl sm:text-3xl md:text-4xl font-bold text-center mb-6 sm:mb-8 text-blue-700">
          About Us
        </h1>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-6 sm:gap-8">
          <section className="bg-white p-4 sm:p-6 shadow-md rounded-lg">
            <h2 className="text-xl sm:text-2xl font-semibold mb-4 text-blue-600 text-center">
              Welcome to EduVerse
            </h2>
            <p className="text-gray-700 leading-relaxed">
              EduVerse is a premier online education platform dedicated to
              making learning accessible, engaging, and effective for everyone.
              Our goal is to empower students with quality education and
              resources to excel in their academic pursuits.
            </p>
          </section>

          <section className="bg-white p-4 sm:p-6 shadow-md rounded-lg">
            <h2 className="text-xl sm:text-2xl font-semibold mb-4 text-blue-600 text-center">
              Our Mission
            </h2>
            <p className="text-gray-700 leading-relaxed">
              Our mission is to bridge the gap between students and knowledge by
              providing a seamless and personalized online learning experience.
              We strive to make education accessible to everyone, anytime, anywhere.
            </p>
          </section>

          <section className="bg-white p-4 sm:p-6 shadow-md rounded-lg col-span-1 md:col-span-2">
            <h2 className="text-xl sm:text-2xl font-semibold mb-4 text-blue-600 text-center">
              Our Services
            </h2>
            <ul className="list-disc list-inside text-gray-700 leading-relaxed space-y-2 ml-4">
              <li>
                <strong>Online Courses:</strong> Access a wide range of courses
                across different domains, designed by expert educators.
              </li>
              <li>
                <strong>Interactive Learning:</strong> Engage with interactive
                content, quizzes, and assessments to enhance your learning experience.
              </li>
              <li>
                <strong>Certifications:</strong> Earn certificates for completed
                courses to showcase your knowledge and skills.
              </li>
              <li>
                <strong>Mentorship:</strong> Connect with experienced mentors for
                personalized guidance and support.
              </li>
            </ul>
          </section>

          <section className="bg-white p-4 sm:p-6 shadow-md rounded-lg col-span-1 md:col-span-2">
            <h2 className="text-xl sm:text-2xl font-semibold mb-4 text-blue-600 text-center">
              Additional Features
            </h2>
            <ul className="list-disc list-inside text-gray-700 leading-relaxed space-y-2 ml-4">
              <li>
                <strong>Flexible Learning:</strong> Learn at your own pace with
                flexible schedules and self-paced courses.
              </li>
              <li>
                <strong>Community Support:</strong> Join a vibrant community of
                learners and educators to collaborate and share knowledge.
              </li>
              <li>
                <strong>Mobile Accessibility:</strong> Access courses on the go
                with our mobile-friendly platform.
              </li>
            </ul>
          </section>

          <section className="bg-white p-4 sm:p-6 shadow-md rounded-lg col-span-1 md:col-span-2">
            <h2 className="text-xl sm:text-2xl font-semibold mb-4 text-blue-600 text-center">
              Why Choose EduVerse?
            </h2>
            <ul className="list-disc list-inside text-gray-700 leading-relaxed space-y-2 ml-4">
              <li>
                <strong>Quality Education:</strong> Our platform offers
                high-quality courses designed by industry experts.
              </li>
              <li>
                <strong>Accessibility:</strong> Our courses are available
                24/7, making education accessible to everyone, anywhere.
              </li>
              <li>
                <strong>Community Driven:</strong> We foster a supportive
                community of learners and educators who are passionate about education.
              </li>
            </ul>
          </section>
        </div>

        <p className="text-center text-gray-700 mt-6 sm:mt-8 text-lg leading-relaxed">
          Join EduVerse and embark on a journey of knowledge and growth.
          Empower yourself with the skills and education needed to succeed in
          today’s world.
        </p>
      </div>
    </div>
  );
};

export default About;
