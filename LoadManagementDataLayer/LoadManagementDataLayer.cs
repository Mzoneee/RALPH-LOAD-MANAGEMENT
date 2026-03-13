using System;
using System.Collections.Generic;
using System.Linq;
using RALPH_LOAD_MANAGEMENT.LoadModelLayer; 

namespace LoadManagementDataLayer
{
    public class LoadManagementDataLayer
    {
        public List<LoadManagementModelLayer> transactions = new List<LoadManagementModelLayer>();

        public LoadManagementDataLayer()
        {
            LoadManagementModelLayer sampleTransaction = new LoadManagementModelLayer
            {
                //placeholder values lang
                TransactionID = Guid.NewGuid().ToString(),
                PhoneNumber = "09171234567",
                Network = "Globe",
                LoadType = "Regular",
                LoadValue = "50"
            };

            transactions.Add(sampleTransaction);
        }

       
        public void AddTransaction(LoadManagementModelLayer transaction)
        {
            transactions.Add(transaction);
        }

        
      
}