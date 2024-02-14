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
            get => _client.GetDatabase(_databaseName).GetContainer("UserReminderSetting");
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

        public async Task <UserReminderSetting> GetOneReminderSettingByUserIDAsync(string objID, string userID)
        {
            try
            {
                ItemResponse<UserReminderSetting> response = 
                    await _container.ReadItemAsync<UserReminderSetting>(objID, new PartitionKey(userID));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        // RG: This is for backend internal use only, do not connect to the frontned. 
        // Input would be 
        // For bulk operation, the function must be async because you don't want to block the main thread for too long.
        public async Task<IEnumerable<UserReminderSetting>> GetReminderSettingsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<UserReminderSetting>(new QueryDefinition(queryString));
            List<UserReminderSetting> results = new List<UserReminderSetting>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
        public async Task UpdateSettingAsync(string partitionId, UserReminderSetting setting)
        {
            await _container.UpsertItemAsync<UserReminderSetting>(setting, new PartitionKey(partitionId));
        }

        public async Task AddItemAsync(UserReminderSetting setting)
        {
            await this._container.CreateItemAsync<UserReminderSetting>(setting, new PartitionKey(setting.UserId));
        }
    }
}
