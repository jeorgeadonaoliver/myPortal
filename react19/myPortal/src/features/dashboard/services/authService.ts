import { signInWithEmailAndPassword, signOut } from "firebase/auth";
import { auth } from "../../../shared/firebase/firebaseConfig";

export const loginWithEmail = async (email: string, password: string) => {
  const result = await signInWithEmailAndPassword(auth, email, password);
  return result.user;
};

export const logout = async () => {
  await signOut(auth);
};
