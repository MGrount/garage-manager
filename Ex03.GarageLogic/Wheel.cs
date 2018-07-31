using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly string r_Manufacturer;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        internal Wheel(string i_Manufacturer, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxAirPressureByManufacturer
        {
            get { return r_MaxAirPressure; }
        }

        public bool AddAirToWheel(float i_AirToAdd)
        {
            // check null
            string exceptionMsg = null;
            bool isInRange = true;
            if (i_AirToAdd >= 0)
            {
                if (i_AirToAdd + m_CurrentAirPressure <= r_MaxAirPressure)
                {
                    m_CurrentAirPressure = m_CurrentAirPressure + i_AirToAdd;
                }
                else
                {
                    exceptionMsg = "You have added more air than availble!";
                    isInRange = false;
                }
            }
            else
            {
                exceptionMsg = "You have filled less than zero!";
                isInRange = false;     
            }

            if(!isInRange)
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure, exceptionMsg);
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
@"ManufacturerName : {0}
AirPressure : {1}", r_Manufacturer, CurrentAirPressure.ToString());

            return stringBuilder.ToString();
        }
    }
}
