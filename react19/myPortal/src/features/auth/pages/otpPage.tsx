import Card from "../../../shared/components/card/card";
import loginImage from "../../../assets/login-image.png"; 
import CardHeader from "../../../shared/components/card/cardheader";
import CardTitle from "../../../shared/components/card/cardtitle";
import CardDescription from "../../../shared/components/card/carddescription";
import CardBody from "../../../shared/components/card/cardbody";
import OtpForm from "../components/otpForm";

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
         <OtpForm />
        </CardBody>
      </Card>
    </div>
         
    );
}