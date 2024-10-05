export const setToken = (token) => {
    sessionStorage.setItem('token', token);
  };
  
  export const getToken = () => {
    return sessionStorage.getItem('token');
  };
  
  export const removeToken = () => {
    sessionStorage.removeItem('token');
  };
  
  export const setUserDetails = (userId, role) => {
    sessionStorage.setItem('userId', userId);
    sessionStorage.setItem('role', role);
  };
  
  export const getUserRole = () => {
    return sessionStorage.getItem('role');
  };
  
  export const getUserId = () => {
    return sessionStorage.getItem('userId');
  };  