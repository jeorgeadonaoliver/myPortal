import { Outlet } from "react-router-dom";
import Footerbar from "../components/footer/footerbar";

export default function AuthLayout() {
  return (
    <>
      <div className="flex flex-col items-center justify-center min-h-screen bg-(--background)">
        <Outlet />
        <footer className="mt-40 w-full">
          <Footerbar />
        </footer>
      </div>
    </>
  );
}