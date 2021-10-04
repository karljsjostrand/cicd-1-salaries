namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Models;

    internal class AccountView
    {
        public AccountView(Account account)
        {
            View();
        }

        private void View()
        {
            System.Console.WriteLine("Account view\n");
        }
    }
}