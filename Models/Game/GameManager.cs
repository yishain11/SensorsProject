using SensorsProject.Models.Terrorists;
using SensorsProject.Models.Investigations;
using SensorsProject.Utils;
using System;

namespace SensorsProject.Models.Game
{
    internal class GameManager
    {

        // gen new terrorist
        Terrorist basicTerrorist = new Terrorist();
        
        public GameManager()
        {
            Console.WriteLine("Welcome to the investigation game!");
            Investigation i = new Investigation(basicTerrorist);
            i.startInvestigation();
        }

    }
}
