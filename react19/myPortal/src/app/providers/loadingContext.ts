import { createContext } from "react";

interface LoadingContextValue {
    isLoading: boolean,
    setIsLoading: (_val: boolean) => void;
}

export const LoadingContext = createContext<LoadingContextValue | undefined>(undefined);