using HomeCleaning.Domain.Entities;


namespace HomeCleaning.Service.Interfaces;

public interface IBookingService
{
    public Task<bool> BookingAsync(Booking booking);
    public Task<Booking> GetByIdAsync(int id);
    public Task<IEnumerable<Booking>> GetAllAsync();
    public Task<IEnumerable<Provider>> BookByPriceAsync(decimal price);
    public Task<bool> CancelBookingById(int id);
}
