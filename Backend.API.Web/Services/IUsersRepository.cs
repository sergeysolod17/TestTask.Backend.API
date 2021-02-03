using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.API.Data.Entities;


namespace Backend.API.Web
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserEntity>> getUsersList();
        Task<UserEntity> getUserById(int id);
        Task<IEnumerable<UserEntity>> getUsersByEmail(string email);        
    }
}