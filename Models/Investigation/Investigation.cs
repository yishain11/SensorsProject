using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsProject.Models.Players;
using SensorsProject.Models.Terrorists;

namespace SensorsProject.Models.Investigations
{
    internal class Investigation
    {
        Terrorist terrorist;
        bool playerTurn = true;
        public Investigation(Terrorist t) {
            this.terrorist = t;
        }

        public void startInvestigation() {
            while (!terrorist.isExposed)
            {
                Player.AttachSensor(this.terrorist);
            }
        }
    }
}
