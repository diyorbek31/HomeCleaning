using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Interfaces;
using HomeCleaning.Service.Services;

namespace HomeCleaning.Presentation;

public class ProviderPresentation
{
    public async static Task Show()
    {
        ProviderService providerService = new ProviderService();
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("1 -> Register new Provider");
                Console.WriteLine("2 -> Get All");
                Console.WriteLine("3 -> Update Provider");
                Console.WriteLine("4 -> Delete Provider by Id ");
                Console.WriteLine("5 -> Get Provider by Id");
                Console.WriteLine("6 -> Exit");

                Console.WriteLine("Enter your choice -> ");
                int num = int.Parse(Console.ReadLine());

                Provider provider = new Provider();
                switch (num)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the name -> ");
                        provider.Name = Console.ReadLine();

                        Console.Write("Enter the service name -> ");
                        provider.Service = Console.ReadLine();

                        Console.Write("Enter the time -> ");
                        provider.AvailableTime = Console.ReadLine();

                        Console.Write("Enter the price -> ");
                        provider.Price = decimal.Parse(Console.ReadLine());

                        providerService.AddProviderAsync(provider);
                        break;
                    case 2:
                        Console.Clear();
                        var providerList = await providerService.GetAllAsync();
                        foreach (var provide in providerList)
                        {
                            Console.WriteLine($"\n\nName : {provide.Name}, " +
                                $"\nService : {provide.Service} " +
                                $"\nTime : {provide.AvailableTime} " +
                                $"\nPrice : {provide.Price}");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("\nEnter the name -> ");
                        provider.Name = Console.ReadLine();
                        Console.Write("Enter the service name -> ");
                        provider.Service = Console.ReadLine();
                        Console.Write("Enter the time -> ");
                        provider.AvailableTime = Console.ReadLine();
                        Console.Write("Enter the price -> ");
                        provider.Price = decimal.Parse(Console.ReadLine());

                        var result = await providerService.UpdateProviderAsync(provider);
                        if (result)
                            Console.WriteLine("Successfully updated!");
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter the provider ID -> ");
                        int provderId = int.Parse(Console.ReadLine());
                        var deleteResponse = await providerService.DeleteByIdAsync(provderId);
                        if (deleteResponse)
                            Console.WriteLine("Successfully deleted!");
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter the provider ID -> ");
                        var id = int.Parse(Console.ReadLine());
                        var provider1 = await providerService.GetByIdAsync(id);

                        Console.WriteLine($"\n\nName : {provider1.Name}, " +
                            $"\nService : {provider1.Service} " +
                            $"\nTime : {provider1.AvailableTime} " +
                            $"\nPrice : {provider1.Price}");
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Thank you :)");
                        check = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}