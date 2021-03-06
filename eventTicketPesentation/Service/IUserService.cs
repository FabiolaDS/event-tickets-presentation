using System.Collections.Generic;
using System.Threading.Tasks;
using eventTicketPesentation.Models;
using eventTicketPesentation.Service.dto;

namespace eventTicketPesentation.Service
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> LoginAsync(LoginUserDTO loginUserDto);
        Task<User> UpdateUserAsync(User user);
        Task<User> GrantAdminPrivilege(long userId);
        Task<List<User>> GetAllUsersAsync();
        Task<User> RemoveAdminPrivilege(long userId);
    }
}