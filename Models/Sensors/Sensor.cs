using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsProject.Models.Sensors
{
    internal static class SensorGenerator
    {

        public static string[] sernsorTypes = { "basic", "thermal"};
        public static List<SensorObj> GenSensors(int num)
        {
            List<SensorObj> sensorsList = new List<SensorObj>();
            Random rand = new Random();
            while (num > 0)
            {
                int randNum = rand.Next(sernsorTypes.Length);
                string sensorType = sernsorTypes[randNum];
                SensorObj newSensor;
                switch (sensorType) {
                    case "basic":
                        newSensor = new BasicSensor();
                        sensorsList.Add(newSensor);
                        break;
                    case "thermal":
                        newSensor = new ThermalSensor();
                        sensorsList.Add(newSensor); 
                        break;
                }
                num -= 1;
            }
            return sensorsList;
        }
    }

    internal abstract class SensorObj
    {
        public string type { get; set; } = "basic";
        public abstract void Activate();
    }

    internal class BasicSensor : SensorObj
    {
        public override void Activate()
        {
            Console.WriteLine($"{this.type} sensor activated");
        }
    }
    internal class ThermalSensor : SensorObj
    {
        public ThermalSensor() {
            this.type = "thermal";
        }
        public override void Activate()
        {
            Console.WriteLine($"{this.type} sensor activated");
        }
    }
}
