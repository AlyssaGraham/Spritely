using spritely.Services;
using StackExchange.Redis;

namespace spritely.Repositories
{
    public class UrlStore
    {
        private ConnectionMultiplexer _connection;

        public UrlStore(RedisService redisConnection)
        {
            _connection = redisConnection.connection;
        }

        public string getValue(string key)
        {
            try
            {
                var db = _connection.GetDatabase();
                var result = db.StringGet(key);

                return result.HasValue ? result.ToString() : "";
            }
            catch(RedisException ex)
            {
                throw ex;
            }
        }

        public void setValue(string key, string value)
        {
            try
            {
                var db = _connection.GetDatabase();
                db.StringSet(key, value);
            }
            catch(RedisException ex)
            {
                throw ex;
            }
        }
    }
}
