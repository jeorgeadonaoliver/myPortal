//import { useState } from "react";

export default function LoginForm()
{
    // const { login, user } = useAuth();
    // const navigate = useNavigate();

    // const [email, setEmail] = useState("");
    // const [password, setPassword] = useState("");
    //const [error, setError] = useState<string | null>(null);
    //const [loading, setLoading] = useState(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        //setError(null);
        //setLoading(true);

        // try {
        // await login(email, password);
        //     navigate("/home/dashboard"); // redirect after success
        // } 
        // catch (err: any) {
        //     setError(err.message);
        // } 
        // finally 
        // {
        //     setLoading(false);
        // }
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
                placeholder="enter password"
              />
            </div>
            <div className="mb-4">
              <button
              className="w-full bg-(--primary) text-white font-semibold py-2 px-4 rounded-2xl hover:bg-(--destructive) focus:outline-none focus:ring-2 focus:ring-(--primary-focus)" 
                type="submit">Login</button>
            </div>
          </form>
    )  
};