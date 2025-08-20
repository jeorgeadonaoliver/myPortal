import Card from "../shared/components/card/card";
import CardBody from "../shared/components/card/cardbody";
import CardDescription from "../shared/components/card/carddescription";
import CardHeader from "../shared/components/card/cardheader";
import CardTitle from "../shared/components/card/cardtitle";
import dollar from "../../src/assets/dollar.jpg"; 
import trade from "../../src/assets/trade.jpg"; 

export default function Dashboard(){
    return (
        <div>
        <div className="grid grid-cols-4 grid-rows-3 gap-4 h-full w-full">
            <div className="col-span-2 w-full h-full">
                <div>
                <Card
                    image={<img src={dollar} alt="Login" className="w-[460px] h-[300px] object-cover rounded-l-4xl" />}
                >
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="Available Cash Balance" />
                                <CardDescription description="Available cash balance to invest." />
                                <CardBody>
                                    <p className="text-6xl text-amber-50">$12,000.00</p>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
                </div>
            </div>
            <div className="col-span-2 w-full h-full">
                <Card
                    image={<img src={trade} alt="trade" className="w-[460px] h-[300px] object-cover rounded-l-4xl" />}
                >
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="Trades" />
                                <CardDescription description="Summary of your Trades." />
                                <CardBody>
                                    <p className="text-7xl text-amber-50">0</p>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
            </div>
            <div className="grid col-span-1">
                <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="Cash" />
                                <CardDescription description="Available Cash to use" />
                                <CardBody>
                                    <p className="text-7xl text-amber-50">0</p>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
            </div>
            <div className="grid col-span-1">
                <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="FX" />
                                <CardDescription description="Available FX to use" />
                                <CardBody>
                                    <p className="text-7xl text-amber-50">0</p>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
            </div>
            <div className="grid col-span-1">
               <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="Managed Funds" />
                                <CardDescription description="Number of Managed Funds" />
                                <CardBody>
                                    <p className="text-7xl text-amber-50">0</p>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
            </div>
            <div className="grid col-span-1">
                <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="Private Assets" />
                                <CardDescription description="Number of private assets" />
                                <CardBody>
                                    <p className="text-7xl text-amber-50">0</p>
                                </CardBody>
                        </div>
                    </CardHeader>
                </Card>
            </div>
            <div className="grid col-span-2">
                <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="System Health" />
                                <CardDescription description="Monitoring different systyem's health." />
                        </div>
                    </CardHeader>
                </Card>
            </div>
            <div className="grid col-span-2">
                <Card>
                    <CardHeader>
                        <div className="flex flex-col gap-2">
                            <CardTitle title="Support Request" />
                                <CardDescription description="List of tickets you raised in support team." />
                        </div>
                    </CardHeader>
                </Card>
            </div>
            

            {/* Example grid items
            {Array.from({ length: 12 }).map((_, i) => (
            <div key={i} className="bg-[--card] border border-neutral-300 rounded-xl p-4 text-center">
                Item {i + 1}
            </div>
            ))} */}
        </div>
        </div>
    );
}