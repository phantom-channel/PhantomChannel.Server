// PhantomChannel.Server.Application/Interfaces/IUserService.cs
using PhantomChannel.Server.Domain.Entities;

namespace PhantomChannel.Server.Application.Interfaces;

public interface IUserService
{
    Task<UserEntity> GetUserByIdAsync(int id);
    Task<UserEntity> CreateUserAsync(UserEntity user);
    Task<UserEntity> UpdateUserAsync(UserEntity user);
    Task<bool> DeleteUserAsync(int id);
}
