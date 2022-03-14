using Centisoft.Domain.ValueObjects;
using Centisoft.UnitTest.Helpers.String;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.ValueObjects.UnitTests.ValueObjects
{
    public class AddressTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_Valid_Address()
        {
            string street = StringRandom.GetRandomString(10);
            string city = StringRandom.GetRandomString(10);
            string zipcode = StringRandom.GetRandomString(10);
            var email = Address.Create(street, city, zipcode);
            Assert.IsTrue(email.IsSuccess);
        }

        [Test]
        [Row]
        public void Create_Invalid_Address_StreetEmpty()
        {

        }
    }
}
