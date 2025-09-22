import { Outlet } from "react-router-dom";
import Sidebar from "../components/side-navbar/sidebar";
import { BiFile, BiLogoGmail, BiSolidBarChartAlt2, BiSolidHand } from "react-icons/bi";
import { BsCCircleFill, BsFillGridFill, BsPeopleFill } from "react-icons/bs";
import { FaUserTie } from "react-icons/fa";

export default function MainLayout() {

    const sidebarItems = [
          { icon: <BsFillGridFill size="25" />, text: "Dash", index: 1, route: '/home/dashboard'},
          { icon: <FaUserTie size="25" />, text: "User", index: 2, route:'/home/customers' },
          { icon: <BsPeopleFill size="25" />, text: "Group", index: 3, route:'/projects' },
          { icon: <BsCCircleFill size="25" />, text: "Custody", index: 4, route: '/teams'},
          { icon: <BiFile  size="25" />, text: "Reports", index: 5, route: '/departments'},
          { icon: <BiSolidBarChartAlt2 size="25" />, text: "Analytics", index: 6, route: '/analytics'},
          { icon: <BiSolidHand   size="25" />, text: "Support", index: 7, route: '/support'},
          { icon: <BiLogoGmail    size="25" />, text: "Tools", index: 8, route: '/tools'},]
          
    return (
        <div className="min-h-screen flex bg-(--background)">
        <aside className="w-20 p-4">
            <Sidebar sidebarItems={sidebarItems}></Sidebar>
        </aside>
        <div className=" min-h-screen w-full rounded-l-4xl overflow-x-hidden">
          <main className="flex-1 p-6 ml-8">
            <Outlet /> 
          </main>
        </div>
        </div>
    );
};