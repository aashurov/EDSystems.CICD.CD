using System;
//using System.Text.Json;
using EDSystems.Application.Interfaces;
using Newtonsoft.Json;
using RedisCacheDemo.Cache;
using StackExchange.Redis;

namespace EDSystems.Persistence.Services;

public class CacheService : ICacheService
{
    private IDatabase _cacheDb;

    public CacheService()
    {
        //string primaryEndpoint = "myrediscluster.baq32s.ng.0001.use1.cache.amazonaws.com:6379,abortConnect=false"; 
        //string readerEndpoint = "myrediscluster-ro.baq32s.ng.0001.use1.cache.amazonaws.com:6379,abortConnect=false";

        //var redis = ConnectionMultiplexer.Connect("localhost:6379");
        //var redis = ConnectionMultiplexer.Connect($"{primaryEndpoint}, {readerEndpoint}");

        _cacheDb = ConnectionHelper.Connection.GetDatabase();

        //_cacheDb = redis.GetDatabase();
    }

    public T GetData<T>(string key)
    {
        var value = _cacheDb.StringGet(key);
        //var options = new JsonSerializerOptions
        //{
        //    IncludeFields = false,
        //    PropertyNameCaseInsensitive = false,
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //};
        if (!string.IsNullOrEmpty(value))
        {
            return JsonConvert.DeserializeObject<T>(value);
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
            //var options = new JsonSerializerOptions
            //{
            //    IncludeFields = true,
            //    PropertyNameCaseInsensitive = true,
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //};
            //var dataSeri = JsonConvert.SerializeObject(value);
            tto = _cacheDb.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
         }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return tto;
    }
}

