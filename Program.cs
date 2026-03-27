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
                Console.WriteLine("2. View Loads");
                Console.WriteLine("3. Update Transaction");
                Console.WriteLine("4. Delete Transaction");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BuyRegularLoad(loadBL);
                        break;
                    case "2":
                        ViewLoads(loadBL);
                        break;
                    case "3":
                        UpdateLoadRecord(loadBL);
                        break;
                    case "4":
                        DeleteTransaction(loadBL);
                        break;
                    case "5":
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

        static void ViewLoads(LoadAppService loadBL)
        {
            Console.Clear();
            Console.WriteLine("\nHere are the list of loads.. ");

            var loads = loadBL.GetLoads();
           
        if(loads.Count == 0)
            {
                Console.WriteLine("No Transactions Found");

            }
            else
            {
                foreach (var load in loads)
                {
                    Console.WriteLine($"ID: {load.TransactionID} Phone: {load.PhoneNumber}, Network: {load.Network}, Type: {load.LoadType}, Value: {load.LoadValue}");

                }
            }
            

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }


        static void UpdateLoadRecord(LoadAppService loadBL)
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE TRANSACTION ===");

            Console.Write("Enter Transaction ID: ");
            string findID = Console.ReadLine();

            Console.Write("Enter new Phone Number: ");
            string newPhone = Console.ReadLine();

            Console.WriteLine("Select new SimCard (1.Globe 2.Smart 3.Dito): ");
            string netChoice = Console.ReadLine();

            string newNetwork = netChoice == "1" ? "Globe" :
                                netChoice == "2" ? "Smart" : "Dito";

            Console.Write("Enter new Load Amount: ");
            string newAmount = Console.ReadLine();

            Load updatedLoad = new Load
            {
                TransactionID = findID,
                PhoneNumber = newPhone,
                Network = newNetwork,
                LoadValue = newAmount,
                LoadType = "Regular"
            };

            loadBL.UpdateTransaction(updatedLoad);

            Console.WriteLine("\nUpdate Successful!");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }


        static void DeleteTransaction(LoadAppService loadBL)
        {
            Console.Clear();
            Console.WriteLine("Enter the transaction ID to DELETE");
            string id = Console.ReadLine();

            bool DELETE = loadBL.RemoveTransaction(id);

            if (DELETE)
            {
                Console.WriteLine("\n YOU HAVE SUCCESSFULLY DELETED THE TRANSACTION");

            }
            else
            {
                Console.WriteLine("\n Transaction ID Was not found, nothing was deleted");

            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}