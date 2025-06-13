using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsProject.Models.Sensors
{
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
