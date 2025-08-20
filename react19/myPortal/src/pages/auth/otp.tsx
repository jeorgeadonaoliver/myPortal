import Card from "../../shared/components/card/card";
import loginImage from "../../assets/login-image.png"; 
import CardHeader from "../../shared/components/card/cardheader";
import CardTitle from "../../shared/components/card/cardtitle";
import CardDescription from "../../shared/components/card/carddescription";
import CardBody from "../../shared/components/card/cardbody";

export default function OtpPage() {
    
    return (
        <div className="flex overflow-hidden mx-auto max-w-sm lg:max-w-4xl w-full">
      <Card 
      image={<img src={loginImage} alt="Login" className="w-full h-full object-cover rounded-l-4xl" />}
      >
        <CardHeader>
          <div className="flex flex-col gap-2">
            <CardTitle title="Your OTP Code" />
            <CardDescription description="Your One-Time Password(OTP) was sent to you." />
          </div>
        </CardHeader>

        <CardBody>
          <form className="mt-6 space-y-4">
            <div className="mb-4">
                <label className="block text-gray-300 font-semibold mb-3" htmlFor="email">
                    This OTP is valid for 2 minutes. Please do not share this code with anyone.
                </label>
              <input
                className="w-full px-4 py-2 rounded-2xl bg-neutral-800 text-white border border-gray-600 focus:outline-none focus:ring-2 focus:ring-white"
                id="otp"
                type="text"
                placeholder="enter your OTP code"
              />
            </div>          
            <div className="mb-4">
              <button
              className="w-full bg-(--primary) text-white font-semibold py-2 px-4 rounded-2xl hover:bg-(--destructive) focus:outline-none focus:ring-2 focus:ring-(--primary-focus)" 
                type="submit">Send OTP Code</button>
            </div>
          </form>
        </CardBody>
      </Card>
</div>
         
    );
}