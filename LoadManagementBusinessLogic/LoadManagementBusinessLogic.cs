    using System;
    using System.Collections.Generic;
    using LoadManagementModels;
    using LoadManagementDataService;
       using LoadManagementDataLayer;
namespace LoadManagementAppService
    {
        public class LoadAppService
        {
       

        private readonly LoadDataLayerService _dataService = new LoadDataLayerService(new LoadDatabase());
        //  private readonly LoadDataLayerService _dataService = new LoadDataLayerService(new LoadJson());
        //  private readonly LoadDataLayerService _dataService = new LoadDataLayerService(new LoadManagementInMemory());

        public Load BuyLoad(Load newTransaction)
            {
            newTransaction.TransactionID = Guid.NewGuid().ToString();
            _dataService.AddTransaction(newTransaction);
            return newTransaction;
        }


            public bool IsValidPhoneNumber(string phoneNumber)
            {
                return phoneNumber.Length >= 10 && phoneNumber.Length <= 11 && long.TryParse(phoneNumber, out _);
            }

            public List<Load> GetLoads()
            {
                return _dataService.GetLoads();
            }


        public void UpdateTransaction(Load updatedLoad)
        {
        
            if (IsValidPhoneNumber(updatedLoad.PhoneNumber))
            {
     
                _dataService.Update(updatedLoad);
            }
        }

        public bool RemoveTransaction(string id)
            {
                return _dataService.DeleteById(id);
            }
        
        }
    }