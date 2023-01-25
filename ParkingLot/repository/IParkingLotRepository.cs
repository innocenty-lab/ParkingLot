using ParkingLot.model;

namespace ParkingLot.repository;

public interface IParkingLotRepository
{
    int getMaxSlot();
    int createParkingLot(int totalSlot);
    int add(Vehicle vehicle);
    bool delete(int slot);
    Dictionary<int, Vehicle> getAll();
    int getCountByVehicleType(String type);
    List<Vehicle> getAllPlateVehiclesByPlateType(String plateType);
    List<Vehicle> getAllCarByColour(String colour);
    List<int> getAllSlotNumberByColour(String colour);
    int getSlotNumberByPlateNumber(String plateNumber);
}