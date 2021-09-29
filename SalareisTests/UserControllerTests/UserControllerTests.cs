using cicd_1_salaries.Controllers;
using cicd_1_salaries.Models;
using cicd_1_salaries.Models.Data;
using NUnit.Framework;

namespace SalareisTests
{
    [TestFixture]
    public class UserControllerTests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void IsValidLoginTest()
        {
            UserController userController = new UserController();
            string name = "Mohammad";
            string pass = "1244";
            var expectedUser = new Account(name, pass,Occupation.Developer);
            var actualUser = userController.Login(name,pass);
            Assert.AreEqual();
           ;
        }
    }
}