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
        public bool isExposed;
        private SensorObj[] _sensorsWeaknessArr;
        private Dictionary<string, int> _weaknessSensorsMap { get; set; }
        private SensorObj[] _attachedSensors;
        private int _sensorNum;
        public Terrorist(int sensorNum = 2, string rank = "basic")
        {
            this._rank = rank;
            this._sensorNum = sensorNum;
            this._sensorsWeaknessArr = this.setSensorList();
            this._weaknessSensorsMap = this.genWeaknessSensorMap();
            this._attachedSensors = new SensorObj[this._sensorNum];
        }

        public static string DescribeObject<T>(T obj)
        {
            var props = typeof(T).GetProperties();
            var details = props.Select(p => $"{p.Name}={p.GetValue(obj)}");
            return $"{typeof(T).Name}: " + string.Join(", ", details);
        }

        public Dictionary<string, int> genWeaknessSensorMap(SensorObj[] sensorList = null)
        {
            if (sensorList == null) {
                sensorList = this._sensorsWeaknessArr;
            }
            Dictionary<string, int> sensorHistogram = new Dictionary<string, int>();
            foreach (SensorObj s in sensorList)
            {
                Console.WriteLine($"s is: {s}");
                if (!sensorHistogram.ContainsKey(s.type))
                {
                    sensorHistogram[s.type] = 0;
                }
                sensorHistogram[s.type] += 1;
            }
            return sensorHistogram;
        }

        public SensorObj[] setSensorList()
        {
            return this._sensorsWeaknessArr = SensorManager.GenRandSensors(this._sensorNum);
        }

        public void showSensorsWeakness()
        {
            foreach (SensorObj sensor in this._sensorsWeaknessArr)
            {
                Console.WriteLine($"I am weak to sensor type: {sensor.type}");
            }
        }

        public void attachSensor(SensorObj sensor, int sensorLocation)
        {
            this._attachedSensors[sensorLocation] = sensor;
            Console.WriteLine(this.checkWeaknessMatching());
        }

        public int getSensorListLen()
        {
            return this._sensorNum;
        }

        public string checkWeaknessMatching()
        {
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
            if (currentMatches == totalSensors) {
                this.isExposed = true;
                Console.WriteLine("Terrorist exposed!");
            }
            return $"{currentMatches}/{totalSensors} matched";
        }
    }
}
