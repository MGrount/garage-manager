using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class Truck : Vehicle
    {
       public enum eTruckProperties
       {
           Model = 1,
           IsCarryingDangerousMaterials = 2,
           MaxCarryWeight = 3,
           CurrentCarryWeight = 4
       }

       private bool m_isCarryingDangerousMaterials;
       private float m_MaxCarryWeight;
       private float m_CurrentCarryWeight;

       internal Truck(string i_LicenseNumber, float i_MaxWheelAirPressure, int i_NumOfWheels)
            : base(i_LicenseNumber, i_MaxWheelAirPressure, i_NumOfWheels)
       {
       }

       public bool IsCarryingDangerousMaterials
       {
           get { return IsCarryingDangerousMaterials; }
           set { m_isCarryingDangerousMaterials = value; }
       }

       public float MaxCarryWeight
       {
           get { return m_MaxCarryWeight; }
           set { m_MaxCarryWeight = value; }
       }

       public float CurrentCarryWeight
       {
           get { return m_CurrentCarryWeight; }
           set
           {
               if (value >= 0 && value <= m_MaxCarryWeight)
               {
                   m_CurrentCarryWeight = value;
               }
               else
               {
                   throw new ValueOutOfRangeException(0, m_MaxCarryWeight, "Value not in range!");
               }
           }
       }

       public override Dictionary<int, string> getVehicleProperties()
       {
           Dictionary<int, string> properties = new Dictionary<int, string>();

           properties.Add((int)eTruckProperties.Model, "Please enter model");
           properties.Add((int)eTruckProperties.IsCarryingDangerousMaterials, "Carry dangerous materials?. 1 - YES, 2 - NO");
           properties.Add((int)eTruckProperties.MaxCarryWeight, "Please enter max carry weight");
           properties.Add((int)eTruckProperties.CurrentCarryWeight, "Please enter current carry weight");

           return properties;
       }

       public override void setProperty(int i_Property, string i_InputFromUserStr)
        {
            eTruckProperties property = (eTruckProperties)i_Property;
            int inputFromUserInt;
            float inputFromUserFloat;

            switch (property)
            {
                case eTruckProperties.Model:
                    {
                        Model = i_InputFromUserStr;
                        break;
                    }

                case eTruckProperties.IsCarryingDangerousMaterials:
                    {
                        if (int.TryParse(i_InputFromUserStr, out inputFromUserInt))
                        {
                            if (inputFromUserInt == 1)
                            {
                                IsCarryingDangerousMaterials = true;
                            }
                            else if (inputFromUserInt == 2)
                            {
                                IsCarryingDangerousMaterials = false;
                            }
                            else
                            {
                                throw new ValueOutOfRangeException(1, 2, "Please enter 1 - YES, 2 - NO");
                            }
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }

                case eTruckProperties.MaxCarryWeight:
                    {
                        if (float.TryParse(i_InputFromUserStr, out inputFromUserFloat))
                        {
                            MaxCarryWeight = inputFromUserFloat;
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }

                case eTruckProperties.CurrentCarryWeight:
                    {
                        if (float.TryParse(i_InputFromUserStr, out inputFromUserFloat))
                        {
                            CurrentCarryWeight = inputFromUserFloat;
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
@"Max carry weight  :{0}
Contains dangerous goods : {1}
Current carry weight: {2}
", m_MaxCarryWeight.ToString(), m_isCarryingDangerousMaterials.ToString(), m_CurrentCarryWeight);

           return stringBuilder.ToString() + base.ToString();
       }
    }
}
