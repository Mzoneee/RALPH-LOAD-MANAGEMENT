using System;
using System.Collections.Generic;
using System.Linq;
using LoadManagementModels;

namespace LoadManagementDataService
{
    public class LoadDataService
    {
        public List<Load> transactions = new List<Load>();

        public LoadDataService()
        {
            Load sampleTransaction = new Load
            {
                //placeholder values lang
                TransactionID = Guid.NewGuid().ToString(),
                PhoneNumber = "09174234567",
                Network = "Globe",
                LoadType = "Regular",
                LoadValue = "50"
            };

            transactions.Add(sampleTransaction);
        }


        public void AddTransaction(Load transaction)
        {
            transactions.Add(transaction);
        }



    }
}