using SensorsProject.Models.Terrorists;

namespace SensorsProject.Models.Game
{
    internal class GameManager
    {

        // gen new terrorist
        Terrorist basicTerrorist = new Terrorist();
        
        public GameManager()
        {
            this.basicTerrorist.showSensors();
        }

    }
}
