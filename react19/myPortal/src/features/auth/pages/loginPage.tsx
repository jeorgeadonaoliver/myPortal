import Card from "../../../shared/components/card/card";
import CardBody from "../../../shared/components/card/cardbody";
import CardDescription from "../../../shared/components/card/carddescription";
import CardHeader from "../../../shared/components/card/cardheader";
import CardTitle from "../../../shared/components/card/cardtitle";
import loginImage from "../../../assets/login-image.png"; 
import LoginForm from "../components/loginForm";

export default function LoginPage() {

    return (
    <div className="flex overflow-hidden mx-auto max-w-sm lg:max-w-4xl w-full">
      <Card 
      image={<img src={loginImage} alt="Login" className="w-full h-full object-cover rounded-l-4xl" />}
      >
        <CardHeader>
          <div className="flex flex-col gap-2">
            <CardTitle title="Login to your account" />
            <CardDescription description="Please enter your credentials to login." />
          </div>
        </CardHeader>

        <CardBody>
            <LoginForm />
        </CardBody>
      </Card>
    </div>

    );
}