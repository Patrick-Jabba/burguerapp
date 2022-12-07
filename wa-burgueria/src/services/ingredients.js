export default (api) => ({
  getIngredients: async () => {
    const request = await api.get("/ingredientes");

    let errors = null;
    
    if (!request.data) {
      errors = {
        status: request.request.status,
        statusText: request.request.statusText,
      };
    }
    
    return {
      data: request.data,
      errors
    };
  },
});
