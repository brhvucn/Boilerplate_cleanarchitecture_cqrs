using Centisoft.Domain.ValueObjects;
using Centisoft.UnitTest.Helpers.String;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.UnitTests.Domain.ValueObjects
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Create_Valid_Address()
        {
            string street = StringRandom.GetRandomString(10);
            string city = StringRandom.GetRandomString(10);
            string zipcode = StringRandom.GetRandomString(10);
            var email = Address.Create(street, city, zipcode);
            Assert.IsTrue(email.Success);
        }

        [TestMethod]
        [DataRow("", "testcity", "testzip")]
        [DataRow("teststreet", "", "testzip")]
        [DataRow("teststreet", "testcity", "")]
        public void Create_Invalid_Address_EmptyParameter(string street, string city, string zipcode)
        {
            var result = Address.Create(street, city, zipcode);
            Assert.IsTrue(result.Failure);
        }
    }
}
