import { LOGIN_SUCCESS, LOGOUT_SUCCESS } from '../types/authTypes';

const initialState = {
  // token: sessionStorage.getItem('token') || null,
  // userId: sessionStorage.getItem('userId') || null,
  // role: sessionStorage.getItem('role') ||null,

  token:null,
  userId:null,
  role:null
};

const authReducer = (state = initialState, action) => {
  switch (action.type) {
    case LOGIN_SUCCESS:
      return {
        ...state,
        token: action.payload.token,
        userId: action.payload.userId,
        role: action.payload.role,
      };
    case LOGOUT_SUCCESS:
      return initialState;
    default:
      return state;
  }
};

export default authReducer;
