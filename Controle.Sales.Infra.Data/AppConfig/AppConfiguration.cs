using System;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.AppConfig
{
    public static class AppConfiguration
    {
        private static IConfiguration _currentConfig;

        public static void SetConfig(IConfiguration configuration)
        {
            _currentConfig = configuration;
        }


        public static string GetConfiguration(string configKey)
        {
            try
            {
                string connectionString = _currentConfig.GetConnectionString(configKey);
                return connectionString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
