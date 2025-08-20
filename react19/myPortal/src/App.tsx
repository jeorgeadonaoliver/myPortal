import './App.css'
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom'
import AuthLayout from './shared/layouts/authlayout'
import LoginPage from './pages/auth/login'
import Dashboard from './pages/dashboard'
import { ToastContainer } from 'react-toastify'
import MainLayout from './shared/layouts/mainlayout'
import OtpPage from './pages/auth/otp'

function App() {
  return (
    <>
    <Router>
      <Routes>
          <Route path="" element={<AuthLayout/>}>
            <Route path='/login' element={<LoginPage />} />
            <Route path='/otp' element={<OtpPage />} />
          </Route>
          <Route path="/home" element={<MainLayout />}>
            <Route path='dashboard' element={<Dashboard />} />
          </Route>
      </Routes>
    </Router>
    <ToastContainer
        position="bottom-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
    </>
  )
}

export default App
