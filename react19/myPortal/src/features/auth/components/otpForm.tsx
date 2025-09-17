import { useEffect, useState } from "react";
import { useAuth } from "../hooks/useAuth";
import { verifyOTP, type AuthType } from "../services/authService";
import { multiFactor } from "firebase/auth";

export default function OtpForm()
{
    const [otp, setOtp] = useState("");
    const { user } = useAuth();

    useEffect(() => {
         const getMfaSession = async () => {
         
        if (user) {
            try {
                const mfaSession = await multiFactor(user).getSession();
                console.log("MFA Session:", mfaSession);
                // You can store this session in state or context if needed
            } catch (error) 
            {
                console.error("Failed to get MFA session:", error);
            }
        }
    };
        getMfaSession();
    }, [user]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const authType : AuthType = {
            uid: user?.uid || "",
            otp: otp
        };
        
        await verifyOTP(authType);
        console.log("OTP submitted:", otp);
    }

    return(
        <>
          <form 
            onSubmit={handleSubmit}
            className="mt-6 space-y-4">
            <div className="mb-4">
                <label className="block text-gray-300 font-semibold mb-3" htmlFor="otp">
                    This OTP is valid for 2 minutes. Please do not share this code with anyone.
                </label>
              <input
                className="w-full px-4 py-2 rounded-2xl bg-neutral-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-white"
                id="otp"
                type="text"
                onChange={(e) => setOtp(e.target.value)}
                placeholder="enter your OTP code"
              />
            </div>          
            <div className="mb-4">
              <button
              className="w-full bg-(--primary) text-white font-semibold py-2 px-4 rounded-2xl hover:bg-(--destructive) focus:outline-none focus:ring-2 focus:ring-(--primary-focus)" 
                type="submit">Send OTP Code</button>
            </div>
          </form>
        </>
    );
}