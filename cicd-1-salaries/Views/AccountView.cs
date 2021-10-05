namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using System;

    internal class AccountView
    {
        private AccountController accountController;
        private Account Account { get; set; }

        public AccountView(Account account)
        {
            accountController = new AccountController();
            Account = account;

            View();
        }

        private void View()
        {
            Console.WriteLine("Account view!\n");

            Console.WriteLine($"Logged in as {Account.Name}.\n");
        }
    }
}