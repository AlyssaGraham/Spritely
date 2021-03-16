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
            var db = _connection.GetDatabase();
            var result = db.StringGet(key);

            return result.HasValue ? result.ToString() : ""; 
        }

        public void setValue(string value)
        {
            /*
            var keyPair = new{ key: value };
            var db = _connection.GetDatabase();
            db.StringSet(new { "key": value });
            */
        }
    }
}
