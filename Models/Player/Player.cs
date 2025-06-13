using SensorsProject.Models.Sensors;
using SensorsProject.Models.Terrorists;
using System;

namespace SensorsProject.Models.Players
{
    internal static class Player
    {
        public static void AttachSensor(Terrorist t)
        {
            //Console.WriteLine("[Player] AttachSensor - Start");

            int sensorLocation = SelectSensorLocation(t);
            //Console.WriteLine($"sensorLocation: {sensorLocation}");
            SensorObj selectedSensor = SelectSensorToAttach();
            //Console.WriteLine($"selectedSensor: {selectedSensor.type}");
            if (selectedSensor == null)
            {
                //Console.WriteLine("[Player] Invalid sensor type. No sensor attached.");
                return;
            }

            //Console.WriteLine($"[Player] Attached sensor of type {selectedSensor.type} to location {sensorLocation}.");
            t.attachSensor(selectedSensor, sensorLocation);

            //Console.WriteLine("[Player] AttachSensor - End");
        }

        public static int SelectSensorLocation(Terrorist t)
        {
            int sensorListLen = t.getSensorListLen();
            Console.WriteLine($"In which location would you like to set the sensor? (0 - {sensorListLen - 1})");
            int newSensorLocation;
            while (!int.TryParse(Console.ReadLine(), out newSensorLocation) ||
                   newSensorLocation < 0 || newSensorLocation >= sensorListLen)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 0 and {sensorListLen - 1}.");
            }

            return newSensorLocation;
        }

        public static SensorObj SelectSensorToAttach()
        {
            while (true)
            {
                Console.WriteLine("Available sensor types:");
                SensorManager.PrintSensorTypes();

                Console.Write("Enter sensor type: ");
                string sensorType = Console.ReadLine()?.Trim().ToLower();

                switch (sensorType)
                {
                    case "basic":
                        return new BasicSensor();
                    case "thermal":
                        return new ThermalSensor();
                    default:
                        Console.WriteLine($"[Error] '{sensorType}' is not a valid sensor type. Please try again.\n");
                        break;
                }
            }
        }

    }
}
