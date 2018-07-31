using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class MotorCycle : Vehicle
    {
        public enum eMotorCycleProperties
        {
            Model = 1,
            LicenseType = 2,
            EngineVolume = 3
        }

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AB = 3,
            B2 = 4,
        }

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        internal MotorCycle(string i_LicenseNumber, float i_MaxWheelAirPressure, int i_NumOfWheels)
            : base(i_LicenseNumber, i_MaxWheelAirPressure, i_NumOfWheels)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public override Dictionary<int, string> getVehicleProperties()
        {
            Dictionary<int, string> properties = new Dictionary<int, string>();

            properties.Add((int)eMotorCycleProperties.Model, "Please enter model");
            properties.Add((int)eMotorCycleProperties.LicenseType, Car.enterEnumMsg<eLicenseType>("LicenseNumber type"));
            properties.Add((int)eMotorCycleProperties.EngineVolume, "Please enter engine volume");

            return properties;
        }

        public override void setProperty(int i_Property, string i_InputFromUserStr)
        {
            eMotorCycleProperties property = (eMotorCycleProperties)i_Property;
            int inputFromUserInt;

            switch (property)
            {
                case eMotorCycleProperties.Model:
                    {
                        Model = i_InputFromUserStr;
                        break;
                    }

                case eMotorCycleProperties.EngineVolume:
                    {
                        if (int.TryParse(i_InputFromUserStr, out inputFromUserInt))
                        {
                            EngineVolume = inputFromUserInt;
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }

                case eMotorCycleProperties.LicenseType:
                    {
                        if (int.TryParse(i_InputFromUserStr, out inputFromUserInt))
                        {
                            if (Enum.IsDefined(typeof(eLicenseType), inputFromUserInt))
                            {
                                LicenseType = (eLicenseType)inputFromUserInt;
                            }
                            else
                            {
                                throw new ValueOutOfRangeException(1, Enum.GetNames(typeof(eLicenseType)).Length, "You have enterd out of range input!");
                            }
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
@"License Type : {0}
Engine Volume : {1}", m_LicenseType.ToString(), m_EngineVolume.ToString());

            return base.ToString() + stringBuilder.ToString();
        }
    }
}
