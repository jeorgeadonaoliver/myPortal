// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAuth, GoogleAuthProvider } from "firebase/auth";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyBZtkK9dt4EC7s6f6ouysHqZT4d42GpcXc",
  authDomain: "myportal-63a5d.firebaseapp.com",
  projectId: "myportal-63a5d",
  storageBucket: "myportal-63a5d.firebasestorage.app",
  messagingSenderId: "894230105044",
  appId: "1:894230105044:web:9cf96586ca5799a6456441",
  measurementId: "G-9EHL8M4DC5"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
export const auth = getAuth(app);
export const googleProvider = new GoogleAuthProvider();