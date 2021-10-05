namespace SalariesTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class IntegrationTests
    {
        //private adminController = new AdminController

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Test_LoginAccountOrAdmin()
        {
            // log in as account user, user is logged in as account
            // log in as admin user, user is logged in as admin
        }

        [Test]
        public void Test_LoginAdminAndEditRequest()
        {
            // log in as admin, user is logged in as admin
            // edit a request
            // request is edited as expected
        }
    }
}
