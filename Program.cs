using System;

public class Program
{
    private static ParkingLot parkingLot = null;
    private static ReportGenerator reportGenerator = new ReportGenerator();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(command))
            {
                continue;
            }

            string[] tokens = command.Split(' ');
            string action = tokens[0].ToLower();

            switch (action)
            {
                case "create_parking_lot":
                    int capacity = int.Parse(tokens[1]);
                    parkingLot = new ParkingLot(capacity);
                    Console.WriteLine($"Created a parking lot with {capacity} slots");
                    break;
                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    string registrationNumber = tokens[1];
                    string colour = tokens[2];
                    VehicleType type = tokens[3].Equals("mobil", StringComparison.OrdinalIgnoreCase) ? VehicleType.Car : VehicleType.Motor;
                    Vehicle vehicle = new Vehicle(registrationNumber, colour, type);
                    parkingLot.ParkVehicle(vehicle);
                    break;
                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    string slotToLeave = tokens[1];
                    parkingLot.RemoveVehicleBySlotNumber(int.Parse(slotToLeave));
                    break;
                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    reportGenerator.GenerateReport(parkingLot.Vehicles);
                    break;
                case "type_of_vehicles":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    string typeToCount = tokens[1];
                    reportGenerator.CountVehiclesByType(parkingLot.Vehicles, typeToCount);
                    break;
                case "registration_numbers_for_vehicles_with_ood_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    reportGenerator.FindVehiclesWithOddPlate(parkingLot.Vehicles);
                    break;
                case "registration_numbers_for_vehicles_with_event_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    reportGenerator.FindVehiclesWithEvenPlate(parkingLot.Vehicles);
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    string colourToFind = tokens[1];
                    reportGenerator.FindVehiclesByColour(parkingLot.Vehicles, colourToFind);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    string colourForSlot = tokens[1];
                    reportGenerator.FindSlotsByColour(parkingLot.Vehicles, colourForSlot);
                    break;
                case "slot_number_for_registration_number":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                        break;
                    }
                    string registrationNumberForSlot = tokens[1];
                    reportGenerator.FindSlotByRegistrationNumber(parkingLot.Vehicles, registrationNumberForSlot);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
