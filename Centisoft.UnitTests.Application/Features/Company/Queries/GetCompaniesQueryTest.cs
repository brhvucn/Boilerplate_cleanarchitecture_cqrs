using Centisoft.Application.Features.Company.Queries.GetAllCompanies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Centisoft.UnitTests.Application.Features.Company.Queries
{
    [TestClass]
    public class GetCompaniesQueryTest
    {
        [TestMethod]
        public void Create_Query_Expect_Success()
        {
            GetAllCompaniesQuery query = new GetAllCompaniesQuery();
            //no params, always true. Placeholder test.
            Assert.IsTrue(true); //
        }
    }
}
