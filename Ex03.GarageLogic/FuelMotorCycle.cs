using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class FuelMotorCycle : MotorCycle
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan96;
        private const float k_MaxWheelAirPressure = 30;
        private const int k_NumOfWheels = 2;
        private const float k_MaxFuelAmount = 6.5f;

        public FuelMotorCycle(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxWheelAirPressure, k_NumOfWheels)
        {
            EngineSystem = new FuelEngine(k_MaxFuelAmount, k_FuelType);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Vehicle type : Fuel Motorbike ");

            return stringBuilder + base.ToString();
        }
    }
}
