using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        internal ElectricEngine(float i_MaxHoursOfBattary) : base(i_MaxHoursOfBattary)
        {
        }

        public override Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> properties = new Dictionary<int, string>();

            properties.Add(1, "Enter current battery time");

            return properties;
        }
    }
}
