import type { ReactNode } from "react";

type CardProps = {
    children: ReactNode;
    image?: ReactNode;
};

export default function Card({ children, image }: CardProps) {

    return (

        !image ? (

            <div className="p-6 rounded-4xl bg-(--card) border border-neutral-700">
                <div className="w-full p-8">
                    <div>
                        {children}
                    </div>
                </div>
            </div>
           
        )
        : (
             <div className="rounded-4xl bg-(--card) border border-neutral-700 flex flex-col gap-2">
                <div className="flex overflow-hidden w-full">
                    <div className="hidden lg:block lg:w-1/2 bg-cover">
                        {image}
                    </div>
                    <div className="w-full p-8 lg:w-1/2">
                    <div>
                        {children}
                    </div>
                </div>
                </div>
            </div>
        )

    );
}