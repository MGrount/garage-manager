using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eCarProperties
        {
            Model = 1,
            Color = 2,
            NumberOfDoors = 3
        }

        public enum eCarNumberOfDoors
        {
            TwoDoors = 1,
            ThreeDoors = 2,
            FourDoors = 3,
            FiveDoors = 4,
        }

        public enum eCarColor
        {
            White = 1,
            Green = 2,
            Blue = 3,
            Red = 4,
        }

        private eCarNumberOfDoors m_NumberOfDoors;
        private eCarColor m_CarColor;
        
        internal Car(string i_LicenseNumber, float i_MaxWheelAirPressure, int i_NumOfWheels)
            : base(i_LicenseNumber, i_MaxWheelAirPressure, i_NumOfWheels)
        {
        }

        public eCarNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public override void setProperty(int i_Property, string i_InputFromUserStr)
        {
            eCarProperties property = (eCarProperties)i_Property;
            int inputFromUserInt;

            switch (property)
            {
                case eCarProperties.Model:
                    {
                    Model = i_InputFromUserStr;
                    break;
                    }

                case eCarProperties.Color:
                    {
                        if (int.TryParse(i_InputFromUserStr, out inputFromUserInt))
                        {
                            if (Enum.IsDefined(typeof(eCarColor), inputFromUserInt))
                            {
                                CarColor = (eCarColor)inputFromUserInt;
                            }
                            else
                            {
                                throw new ValueOutOfRangeException(1, Enum.GetNames(typeof(eCarColor)).Length, "You have enterd out of range input!");
                            }
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                       break;
                    }

                case eCarProperties.NumberOfDoors:
                    {
                        if (int.TryParse(i_InputFromUserStr, out inputFromUserInt))
                        {
                            if (Enum.IsDefined(typeof(eCarNumberOfDoors), inputFromUserInt))
                            {
                                NumberOfDoors = (eCarNumberOfDoors)inputFromUserInt;
                            }
                            else
                            {
                                throw new ValueOutOfRangeException(1, Enum.GetNames(typeof(eCarNumberOfDoors)).Length, "You have enterd out of range input!");
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
@"Car color : {0}:
Number of doors : {1}
", m_CarColor.ToString(), NumberOfDoors.ToString());

            return base.ToString() + stringBuilder.ToString();
        }

        public override Dictionary<int, string> getVehicleProperties()
        {
            Dictionary<int, string> properties = new Dictionary<int, string>();

            properties.Add((int)eCarProperties.Model, "Please enter model");
            properties.Add((int)eCarProperties.Color, enterEnumMsg<eCarColor>("car color"));
            properties.Add((int)eCarProperties.NumberOfDoors, enterEnumMsg<eCarNumberOfDoors>("number of doors"));

            return properties;
        }

        public static string enterEnumMsg<T>(string i_ValueName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int index = 1;

            stringBuilder.AppendFormat("Please enter {0}{1}", i_ValueName, Environment.NewLine);
            foreach(T currentValue in Enum.GetValues(typeof(T)))
            {
                stringBuilder.AppendFormat("{0} - {1}{2}", index, currentValue.ToString(), Environment.NewLine);
                index++;
            }

            return stringBuilder.ToString();
        }
    }
}
