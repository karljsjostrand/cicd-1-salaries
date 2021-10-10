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

            Console.WriteLine($"Logged in as {account.Name}\n");
            Console.WriteLine($"{account}\n");

            NavMenu();
        }

        private AccountController accountController;
        private Account Account { get; set; }

        private enum Nav
        {
            RequestNewRole,
            RequestNewSalary,
            RemoveAccount,
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
                    case Nav.RequestNewRole:
                        RequestNewRole();
                        break;
                    case Nav.RequestNewSalary:
                        RequestNewSalary();
                        break;
                    case Nav.RemoveAccount:
                        RemoveAccount();
                        break;
                    case Nav.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private void RemoveAccount()
        {
            throw new NotImplementedException();
        }

        private void RequestNewRole()
        {
            var role = PromptAccountRole();

            var request = new RoleRequest(Account, role);

            accountController.CreateRequest(request);
        }

        private void RequestNewSalary()
        {
            var role = PromptAccountRole();

            var request = new RoleRequest(Account, role);

            accountController.CreateRequest(request);
        }

        private int PromptNewSalary()
        {
            try
            {
                Console.WriteLine("New salary: ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return PromptNewSalary();
            }
        }

        private Role PromptAccountRole()
        {
            Console.WriteLine("Select role");
            foreach (var roleName in Enum.GetNames(typeof(Role)))
            {
                Console.WriteLine($" [{roleName}]");
            }
            Console.Write("> ");
            var input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                var role = Enum.Parse(typeof(Role), input, true);
                return (Role) role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return PromptAccountRole();
            }
        }

        private Nav PromptNavigation()
        {
            Console.WriteLine("Select");
            Console.WriteLine(" [1] Request new role");
            Console.WriteLine(" [2] Request new salary");
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