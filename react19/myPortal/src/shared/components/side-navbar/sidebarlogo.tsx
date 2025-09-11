import { useCallback } from "react";
import { useNavigate } from "react-router-dom";

type SidebarIconProps = {
    imagePath: string;
    name: string;
};

export default function SidebarLogo({ imagePath, name }: SidebarIconProps) {
    const navigate = useNavigate();
    const navigateToPage = useCallback((page: string) => {
        navigate(page);}, [navigate]);

    return (
    <div className="sidebar-image mt-4" onClick={() => navigateToPage('/home') }>
        <img src={imagePath} 
        alt="Profile"
        //className="w-[100px] h-[50px] object-cover"
        />

        <span className="text-sm text-white mt-1">{name}</span>
    </div>)
};