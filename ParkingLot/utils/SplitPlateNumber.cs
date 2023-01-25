namespace ParkingLot.utils;

public class SplitPlateNumber
{
    public static int plateNumber(String vehiclePlateNumber)
    {
        string[] temp = vehiclePlateNumber.Split("-");
        return int.Parse(temp[1]);
    }
}