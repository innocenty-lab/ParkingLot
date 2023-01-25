namespace ParkingLot.utils;

public class IdentifyPlateNumber
{
    public static bool IdentifyPlate(string vehiclePlateNumber, int modResult)
    {
        int resultNumber = SplitPlateNumber.plateNumber(vehiclePlateNumber);

        if (resultNumber%2 == modResult)
        {
            return true;
        }

        return false;
    }
}