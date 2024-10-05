import React from "react";
import WhatsApp from "../../../assets/images/Team/WhatsApp.svg";
import abhishek from "../../../assets/images/Team/Abhishek.jpg";
import aakanksha from "../../../assets/images/Team/Aakanksha.jpg";
import rushikesh from "../../../assets/images/Team/Rushikesh.jpg";
import pranoti from "../../../assets/images/Team/Pranoti.png";
import pratik from "../../../assets/images/Team/Pratik.jpg";

const teamMembers = [
  {
    name: 'Rushikesh Ghuge',
    location: '070 Juhu',
    description: `Rushikesh is an integral part of our team. His coursework at CDAC has enhanced his expertise in various technologies. When he’s not coding, Rushikesh enjoys solving complex problems.`,
    imgUrl: rushikesh,
    linkedin: 'https://www.linkedin.com/in/rushikesh-ghuge-78ab0423b?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app',
    mail: 'mailto:rushikeshghuge2019@gmail.com',
    whatsapp: 'https://wa.me/9527025495',
  },
  {
    name: 'Abhishek Shivade',
    location: '008 Juhu',
    description: `Abhishek is the driving force behind our project, currently pursuing advanced studies at CDAC. He excels in leading our team through complex challenges.`,
    imgUrl: abhishek,
    linkedin: 'https://www.linkedin.com/in/abhishek-shivade/',
    mail: 'mailto:abhishekshivade@gmail.com',
    whatsapp: 'https://wa.me/9518973338',
  },
  {
    name: 'Pranoti Koshti',
    location: '059 Juhu',
    description: `Pranoti is the driving force behind our project, currently pursuing advanced studies at CDAC. She excels at leading our team through complex challenges. In her spare time, Pranoti enjoys exploring technologies.`,
    imgUrl: pranoti,
    linkedin: 'https://www.linkedin.com/in/pranoti-koshti-37587b193/',
    mail: 'mailto:pranotikoshti2904@gmail.com',
    whatsapp: 'https://wa.me/9960984921',
  },
  {
    name: 'Aakanksha Somankar',
    location: '001 Juhu',
    description: `As an entry-level full stack developer, Aakanksha is adept at building and maintaining full-stack web applications. Her skill set spans a range of technologies, allowing her to handle the complete development cycle.`,
    imgUrl: aakanksha,
    linkedin: 'https://www.linkedin.com/in/aakanksha-somankar-5a1831167?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app',
    mail: 'mailto:aakankshasomankar28@gmail.com',
    whatsapp: 'https://wa.me/8605836913',
  },
  {
    name: 'Pratik Dhayagude',
    location: '062 Juhu',
    description: `Pratik specializes in end-to-end development. His training at CDAC has equipped him with the latest skills. In his free time, he is an avid reader of non-fiction books and enjoys exploring new technologies.`,
    imgUrl: pratik,
    linkedin: 'https://www.linkedin.com/in/pratik-dhayagude-04120a281?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app',
    mail: 'mailto:pratikd0402@gmail.com',
    whatsapp: 'https://wa.me/9922853917',
  },
];

const TeamMemberCard = ({ member }) => {
  return (
    <div className="bg-white shadow-lg rounded-lg p-6 text-center flex flex-col items-center">
      <img className="rounded-full h-32 w-32 object-cover mb-4" src={member.imgUrl} alt={member.name} />
      <h2 className="text-xl font-semibold text-gray-800 mb-2">{member.name}</h2>
      <p className="text-gray-500 text-sm mb-2">{member.location}</p>
      <p className="text-gray-700 text-sm mb-4">{member.description}</p>
      <div className="flex space-x-4">
        <a href={member.linkedin} className="text-blue-600 hover:text-blue-800">
          <i className="fab fa-linkedin fa-2x"></i>
        </a>
        <a href={member.mail} className="text-red-600 hover:text-red-800">
          <i className="fas fa-envelope fa-2x"></i>
        </a>
        <a href={member.whatsapp} className="text-green-600 hover:text-green-800">
          <i className="fab fa-whatsapp fa-2x"></i>
        </a>
      </div>
    </div>
  );
};

const Team = () => {
  return (
    <div className="container mx-auto px-4 py-8">
      <h1 className="text-3xl sm:text-4xl font-bold text-center mb-8">The Team Behind EduVerse</h1>
      <p className="text-center text-lg text-gray-600 mb-12">
        Welcome to EduVerse, your gateway to a world of knowledge and growth. We're dedicated to providing a reliable platform for learners and educators alike, ensuring that your educational journey is supported every step of the way. Our passionate team is here to help you achieve your goals and create a brighter future. Join us in our mission to empower minds and transform lives through education.
      </p>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-8">
        {teamMembers.map((member, index) => (
          <TeamMemberCard key={index} member={member} />
        ))}
      </div>
    </div>
  );
};

export default Team;
