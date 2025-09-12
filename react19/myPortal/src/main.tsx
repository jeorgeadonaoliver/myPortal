import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "./app.css"; 
import { AuthProvider } from './app/providers/authProvider.tsx'
import { AppRouter } from './app/router/AppRouter.tsx'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
      <AuthProvider>
        <AppRouter />
      </AuthProvider>
    </StrictMode>
)
