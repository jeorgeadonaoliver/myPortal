import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "./app.css"; 
import { AuthProvider } from './app/providers/authProvider.tsx'
import { AppRouter } from './app/router/AppRouter.tsx'
import { ToastContainer } from 'react-toastify';
import { LoadingProvider } from './app/providers/loadingProvider.tsx';
import LoadingModal from './shared/components/loadingmodal/loadingModal.tsx';


createRoot(document.getElementById('root')!).render(
    <StrictMode>
      <LoadingProvider>
        <AuthProvider>
         <ToastContainer
            position="top-right"
            autoClose={50000}
            hideProgressBar={false}
            newestOnTop={false}
            closeOnClick
            rtl={false}
            pauseOnFocusLoss
            draggable
            pauseOnHover
            />
            <AppRouter />
            <LoadingModal/>
        </AuthProvider>
      </LoadingProvider>
    </StrictMode>
)
