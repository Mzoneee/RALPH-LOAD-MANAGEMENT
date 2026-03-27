using LoadManagementDataLayer;
using LoadManagementModels;
using System.Collections.Generic;

namespace LoadManagementDataService
{
    public class LoadDataLayerService
    {

        private readonly ILoadDataService _dataService;


        public LoadDataLayerService(ILoadDataService loadDataService)
        {
            _dataService = loadDataService;
        }


        public void AddTransaction(Load transaction)
        {
            _dataService.AddTransaction(transaction);
        }

        public List<Load> GetLoads()
        {
            return _dataService.GetLoads();
        }

        public Load? GetById(string id)
        {
            return _dataService.GetById(id);
        }

        public bool DeleteById(string id)
        {
            return _dataService.DeleteById(id);
        }

        public void Update(Load transaction)
        {
            _dataService.Update(transaction);
        }
    }
}