using System;
using System.Collections.Generic;
using LoadManagementModels;
using LoadManagementDataService;

namespace LoadManagementAppService
{
    public class LoadAppService
    {
        public LoadDataService dataService = new LoadDataService();
        public Load BuyLoad(Load newTransaction)
        {
            dataService.AddTransaction(newTransaction);
            newTransaction.TransactionID = Guid.NewGuid().ToString();           
            return newTransaction;
        }

       
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length >= 10 && phoneNumber.Length <= 11 && long.TryParse(phoneNumber, out _);
        }

        public List<Load> GetLoads()
        {
            return dataService.GetLoads();
        }
    }
}