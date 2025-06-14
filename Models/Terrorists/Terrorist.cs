using System;
using System.Collections.Generic;
using SensorsProject.Models.Sensors;
using SensorsProject.Utils;

namespace SensorsProject.Models.Terrorists
{
    internal class Terrorist
    {
        public string _rank;
        public bool isExposed;
        private SensorObj[] _sensorsWeaknessArr;
        private Dictionary<string, int> _weaknessSensorsMap;
        private SensorObj[] _attachedSensors;
        private int _sensorNum;
        private int _numOfMatches;
        public Terrorist(int sensorNum = 2, string rank = "basic")
        {
            this._rank = rank;
            this._sensorNum = sensorNum;
            this._sensorsWeaknessArr = this.setSensorList();
            this._weaknessSensorsMap = this.genWeaknessSensorMap();
            this._attachedSensors = new SensorObj[this._sensorNum];
            this._numOfMatches = 0;
        }

        public Dictionary<string, int> genWeaknessSensorMap(SensorObj[] sensorList = null)
        {
            if (sensorList == null) {
                sensorList = this._sensorsWeaknessArr;
            }
            Dictionary<string, int> sensorHistogram = new Dictionary<string, int>();
            foreach (SensorObj s in sensorList)
            {
                if(s!= null)
                {
                    if (!sensorHistogram.ContainsKey(s.type))
                    {
                        sensorHistogram[s.type] = 0;
                    }
                    sensorHistogram[s.type] += 1;
                }
            }
            return sensorHistogram;
        }

        public SensorObj[] setSensorList()
        {
            return SensorManager.GenRandSensors(this._sensorNum);
        }

        public void showSensorsWeakness()
        {
            foreach (SensorObj sensor in this._sensorsWeaknessArr)
            {
                Console.WriteLine($"I am weak to sensor type: {sensor.type}");
            }
        }

        public bool attachSensor(SensorObj sensor, int sensorLocation)
        {
            if (sensorLocation < this._attachedSensors.Length)
            {
                this._attachedSensors[sensorLocation] = sensor;
            }
            this.isExposed = this.checkWeaknessMatching();
            return this.isExposed;
        }

        public int getSensorListLen()
        {
            return this._sensorNum;
        }

        public bool checkWeaknessMatching()
        {
            this._numOfMatches = 0;
            // move checking logic into the sensor active method
            bool isTerroristExposed = false;
            int totalSensors = this._sensorNum;
            int currentMatches = 0;
            Dictionary<string, int> attachedWeaknessMap = this.genWeaknessSensorMap(this._attachedSensors);
            foreach (var sensorAmount in attachedWeaknessMap) {
                string attachedSensorType = sensorAmount.Key;
                if (this._weaknessSensorsMap.ContainsKey(attachedSensorType))
                {
                    if (this._weaknessSensorsMap[attachedSensorType] > sensorAmount.Value)
                    {
                        currentMatches += sensorAmount.Value;
                    } else
                    {
                        currentMatches += this._weaknessSensorsMap[attachedSensorType];
                    }
                }
            }
            Console.WriteLine($"{currentMatches}/{totalSensors} matched");
            if (currentMatches == totalSensors) {
                this.isExposed = true;
                foreach (SensorObj s in this._attachedSensors)
                {
                    s.Activate();
                }
                Console.WriteLine("Terrorist exposed!");
                isTerroristExposed = true;
            }
            return isTerroristExposed;
            
        }
    }
}
