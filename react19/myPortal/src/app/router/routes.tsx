import LoginPage from "../../features/auth/pages/loginPage";
import OtpPage from "../../features/auth/pages/otpPage";
import DashboardPage from "../../features/dashboard/pages/dashboardPage";
import AuthLayout from "../../shared/layouts/authlayout";
import MainLayout from "../../shared/layouts/mainlayout";

export const routes = [
    {
        path: "/",
        element: <AuthLayout />,
        children: [
            { path: "login", element: <LoginPage /> },
            { path: "otp", element: <OtpPage /> },
        ],
    }, 
    {
        path: "/home",
        element: <MainLayout />,
        //protected: true, 
        children: [
            {path: "dashboard", element: <DashboardPage />},
        ],
    }
];