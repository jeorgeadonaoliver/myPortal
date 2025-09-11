import { Outlet } from "react-router-dom";
import Sidebar from "../components/side-navbar/sidebar";
import { BiFile, BiLogoGmail, BiSolidBarChartAlt2, BiSolidHand, BiUser } from "react-icons/bi";
import { BsCCircleFill, BsFillGridFill, BsPeopleFill } from "react-icons/bs";

export default function MainLayout() {

    const sidebarItems = [
          { icon: <BsFillGridFill size="25" />, text: "Dash", index: 1, route: '/employees'},
          { icon: <BsPeopleFill size="25" />, text: "Group", index: 2, route:'/projects' },
          { icon: <BiUser size="25" />, text: "Users", index: 2, route:'/projects' },
          { icon: <BsCCircleFill size="25" />, text: "Custody", index: 3, route: '/teams'},
          { icon: <BiFile  size="25" />, text: "Reports", index: 4, route: '/departments'},
          { icon: <BiSolidBarChartAlt2 size="25" />, text: "Analytics", index: 5, route: '/departments'},
          { icon: <BiSolidHand   size="25" />, text: "Support", index: 6, route: '/departments'},
          { icon: <BiLogoGmail    size="25" />, text: "Tools", index: 7, route: '/departments'},]
          

 
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