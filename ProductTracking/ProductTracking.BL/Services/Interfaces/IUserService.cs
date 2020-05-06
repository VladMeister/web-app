using ProductTracking.BL.DTO;
using System.Collections.Generic;

namespace ProductTracking.BL.Services.Interfaces
{
    public interface IUserService
    {
        void DeleteUser(UserDto userDTO);
        bool ExistingUser(string login, string password);
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int? id);
        UserDto GetUserByLogin(string userLogin);
        string GetUserRole(string userLogin);
        string[] GetUserRolesNames();
        void RegisterUser(UserDto userDTO);
        void UpdateUser(UserDto userDTO);
    }
}