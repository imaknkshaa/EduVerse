import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { GET_NOTE_BY_COURSE_ID } from '../../constants/apiConstants';
// import { getUserById } from '../../services/userServices';
import { useSelector } from 'react-redux';
// import { fetchNotes } from '../../services/studentServices';

const ViewNotes = ({courseId}) => {
  const { userId, token } = useSelector((state) => state.auth);
  const [notes, setNotes] = useState([]);
  // const [courseId,setCourseId]=useState('')
  
  useEffect(() => {
    const fetchUser=async()=>{
      // const response =await getUserById(userId,token)

      // setCourseId(response.data.courseId)
    }

    const loadNotes = async () => {
      try {
        await fetchUser()
        const response = await axios.get(`${GET_NOTE_BY_COURSE_ID}/${courseId}`,{
          headers: {
            Authorization: `Bearer ${token}`,
          },
        })
        setNotes(response.data);
      } catch (error) {
        console.error('Failed to fetch notes', error);
      }
    };
    loadNotes();
  }, [courseId,token,userId]);

  const handleNoteClick = (note) => {
    window.open(note.file, '_blank');
  };

  return (
    <div className="p-6 bg-white rounded-lg shadow-md">
      <h2 className="text-2xl font-semibold mb-4">Notes</h2>
      {notes.length > 0 ? (
        <ul className="space-y-4">
          {notes.map((note) => (
            <li
              key={note.noteID}
              onClick={() => handleNoteClick(note)}
              className="cursor-pointer p-4 bg-gray-100 hover:bg-gray-200 rounded-lg shadow-md transition-transform transform hover:scale-105"
            >
              <h3 className="text-lg font-medium">{note.title}</h3>
            </li>
          ))}
        </ul>
      ) : (
        <p>No notes available for your course.</p>
      )}
    </div>
  );
};

export default ViewNotes;
