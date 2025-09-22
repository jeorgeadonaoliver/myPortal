
type SideBarIconProps = {
    icon: React.ReactNode;
    text: string;
    isActive: boolean;
    onClick : () => void;
};

export default function SidebarIcon({ icon, text, isActive, onClick }: SideBarIconProps) {
    return (
      <div>
        <div
          onClick={onClick}
          className={`relative flex flex-col items-center justify-center
          h-15 w-16 mt-1.5 mb-0 mx-auto hover:-translate-y-1 hover:scale-110
            ${isActive ? 'bg-amber-700 text-amber-50 rounded-xl' : 'bg-(--card) text-gray-400 hover:bg-(--primary) hover:text-white rounded-xl'}`}>
          <div>{icon}</div>
          <span className="text-[12px] text-amber-50 mt-2">{text}</span>
        </div>
      </div>
    
  );
};