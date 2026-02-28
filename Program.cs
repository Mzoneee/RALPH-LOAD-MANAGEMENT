namespace RALPH_LOAD_MANAGEMENT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string network = "";
            string number = "";
            string loadtype = "";
            string promo = "";
            string amount = "";

            string choice = "";


            Console.WriteLine("Load Management Menu");
            Console.WriteLine("1. Buy Load");
            Console.WriteLine("2. View Transaction");
            Console.WriteLine("3. Update Number");
            Console.WriteLine("4. Cancel Transaction");
            Console.WriteLine("5. Exit");
            choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    Console.Write("\nEnter Network (1-Globe, 2-Smart, 3-DITO): ");
                    string netChoice = Console.ReadLine();

                    if (netChoice == "1")
                        network = "Globe";

                    else if (netChoice == "2")
                        network = "Smart";
                    else if (netChoice == "3")
                        network = "DITO";
                    else { Console.WriteLine("Invalid Network");

                    }
                  


                    Console.WriteLine("Enter Mobile Number");
                    number = Console.ReadLine();
                    Console.WriteLine("Select your Load Type (1. Regular 2.Promo)");
                    string choiceload = Console.ReadLine();

                    if (choiceload == "1")
                    {
                        loadtype = "Regular";
                        promo = "N/A";


                        Console.WriteLine("Enter Amopunt");
                        amount = Console.ReadLine();

                    }
                    else if (choiceload == "2")
                    {
                        loadtype = "Promo";

                        Console.WriteLine("Choose Promo:");
                        Console.WriteLine("1. Go+109 with FREE 5G");
                        Console.WriteLine("2. GoEXTRA109 with FREE 5G");
                        Console.WriteLine("3. Unli 5G 50");
                        Console.WriteLine("4. UnliGo99 Instagram");
                        Console.WriteLine("5. Go5G 20");

                        Console.WriteLine("Enter Promo Choice: ");
                        string promoChoice = Console.ReadLine();
                        switch (promoChoice)
                        {
                            case "1":
                                promo = "Go+109 with FREE 5G";
                                amount = "109";
                                break;
                            case "2":
                                promo = "GoEXTRA109 with FREE 5G";
                                amount = "109";
                                break;
                            case "3":
                                promo = "Unli 5G 50";
                                amount = "50";
                                break;
                            case "4":
                                promo = "UnliGo99 Instagram";
                                amount = "99";
                                break;
                            case "5":
                                promo = "Go5G 20";
                                amount = "20";
                                break;
                            default:
                                promo = "Unknown";
                                amount = "0";
                                break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Load Type: ");
                    }
                    Console.WriteLine("Load Purchased Successfully!");
                    break;





            }
        }
    }
}
