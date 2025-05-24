using E_Commerce.Core.Interfaces.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class CashService : ICashService
    {
        private readonly IDatabase _database;
        public CashService(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<string?> GetCashResponseAsync(string Key)
        {
            var response = await _database.StringGetAsync(Key);
            return response.IsNullOrEmpty ? null :response.ToString(); 
        }

        public async Task SetCashResponseAsync(string Key, object response, TimeSpan time)
        {
            var serializedResponse = JsonSerializer.Serialize(response ,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
          await _database.StringSetAsync(Key, serializedResponse , time);
        }
    }
}
