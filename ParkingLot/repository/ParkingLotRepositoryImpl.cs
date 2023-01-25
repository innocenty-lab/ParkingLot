using System.Collections;
using ParkingLot.model;
using ParkingLot.utils;

namespace ParkingLot.repository;

public class ParkingLotRepository : IParkingLotRepository
{
    private Dictionary<int, Vehicle> parkingLot = new Dictionary<int, Vehicle>();
    private int maxSlot = 0;

    public ParkingLotRepository()
    {
    }

    public int getMaxSlot()
    {
        return this.maxSlot;
    }

    public int createParkingLot(int totalSlot)
    {
        this.maxSlot = totalSlot;
        for (int i = 0; i < this.maxSlot; i++)
        {
            parkingLot.Add(i+1, null);
        }
        return getMaxSlot();
    }

    public int add(Vehicle vehicle)
    {
        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Value == null)
            {
                parkingLot[pair.Key] = vehicle;
                return pair.Key;
            }
        }
        return 0;
    }

    public bool delete(int slot)
    {
        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Key == slot)
            {
                parkingLot[pair.Key] = null;
                return true;
            }
        }
        return false;
    }

    public Dictionary<int, Vehicle> getAll()
    {
        Dictionary<int, Vehicle> vehicles = new Dictionary<int, Vehicle>();
        
        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Value != null)
            {
                vehicles.Add(pair.Key, pair.Value);
            }
        }

        return vehicles;
    }

    public int getCountByVehicleType(string type)
    {
        int countResult = 0;
        
        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Value.GetVehicleType.ToLower().Equals(type.ToLower()))
            {
                countResult += 1;
            }
        }

        return countResult;
    }

    public List<Vehicle> getAllPlateVehiclesByPlateType(string plateType)
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        switch (plateType)
        {
            case "odd":
                foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
                {
                    bool resultIdentify = IdentifyPlateNumber.IdentifyPlate(pair.Value.GetNumber, 1);

                    if (resultIdentify)
                    {
                        vehicles.Add(pair.Value);
                    }
                }
                break;
            case "event":
                foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
                {
                    bool resultIdentify = IdentifyPlateNumber.IdentifyPlate(pair.Value.GetNumber, 0);
                    if (resultIdentify)
                    {
                        vehicles.Add(pair.Value);
                    }
                }
                break;
        }

        return vehicles;
    }

    public List<Vehicle> getAllCarByColour(string colour)
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Value.GetColor.ToLower().Equals(colour.ToLower()))
            {
                vehicles.Add(pair.Value);
            }
        }

        return vehicles;
    }

    public List<int> getAllSlotNumberByColour(string colour)
    {
        List<int> slots = new List<int>();

        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Value.GetColor == colour)
            {
                slots.Add(pair.Key);
            }
        }

        return slots;
    }

    public int getSlotNumberByPlateNumber(string plateNumber)
    {
        int slots = 0;

        foreach (KeyValuePair<int, Vehicle> pair in parkingLot)
        {
            if (pair.Value.GetNumber.ToLower().Equals(plateNumber.ToLower()))
            {
                slots = pair.Key;
            }
        }

        return slots;
    }
}