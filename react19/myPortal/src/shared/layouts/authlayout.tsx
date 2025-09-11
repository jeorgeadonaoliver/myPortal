import { Outlet } from "react-router-dom";
import Footerbar from "../components/footer/footerbar";

export default function AuthLayout() {
  return (
    <>
      <div className="flex flex-col min-h-screen bg-(--background)">
        <main className="flex flex-grow items-center justify-center">
          <div className="w-full sm:max-w-xl md:max-w-2xl lg:max-w-4xl mx-auto">
            <Outlet />
          </div>
        </main>
        <footer className=" w-full">
          <Footerbar />
        </footer>
      </div>
    </>
  );
}