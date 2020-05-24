using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSWebApiDapperMySql
{
    public class AppSettingsConfiguration
    {
        static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
                                                                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                                .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
                                                                .Build();



        public class DataBase
        {
            public static string ConnectionStringMySql { get { return configuration["ConnectionStringMySql"]; } }
        }


    }
}
