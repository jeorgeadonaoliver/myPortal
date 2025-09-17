import { onAuthStateChanged, signInWithPopup, signOut, type User } from "firebase/auth";
import type { AuthUser } from "../types/AuthUser";
import { auth, googleProvider } from "../../../shared/firebase/firebaseConfig";
import api from "../../../app/api/api";

const mapFirebaseUser = (user: User | null): AuthUser | null => {
  if (!user) return null;
  return {
    uid: user.uid
  };
};

export const loginWithGoogle = async (): Promise<AuthUser> => {
  const result = await signInWithPopup(auth, googleProvider);
  return mapFirebaseUser(result.user)!;
};

export const logout = async (): Promise<void> => {
  await signOut(auth);
};

export const observeAuth = (callback: (user: AuthUser | null) => void) => {
  return onAuthStateChanged(auth, (firebaseUser) => {
    callback(mapFirebaseUser(firebaseUser));
  });
};

export const getOTP = async() => {
    const response =await api.get('auth/otp');
    return response.data;
};