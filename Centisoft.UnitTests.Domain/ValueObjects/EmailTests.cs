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
            Assert.IsTrue(email.Success);
        }

        [TestMethod]
        public void Create_Invalid_Email()
        {
            var email = Email.Create("invalidemail"); //invalid, does not follow pattern
            Assert.IsTrue(email.Failure);
        }

        [TestMethod]
        public void Create_Invalid_Email_given_empty()
        {
            var email = Email.Create(""); //invalid empty  
            Assert.IsTrue(email.Failure);
        }

        [TestMethod]
        public void Create_Invalid_Email_given_null()
        {
            var email = Email.Create(null);//invalid null
            Assert.IsTrue(email.Failure);
        }

        [TestMethod]
        public void Create_Invalid_Email_Too_Long()
        {
            var email = Email.Create(StringRandom.GetRandomString(101));
            Assert.IsTrue(email.Failure);
        }

        [TestMethod]
        public void Create_Two_Emails_Expect_Equal()
        {
            string email = "test@test.dk";
            Email email1 = Email.Create(email).Value;
            Email email2 = Email.Create(email).Value;
            Assert.AreEqual(email1, email2);
        }

        [TestMethod]
        public void Create_Two_Emails_Expect_Different()
        {
            string email1 = "test1@test.dk";
            string email2 = "test2@test.dk";
            var testEmail1 = Email.Create(email1).Value;
            var testEmail2 = Email.Create(email2).Value;
            Assert.AreNotEqual(testEmail1, testEmail2);
        }
    }
}
