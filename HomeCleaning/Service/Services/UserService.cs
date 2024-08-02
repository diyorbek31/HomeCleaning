using HomeCleaning.Data.IRepositories;
using HomeCleaning.Data.Repositories;
using HomeCleaning.Domain.Entities;
using HomeCleaning.Service.Interfaces;
using HomeCleaning.Service.Exceptions;
using HomeCleaning.Service.DTOs.Users;

namespace HomeCleaning.Service.Services;

public class UserService : IUserService
{
    IRepository<User> userRepository = new Repository<User>();
    public async Task<bool> DeleteByIdAsync(int id)
    {
        var deleteResponse = await this.userRepository.DeleteByIdAsync(id);
        if (deleteResponse)
            return true;
        throw new CustomException(404, "User not found");
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var mappedUsers = new List<UserForResultDto>();
        var users = await this.userRepository.RetrievAllAsync();
        if (users is null)
            throw new CustomException(404, "Users not found");
        foreach (var user in users)
        {
            var mappedUser = new UserForResultDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
            mappedUsers.Add(mappedUser);
        }
        return mappedUsers;
    }

    public async Task<UserForResultDto> GetByIdAsync(int id)
    {
        var user = await this.userRepository.RetrievByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "User not found");
        var mappedUser = new UserForResultDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
        return mappedUser;
    }

    public async Task<bool> AddUserAsync(User user)
    {
        var users = await this.userRepository.RetrievAllAsync();
        if (users.Any(u => u.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase)))
            throw new CustomException(409, "User already exists");
        await this.userRepository.InsertAsync(user);
        return true;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        var person = await this.userRepository.RetrievByIdAsync(user.Id);
        if (person is null)
            throw new CustomException(404, "User not found");
        await this.userRepository.UpdateAsync(user);
        return true;    
    }
}
