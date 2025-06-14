using System;

namespace SensorsProject.Models.Sensors
{
    internal static class SensorManager
    {

        public static string[] sensorTypes = { "basic", "thermal" };
        public static string allSensorTypes = "";
        
        public static void PrintSensorTypes() {
            string types = "";
            foreach (string type in sensorTypes) {
                types += $"{type} ";
            }
            allSensorTypes = types;
            Console.WriteLine($"types: {types}");
        }
        public static SensorObj[] GetAllPossibleSensors()
        {
            SensorObj[] sensorArr = new SensorObj[sensorTypes.Length];
            for(int i=0;i< sensorTypes.Length; i++)
            {
                SensorObj sensor = GetSpecificSensor(sensorTypes[i]);
                sensorArr[i] = sensor;
            }
            return sensorArr;
        }

        public static SensorObj GetSpecificSensor(string sensorType)
        {
            if (sensorType == "basic") return new BasicSensor();
            if (sensorType == "thermal") return new ThermalSensor();

            Console.WriteLine($"[Warning] Unknown sensor type: {sensorType}, defaulting to BasicSensor");
            return new BasicSensor();

        }

        public static SensorObj genRandSensorSingle() {
            Random rand = new Random();
            int randNum = rand.Next(sensorTypes.Length);
            string sensorType = sensorTypes[randNum];
            SensorObj newSensor = GetSpecificSensor(sensorType);
            return newSensor;
        }
        public static SensorObj[] GenRandSensors(int num)
        {
            SensorObj[] sensorsList = new SensorObj[num];
            int counter = 0; 
            while (counter < num)
            {
                SensorObj newSensor = genRandSensorSingle();
                while(newSensor == null)
                {
                    newSensor = genRandSensorSingle();

                }
                sensorsList[counter] = newSensor;
                counter += 1;
            }
            return sensorsList;
        }
    }

}
