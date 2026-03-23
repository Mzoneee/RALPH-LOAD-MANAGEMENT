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


        public void UpdateTransaction(Load updatedLoad)
        {
            var existing = dataService.GetById(updatedLoad.TransactionID);
            if (existing != null)
            {
                if (IsValidPhoneNumber(updatedLoad.PhoneNumber))
                {
                    existing.PhoneNumber = updatedLoad.PhoneNumber;
                    existing.Network = updatedLoad.Network;
                    existing.LoadValue = updatedLoad.LoadValue;
                }
            }
        }

        public bool RemoveTransaction(string id)
        {
            return dataService.DeleteById(id);
        }
        
    }
}