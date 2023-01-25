using ParkingLot.model;
using ParkingLot.repository;

namespace ParkingLot.services;

public class ParkingLotServices : IParkingLotServices
{
    private IParkingLotRepository iParkingLotRepository;

    public ParkingLotServices(IParkingLotRepository iParkingLotRepository)
    {
        this.iParkingLotRepository = iParkingLotRepository;
    }

    public int getMaxSlot()
    {
        return iParkingLotRepository.getMaxSlot();
    }

    public string createParkingLot(int totalSlot)
    {
        int result = iParkingLotRepository.createParkingLot(totalSlot);
        return "Created a parking lot with " + result + " slots\n";
    }

    public string park(Vehicle vehicle)
    {
        int result = iParkingLotRepository.add(vehicle);

        if (result != 0)
        {
            return "Allocated slot number: " + result + "\n";
        }
        else
        {
            return "Sorry, parking lot is full\n";
        }
    }

    public string leave(int slot)
    {
        bool result = iParkingLotRepository.delete(slot);

        if (result)
        {
            return "Slot number " + slot + " is free\n";
        }
        else
        {
            return "Slot number " + slot + " is not found\n";
        }
    }

    public Dictionary<int, Vehicle> status()
    {
        return iParkingLotRepository.getAll();
    }

    public int getCountByVehicleType(string type)
    {
        return iParkingLotRepository.getCountByVehicleType(type);
    }

    public string getAllPlateVehiclesByPlateType(string plateType)
    {
        List<Vehicle> result = iParkingLotRepository.getAllPlateVehiclesByPlateType(plateType);
        
        if (result.Count > 0)
        {
            string plateResult = "";

            foreach (var vehicle in result)
            {
                plateResult += vehicle.GetNumber + ", ";
            }

            return plateResult.Remove(plateResult.Length - 2, 1) + "\n";
        }
        else
        {
            return "Registration numbers for vehicles with " + plateType + " plate is not found!\n";
        }
    }

    public string getAllCarByColour(string colour)
    {
        List<Vehicle> result = iParkingLotRepository.getAllCarByColour(colour);

        if (result.Count > 0)
        {
            string plateResult = "";

            foreach (var vehicle in result)
            {
                plateResult += vehicle.GetNumber + ", ";
            }

            return plateResult.Remove(plateResult.Length - 2, 1) + "\n";
        }
        else
        {
            return "Registration numbers for vehicles with colour " + colour + "is not found!\n";
        }
    }

    public string getAllSlotNumberByColour(string colour)
    {
        List<int> result = iParkingLotRepository.getAllSlotNumberByColour(colour);

        if (result.Count > 0)
        {
            string slotsNumberResult = "";

            foreach (var slotNumber in result)
            {
                slotsNumberResult += slotNumber + ", ";
            }

            return slotsNumberResult.Remove(slotsNumberResult.Length - 2, 1) + "\n";
        }
        else
        {
            return "Slot numbers for vehicles with colour " + colour + "is not found!\n";
        }
    }

    public string getSlotNumberByPlateNumber(string plateNumber)
    {
        int result = iParkingLotRepository.getSlotNumberByPlateNumber(plateNumber);
        
        if (result != 0)
        {
            return result + "\n";
        }

        return "Not Found\n";
    }
}