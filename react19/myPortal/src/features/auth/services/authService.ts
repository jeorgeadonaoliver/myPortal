import { onAuthStateChanged, signInWithPopup, signOut, type User } from "firebase/auth";
import type { AuthUser } from "../types/AuthUser";
import { auth, googleProvider } from "../../../shared/firebase/firebaseConfig";

const mapFirebaseUser = (user: User | null): AuthUser | null => {
  if (!user) return null;
  return {
    uid: user.uid,
    email: user.email,
    displayName: user.displayName,
    photoURL: user.photoURL,
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