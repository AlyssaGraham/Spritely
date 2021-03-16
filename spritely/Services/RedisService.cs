using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace spritely.Services
{
    public class RedisService : IDisposable
    {
        private bool disposedValue;

        private readonly string _connectionString;
        public ConnectionMultiplexer connection;

        public RedisService(IConfiguration config)
        {
            var host = config.GetValue<string>("Redis:host");
            var port = config.GetValue<int>("Redis:port");
            var retries = config.GetValue<int>("Redis:retries") == 0 ? 3 : config.GetValue<int>("Redis.retries");


            _connectionString = $"{host}:{port},connectRetry={retries}";
        }

        public void connect()
        {
            try
            {
                connection = ConnectionMultiplexer.Connect(_connectionString);
            }
            catch (RedisConnectionException ex)
            {
                throw ex;
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    connection.Close();
                    connection.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RedisService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
