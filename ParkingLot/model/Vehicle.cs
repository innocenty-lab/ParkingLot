namespace ParkingLot.model;

public class Vehicle
{
    private string Number;
    private string VehicleType;
    private string Color;

    public Vehicle(string number, string vehicleType, string color)
    {
        Number = number;
        VehicleType = vehicleType;
        Color = color;
    }

    public string GetNumber
    {
        get => Number;
        set => Number = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string GetVehicleType
    {
        get => VehicleType;
        set => VehicleType = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string GetColor
    {
        get => Color;
        set => Color = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return $"{nameof(Number)}: {Number}, {nameof(VehicleType)}: {VehicleType}, {nameof(Color)}: {Color}";
    }
}