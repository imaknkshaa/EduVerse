import React, { useState, useEffect } from 'react';
import { useSelector } from 'react-redux';
// import { fetchAssignments, submitAssignment } from '../../services/studentServices'; // Uncomment and replace with actual service functions

const Assignments = ({courseId}) => {
  const [assignments, setAssignments] = useState([]);
  const [uploading, setUploading] = useState(false);
  const [error, setError] = useState(null);
  const {userId,token} = useSelector((state) => state.auth);


  useEffect(() => {
    if (userId && courseId) {
      const loadAssignments = async () => {
        try {
          // const response = await fetchAssignments(courseId);
          const response=null;
          setAssignments(response.data);
        } catch (error) {
          console.error('Failed to fetch assignments', error);
          setError('Failed to load assignments.');
        }
      };
      loadAssignments();
    }
  }, [userId,courseId]);

  const handleFileUpload = async (e, assignmentId) => {
    const file = e.target.files[0];
    if (!file) return;

    setUploading(true);
    setError(null);

    try {
      const formData = new FormData();
      formData.append('file', file);
      formData.append('assignmentID', assignmentId);
      formData.append('studentID', userId);

      // await submitAssignment(formData);

      setAssignments(assignments.map(assignment => 
        assignment.assignmentId === assignmentId ? { ...assignment, isSubmitted: true } : assignment
      ));

    } catch (error) {
      console.error('Failed to submit assignment', error);
      setError('Failed to submit the assignment. Please try again.');
    } finally {
      setUploading(false);
    }
  };

  const handleAssignmentClick = (assignment) => {
    window.open(assignment.file, '_blank');
  };

  const handleSubmissionClick = (assignment) => {
    if (assignment.submittedFile) {
      window.open(assignment.submittedFile, '_blank');
    }
  };

  return (
    <div className="p-6 bg-white rounded-lg shadow-md">
      <h2 className="text-2xl font-semibold mb-4">Assignments</h2>
      {error && <p className="text-red-500 mb-4">{error}</p>}
      {assignments.length > 0 ? (
        <ul className="space-y-4">
          {assignments.map((assignment) => (
            <li
              key={assignment.assignmentID}
              className="p-4 bg-gray-100 rounded-lg shadow-md transition-transform transform hover:scale-105"
            >
              <div className="flex justify-between items-center">
                <div className="cursor-pointer" onClick={() => handleAssignmentClick(assignment)}>
                  <h3 className="text-lg font-medium">{assignment.title}</h3>
                  <p className="text-gray-500">Due Date: {new Date(assignment.dueDate).toLocaleDateString()}</p>
                </div>
                <div className="text-right">
                  <p className={`text-sm font-semibold ${assignment.isSubmitted ? 'text-green-500' : 'text-red-500'}`}>
                    {assignment.isSubmitted ? 'Submitted' : 'Not Submitted'}
                  </p>
                  {!assignment.isSubmitted && (
                    <div className="mt-2">
                      <input
                        type="file"
                        onChange={(e) => handleFileUpload(e, assignment.assignmentID)}
                        disabled={uploading}
                        className="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 focus:outline-none"
                      />
                    </div>
                  )}
                </div>
              </div>

              {/* Display submitted solution, grades, and remark if available */}
              {assignment.isSubmitted && (
                <div className="mt-4">
                  <p className="text-sm text-gray-600">
                    <strong>Submitted Solution:</strong>{' '}
                    {assignment.submittedFile ? (
                      <span
                        className="text-blue-500 cursor-pointer"
                        onClick={() => handleSubmissionClick(assignment)}
                      >
                        View Submission
                      </span>
                    ) : (
                      'Not Available'
                    )}
                  </p>
                  <p className="text-sm text-gray-600">
                    <strong>Grade:</strong> {assignment.grade !== null ? assignment.grade : 'Not Graded'}
                  </p>
                  <p className="text-sm text-gray-600">
                    <strong>Remark:</strong> {assignment.remark || 'No Remark'}
                  </p>
                </div>
              )}
            </li>
          ))}
        </ul>
      ) : (
        <p>No assignments available for your course.</p>
      )}
    </div>
  );
};

export default Assignments;
