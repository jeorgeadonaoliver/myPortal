import axios from "axios";
import { getAuth } from "firebase/auth";

const api = axios.create({
  baseURL: "https://localhost:7078/",
  timeout: 5000,
});

api.interceptors.request.use(async (config) => {

  const auth = getAuth();
  const token = await auth.currentUser?.getIdToken(); 
  console.log("Firebase Token:", token);

  if(token){
    config.headers.Authorization = `Bearer ${token}`;
  }

  return config;
});

export default api;