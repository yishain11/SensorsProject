using SensorsProject.Models.Terrorists;

namespace SensorsProject.Models.Sensors
{
    internal interface IGeneralSensor
    {
        int Activate(Terrorist t);
        string type { get; set; }
    }

}