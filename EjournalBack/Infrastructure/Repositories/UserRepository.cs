using AutoMapper;
using EjournalBack.Domain.DTO;
using EjournalBack.Domain.Models;
using EjournalBack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace EjournalBack.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ILogger _logger;
        private readonly JournalDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ILogger logger, JournalDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetByLogin(string login)
        {
            var user = await _context.SiteUsers
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Login == login);
            
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO?> Authorize(string login, string passwordHash)
        {
            var user = await _context.SiteUsers
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == passwordHash);
            
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}