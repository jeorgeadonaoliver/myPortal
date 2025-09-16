import { useState } from "react";
import { useAuth } from "../hooks/useAuth";
import { useNavigate } from "react-router-dom";

export default function LoginForm()
{
    const { login } = useAuth();
    const navigate = useNavigate();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [disabled, setDisabled] = useState(false);
    const [clicked, setClicked] = useState(false);

    //const [error, setError] = useState<string | null>(null);
    //const [loading, setLoading] = useState(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        //setError(null);
        //setLoading(true);

        setClicked(true);
        setDisabled(true);

         try {
          await login(email, password);
          navigate("/otp"); // redirect after success

         } 
         catch (err) {
              console.error("Login failed:", err);
              setClicked(false);
              setDisabled(false);
         } 

        console.log("Login attempted with:", { email, password });
    };

    return(
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
    )  
};