using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using System.Linq;
using TestApp.Models.Services;
using TestApp.Models.Repository;
using TestApp.Models;
namespace NUnitTests
{
    class ServiceTests
    {

        [Test]
        public void GetIpAddressesTest()
        {
            IList<IpAddressModel> products = new List<IpAddressModel>
                {
                    new IpAddressModel { Id = 1, IpAdderss = "1.1.1.1/1" },

                    new IpAddressModel { Id = 2, IpAdderss = "2.2.2.2/2" },

                    new IpAddressModel { Id = 3, IpAdderss = "3.3.3.3/3" }
                };

            var mock = new Mock<INetworkAddressRepository>();

            mock.Setup(a => a.GetAllIpAddressesFromDataBase()).Returns(products);

            var serviceInstance = new HomeService(mock.Object);

            var serviceMethodCallResult = serviceInstance.GetIpAddresses();

            Assert.AreSame(products, serviceMethodCallResult);
        }


        [Test]
        public void AddIpAddressTest()
        {
            string newAddress = "4.4.4.4/4";

            var mock = new Mock<INetworkAddressRepository>();
            var serviceInstance = new HomeService(mock.Object);

            mock.Setup(a => a.AddIpAddressToDataBase(It.IsAny<string>())).Verifiable();

            serviceInstance.AddIpAddress(newAddress);

            mock.Verify();
            var actual = mock.Invocations.Count;
            

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void RemoveIpAddressTest()
        {
            int ipAddressId = 4;

            var mock = new Mock<INetworkAddressRepository>();
            var serviceInstance = new HomeService(mock.Object);

            mock.Setup(a => a.RemoveIpAddressFromDataBase(It.IsAny<int>())).Verifiable();

            serviceInstance.RemoveIpAddress(ipAddressId);
            mock.Verify();
            var actual = mock.Invocations.Count;

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void UpdateIpAddressTest()
        {
            int ipAddressId = 3;
            string ipAddressValue = "3.1.3.1/13";

            var mock = new Mock<INetworkAddressRepository>();
            var serviceInstance = new HomeService(mock.Object);

            mock.Setup(a => a.UpdateIpAddressInDataBase(It.IsAny<int>() , It.IsAny<string>())).Verifiable();

            serviceInstance.UpdateIpAddress(ipAddressId, ipAddressValue);
            mock.Verify();
            var actual = mock.Invocations.Count;

            Assert.AreEqual(1, actual);
        }


        [TestCase("1.1.3.1/31")]
        [TestCase("0.1.1.2/1")]
        [TestCase("0.11.1.2/10")]
        public void CheckIpAddressValidIpTest(string ipAddressValue)
        {

            var mock = new Mock<INetworkAddressRepository>();
            var serviceInstance = new HomeService(mock.Object);

            Assert.True(serviceInstance.CheckIpAddress(ipAddressValue));
        }

        [TestCase("-3.1.3.1/331")]
        [TestCase("0.f.1.2/32")]
        [TestCase("0.1111.1.2/0")]
        public void CheckIpAddressInvalidIpTest(string ipAddressValue)
        {
            var mock = new Mock<INetworkAddressRepository>();
            var serviceInstance = new HomeService(mock.Object);

            Assert.False(serviceInstance.CheckIpAddress(ipAddressValue));
        }
    }
}
