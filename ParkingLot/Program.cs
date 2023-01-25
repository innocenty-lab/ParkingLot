using ParkingLot.model;
using ParkingLot.repository;
using ParkingLot.services;

public class Program
{
    public static void Main(string[] args)
    {
        IParkingLotRepository iParkingLotRepository = new ParkingLotRepository();
        IParkingLotServices iParkingLotServices = new ParkingLotServices(iParkingLotRepository);
        
        while (true)
        {
            try
            {
                Console.Write("$ ");
                string[] input = Console.ReadLine().Split(" ");

                if (iParkingLotServices.getMaxSlot() <= 0)
                {
                    switch (input[0])
                    {
                        case "create_parking_lot":
                            if (int.Parse(input[1]) <= 0)
                            {
                                Console.WriteLine("Total parking slots must be more than 0!\n");
                            }
                            else
                            {
                                Console.WriteLine(iParkingLotServices.createParkingLot(int.Parse(input[1])));    
                            }
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine("Action Menu Not Found! Determine in advance the total parking slot!\n");
                            break;
                    }
                }
                else
                {
                    switch (input[0])
                    {
                        case "park":
                            Vehicle vehicle = new Vehicle(input[1], input[3], input[2]);
                            Console.WriteLine(iParkingLotServices.park(vehicle));
                            break;
                        case "leave":
                            Console.WriteLine(iParkingLotServices.leave(int.Parse(input[1])));
                            break;
                        case "status":
                            var resultStatus = iParkingLotServices.status();
                            Console.WriteLine("Slot\t" + "No.\t\t" + "Type\t\t" + "Registration No Colour\t");
                            foreach (KeyValuePair<int, Vehicle> pair in resultStatus)
                            {
                                Console.WriteLine(pair.Key + "\t" + pair.Value.GetNumber + "\t" + pair.Value.GetVehicleType + "\t\t" + pair.Value.GetColor);
                            }
                            Console.WriteLine();
                            break;
                        case "type_of_vehicles":
                            Console.WriteLine(iParkingLotServices.getCountByVehicleType(input[1] + "\n"));
                            break;
                        case "registration_numbers_for_vehicles_with_ood_plate":
                            Console.WriteLine(iParkingLotServices.getAllPlateVehiclesByPlateType("odd"));
                            break;
                        case "registration_numbers_for_vehicles_with_event_plate":
                            Console.WriteLine(iParkingLotServices.getAllPlateVehiclesByPlateType("event"));
                            break;
                        case "registration_numbers_for_vehicles_with_colour":
                            Console.WriteLine(iParkingLotServices.getAllCarByColour(input[1]));
                            break;
                        case "slot_numbers_for_vehicles_with_colour":
                            Console.WriteLine(iParkingLotServices.getAllSlotNumberByColour(input[1]));
                            break;
                        case "slot_number_for_registration_number":
                            Console.WriteLine(iParkingLotServices.getSlotNumberByPlateNumber(input[1]));
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine("Action Menu Not Found!\n");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect command format, Repeat command correctly!\n");
            }
        }
    }
}