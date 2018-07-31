using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class ElectricCar : Car
    {
        private const float k_MaxWheelAirPressure = 29;
        private const int k_NumOfWheels = 4;
        private const float k_MaxBatteryTime = 2.6f;

        /// <summary>
        /// class constructor that creates ElectricEngine
        /// </summary>
        // $G$ DSN-006 (-3) Creation of vehicle entities should not be allowed outside of this project (constructors should be marked as internal).
        public ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxWheelAirPressure, k_NumOfWheels)
        {
            EngineSystem = new ElectricEngine(k_MaxBatteryTime);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Vehicle type : Electric Automobile ");

            return stringBuilder + base.ToString();
        }
    }
}
