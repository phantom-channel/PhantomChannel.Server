using Microsoft.EntityFrameworkCore;
using PhantomChannel.Server.Application.Interfaces;
using PhantomChannel.Server.Domain.Entities;
using PhantomChannel.Server.Infrastructure.Data;

namespace PhantomChannel.Server.Application.Services;

public class UserService : IUserService
{
    private readonly PhantomDbContext _context;

    public UserService(PhantomDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEntity>> GetAllUserAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<UserEntity> GetUserByIdAsync(int id)
    {
        return (await _context.User.FindAsync(id))!;
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity> UpdateUserAsync(UserEntity user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
