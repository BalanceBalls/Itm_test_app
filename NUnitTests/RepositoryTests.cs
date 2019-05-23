using NUnit.Framework;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using TestApp.Models.Repository;
using TestApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;



namespace Tests
{
    public class Tests
    {
        
        private const string ConnectionString = "Data Source=(localdb)\\LocalDB;Initial Catalog=ITMIpList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        private static IConfiguration _config;
        private NetworkAddressRepository _repository;
        protected IDbConnection Connection;

        
        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(@"C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\NUnitTests")
                   .AddJsonFile("appsettings.test.json", optional: false)
                   .AddEnvironmentVariables();
            IConfiguration config = builder.Build();
            _config = config;
            string temp = _config.GetConnectionString("DefaultConnection");
            Connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            _repository = new NetworkAddressRepository(_config);
        }


        [Test]
        public void AddingSubnetToDatabaseTest()
        {
            const string testSubnet = "1.2.3.4/56";
            var countExpected = 1;

            int actualValue;
            
            using (var conn = Connection)
            {
                conn.Open();
                
                countExpected += int.Parse(conn.ExecuteScalar<string>(@"
select count(*) from IpAddresses
"));
                _repository.AddIpAddressToDataBase(testSubnet);

                actualValue = int.Parse(conn.ExecuteScalar<string>(@"
select count(*) from IpAddresses
"));

                conn.Execute($@"
delete from IpAddresses
Where IpAddress = @{nameof(testSubnet)}
",  new { testSubnet });
            }

            Assert.AreEqual(countExpected, actualValue);
        }



        [Test]
        public void RemovingSubnetFromDatabaseTest()
        {

            const string testSubnet = "1.2.3.4/56";

            int countExpected = 0;

            int actualValue;

            using (var conn = Connection)
            {
                conn.Open();

                conn.Execute($@"
insert into	IpAddresses  (IpAddress) 
values
(  
    @{nameof(testSubnet)}
)
", new { testSubnet });

                int _id = conn.ExecuteScalar<int>($@"
select Id from IpAddresses
where IpAddress = @{nameof(testSubnet)}
",new { testSubnet });

                _repository.RemoveIpAddressFromDataBase(_id);

                actualValue = conn.ExecuteScalar<int>($@"
select Id from IpAddresses
where IpAddress = @{nameof(testSubnet)}
", new { testSubnet });

                conn.Execute($@"
delete from IpAddresses
where IpAddress = @{nameof(testSubnet)}
", new { testSubnet });
            }

            Assert.AreEqual(countExpected, actualValue);
        }



        [Test]
        public void UpdatingSubnetInDatabaseTest()
        {
            const string testSubnet = "1.2.3.4/56";
            const string changedTestSubnet = "1.3.3.4/91";

            int countExpected = 0;

            string actualValue;

            using (var conn = Connection)
            {
                conn.Open();

                conn.Execute($@"
insert into	IpAddresses  (IpAddress) 
values
(  
    @{nameof(testSubnet)}
)
", new { testSubnet });

                int _id = conn.ExecuteScalar<int>($@"
select Id from IpAddresses
where IpAddress = @{nameof(testSubnet)}
", new { testSubnet });


                _repository.UpdateIpAddressInDataBase(_id , changedTestSubnet);

                actualValue = conn.ExecuteScalar<string>($@"
select IpAddress from IpAddresses
where Id = @{nameof(_id)}
", new { _id });

                conn.Execute($@"
delete from IpAddresses
where Id = @{nameof(_id)}
", new { _id });
            }

            Assert.AreEqual(changedTestSubnet, actualValue);
        }

        [Test]
        public void GetIpAddressesFromDatabase()
        {
            const string testSubnet = "1.2.3.4/56";


            int countExpected = 1;

            int actualValue;

            using (var conn = Connection)
            {
                conn.Open();

                conn.Execute($@"
insert into	IpAddresses  (IpAddress) 
values
(  
    @{nameof(testSubnet)}
)
", new { testSubnet });

                actualValue = conn.ExecuteScalar<int>($@"
select count(*) from IpAddresses
");

                conn.Execute($@"
delete from IpAddresses
where IpAddress = @{nameof(testSubnet)}
", new { testSubnet });

            }

            Assert.GreaterOrEqual(countExpected, actualValue);

        }
    }
}