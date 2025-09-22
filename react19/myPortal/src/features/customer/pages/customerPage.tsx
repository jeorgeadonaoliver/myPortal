import Card from "../../../shared/components/card/card";
import CardBody from "../../../shared/components/card/cardbody";
import CardDescription from "../../../shared/components/card/carddescription";
import CardHeader from "../../../shared/components/card/cardheader";
import CardTitle from "../../../shared/components/card/cardtitle";

export default function CustomerPage()
{

const people = [
  { name: 'Olivia Martin', email: 'm@example.com' },
  { name: 'Isabella Nguyen', email: 'b@example.com' },
  { name: 'Sofia Davis', email: 'p@example.com' },
  { name: 'Ethan Thompson', email: 'e@example.com' },
];

    return(
        <>
    <div className="grid grid-cols-4 grid-rows-3 gap-4 h-full w-full">
            <div className="col-span-3 w-full h-full">
                <div>
                <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="User Directory Page" />
                                <CardDescription description="The user management page provides a complete list of all active users. Use this page to add new users, update existing profiles, or remove access." />
                                <br></br>
                                <div className="h-px w-full bg-white/40 transform -translate-y-1/2"></div>
                                <CardBody>

                                    <br></br>
                                    <h2 className="text-lg font-semibold text-white">People with access</h2>
                                    <br></br>
                                    <div className="w-full text-white space-y-6">
                                        {people.map((person, idx) => (
                                            <div key={idx} className="flex items-center justify-between hover:bg-amber-700">
                                            <div className="flex items-center space-x-3">
                                                {/* Placeholder avatar */}
                                                <div className="w-10 h-10 rounded-full bg-gray-700 flex items-center justify-center text-sm font-bold">
                                                {person.name.charAt(0)}
                                                </div>
                                                <div>
                                                <div className="font-medium">{person.name}</div>
                                                <div className="text-sm text-gray-400">{person.email}</div>
                                                </div>
                                            </div>
                                            <div>
                                                <button className="bg-gray-800 text-white text-sm px-3 py-1 rounded-md flex items-center space-x-1 hover:bg-gray-700">
                                                <span>Can edit</span>
                                                <svg className="w-4 h-4" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24">
                                                    <path strokeLinecap="round" strokeLinejoin="round" d="M19 9l-7 7-7-7" />
                                                </svg>
                                                </button>
                                            </div>
                                            </div>
                                        ))}
                                        </div>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
                </div>
            </div>
        </div>
        </>
    );
}