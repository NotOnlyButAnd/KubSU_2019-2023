import axios from "axios";
import interseptors from "./interceptors";

const instance = axios.create({
  baseURL: process.env.VUE_APP_API_URL,
  // moved to interseptors!!!
  // params: {
  //   apikey: process.env.VUE_APP_API_KEY,
  //   plot: "full",
  // },
});

interseptors(instance);

export default instance;
