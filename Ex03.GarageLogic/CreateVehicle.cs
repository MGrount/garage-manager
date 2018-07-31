using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        public enum eVehicleType
        {
            FuelMotorCycle = 1,
            ElectricMotorCycle  = 2,
            FuelCar = 3,
            ElectricCar = 4,
            FuelTruck = 5,
        }

        internal static Vehicle createVehicle(eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;

            switch(i_VehicleType)
            {
                case eVehicleType.FuelMotorCycle:
                    {
                        newVehicle = new FuelMotorCycle(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricMotorCycle:
                    {
                        newVehicle = new ElectricMotorCycle(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.FuelCar:
                    {
                        newVehicle = new FuelCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        newVehicle = new ElectricCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.FuelTruck:
                    {
                        newVehicle = new FuelTruck(i_LicenseNumber);
                        break;
                    }
            }

            return newVehicle;
        }
    }
}
