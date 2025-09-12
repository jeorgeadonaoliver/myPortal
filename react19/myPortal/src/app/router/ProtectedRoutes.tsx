import { Navigate } from "react-router-dom";
import { useAuth } from "../../features/auth/hooks/useAuth";
import type { ReactNode } from "react";

interface ProtectedRouteProps {
  children: ReactNode;
}

export const ProtectedRoute = ({children}: ProtectedRouteProps) => {
    const { user } = useAuth();
    if (!user) {
        return <Navigate to="/login" replace />;
    }

    return <>{children}</>;
};