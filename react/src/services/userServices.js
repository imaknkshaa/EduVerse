import axios from 'axios';
import { GET_USER_BY_ID, PUT_USER_BY_ID } from '../constants/apiConstants';

export const getUserById = ( userId,token) => {
  return axios.get(`${GET_USER_BY_ID}/${userId}`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
};

export const updateUserById=(userId,token,user)=>{
  return axios.put(`${PUT_USER_BY_ID}/${userId}`,user, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
}