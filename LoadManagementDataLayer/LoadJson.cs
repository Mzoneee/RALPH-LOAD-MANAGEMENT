using LoadManagementModels;
using System.Text.Json;

namespace LoadManagementDataLayer
{
    public class LoadJson : ILoadDataService
    {
        private List<Load> _loads = new List<Load>();

        private string _jsonFileName;

        public LoadJson()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Load.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {

            if (File.Exists(_jsonFileName))
            {
                RetrieveDataFromJsonFile();
            }
            else
            {
   
                _loads = new List<Load>();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.Create(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Load>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , _loads); 
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                _loads = JsonSerializer.Deserialize<List<Load>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void AddTransaction(Load transaction)
        {
            _loads.Add(transaction);
            SaveDataToJsonFile();  
        }

        public List<Load> GetLoads()
        {
            RetrieveDataFromJsonFile();
            return _loads;
        }

        public Load? GetById(string id)
        {
            RetrieveDataFromJsonFile();
            return _loads.Where(x => x.TransactionID == id).FirstOrDefault();
        }

        public bool DeleteById(string id)
        {
            RetrieveDataFromJsonFile();
            var target = _loads.FirstOrDefault(x => x.TransactionID == id);

            if (target != null)
            {
                _loads.Remove(target);
                SaveDataToJsonFile();
                return true;
            }
            return false;
        }


        public void Update(Load transaction)
        {
            RetrieveDataFromJsonFile();


            var existingLoad = _loads.FirstOrDefault(x => x.TransactionID == transaction.TransactionID);

            if (existingLoad != null)
            {
                existingLoad.PhoneNumber = transaction.PhoneNumber;
                existingLoad.Network = transaction.Network;
                existingLoad.LoadType = transaction.LoadType;
                existingLoad.LoadValue = transaction.LoadValue;
            }

            SaveDataToJsonFile();
        }
    }
}