using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class FuelCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxWheelAirPressure = 29;
        private const int k_NumOfWheels = 4;
        private const float k_MaxFuelAmount = 45f;

        public FuelCar(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxWheelAirPressure, k_NumOfWheels)
        {
            EngineSystem = new FuelEngine(k_MaxFuelAmount, k_FuelType);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Fuel Type : " + k_FuelType.ToString());

            return base.ToString() + stringBuilder;
        }
    }
}
