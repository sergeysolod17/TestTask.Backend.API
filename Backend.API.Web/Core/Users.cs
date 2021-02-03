using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Backend.API.Data.Entities;

namespace Backend.API.Web.Core
{
    class Users
    {
        private IUsersRepository repository;        
        public Users()
        {
            repository = new UsersRepository();
        }

        //returns user with the requested id
        public async Task<UserEntity> getById(int id)
        {
            return await repository.getUserById(Convert.ToInt32(id));
        }

        //returns a list of all users
        public async Task<IEnumerable<UserEntity>> getUsersList()
        {
            return await repository.getUsersList();
        }

        //returns a list of users with the requested email 
        public async Task<IEnumerable<UserEntity>> getUsersByEmail(string email)
        {
            return await repository.getUsersByEmail(email);
        }
    }
}
