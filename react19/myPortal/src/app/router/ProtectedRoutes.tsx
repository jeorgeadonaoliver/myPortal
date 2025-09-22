import { Navigate } from "react-router-dom";
import { useAuth } from "../../features/auth/hooks/useAuth";
import type { ReactNode } from "react";

interface ProtectedRouteProps {
  children: ReactNode;
}

export const ProtectedRoute = ({children}: ProtectedRouteProps) => {

    const { user, validUser } = useAuth();

    if (user && validUser) {
      return <>{children}</>;
    }
    else
    {
      return <Navigate to="/login" replace />;
    }
};