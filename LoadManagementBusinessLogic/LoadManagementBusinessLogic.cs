using System;
using System.Collections.Generic;
using RALPH_LOAD_MANAGEMENT;

namespace LoadManagementBusinessLogic
{
    public class LoadManagementBusinessLogic
    {
       
        LoadManagementDataLayer loadService = new LoadManagementDataLayer();        
        public LoadManagementModelLayer BuyLoad(LoadManagementModelLayer newTransaction)
        {
        
            newTransaction.TransactionID = Guid.NewGuid().ToString();

            
            loadService.AddTransaction(newTransaction);

           
            return newTransaction;
        }

       
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length >= 10 && phoneNumber.Length <= 11 && long.TryParse(phoneNumber, out _);
        }
    }
}