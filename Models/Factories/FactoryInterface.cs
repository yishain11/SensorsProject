﻿using SensorsProject.Models.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsProject.Models.Factories
{
    internal interface SensoryFactory
    {
        IGeneralSensor Create();
    }
}
