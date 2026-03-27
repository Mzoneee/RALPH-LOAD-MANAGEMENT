using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadManagementModels;
namespace LoadManagementDataLayer
{
    public interface ILoadDataService
    {
        void AddTransaction(Load Transaction);
        Load? GetById(string id);
        List<Load> GetLoads();
        bool DeleteById(string id);
        void Update(Load transaction);  
    }
}
