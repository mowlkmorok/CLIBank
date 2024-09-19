using CLIBank.Controller;
using CLIBank.Model;
using CLIBank.Views.Templates;

namespace Program
{
    class Program
    {


        public static void Main()
        {
            //Home.home();
            //Main();

            //Console.WriteLine(ApiQuery.getToken(34));

            //ApiQuery.updateValueFromAcc("31", "balance", "300.00");

            //HomeAccount.updateValueFromAcc("test");

            //HomeAccount.accountHomeOptions("test");

            //Actions.moneyWithdraw();

            //Console.WriteLine(ApiQuery.getLogs(34));

            //Actions.homeOptions();

            Actions actions = new Actions();
            actions.home();

        }
    }

}