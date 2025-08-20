type CardTitleProps = {
    title: string;
};

export default function CardTitle({title}: CardTitleProps) {
    return (
        <div className="text-3xl font-bold text-gray-200">
            {title}
        </div>
    );
}