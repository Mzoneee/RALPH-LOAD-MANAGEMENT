    using System;
    using System.Collections.Generic;
    using System.Linq;
using System.Runtime.ConstrainedExecution;
using LoadManagementModels;

    namespace LoadManagementDataService
    {
        public class LoadDataService
        {
        public List<Load> transactions;

            public LoadDataService()
            {
              transactions = new List<Load>();
            }


        public void AddTransaction(Load transaction)
            {
                transactions.Add(transaction);
            }

            public List<Load> GetLoads()
            {
                return transactions;
            }

        public Load GetById(string id)
        {
            return transactions.FirstOrDefault(x => x.TransactionID == id);

        }

        }
    }