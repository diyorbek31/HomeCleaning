using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Services;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace HomeCleaning.Presentation;

public class BookingPresentation
{
    public async static Task Show()
    {
        BookingService bookingService = new BookingService();
        
        bool check = true;
        while (check)
        {
            try
            {
                Console.WriteLine("Welcome to the Home Cleaning and Maintenance Service");
                Console.WriteLine("1 -> Make a booking");
                Console.WriteLine("2 -> Book by a price");
                Console.WriteLine("3 -> Cancel a booking");
                Console.WriteLine("4 -> View all bookings "); 
                Console.WriteLine("5 -> View a booking");
                Console.WriteLine("6 -> Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your option ... -> ");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.Clear();
                        var booking = new Booking();
                        Console.Write("Enter User Email: ");
                        booking.UserEmail = Console.ReadLine();

                        Console.Write("Enter Service: ");
                        booking.Service = Console.ReadLine();

                        Console.Write("Enter Provider: ");
                        booking.Provider = Console.ReadLine();

                        Console.Write("Enter Time: ");
                        booking.Time = Console.ReadLine();

                        bool result = await bookingService.BookingAsync(booking);

                        if(result)
                            Console.WriteLine("Booking successful!");
                        else
                            Console.WriteLine("Booking failed.");
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter maximum price you can get : ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        var providers = await bookingService.BookByPriceAsync(price);
                        Console.WriteLine("Available Providers:");
                        foreach (var provider in providers)
                        {
                            Console.WriteLine($"Name: {provider.Name}, Service: {provider.Service}, Price: {provider.Price}, Available Time: {provider.AvailableTime}");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter Booking ID to cancel: ");
                        int id = int.Parse(Console.ReadLine());

                        bool resultCancel = await bookingService.CancelBookingById(id);

                        if (resultCancel)
                            Console.WriteLine("Booking cancelled successfully!");
                        else
                            Console.WriteLine("Failed to cancel booking.");
                        break;
                    case 4:
                        Console.Clear();
                        var bookings = await bookingService.GetAllAsync();

                        Console.WriteLine("All bookings");
                        foreach(var order in bookings)
                        {
                            Console.WriteLine($"ID: {order.Id}, User Email: {order.UserEmail}, Service: {order.Service}, Provider: {order.Provider}, Time: {order.Time}");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter Booking ID -> ");
                        int bookingId = int.Parse(Console.ReadLine());

                        var book = await bookingService.GetByIdAsync(bookingId);

                        if (book is null)
                            Console.WriteLine("Booking not found");
                        else
                            Console.WriteLine($"ID: {book.Id}, User Email: {book.UserEmail}, Service: {book.Service}, Provider: {book.Provider}, Time: {book.Time}");

                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Thank you :)");
                        check = false;
                        break;


                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
