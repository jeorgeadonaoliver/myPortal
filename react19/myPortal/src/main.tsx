import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "./app.css"; 
import { AuthProvider } from './app/providers/authProvider.tsx'
import { AppRouter } from './app/router/AppRouter.tsx'
import { ToastContainer } from 'react-toastify';


createRoot(document.getElementById('root')!).render(
    <StrictMode>
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
      </AuthProvider>
    </StrictMode>
)
