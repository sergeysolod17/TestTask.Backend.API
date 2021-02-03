using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Backend.API.Data.Entities;
using Backend.API.Data;


namespace Backend.API.Web
{
    public class UsersRepository: IUsersRepository
    {
        protected readonly string ConnectionString;      

        public UsersRepository()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("app.settings.json")
                        .Build();
            ConnectionString = configuration["ConnectionStrings:TestDatabase"];                        
        }

        //returns a list of all users
        public async Task<IEnumerable<UserEntity>> getUsersList() 
        {
            using(DataContext dataContext = new DataContext(ConnectionString))
            {
                return await dataContext.Users.ToListAsync();                
            }
        }

        //returns user with the requested id
        public async Task<UserEntity> getUserById(int id)
        {
            using(DataContext dataContext = new DataContext(ConnectionString))
            {                
                return await dataContext.Users.FindAsync(id);
            }
        }

        //returns a list of users with the requested email 
        public async Task<IEnumerable<UserEntity>> getUsersByEmail(string email)
        {
            using(DataContext dataContext = new DataContext(ConnectionString))
            {                
                return await dataContext.Users.Where(p => p.Email == email).ToListAsync();
            }
        }
    }
}