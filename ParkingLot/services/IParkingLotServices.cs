using ParkingLot.model;

namespace ParkingLot.services;

public interface IParkingLotServices
{
    int getMaxSlot();
    string createParkingLot(int totalSlot);
    string park(Vehicle vehicle);
    string leave(int slot);
    Dictionary<int, Vehicle> status();
    int getCountByVehicleType(String type);
    string getAllPlateVehiclesByPlateType(String plateType);
    string getAllCarByColour(String colour);
    string getAllSlotNumberByColour(String colour);
    string getSlotNumberByPlateNumber(String plateNumber);
}