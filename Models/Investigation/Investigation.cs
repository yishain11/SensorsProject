using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsProject.Models.Terrorists;

namespace SensorsProject.Models.Investigation
{
    internal class Investigation
    {
        Terrorist terrorist;
        bool isExposed = false;
        bool playerTurn = true;
        public Investigation(Terrorist t) {
            this.terrorist = t;
        }

        public void startInvestigation() {
            while (!this.isExposed)
            {
                   
            }
        }
    }
}
