import Card from "../../../shared/components/card/card";
import CardBody from "../../../shared/components/card/cardbody";
import CardDescription from "../../../shared/components/card/carddescription";
import CardHeader from "../../../shared/components/card/cardheader";
import CardTitle from "../../../shared/components/card/cardtitle";
import loginImage from "../../../assets/login-image.png"; 

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
          <form className="mt-6 space-y-4">
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
        </CardBody>
      </Card>
</div>

    );
}