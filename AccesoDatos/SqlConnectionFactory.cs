﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos
{
    public class SqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }
    }
}
