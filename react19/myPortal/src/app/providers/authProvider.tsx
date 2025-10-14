import { useEffect, useState, type ReactNode } from "react";
import { AuthContext } from "./authContext";
import { onAuthStateChanged, sendPasswordResetEmail, signInWithEmailAndPassword, signOut, type User } from "firebase/auth";
import { auth } from "../../shared/firebase/firebaseConfig";
import { toast } from "react-toastify";
import { verifyToken } from "../../features/auth/services/authService";

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true); 
  const [validUser, setValidUser] = useState(false);

  useEffect(() => {
    const unsubscribe = onAuthStateChanged(auth, (firebaseUser) => {
      setUser(firebaseUser);
      setLoading(false);
    });
    return () => unsubscribe();
  }, []);

  const login = async (email: string, password: string) => {
    setLoading(true);
    try
    {
      const userinfo = await signInWithEmailAndPassword(auth, email, password);

      const token = await userinfo.user.getIdToken();
      const response = await verifyToken(token);
      
      localStorage.setItem("authToken", token);


      console.log("Token verification response:", response);

      if (!response) {
        throw new Error('Token validation failed');
      }

      setValidUser(true);
      setLoading(false);
      setUser(userinfo.user);

      return true;
    }
    catch(error)
    {
      setValidUser(false);
      toast.error("Login failed. Please check your credentials and try again.");
      console.error("Login error:", error);
      setLoading(false);
      return false;
    }
  };

  const logout = async () => {
    await signOut(auth);
    setUser(null);
    setValidUser(false);
    toast.error("You have been logged out.");
  };

  const forgotpassword = async (email: string) => {
      //const auth = getAuth();
      await sendPasswordResetEmail(auth, email)
      .then(() => {
          console.log('Password reset email sent');
      })
      .catch((error)=>{
          console.error('Error sending password reset email:', error);
      });
  }

  const validOtp = () => {
    setValidUser(true);
  }

  return (
    <AuthContext.Provider value={{ user, login, logout, loading, forgotpassword, validOtp, validUser }}>
      {children}
    </AuthContext.Provider>
  );
};