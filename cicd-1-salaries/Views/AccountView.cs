namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using System;

    internal class AccountView
    {
        public AccountView(Account account)
        {
            accountController = new AccountController();
            Account = account;

            Console.WriteLine("Account view!\n");

            NavMenu();
        }

        private AccountController accountController;
        private Account Account { get; set; }

        private enum Nav
        {
            // TODO
            DisplayBalance,
            DisplaySalary,
            DisplayRole,
            RequestNewSalary,
            RequestNewRole,
            Exit,
        }

        private void NavMenu()
        {
            var exit = false;

            while (exit is false)
            {
                var nav = PromptNavigation();

                switch (nav)
                {
                    case Nav.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private Nav PromptNavigation()
        {
            Console.WriteLine("Select");
            Console.WriteLine(" [E] Exit");
            Console.Write("> ");
            var input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return input switch
            {
                "E" => Nav.Exit,
                _ => PromptNavigation(),
            };
        }
    }
}