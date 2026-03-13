using System;
using LoadManagementModels;
using LoadManagementAppService;

namespace LoadManagementConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
    
            LoadAppService loadBL = new LoadAppService();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Load Management System ===");
                Console.WriteLine("1. Buy Load (Regular only)");
                Console.WriteLine("2. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BuyRegularLoad(loadBL);
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void BuyRegularLoad(LoadAppService loadBL)
        {
            Console.Clear();
            Console.WriteLine("=== Buy Regular Load ===");

            string phoneNumber;
            do
            {
                Console.Write("Enter phone number: ");
                phoneNumber = Console.ReadLine();

                if (!loadBL.IsValidPhoneNumber(phoneNumber))
                    Console.WriteLine("Invalid phone number. Must be 10-11 digits.");
            } while (!loadBL.IsValidPhoneNumber(phoneNumber));

       
            Console.WriteLine("Select SIM card:");
            Console.WriteLine("1. Globe");
            Console.WriteLine("2. Smart");
            Console.WriteLine("3. Dito");
            Console.Write("Choice: ");
            string networkChoice = Console.ReadLine();

            string network = "";
            switch (networkChoice)
            {
                case "1": network = "Globe"; break;
                case "2": network = "Smart"; break;
                case "3": network = "Dito"; break;
                default: network = "Unknown"; break;
            }

          
            Console.Write("Enter load amount: ");
            string loadValue = Console.ReadLine();

            var transaction = new Load
            {
                PhoneNumber = phoneNumber,
                Network = network,
                LoadType = "Regular",
                LoadValue = loadValue
            };

     
            var result = loadBL.BuyLoad(transaction);

 
            Console.WriteLine($"\nThank you for purchasing {result.LoadValue} worth of load for {result.PhoneNumber} ({result.Network})!");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
    }
}