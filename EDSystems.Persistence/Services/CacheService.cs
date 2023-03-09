using System;
using System.Text.Json;
using EDSystems.Application.Interfaces;
using StackExchange.Redis;

namespace EDSystems.Persistence.Services;

public class CacheService : ICacheService
{
    private IDatabase _cacheDb;

    public CacheService()
    {
        var redis = ConnectionMultiplexer.Connect("localhost:6379");

        _cacheDb = redis.GetDatabase();
    }
   
    public T GetData<T>(string key)
    {
        var value = _cacheDb.StringGet(key);
        var options = new JsonSerializerOptions
        {
            IncludeFields = false,
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        if (!string.IsNullOrEmpty(value))
        {
            return JsonSerializer.Deserialize<T>(value, options);
        }

        return default;
    }

    public object RemoveData(string key)
    {
        var _exist = _cacheDb.KeyExists(key);

        if (_exist)
            return _cacheDb.KeyDelete(key);
        return false;
    }

    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        bool tto = true;
        try
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var dataSeri = JsonSerializer.Serialize(value, options);
            tto = _cacheDb.StringSet(key, JsonSerializer.Serialize(value, options), expiryTime);
         }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return tto;
    }
}

