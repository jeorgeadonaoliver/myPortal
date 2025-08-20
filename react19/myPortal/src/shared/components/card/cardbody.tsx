import type { ReactNode } from "react";

export default function CardBody({children}: {children: ReactNode}) {
    return (
        <div className="w-full p-3">
            {children}
        </div>
    );
}