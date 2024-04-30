using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    private readonly int _capacity;
    private List<Vehicle> _vehicles;

    public ParkingLot(int capacity)
    {
        _capacity = capacity;
        _vehicles = new List<Vehicle>();
    }

    public int Capacity => _capacity;

    public int OccupiedSlotsCount => _vehicles.Count;

    public int AvailableSlotsCount => _capacity - OccupiedSlotsCount;

    public List<Vehicle> Vehicles => _vehicles;

    public void ParkVehicle(Vehicle vehicle)
    {
        if (AvailableSlotsCount > 0)
        {
            _vehicles.Add(vehicle);
            vehicle.ParkingSlotNumber = _vehicles.Count;
            Console.WriteLine($"Allocated slot number: {vehicle.ParkingSlotNumber}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void RemoveVehicle(string registrationNumber)
    {
        var vehicleToRemove = _vehicles.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
        if (vehicleToRemove != null)
        {
            _vehicles.Remove(vehicleToRemove);
            Console.WriteLine($"Slot number {vehicleToRemove.ParkingSlotNumber} is free");
        }
        else
        {
            Console.WriteLine($"Vehicle with registration number {registrationNumber} not found in parking lot");
        }
    }

    internal void RemoveVehicleBySlotNumber(int slotNumber)
    {
        var vehicleToRemove = _vehicles.FirstOrDefault(v => v.ParkingSlotNumber == slotNumber);
        if (vehicleToRemove != null)
        {
            _vehicles.Remove(vehicleToRemove);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine($"No vehicle found in slot number {slotNumber}");
        }
    }
}