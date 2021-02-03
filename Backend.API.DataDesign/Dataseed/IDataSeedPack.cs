using Backend.API.Data;

//interface for data upload packs
namespace Backend.API.DataDesign.DataSeed
{
    public interface IDataSeedPack
    {
        bool IsPresent(Backend.API.Data.DataContext context);        
        void Apply(Backend.API.Data.DataContext context);
    }
}