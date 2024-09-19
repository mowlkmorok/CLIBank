using CLIBank.Controller;
using CLIBank.Model;

namespace CLIBank.Views.Templates;

public class HomeAccount
{





    public static int backHome()
    {

        string menuOptions = "Press ENTER to BACK";
        int menuSelect = 0;

        int count = 0;

        while (true)
        {
            Console.CursorVisible = false;
            //Console.Clear();
            // Add account return message

            //MyBanners.showBanner(myBanner, "Enter to back");

            int i = 0;
            
            if (count < 1) Console.WriteLine("> "+menuOptions+" <");
            

            var keyPressed = Console.ReadKey();
            Console.Write("\b \b");


            if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        Console.Clear();
                        return 0;

                    default:
                        Console.Write("\b \b");
                        break;
                }
            }
            count++;
        }

    }





    public static int confirmOperation(string myBanner,  string value)
    {
        
        string[] menuOptions = new string[] { "  CONFIRM", "   BACK" };
        int menuSelect = 0;

        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            // Add account return message

            MyBanners.showBanner(myBanner, "Confirm Operation ?");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "----->" : "") + menuOptions[i] + (i == menuSelect ? "" : ""));
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        Console.Clear();
                        return 0;
                    case 1:
                        return 1;
                }
            }
        }

    }


    public static int youSureTransfer(string msg, string value)
    {

        string[] menuOptions = new string[] { "  CONFIRM", "   BACK" };
        int menuSelect = 0;

        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            // Add account return message

            MyBanners.showBanner(MyBanners.logonLogin, $"Withdraw {value}$. Confirm?");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "----->" : "") + menuOptions[i] + (i == menuSelect ? "" : ""));
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                }
            }
        }

    }



    public static bool youSureTransfer(string msg, string value, string destinationName = "")
    {
        
        string[] menuOptions = new string[] { "  YES", "   NO"};
        int menuSelect = 0;

        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            // Add account return message

            MyBanners.showBanner(MyBanners.logonTransferAcc, $"Transfer {value}$ to {destinationName}.\n$ Sure?");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "----->" : "") + menuOptions[i] + (i == menuSelect ? "" : ""));
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        return true;

                    case 1:
                        return false;

                }
            }
        }

    }





    public static (string, string) confirmAuthTemplate(string msg = "Confirm authentication")
    {
        Console.CursorVisible = true;

        string? document_id;
        string? password;


        MyBanners.showBanner(MyBanners.logonWithdrawAcc, msg);
        while (true)
        {

            Console.Write("\nYour ID: ");

            document_id = Console.ReadLine() ?? string.Empty;



            Console.Clear();
            MyBanners.showBanner(MyBanners.logonLogin, "Type your password");
            Console.Write("\nPassowrd: ");

            password = Console.ReadLine() ?? string.Empty;

            return (document_id, password);

        }
    }





    public int accOptionsTemplate(string msg = "Welcome to your bank !")
    {
        
        string[] menuOptions = new string[] { "  CHECK BALANCE", "  DEPOSIT", "  WITHDROW", "  TRANSFER", "  HISTORY", "  EXIT" };
        int menuSelect = 0;

        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            // Add account return message

            MyBanners.showBanner(MyBanners.logonHomeAcc, msg);

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "----->" : "") + menuOptions[i] + (i == menuSelect ? "" : ""));
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        Console.Clear();
                        //Actions.checkAuthentication();
                        return 0;
                    case 1:
                        //depositTemplate();
                        return 1;
                    case 2:
                        //Actions.moneyWithdraw();
                        return 2;
                    case 3:
                        //Actions.moneyTransfer();
                        return 3;
                    case 4:

                        //showLogsAcc();
                        return 4;
                    case 5:
                        return 5;

                }
            }
        }


    }


    public static (string, string) transferTemplate()
    {
        
        Console.CursorVisible = true;

        Console.Clear();

        MyBanners.showBanner(MyBanners.logonTransferAcc, "Type the ID");
        while (true)
        {

            Console.Write("\nTranfer to: ");

            string document_id = Console.ReadLine() ?? string.Empty;



            Console.Clear();
            MyBanners.showBanner(MyBanners.logonTransferAcc, "Value to transfer");
            Console.Write("\nValue $: ");

            string value = Console.ReadLine() ?? string.Empty;

            return (document_id, value);

        }

    }

    public static string withdrowTemplate()
    {

        Console.CursorVisible = true;

        string? value;

        Console.Clear();
        MyBanners.showBanner(MyBanners.logonWithdrawAcc, "Withdraw");
        while (true)
        {

            Console.Write("\nType the value $: ");

            value = Console.ReadLine() ?? string.Empty;

            
            break;
        }

        return value;

    }

    public static string depositTemplate()
    {

        Console.CursorVisible = true;

        string? value;

        Console.Clear();
        MyBanners.showBanner(MyBanners.logonDepositAcc, "Deposit");
        while (true)
        {

            Console.Write("\nType the value $: ");

            value = Console.ReadLine() ?? string.Empty;


            break;
        }

        return value;

    }



}
