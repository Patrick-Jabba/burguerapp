export default (httpClient) => ({
  register: async ({ name, email, password, isAdmin }) => {
    const response = await httpClient.post("/users", {
      name,
      email,
      password,
      isAdmin
    });
    let errors = null;
    
    if (!response.data) {
      errors = {
        status: response.request.status,
        statusText: response.request.statusText,
      };
    }

    return {
      data: response.data,
      errors,
    };
  },

  login: async ({ email, password }) => {
    const response = await httpClient.post("/users", {
      email,
      password,
    });

    let errors = null;
    if (!response.data) {
      errors = {
        status: response.request.status,
        statusText: response.request.statusText,
      };
    }

    return {
      data: response.data,
      errors,
    };
  },

  getMe: async () => {
    const response = await httpClient.get('/users');
    
    return {
      users: response.data
    }
  },

  getUserByEmail: async (email) => {
    const response = await httpClient.get(`/users/${email}`);

    return {
      dataBaseUser: response.data
    }
  }
});
