import axios from 'axios';
import { GET_NOTES } from '../constants/apiConstants';

const getNotes = (token) => {
  console.log('token : ',token)
  return axios.get(`${GET_NOTES}`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
};

const studentServices = {
  getNotes,
};

export default studentServices;
