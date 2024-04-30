using System;
using System.Collections.Generic;
using System.Linq;

public class ReportGenerator
{
    public void GenerateReport(List<Vehicle> vehicles)
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"{vehicle.ParkingSlotNumber}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Colour}");
        }
    }

    public void CountVehiclesByType(List<Vehicle> vehicles, string typeToCount)
    {
        VehicleType type = typeToCount.Equals("mobil", StringComparison.OrdinalIgnoreCase) ? VehicleType.Car : VehicleType.Motor;
        int count = vehicles.Count(v => v.Type == type);
        Console.WriteLine(count);
    }

    public void FindSlotByRegistrationNumber(List<Vehicle> vehicles, string registrationNumberForSlot)
    {
        var vehicle = vehicles.FirstOrDefault(v => v.RegistrationNumber == registrationNumberForSlot);
        if (vehicle != null)
        {
            Console.WriteLine(vehicle.ParkingSlotNumber);
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    public void FindSlotsByColour(List<Vehicle> vehicles, string colourForSlot)
    {
        var slots = vehicles.Where(v => v.Colour.Equals(colourForSlot, StringComparison.OrdinalIgnoreCase))
        .Select(v => v.ParkingSlotNumber);
        Console.WriteLine(string.Join(", ", slots));
    }

    public void FindVehiclesByColour(List<Vehicle> vehicles, string colourToFind)
    {
        var vehiclesByColour = vehicles.Where(v => v.Colour.Equals(colourToFind, StringComparison.OrdinalIgnoreCase))
        .Select(v => v.RegistrationNumber);
        Console.WriteLine(string.Join(", ", vehiclesByColour));
    }

    public void FindVehiclesWithEvenPlate(List<Vehicle> vehicles)
    {
        var vehiclesWithEvenPlate = vehicles.Where(v => IsEvenPlate(v.RegistrationNumber));
        Console.WriteLine(string.Join(", ", vehiclesWithEvenPlate.Select(v => v.RegistrationNumber)));
    }

    public void FindVehiclesWithOddPlate(List<Vehicle> vehicles)
    {
        var vehiclesWithOddPlate = vehicles.Where(v => !IsEvenPlate(v.RegistrationNumber));
        Console.WriteLine(string.Join(", ", vehiclesWithOddPlate.Select(v => v.RegistrationNumber)));
    }

    private bool IsEvenPlate(string registrationNumber)
    {
        string digitsOnly = new string(registrationNumber.Where(char.IsDigit).ToArray());

        if (!string.IsNullOrEmpty(digitsOnly))
        {
            int lastDigit = int.Parse(digitsOnly[digitsOnly.Length - 1].ToString());

            return lastDigit % 2 == 0;
        }
        
        return false;
    }

}
