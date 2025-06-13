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
        private SensorObj[] _sensorsWeakness;
        private SensorObj[] _attachedSensors;
        private int _sensorNum;
        public Terrorist(int sensorNum = 2, string rank = "basic")
        {
            this._rank = rank;
            this._sensorNum = sensorNum;
            this.setSensorList();
            this._attachedSensors = new SensorObj[this._sensorNum];
        }

        public void setSensorList() {
            this._sensorsWeakness = SensorManager.GenRandSensors(this._sensorNum);
        }

        public void showSensorsWeakness() { 
            foreach (SensorObj sensor in this._sensorsWeakness)
            {
                Console.WriteLine($"I am week to sensor type: {sensor.type}");
            }
        }

        public void attachSensor(SensorObj sensor) { }

        public int getSensorListLen() {
            return this._sensors.Count;
        }

    }
}
