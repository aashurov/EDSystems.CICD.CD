using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
namespace RedisCacheDemo.Cache
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            string primaryEndpoint = "myrediscluster.baq32s.ng.0001.use1.cache.amazonaws.com:6379,abortConnect=false";
            string readerEndpoint = "myrediscluster-ro.baq32s.ng.0001.use1.cache.amazonaws.com:6379,abortConnect=false";

            lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect($"{primaryEndpoint}, {readerEndpoint}");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}