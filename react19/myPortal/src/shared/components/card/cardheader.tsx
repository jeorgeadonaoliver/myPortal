import type { ReactNode } from "react";

type CardHeaderProps = {
    children: ReactNode;
    className?: string;
}

export default function CardHeader({children, className}: CardHeaderProps) {
    return (
        <div className={`justify-between items-center w-full ${className}`}>
            {children}
        </div>
    );
}