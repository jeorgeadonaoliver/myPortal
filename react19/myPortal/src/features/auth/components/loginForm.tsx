import { useState } from "react";
import { useAuth } from "../hooks/useAuth";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useLoading } from "../../../shared/hooks/useLoading";

export default function LoginForm()
{
    const { login } = useAuth();
    const { setIsLoading } = useLoading();
    const navigate = useNavigate();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [disabled, setDisabled] = useState(false);
    const [clicked, setClicked] = useState(false);

    //const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setIsLoading(true);
        setClicked(true);
        setDisabled(true);

        try 
        {
          const result = await login(email, password);
          console.log("Login successful:", result);
           
          if(result)
          navigate("/otp"); // redirect after success
          setIsLoading(false);
             
        } 
         catch (err) {
            toast.error("Login failed. Please check your credentials and try again.");
            console.error("Login error:", err);
            setClicked(false);
            setDisabled(false);
            setIsLoading(false);
         } 

        console.log("Login attempted with:", { email, password });
    };

    return(
      <>
         <form 
         onSubmit={handleSubmit}
         className="mt-6 space-y-4">
            <div className="mb-4">
              <label className="block text-gray-300 font-semibold mb-3" htmlFor="email">
                Email:
              </label>
              <input
                className="w-full px-4 py-2 rounded-2xl bg-neutral-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-white"
                id="email"
                type="email"
                value={email}
                disabled={disabled}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="enter email address"
              />
            </div>
            <div className="mb-4">
              <label className="block text-gray-300 font-semibold mb-3" htmlFor="password">
                Password:
              </label>
              <input
                className="w-full px-4 py-2 rounded-2xl bg-neutral-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-white"
                id="password"
                type="password"
                value={password}
                disabled={disabled}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="enter password"
              />
            </div>
            <div className="mb-4 text-right">
                <a onClick={() => navigate("/forgotpassword")} className="text-md font-semibold text-amber-50 transition-colors duration-300 hover:text-amber-700">
                  Forgot password?
                </a>
            </div>
            <div className="mb-4">
              <button
                className={`w-full bg-(--primary) text-white font-semibold py-2 px-4 rounded-2xl hover:bg-(--destructive) focus:outline-none focus:ring-2 focus:ring-(--primary-focus)
                  ${clicked ? 'pointer-events-none opacity-70' : ''}`} 
                  type="submit"
                  disabled={clicked}
                >
                  {clicked ? 'Logging in...' : 'Login'}
                </button>
            </div>
          </form>
      </>
    )  
};