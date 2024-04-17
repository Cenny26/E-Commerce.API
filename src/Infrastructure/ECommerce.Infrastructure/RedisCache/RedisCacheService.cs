using ECommerce.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ECommerce.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _database;
        private readonly RedisCacheSettings _settings;
        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            _settings = options.Value;
            var opt = ConfigurationOptions.Parse(_settings.ConnectionString);
            _redisConnection = ConnectionMultiplexer.Connect(opt);
            _database = _redisConnection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUntilExpiration = expirationTime.Value - DateTime.Now;
            await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUntilExpiration);
        }
    }
}
