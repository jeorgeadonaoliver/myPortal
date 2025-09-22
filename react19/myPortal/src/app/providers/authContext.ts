import { createContext } from "react";
import type { User } from "firebase/auth";

interface AuthContextValue {
  user: User | null;
  login: (email: string, password: string) => Promise<boolean>;
  logout: () => Promise<void>;
  loading: boolean;
  forgotpassword: (email: string) => Promise<void>;
  validOtp : () => void;
  validUser: boolean;
}

export const AuthContext = createContext<AuthContextValue | undefined>(undefined);