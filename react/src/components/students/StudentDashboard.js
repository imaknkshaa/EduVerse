import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { getUserById } from "../../services/userServices";
import Notes from "./Notes";
import Assignments from "./Assignments";
import Quiz from "./Quiz";
import Profile from "./Profile";

const StudentDashboard = () => {
  const { userId, token } = useSelector((state) => state.auth);
  const [user, setUser] = useState(null);
  const [activeComponent, setActiveComponent] = useState("notes"); // Default component

  useEffect(() => {
    const fetchUserInfo = async () => {
      try {
        const response = await getUserById(userId, token);
        setUser(response.data);
      } catch (error) {
        console.error("Error fetching user information:", error);
      }
    };

    if (userId) {
      fetchUserInfo();
    }
  }, [userId, token]);

  if (!user) {
    return <div className="min-h-screen text-center"><h1 className="text-xl font-semibold my-48">Loading...</h1></div>;
  }

  // Render the active component based on the state
  const renderComponent = () => {
    switch (activeComponent) {
      case "notes":
        return <Notes courseId={user.courseId} />;
      case "assignments":
        return <Assignments courseId={user.courseId} />;
      case "quiz":
        return <Quiz />;
      case "profile":
        return <Profile />;
      default:
        return <Notes />;
    }
  };

  return (
    <div className="p-6 min-h-screen">
      <div className="mb-16 text-center sm:text-left">
        <h1 className="text-2xl sm:text-3xl lg:text-4xl font-bold mb-4">
          Welcome, {user.firstName}
        </h1>
        <p className="text-lg sm:text-xl lg:text-2xl mb-8">
          Explore your resources and manage your assignments, quizzes, and profile.
        </p>
      </div>

      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        <button
          onClick={() => setActiveComponent("notes")}
          className="block p-6 bg-[#28425A] text-white hover:text-black rounded-lg hover:bg-[#9CBAC0] transition duration-300"
        >
          <h2 className="text-xl sm:text-2xl font-semibold mb-2">Notes</h2>
          <p className="text-sm sm:text-base">
            View notes uploaded by your teachers.
          </p>
        </button>

        <button
          onClick={() => setActiveComponent("assignments")}
          className="block p-6 bg-[#28425A] text-white hover:text-black rounded-lg hover:bg-[#9CBAC0] transition duration-300"
        >
          <h2 className="text-xl sm:text-2xl font-semibold mb-2">Assignments</h2>
          <p className="text-sm sm:text-base">
            Submit your assignments and check deadlines.
          </p>
        </button>

        <button
          onClick={() => setActiveComponent("quiz")}
          className="block p-6 bg-[#28425A] text-white hover:text-black rounded-lg hover:bg-[#9CBAC0] transition duration-300"
        >
          <h2 className="text-xl sm:text-2xl font-semibold mb-2">Quizzes</h2>
          <p className="text-sm sm:text-base">
            Attempt quizzes and track your performance.
          </p>
        </button>

        <button
          onClick={() => setActiveComponent("profile")}
          className="block p-6 bg-[#28425A] text-white hover:text-black rounded-lg hover:bg-[#9CBAC0] transition duration-300"
        >
          <h2 className="text-xl sm:text-2xl font-semibold mb-2">Profile</h2>
          <p className="text-sm sm:text-base">
            Manage your profile and update your information.
          </p>
        </button>
      </div>

      <div className="mt-12">
        {renderComponent()}
      </div>
    </div>
  );
};

export default StudentDashboard;
