using SensorsProject.Models.Sensors;
using SensorsProject.Models.Terrorists;
using System;

namespace SensorsProject.Models.Player
{
    internal static class Player
    {
        public static void AttachSensor(Terrorist t) {
            int sensorLocation = SelectSensorLocation(t);
            SensorObj selectedSensor = SelectSensorToAttach();
            if (selectedSensor != null)
            {
                t.attachSensor(selectedSensor, sensorLocation);
            }

        }

        public static int SelectSensorLocation(Terrorist t) {
            int sensorListLen = t.getSensorListLen();
            Console.WriteLine($"In which location would you like to set the sensor?\n0-{sensorListLen-1}");
            int newSensorLocation = int.Parse(Console.ReadLine());
            while (newSensorLocation<0 || newSensorLocation > sensorListLen) { 
                Console.WriteLine($"Wrong input. In which location would you like to set the sensor?\n0-{sensorListLen-1}");
                newSensorLocation = int.Parse(Console.ReadLine());
            }
            return newSensorLocation;
        }


        public static SensorObj SelectSensorToAttach() {
            SensorObj[] sensorList = SensorManager.GetAllPossibleSensors();
            Console.WriteLine($"types to attach: ");
            SensorManager.GetSensorTypesStr();
            string sensorType = Console.ReadLine();
            SensorObj selectedSensor = null;
            foreach(SensorObj sensor in sensorList)
            {
                if(sensor.type == sensorType)
                {
                    selectedSensor = sensor;
                }
            }
            return selectedSensor;
        }
    }
}
