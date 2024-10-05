import { LOGIN_SUCCESS, LOGIN_FAILURE, LOGOUT_SUCCESS } from '../types/authTypes';
import {setToken, setUserDetails} from '../../components/utils/auth'

export const login = (token, userId, role) => {
  return (dispatch) => {
    setToken(token);
    setUserDetails(userId, role);
    dispatch({
      type: LOGIN_SUCCESS,
      payload: { token, userId, role }
    });
  };
};

export const logout = () => {
  return (dispatch) => {
    sessionStorage.clear()
    dispatch({ type: LOGOUT_SUCCESS });
  };
};
