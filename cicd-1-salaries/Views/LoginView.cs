namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal enum Navigation
    {
        Login,
        Exit,
    }

    internal class LoginView
    {
        public LoginView()
        {
            Nav();
        }

        private User User { get; set; }

        private void Nav()
        {
            while (User is null)
            {
                var nav = PromptNavigation();

                switch (nav)
                {
                    case Navigation.Login:
                        Login();
                        break;
                    case Navigation.Exit:
                        return;
                }
            }
        }

        private void Login()
        {
            var (name, password) = PromptLoginDetails();
            User = new Admin(name, password, Role.Manager); // TODO get user model from user controller

            // Create new view based on user type.
            if (User is Admin)
            {
                new AdminView();
            }
            else if (User is Account)
            {
                new AccountView();
            }
        }

        private Navigation PromptNavigation()
        {
            Console.WriteLine("Select");
            Console.WriteLine(" [1] Login");
            Console.WriteLine(" [E] Exit");
            Console.Write("> ");
            var input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return input switch
            {
                "1" => Navigation.Login,
                "E" => Navigation.Exit,
                _ => PromptNavigation(),
            };
        }

        private (string name, string password) PromptLoginDetails()
        {
            Console.WriteLine("Login\n");
            Console.Write("User: ");
            var name = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            return (name, password);
        }
    }
}
