import axios from 'axios';
import { AUTH_LOGIN, POST_USERS } from '../constants/apiConstants';

export const login = async user => {
  // try {
    // const credentials = {email,password}
    // console.log(`${AUTH_LOGIN}, ${credentials}`,)
    const response = await axios.post(`${AUTH_LOGIN}`, user);
    return response;
  // } catch (error) {
  //   throw error;
  // }
};

export const registerStudent = async user =>{
  const response = await axios.post(`${POST_USERS}`,user)

  return response
}