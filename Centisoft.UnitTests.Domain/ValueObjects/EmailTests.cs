using Centisoft.Domain.ValueObjects;
using Centisoft.UnitTest.Helpers.String;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Centisoft.UnitTests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Create_Valid_Email()
        {
            var email = Email.Create("valid@email.com");
            Assert.IsTrue(email.IsSuccess);
        }

        [TestMethod]
        public void Create_Invalid_Email()
        {
            var email = Email.Create("invalidemail"); //invalid, does not follow pattern
            Assert.IsTrue(email.IsFailure);
        }

        [TestMethod]
        public void Create_Invalid_Email_given_empty()
        {
            var email = Email.Create(""); //invalid empty  
            Assert.IsTrue(email.IsFailure);
        }

        [TestMethod]
        public void Create_Invalid_Email_given_null()
        {
            var email = Email.Create(null);//invalid null
            Assert.IsTrue(email.IsFailure);
        }

        [TestMethod]
        public void Create_Invalid_Email_Too_Long()
        {
            var email = Email.Create(StringRandom.GetRandomString(101));
            Assert.IsTrue(email.IsFailure);
        }
    }
}
