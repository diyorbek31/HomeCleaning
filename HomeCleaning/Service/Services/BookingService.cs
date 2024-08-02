using HomeCleaning.Data.IRepositories;
using HomeCleaning.Data.Repositories;
using HomeCleaning.Domain.Entities;

using HomeCleaning.Service.Exceptions;
using HomeCleaning.Service.Interfaces;

namespace HomeCleaning.Service.Services;

public class BookingService : IBookingService
{
    private readonly IRepository<User> userRepository = new Repository<User>();
    private readonly IRepository<Provider> provoderRepository = new Repository<Provider>();
    private readonly IRepository<Booking> bookingRepository = new Repository<Booking>();
    private readonly IRepository<ServiceNT> serviceRepository = new Repository<ServiceNT>();
    public async Task<IEnumerable<Provider>> BookByPriceAsync(decimal price)
    {
        var providers = await this.provoderRepository.RetrievAllAsync();
        if (providers is null)
            throw new CustomException(404, "Booking not found");
        var selectByPrice = providers.Where(p => p.Price <= price);
        return selectByPrice;
    }

    public async Task<bool> BookingAsync(Booking booking)
    {
        var bookings = await this.bookingRepository.RetrievAllAsync();
        if (bookings.Any(b => b.UserEmail.Equals(booking.UserEmail,StringComparison.OrdinalIgnoreCase)))
            throw new CustomException(404, "Nothing is found");
        await this.bookingRepository.InsertAsync(booking);
        return true;
    }

    public async Task<bool> CancelBookingById(int id)
    {
        var booking = await this.bookingRepository.RetrievByIdAsync(id);
        if (booking is null)
            throw new CustomException(404, "Booking not found");
        await this.bookingRepository.DeleteByIdAsync(id);
        return true;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        var bookings = await this.bookingRepository.RetrievAllAsync();
        if (bookings is null)
            throw new CustomException(404, "Booking not found");
        return bookings;
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        var bookings = await this.bookingRepository.RetrievByIdAsync(id);
        if (bookings is null)
            throw new CustomException(404, "Booking not found");
        var booking = await this.bookingRepository.RetrievByIdAsync(id);
        return booking;
    }
}
