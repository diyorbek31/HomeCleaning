using HomeCleaning.Presentation;

namespace HomeCleaning;

public class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            try {
                Console.WriteLine();
                Console.WriteLine("\n\t\t\tWelcome to the Home Cleaning and Maintenance Service");
                Console.WriteLine("\t\t\t\t\t1 - Register new User");
                Console.WriteLine("\t\t\t\t\t2 - Services ");
                Console.WriteLine("\t\t\t\t\t3 - Providers ");
                Console.WriteLine("\t\t\t\t\t4 - Booking");
                Console.WriteLine("\t\t\t\t\t5 - Exit");

                Console.Write("\t\t\t\t\tEnter your option -> ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    await UserPresentation.Show();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    await ServiceNTPresentation.Show();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    await ProviderPresentation.Show();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    await BookingPresentation.Show();
                }
                else if (choice == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Thank you :)");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number! Please try again!");
                }
                
                }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        
    }
}
