using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Services;

namespace HomeCleaning.Presentation;

public class UserPresentation
{
    public async static Task Show()
    {
        UserService userService = new UserService();
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("1 -> Register new User");
                Console.WriteLine("2 -> Get All");
                Console.WriteLine("3 -> Update User");
                Console.WriteLine("4 -> Delete User by Id ");
                Console.WriteLine("5 -> Get User by Id");
                Console.WriteLine("6 -> Exit");

                Console.WriteLine("Enter your choice -> ");
                int num = int.Parse(Console.ReadLine());

                User user = new User();
                switch (num)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the name -> ");
                        user.Name = Console.ReadLine();

                        Console.Write("Enter the email -> ");
                        user.Email = Console.ReadLine();

                        Console.Write("Enter the password -> ");
                        user.Password = Console.ReadLine();

                        userService.AddUserAsync(user);
                        break;
                    case 2:
                        Console.Clear();
                        var userList = await userService.GetAllAsync();
                        foreach (var person in userList)
                        {
                            Console.WriteLine($"ID : {person.Id} Name : {person.Name}, E-mail : {person.Email}");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the name -> ");
                        user.Name = Console.ReadLine();
                        Console.Write("Enter the email -> ");
                        user.Email = Console.ReadLine();
                        Console.Write("Enter the password -> ");
                        user.Password = Console.ReadLine();

                        var result = await userService.UpdateAsync(user);
                        if (result)
                            Console.WriteLine("Successfully updated!");
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter the user ID -> ");
                        int userID = int.Parse(Console.ReadLine());
                        var deleteResponse = await userService.DeleteByIdAsync(userID);
                        if (deleteResponse)
                            Console.WriteLine("Successfully deleted!");
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter the user ID -> ");
                        var id = int.Parse(Console.ReadLine());
                        var human = await userService.GetByIdAsync(id);

                        Console.WriteLine($"ID : {human.Id} Name : {human.Name} E-mail : {human.Email}");
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
                Console.WriteLine(ex.Message);

            }
        }
    }
}
