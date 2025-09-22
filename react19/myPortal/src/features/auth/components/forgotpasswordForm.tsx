import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useLoading } from "../../../shared/hooks/useLoading";
import { useAuth } from "../hooks/useAuth";

export default function ForgotPasswordForm()
{
    const navigate = useNavigate();
    const {setIsLoading} = useLoading();
    const { forgotpassword } = useAuth();

    const[email, setEmail] = useState("");
    const[clicked, setClicked] = useState(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setIsLoading(true);
        setClicked(true);

        try
        {
            await forgotpassword(email);
            setIsLoading(false);
            toast.success("If this email is registered, a password reset link has been sent.");
            navigate("/login");
        }
        catch(error)
        {
            console.error("Error in sending password reset email:", error);
            toast.error("Failed to send password reset email. Please try again.");
            setIsLoading(false);
            setClicked(false);
        }
    }

    return(
        <>
            <form 
            onSubmit={handleSubmit}
            className="mt-6 space-y-4">
            <div className="mb-4">
                <label className="block text-gray-300 font-semibold mb-3" htmlFor="otp">
                    To continue, please enter a valid email address below.
                </label>
              <input
                className="w-full px-4 py-2 rounded-2xl bg-neutral-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-white"
                id="email"
                type="text"
                onChange={(e) => setEmail(e.target.value)}
                placeholder="enter valid email address"
              />
            </div>          
            <div className="mb-4">
              <button
              className={`w-full bg-(--primary) text-white font-semibold py-2 px-4 rounded-2xl hover:bg-(--destructive) focus:outline-none focus:ring-2 focus:ring-(--primary-focus)
                  ${clicked ? 'pointer-events-none opacity-70' : ''}`} 
                type="submit"
                disabled={clicked}>
                { clicked ? 'Sending to email...' : 'Send Email Address'}
                </button>
            </div>
          </form>
        </>
    );
}