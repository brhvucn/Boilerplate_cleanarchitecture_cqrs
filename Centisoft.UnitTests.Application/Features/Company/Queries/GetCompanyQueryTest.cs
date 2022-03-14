using Centisoft.Application.Features.Company.Queries.GetCompany;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.UnitTests.Application.Features.Company.Queries
{
    [TestClass]
    public class GetCompanyQueryTest
    {
        [TestMethod]
        public void Create_Valid_Company_Query_Expect_Success()
        {
            GetCompanyQuery query = new GetCompanyQuery(1);
            Assert.AreEqual(1, query.CompanyId);
        }

        [TestMethod]
        public void Create_InvalidCompany_Query_Given_Zero_Expect_Exception()
        {

            Assert.ThrowsException<ArgumentException>(() => new GetCompanyQuery(0));
        }

        [TestMethod]
        public void Create_InvalidCompany_Query_Given_Negative_Expect_Exception()
        {

            Assert.ThrowsException<ArgumentException>(() => new GetCompanyQuery(-1));
        }
    }
}
