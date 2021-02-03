using System.Collections.Generic;
using Backend.API.DataDesign.DataSeed.Packs;
using Backend.API.Data;
using Backend.API.DataDesign.DataSeed;

namespace Backend.API.DataDesign.DataSeed
{
    public class DataSeedOrchestrator
    {
        private readonly DataContext _dataContext;
        private readonly List<IDataSeedPack> _dataSeedPacks = new List<IDataSeedPack>
        {
            new Pack1()
        };

        public DataSeedOrchestrator(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void ApplyAll()
        {
            foreach(var pack in _dataSeedPacks)
            {
                if(!pack.IsPresent(_dataContext))
                {
                    pack.Apply(_dataContext);
                }
            }
        }
    }
}