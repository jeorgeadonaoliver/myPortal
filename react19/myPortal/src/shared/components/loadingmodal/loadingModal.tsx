import { useLoading } from "../../hooks/useLoading";
import apexLogo from "../../../assets/icon2.png";

export default function LoadingModal({message}: {message?: string}) {

  const { isLoading } = useLoading();
  if (!isLoading) return null;

  return (

     <div className="fixed inset-0 z-[9999] flex items-center justify-center">
      <div className="fixed inset-0 bg-neutral-900 opacity-40"></div>      
      <div className="p-6 rounded-xl flex flex-col items-center z-10">
        <div className="loading-container">
          <img
            src={apexLogo}
            alt="Loading..."
            className="loading-icon-pulse"
            style={{ width: '100px', height: '100px' }}
          />
        </div>
        <p className="text-white text-md mt-4">{message || 'Loading...'}</p>
      </div>
    </div>
  );
};