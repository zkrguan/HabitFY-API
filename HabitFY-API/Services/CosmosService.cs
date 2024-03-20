using HabitFY_API.Models;
using HabitFY_API.Models.CosmosModels;
using Microsoft.Azure.Cosmos;

// RG: your ultimate reference should be here
// https://learn.microsoft.com/en-us/dotnet/api/microsoft.azure.cosmos.container.upsertitemasync?view=azure-dotnet

namespace HabitFY_API.Services
{
    public class CosmosService
    {
        private readonly CosmosClient _client;
        private readonly string _databaseName;
        private Container _container 
        {
            get => _client.GetDatabase(_databaseName).GetContainer("UserDailyReport");
        }

        public CosmosService()
        {
            var config = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .Build();
            string connnection = config.GetConnectionString("COSMOS_DB_CONNECTIONSTRING") ?? 
                throw new InvalidOperationException("COSMOS_DB_CONNECTIONSTRING is missing in the configuration file.");
            _databaseName = config.GetConnectionString("COSMOS_DB_DATABASENAME") ?? 
                throw new InvalidOperationException("COSMOS_DB_DATABASENAME is missing in the configuration file.");
            _client = new CosmosClient(connectionString: connnection);
        }

        public async Task <UserReportCache> GetOneUserReportByUserIDAsync(string userID,string postalCode)
        {
            try
            {
                ItemResponse<UserReportCache> response = 
                    await _container.ReadItemAsync<UserReportCache>(userID, new PartitionKey(postalCode));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
