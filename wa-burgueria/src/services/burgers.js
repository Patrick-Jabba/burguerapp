export default (api) => ({
  createOrder: async ({ nome, carne, pao, opcionais, status }) => {
    const request = await api.post("/burgers", {
      nome,
      carne,
      pao,
      opcionais,
      status,
    });

    let errors = null;

    if (!request.data) {
      errors = {
        status: request.request.status,
        statusText: request.request.statusText,
      };
    }

    return {
      data: request.data,
      errors,
    };
  },

  getBurgers: async () => {
    const burgerList = await api.get("/burgers");

    return {
      data: burgerList.data,
    };
  },

  getBurgerById: async (id) => {
    const request = await api.get(`/burgers/${id}`);

    return {
      data: request.data,
    };
  },

  getOrderStatus: async () => {
    const request = await api.get("/status");

    return {
      data: request.data,
    };
  },

  deleteOrder: async (id) => {
    await api.delete(`/burgers/${id}`);
  },

  updateOrder: async (id, status) => {
    const request = await api.patch(`/burgers/${id}`, {
      id,
      status,
    });

    return {
      data: request.data,
    };
  },
});
