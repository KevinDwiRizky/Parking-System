public class Vehicle
{
    public string RegistrationNumber { get; }
    public string Colour { get; }
    public VehicleType Type { get; }
    public int ParkingSlotNumber { get; set; }

    public Vehicle(string registrationNumber, string colour, VehicleType type)
    {
        RegistrationNumber = registrationNumber;
        Colour = colour;
        Type = type;
    }
}

public enum VehicleType
{
    Car,
    Motor
}