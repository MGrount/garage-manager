using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GarageManagementUI garageUI = new GarageManagementUI();
            garageUI.OpenGarage();
        }
    }
}
