type CardDescriptionProps = {
   description: string;
};

export default function CardDescription({description}: CardDescriptionProps) {

    return (
        <div className="text-gray-500 text-lg mt-2">
            {description}
        </div>
    );
}