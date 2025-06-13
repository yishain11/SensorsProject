using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsProject.Models.Sensors
{
    internal static class SensorManager
    {

        public static string[] sensorTypes = { "basic", "thermal" };
        public static string allSensorTypes { get; set; } = "";
        
        public static void GetSensorTypesStr() {
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
                SensorObj sensor = getSpecificSensor(sensorTypes[i]);
                sensorArr[i] = sensor;
            }
            return sensorArr;
        }

        public static SensorObj getSpecificSensor(string sensorType)
        {
            SensorObj newSensor;
            switch (sensorType)
            {
                case "basic":
                    newSensor = new BasicSensor();
                    break;
                case "thermal":
                    newSensor = new ThermalSensor();
                    break;
                default:
                    newSensor = new BasicSensor();
                    break;
            }
            return newSensor;

        }

        public static SensorObj genRandSensorSingle() {
            Random rand = new Random();
            int randNum = rand.Next(sensorTypes.Length);
            string sensorType = sensorTypes[randNum];
            SensorObj newSensor = getSpecificSensor(sensorType);
            return newSensor;
        }
        public static SensorObj[] GenRandSensors(int num)
        {
            SensorObj[] sensorsList = new SensorObj[num];
            SensorObj newSensor = genRandSensorSingle();
            while (num > 0)
            {
                while(newSensor == null)
                {
                    newSensor = genRandSensorSingle();

                }
                sensorsList[num-1]= newSensor;
                num -= 1;
            }
            return sensorsList;
        }
    }

}
