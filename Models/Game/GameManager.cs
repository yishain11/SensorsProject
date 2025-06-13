using SensorsProject.Models.Terrorists;
using SensorsProject.Models.Investigations;

namespace SensorsProject.Models.Game
{
    internal class GameManager
    {

        // gen new terrorist
        Terrorist basicTerrorist = new Terrorist();
        
        public GameManager()
        {
            Investigation i = new Investigation(basicTerrorist);
            i.startInvestigation();
        }

    }
}
