using Centisoft.Domain.ValueObjects;
using Centisoft.UnitTest.Helpers.String;
using NUnit.Framework;

namespace Centisoft.Domain.UnitTests
{
    public class EmailTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_Valid_Email()
        {
            var email = Email.Create("valid@email.com");
            Assert.IsTrue(email.IsSuccess);
        }

        [Test]
        public void Create_Invalid_Email()
        {
            var email = Email.Create("invalidemail"); //invalid, does not follow pattern
            Assert.IsTrue(email.IsFailure);
        }

        [Test]
        public void Create_Invalid_Email_given_empty()
        {
            var email = Email.Create(""); //invalid empty  
            Assert.IsTrue(email.IsFailure);
        }

        [Test]
        public void Create_Invalid_Email_given_null()
        {
            var email = Email.Create(null);//invalid null
            Assert.IsTrue(email.IsFailure);
        }

        [Test]
        public void Create_Invalid_Email_Too_Long()
        {
            var email = Email.Create(StringRandom.GetRandomString(101));
            Assert.IsTrue(email.IsFailure);
        }
    }
}