using Application.Abstractions.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext _context) : IUserRepository
{
    
}
