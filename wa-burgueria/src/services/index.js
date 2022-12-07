import IngredientsService from "./ingredients";
import BurgersService from "./burgers";
import AuthService from "./auth";
import router from "../router";

import axios from "axios";

const API_ENVS = {
  local: "http://localhost:3000",
};

const api = axios.create({
  baseURL: API_ENVS.local,
});

api.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    const canThrowAnError =
      error.request.status === 0 || error.request.status === 500;

    if (canThrowAnError) {
      throw new Error(error.message);
    }

    if (error.response.status === 401) {
      router.push({ path: "/" });
    }

    return error;
  }
);

export default {
  ingredients: IngredientsService(api),
  burgers: BurgersService(api),
  auth: AuthService(api),
};
