using Microsoft.Extensions.Configuration;

namespace Dapper.Extensions.Linq.Core.Sessions
{
    public class StaticConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString(string connectionStringName)
        {
            var builder = new ConfigurationBuilder();
            var config = builder.Build();

            return config.GetConnectionString(connectionStringName);


            //var config = ConfigurationManager.ConnectionStrings[connectionStringName];
            //if (config == null) throw new NullReferenceException(string.Format("Connection string '{0}' not found", connectionStringName));
            //return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }

    public class StoredConnectionStringProvider : IConnectionStringProvider
    {
        private IConfiguration _configuration;

        public StoredConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString(string connectionStringName)
        {
            return _configuration.GetConnectionString(connectionStringName);

            //var config = ConfigurationManager.ConnectionStrings[connectionStringName];
            //if (config == null) throw new NullReferenceException(string.Format("Connection string '{0}' not found", connectionStringName));
            //return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }
}
