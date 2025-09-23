import Card from "../../../shared/components/card/card";
import CardBody from "../../../shared/components/card/cardbody";
import CardDescription from "../../../shared/components/card/carddescription";
import CardHeader from "../../../shared/components/card/cardheader";
import CardTitle from "../../../shared/components/card/cardtitle";
import { TiUserAdd } from "react-icons/ti";

export default function CustomerPage()
{

    const people = [
        { name: 'Olivia Martin', email: 'm@example.com', status: 'Active' },
        { name: 'Isabella Nguyen', email: 'b@example.com', status: 'Inactive' },
        { name: 'Sofia Davis', email: 'p@example.com', status: 'Active' },
        { name: 'Ethan Thompson', email: 'e@example.com', status: 'Inactive' },
    ];

    return(
        <>
    <div className="grid grid-cols-4 gap-4 h-full w-full">
            <div className="col-span-3 w-full h-full">
                <div>
                <Card>
                    <CardHeader>
                        <CardTitle title="User Directory Page" />
                            <CardDescription description="The user management page provides a complete list of all active users. Use this page to add new users, update existing profiles, or remove access." />
                    </CardHeader>
                    <br></br>
                    <div className="h-px w-full bg-white/40 transform -translate-y-1/2"></div>
                        <CardBody>
                            <div className="flex flex-col gap-2">
                                <br></br>
                                    <div className="flex items-center justify-between">
                                        <h2 className="text-lg font-semibold text-white">People with access</h2>
                                        <button className=" hover:bg-(--primary) text-white font-bold py-2 px-4 rounded-xl inline-flex items-center">
                                            <TiUserAdd size="23" />
                                            <span className="text-md font-semibold text-white ml-2">Add User</span>
                                        </button>
                                    </div>
                                    <br></br>
                                    <div className="w-full text-white space-y-6">
                                        {people.map((person, idx) => (
                                            <div key={idx} className="flex items-center justify-between hover:bg-neutral-700 rounded-3xl">
                                                <div className="flex items-center space-x-3">
                                                    {/* Placeholder avatar */}
                                                    <div className="w-13 h-13 rounded-full bg-neutral-700 flex items-center justify-center text-sm font-bold">
                                                    {person.name.charAt(0)}
                                                    </div>
                                                    <div>
                                                        <div className="font-medium">{person.name}</div>
                                                        <div className="text-sm text-gray-400">{person.email}</div>
                                                        
                                                    </div>
                                                    </div>
                                                    <div className="h-full flex items-center space-x-3">
                                                        {/* The status label */}
                                                        <div className="text-sm font-medium text-gray-400">
                                                            {person.status === 'Active' ? 'Active' : 'Inactive'}
                                                        </div>
                                                        <button  className={`w-12 h-6 flex items-center rounded-full p-1 cursor-pointer 
                                                            ${person.status === 'Active' ? 'bg-green-500' : 'bg-gray-500'}`}>
                                                            <div className={`w-4 h-4 bg-white rounded-full shadow-md transform duration-300 ease-in-out ${person.status === 'Active' ? 'translate-x-6' : 'translate-x-0'}`}></div>
                                                        </button>
                                                    </div>
                                                </div>
                                            ))}
                                    </div>
                            </div>               
                        </CardBody>
                </Card>
                </div>
            </div>
        </div>
        </>
    );
}