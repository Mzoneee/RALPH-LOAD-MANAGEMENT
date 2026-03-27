using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadManagementModels;
using Microsoft.Data.SqlClient;
namespace LoadManagementDataLayer
{
    public class LoadDatabase : ILoadDataService
    {
        private string connectionString = @"Data Source=LAPTOP-O72KAUC7\SQLEXPRESS; Initial Catalog=LoadManagement; Integrated Security=True; TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public LoadDatabase()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public void AddTransaction(Load transaction)
        {
            var insertStatement = "INSERT INTO Transactions (TransactionID, PhoneNumber, Network, LoadType, LoadValue) VALUES (@ID, @Phone, @Net, @Type, @Val)";
            using (SqlCommand insrt = new SqlCommand(insertStatement, sqlConnection))
            {
                insrt.Parameters.AddWithValue("@ID", transaction.TransactionID);
                insrt.Parameters.AddWithValue("@Phone", transaction.PhoneNumber);
                insrt.Parameters.AddWithValue("@Net", transaction.Network);
                insrt.Parameters.AddWithValue("@Type", transaction.LoadType);
                insrt.Parameters.AddWithValue("@Val", transaction.LoadValue);

                sqlConnection.Open();
                insrt.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<Load> GetLoads()
        {
            string selectStatement = "SELECT TransactionID, PhoneNumber, Network, LoadType, LoadValue FROM Transactions";
            var loads = new List<Load>();

            using (SqlCommand slct = new SqlCommand(selectStatement, sqlConnection))
            {
                sqlConnection.Open();
                using (SqlDataReader reader = slct.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loads.Add(new Load
                        {
                            TransactionID = reader["TransactionID"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Network = reader["Network"].ToString(),
                            LoadType = reader["LoadType"].ToString(),
                            LoadValue = reader["LoadValue"].ToString()
                        });
                    }
                }
                sqlConnection.Close();
            }
            return loads;
        }

        public void Update(Load transaction)
        {
            var updateStatement = "UPDATE Transactions SET PhoneNumber=@Phone, Network=@Net, LoadType=@Type, LoadValue=@Val WHERE TransactionID=@ID";

            using (SqlCommand updt = new SqlCommand(updateStatement, sqlConnection))
            {
                updt.Parameters.AddWithValue("@Phone", transaction.PhoneNumber ?? "");
                updt.Parameters.AddWithValue("@Net", transaction.Network ?? "");
                updt.Parameters.AddWithValue("@Type", transaction.LoadType ?? "Regular");
                updt.Parameters.AddWithValue("@Val", transaction.LoadValue ?? "0");
                updt.Parameters.AddWithValue("@ID", transaction.TransactionID);

                sqlConnection.Open();
                updt.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public bool DeleteById(string id)
        {
            var deleteStatement = "DELETE FROM Transactions WHERE TransactionID = @ID";
            using (SqlCommand delt = new SqlCommand(deleteStatement, sqlConnection))
            {
                delt.Parameters.AddWithValue("@ID", id);
                sqlConnection.Open();
                int rowsAffected = delt.ExecuteNonQuery();
                sqlConnection.Close();
                return rowsAffected > 0;
            }
        }

        public Load? GetById(string id)
        {
            return GetLoads().FirstOrDefault(x => x.TransactionID == id);
        }
    }
}
        
    

