using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class GarageManagementUI
    {
        public enum eUserChoiseMainMenu
        {
            InsertNewCarToTheGarage = 1,
            ShowListOfAllVehicleLicenseNumber = 2,
            ChangeVehicleStatus = 3,
            FillAirPressureToMax = 4,
            LoadEnergy = 5,
            ShowVehicleFullDetails = 6,
            Exit = 7,
        }

        private eUserChoiseMainMenu m_UserChoiseMainMenu;
        private GarageActions m_GarageActions = new GarageActions();

        public void OpenGarage()
        {
            do
            {
                printMainMenu();
                try
                {
                    mainMenuAction(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while(true);
        }

        private void mainMenuAction(string i_UserChoise)
        {
            m_UserChoiseMainMenu = (eUserChoiseMainMenu)Enum.Parse(typeof(eUserChoiseMainMenu), i_UserChoise);

            switch (m_UserChoiseMainMenu)
            {
                case eUserChoiseMainMenu.InsertNewCarToTheGarage:
                    {
                        CreateVehicle();
                        break;
                    }

                case eUserChoiseMainMenu.ShowListOfAllVehicleLicenseNumber:
                    {
                        showListOfAllVehicleLicenseNumber();
                        break;
                    }

                        case eUserChoiseMainMenu.ChangeVehicleStatus:
                            {
                                changeVehicleStatus();
                                break;
                            }

                        case eUserChoiseMainMenu.FillAirPressureToMax:
                            {
                                fillAirPressureToMax();
                                break;
                            }

                        case eUserChoiseMainMenu.LoadEnergy:
                            {
                                loadEnergy();
                                break;
                            }

                        case eUserChoiseMainMenu.ShowVehicleFullDetails:
                            {
                                showVehicleFullDetails();
                                break;
                            }

                        case eUserChoiseMainMenu.Exit:
                            {
                                Console.WriteLine("Bye bye...");
                                Environment.Exit(0);
                                break;
                            }

                        default:
                            {
                                throw new ArgumentException(string.Format("Enter valid number!", m_UserChoiseMainMenu));
                            }    
                    }     
        }

        private void printMainMenu()
        {
            Console.WriteLine(
 @"
Main Menu: 
==========
1 - Insert new car to the garage.
2 - Show list of all vehicle at the garage.
3 - Change vehicle status in the garage.
4 - Fill wheels air pressure to maximum.
5 - Load Energy
6 - Show full details of vehicle.
7 - Exit.

* all choises are by license number.");
        }

        private void CreateVehicle()
        {
            Console.WriteLine("Please enter license number");
            string licenseNumber = Console.ReadLine();
            string msg;
            if (m_GarageActions.CheckIfVehicleExistsAndChangeStatus(licenseNumber, out msg))
            {
                Console.WriteLine(msg);
                Console.WriteLine("Please enter owner name");
                string ownerName = Console.ReadLine();

                Console.WriteLine("Please enter owner phone number ");
                string ownerPhoneNumber = Console.ReadLine();
                int typeOfVehicleFromUser = getVehicleTypeFromUser();
                try
                {
                    m_GarageActions.AddCarToGarage(ownerName, ownerPhoneNumber, licenseNumber, typeOfVehicleFromUser);
                    insertProperties();
                    addWheels();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        private void loadEnergy()
        {
            setLicenseNumber();
            Dictionary<int, string> energyProperties = m_GarageActions.GetEnergyProperties();
            bool isValid;

            for (int i = 1; i <= energyProperties.Count; i++)
            {
                isValid = false;
                Console.WriteLine(energyProperties[i]);
                do
                {
                    try
                    {
                        m_GarageActions.SetEngineProperty(i, Console.ReadLine());
                        isValid = true;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("value are between {0} to {1}", ex.MinValue, ex.MaxValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!isValid);
            }
        }

        private void showVehicleFullDetails()
        {
            try
            {
                setLicenseNumber();
                Console.WriteLine(m_GarageActions.GetVehicleDetails());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void insertProperties()
        {
            Dictionary<int, string> properties = m_GarageActions.GetVehicleProperties();
            bool isValid;

            for(int i = 1; i <= properties.Count; i++ )
            {
                isValid = false;
                Console.WriteLine(properties[i]);
                do
                {
                    try
                    {
                        m_GarageActions.SetProperty(i, Console.ReadLine());
                        isValid = true;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("value are between {0} to {1}", ex.MinValue, ex.MaxValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!isValid);
            }
        }

        private int getVehicleTypeFromUser()
        {
            int userChoice;
            bool isInputValid = false;
            do
            {
                Console.WriteLine(m_GarageActions.GetTypesOfVehicles());
                if(int.TryParse(Console.ReadLine(), out userChoice))
                {
                    isInputValid = m_GarageActions.isUserVehicleTypeChoiceLegal(userChoice);
                }
            }
            while(!isInputValid);

            return userChoice;
        }

       private void showListOfAllVehicleLicenseNumber()
       {
            int yesNoChoice;

            bool isInputValid = true;
            do
            {
                isInputValid = true;
                Console.WriteLine("Filter by status? 1 - Yes, 2 - No");

                if(int.TryParse(Console.ReadLine(), out yesNoChoice))
                {
                    if(yesNoChoice == 1)
                    {
                        showListOfAllVehicleLicenseNumberByStatus();
                    }
                    else if(yesNoChoice == 2)
                    {
                        Console.WriteLine(m_GarageActions.GetListOfVehiclesInGarage());
                    }
                    else
                    {
                        isInputValid = false;
                    }    
                }
                else
                {
                    isInputValid = false;
                }
            }
            while(!isInputValid);
       }

        private void showListOfAllVehicleLicenseNumberByStatus()
        {
            int userChoice;
            bool isInputValid = false;
            do
            {
                Console.WriteLine(m_GarageActions.GetListOfStatuses());
                if(int.TryParse(Console.ReadLine(), out userChoice))
                {
                    try
                    {
                        Console.WriteLine(m_GarageActions.GetListOfVehiclesInGarageByStatus(userChoice));
                        isInputValid = true;
                    }
                    catch(ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("value are between {0} to {1}", ex.MinValue, ex.MaxValue);
                    }
                }
            }
            while(!isInputValid);
        }

        private void changeVehicleStatus()
        {
            int status;

            setLicenseNumber();
            Console.WriteLine("Choose status");
            Console.WriteLine(m_GarageActions.GetListOfStatuses());
            if (int.TryParse(Console.ReadLine(), out status))
            {
              try
              {
                 m_GarageActions.TryChangeVehicleStatus(status);
              }
              catch (ValueOutOfRangeException ex)
              {
                     Console.WriteLine(ex.Message);
                Console.WriteLine("value are between {0} to {1}", ex.MinValue, ex.MaxValue);
              }
              catch(Exception ex)
              {
                 Console.WriteLine(ex.Message);
              }
            }
         }
        
        private void setLicenseNumber()
        {
            Console.WriteLine("Please enter license number");

            while(!m_GarageActions.setCurrentVehicleInGarage(Console.ReadLine()))
            {
                Console.WriteLine("vehicle does not exists! pLease enter correct license number!");
            }

        }

        private void fillAirPressureToMax()
        {
            try
            {
                setLicenseNumber();
                m_GarageActions.TryAddMaxAirToWheels();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addWheels()
        {
            Console.WriteLine("Please enter wheel manufacturer name");
            string manufacturer = Console.ReadLine();
            float currentAirPressure;
            bool isInputValid = false;

            do
            {
                Console.WriteLine("Please enter current wheel air pressure");
                if (float.TryParse(Console.ReadLine(), out currentAirPressure))
                {
                    try
                    {
                        m_GarageActions.AddWheels(manufacturer, currentAirPressure);
                        isInputValid = true;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("value are between {0} to {1}", ex.MinValue, ex.MaxValue);
                    }
                }
            }
            while (!isInputValid);
        }
    }
}
