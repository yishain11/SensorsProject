using System;
using SensorsProject.Models.Players;
using SensorsProject.Models.Terrorists;

namespace SensorsProject.Models.Investigations
{
    internal class Investigation
    {
        Terrorist terrorist;
        bool playerTurn = true;
        Random rand = new Random();
        public Investigation(Terrorist t) {
            this.terrorist = t;
            
        }

        public void startInvestigation() {
            Console.WriteLine("Investigation begining...");
            if(this.terrorist != null)
            {
                Console.WriteLine($"terrorist is waiting in room {this.rand.Next(1,10)}");
            }
            while (!terrorist.isExposed)
            {
                Player.AttachSensor(this.terrorist);
            }
        }
    }
}
