import type React from "react";
import { useCallback, useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import SidebarIcon from "./sidebaricon";
import { BiLogOut } from "react-icons/bi";
import { TbBellRinging2Filled } from "react-icons/tb";
import apexLogo from "../../../assets/icon.png";
import SidebarLogo from "./sidebarlogo";

type SidebarProps = {
    icon: React.ReactNode;
    text: string;
    index: number;
    route?: string;
};


export default function Sidebar({sidebarItems}: {sidebarItems: SidebarProps[]}) {
    const [activeIndex, setActiveIndex] = useState<number | null>(null);
    const sidebarRef = useRef<HTMLDivElement>(null);

    const navigate = useNavigate();

    const navigateToPage = useCallback((page: string) => {
        navigate(page);
    }, [navigate]);

    const handleItemClick = useCallback((index: number | null, route?: string) => {
        setActiveIndex(index);
        if (route) {
            navigateToPage(route);
        }
    }, [navigateToPage, setActiveIndex]);

    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (
                sidebarRef.current &&
                !sidebarRef.current.contains(event.target as Node)
            ) {
                setActiveIndex(null); 
            }
        };
        document.addEventListener("mousedown", handleClickOutside);
        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
        };
    }, [sidebarRef, setActiveIndex]);

    return(
       <div className="fixed top-0 left-0 h-screen w-22 m-0 flex flex-col items-center bg-(--card) text-white shadow-lg overflow-y-auto text-sm p-2 border border-neutral-700">
            <SidebarLogo imagePath={apexLogo} name={""}></SidebarLogo>

            <div className=" relative w-full flex justify-center mt-4 mb-8">
                     <div className="absolute h-0.5 w-16 bg-white top-1/2 transform -translate-y-1/2"></div>
            </div>
                
                {sidebarItems.map((item) => (
                    <SidebarIcon
                        key={item.text}
                        icon={item.icon}
                        text={item.text}
                        isActive={activeIndex === item.index}
                        onClick={() => {
                                handleItemClick(item.index);
                                navigateToPage(item.route ?? '');
                        }}
                    />
                ))}

                <div className="flex-col justify-center mt-auto mb-3" >
                    {/* <div className=" relative w-full flex justify-center mb-3">
                         <div className="absolute h-0.5 w-16 bg-white top-1/2 transform -translate-y-1/2"></div>
                    </div> */}
                    <SidebarIcon
                        key={"News"}
                        icon={<TbBellRinging2Filled  size="25" />}
                        text={"News"}
                        isActive={activeIndex === 0}
                        onClick={() => {
                            navigateToPage('/login');
                        }}
                    />
                    <SidebarIcon
                        key={"Logout"}
                        icon={<BiLogOut size="25" />}
                        text={"Logout"}
                        isActive={activeIndex === 0}
                        onClick={() => {
                            navigateToPage('/login');
                        }}
                    />
                </div>
        </div>
    );

}