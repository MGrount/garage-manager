using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineProperties
        {
            CurrentEnergy = 1
        }
        
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public Engine(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
        }

        protected float CurrenteEnergy
        {
            get { return m_CurrentEnergy; }
            set
            {
                if (value <= r_MaxEnergy)
                {
                    m_CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(1, r_MaxEnergy, "You have enterd out of range input!");
                }
            }
        }

        public float MaxEngineEnergy
        {
            get { return r_MaxEnergy; }
        }

        public virtual Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> properties = new Dictionary<int, string>();

            properties.Add(1, "Enter current energy");

            return properties;
        }

        public virtual void setProperty(int i_Property, string i_InputFromUserStr)
        {
            float inputFromUserFloat;
            eEngineProperties property = (eEngineProperties)i_Property;

            switch (property)
            {
                case eEngineProperties.CurrentEnergy:
                    {
                        if (float.TryParse(i_InputFromUserStr, out inputFromUserFloat))
                        {
                            CurrenteEnergy = inputFromUserFloat;
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }
            }
        }

        public float EnergyPrecentLeft
        {
            get
            {
                return (m_CurrentEnergy * 100) / r_MaxEnergy;
            }
        }
    }
}
