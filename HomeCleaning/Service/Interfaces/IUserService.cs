using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.DTOs.Users;

namespace HomeCleaning.Service.Interfaces;

public interface IUserService
{
    public Task<bool> AddUserAsync(User user);
    public Task<bool> UpdateAsync(User user);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<UserForResultDto> GetByIdAsync(int id);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();

}
