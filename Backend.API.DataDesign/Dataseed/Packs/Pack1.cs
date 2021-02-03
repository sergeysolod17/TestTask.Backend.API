using System.Linq;
using Backend.API.DataDesign.DataSeed;
using Backend.API.Data;
using Backend.API.Data.Entities;


namespace Backend.API.DataDesign.DataSeed.Packs
{
    //class for data upload pack
    public class Pack1: IDataSeedPack
    {
        public bool IsPresent(Backend.API.Data.DataContext context)
        {
            var isPresent = context.Users.Any(p => p.Name == "Anton Boyko");
            return isPresent;
        }
        public void Apply(Backend.API.Data.DataContext context)
        {
            context.Users.AddRange(new []
            {
                new UserEntity { Name = "Anton Boyko", Email = "test@gmail.com", Phone = "+123456887456"},
                new UserEntity { Name = "Sergey Solod", Email = "test@gmail.com", Phone = "+383456887456"},
                new UserEntity { Name = "Ivan Ivanov", Email = "user@gmail.com", Phone = "+456987123852"},
                new UserEntity { Name = "Petro Petrov", Email = "user2@gmail.com", Phone = "+159987741369"}
            });
            context.SaveChanges();
        }
    }
}