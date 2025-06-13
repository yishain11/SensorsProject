using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsProject.Models.Sensors;

namespace SensorsProject.Models.Terrorists
{
    internal class Terrorist
    {
        private string _rank;
        private List<SensorObj> _sensors;
        private int _sensorNum;
        public Terrorist(int sensorNum = 2, string rank = "basic")
        {
            this._rank = rank;
            this._sensorNum = sensorNum;
            this.setSensorList();
        }

        public void setSensorList() {
            this._sensors = SensorGenerator.GenSensors(this._sensorNum);
        }

        public void showSensors() { 
            foreach (SensorObj sensor in this._sensors)
            {
                Console.WriteLine($"I have sensor type: {sensor.type}");
            }
        }
    }
}
