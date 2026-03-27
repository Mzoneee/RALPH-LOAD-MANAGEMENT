using LoadManagementDataLayer;
using LoadManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadManagementDataService
{
    public class LoadInMemoryData : ILoadDataService
    {
       
        private List<Load> _transactions;

        public LoadInMemoryData()
        {
            _transactions = new List<Load>();

        }

        public void AddTransaction(Load transaction)
        {
            _transactions.Add(transaction);
        }

        public List<Load> GetLoads()
        {
            return _transactions;
        }

        public Load? GetById(string id)
        {
            return _transactions.FirstOrDefault(x => x.TransactionID == id);
        }

        public bool DeleteById(string id)
        {
            var target = _transactions.FirstOrDefault(x => x.TransactionID == id);
            if (target != null)
            {
                _transactions.Remove(target);
                return true;
            }
            return false;
        }

        public void Update(Load transaction)
        {
            var existing = GetById(transaction.TransactionID);
            if (existing != null)
            {
                existing.PhoneNumber = transaction.PhoneNumber;
                existing.Network = transaction.Network;
                existing.LoadValue = transaction.LoadValue;
                existing.LoadType = transaction.LoadType;
            }
        }
    }
}