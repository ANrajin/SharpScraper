using Autofac;
using StockData.Domain.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class WorkerModule:Module
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public WorkerModule(string connectionString, string migrationAssembly,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
