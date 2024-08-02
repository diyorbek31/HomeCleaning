using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Interfaces;
using HomeCleaning.Service.Services;

namespace HomeCleaning.Presentation;

public class ServiceNTPresentation
{
    public async static Task Show()
    {
        ServiceNT serviceNT = new ServiceNT();
        ServiceNTService serviceNTService = new ServiceNTService();
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("1 -> Register new Service");
                Console.WriteLine("2 -> Get All");
                Console.WriteLine("3 -> Update Service");
                Console.WriteLine("4 -> Delete Service by Id ");
                Console.WriteLine("5 -> Retriev Service by Id");
                Console.WriteLine("6 -> Exit");

                Console.WriteLine("Enter your choice -> ");
                int num = int.Parse(Console.ReadLine());


                switch (num)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the service name ->");
                        serviceNT.Name = Console.ReadLine();

                        Console.Write("Enter the description ->");
                        serviceNT.Description = Console.ReadLine();

                        serviceNTService.AddServiceAsync(serviceNT);
                        break;
                    case 2:
                        Console.Clear();
                        var services = await serviceNTService.GetAllAsync();
                        foreach(var service in services)
                        {
                            Console.WriteLine($"\nID : {service.Id} " +
                                $"Name : {service.Name} " +
                                $"\nDescription : {service.Description}");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the service name ->");
                        serviceNT.Name = Console.ReadLine();
                        Console.Write("Enter the description ->");
                        serviceNT.Description = Console.ReadLine();

                        var result = await serviceNTService.UpdateServiceAsync(serviceNT);
                        if (result)
                            Console.WriteLine("Successfully updated");
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter the service ID -> ");
                        int serviceId = int.Parse(Console.ReadLine());
                        var deleteResponse = await serviceNTService.DeleteByIdAsync(serviceId);
                        if (deleteResponse)
                            Console.WriteLine("Successfully deleted!");
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter the user ID -> ");
                        var id = int.Parse(Console.ReadLine());
                        var service1 = await serviceNTService.GetByIdAsync(id);

                        Console.WriteLine($"\nID : {service1.Id} " +
                            $"Name : {service1.Name} " +
                            $"\nDescription : {service1.Description}");
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Thank you :)");
                        check = false;
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }
}
