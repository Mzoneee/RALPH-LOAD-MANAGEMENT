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

            switch(choice) {
                case "1":
                    Console.Write("\nEnter Network (1-Globe, 2-Smart, 3-DITO): ");
                    string netChoice = Console.ReadLine();

                    if (netChoice == "1")
                        network = "Globe";
                    else if (netChoice == "2")
                        network = "Smart";
                    else if (netChoice == "3")
                        network = "DITO";
                    else
                    
                        Console.WriteLine("Invalid Network");
                        break;
                       

            
           
                        }
            }
        }
    }
}
