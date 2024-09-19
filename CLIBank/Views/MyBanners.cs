using CLIBank.Model;

namespace CLIBank.Views;

public class MyBanners
{

    public static string logonLogin = "$ + + + + Login + + + + + + + + + + + + + $|";
    public static string logonNewAcc ="$ + + + Sign-up + + + + + + + + + + + + + $|";
    public static string logonHomeAcc="$+ + + Home account + + + + + + + + + + + $|";
    public static string logonWithdrawAcc = "$+ + + + Withdraw + + + + + + + + + + +$|";
    public static string logonTransferAcc = "$+ + + + Transfer + + + + + + + + + + +$|";
    public static string logonDepositAcc =  "$+ + + + Deposit  + + + + + + + + + + +$|";
    public static string logonHistory =     "$+ Transaction History + + + + + + + + $|";

    public static string setInfoMsg = "Set yours informations ";
    
    public static string transferToMsg = "Transfer {value} to {destinationName} ?";
    public static string tranferSetLogs = "Operation: tranfer\t";
    public static string withdrawSetLogs = "Operation: withdraw\t";
    public static string depositSetLogs = "Operation: deposit\t";



    public static string AccDefaultMsg { get; set; }
    public static string LoginDefaultMsg { get; set; }



    public MyBanners(string accDefaultMsg = "Set yours informations ", string loginDefaultMsg = "Wel come to login")
    {
        AccDefaultMsg = accDefaultMsg;
        LoginDefaultMsg = loginDefaultMsg;
    }


    public static void firstBannerNewAcc()
    {
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$|");
        Console.WriteLine("$ + + + Sign-up + + + + +$|");
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$|");
        Console.WriteLine("$--------------------------");
        Console.WriteLine($"$ Set yours informations");
        Console.WriteLine("$--------------------------");
    }

    public static void showBanner(string logon, string msg)
    {




        if (logon == logonNewAcc)
        {
            Actions.Msg = AccDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonNewAcc);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");
        }
        else if (logon == logonLogin)
        {
            Actions.Msg = LoginDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonLogin);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");

        }

        else if (logon == logonHomeAcc)
        {
            Actions.Msg = LoginDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonHomeAcc);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------\n");

        }
        else if (logon == logonWithdrawAcc)
        {
            Actions.Msg = LoginDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonWithdrawAcc);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");

        }

        else if (logon == logonTransferAcc)
        {
            Actions.Msg = LoginDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonTransferAcc);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");

        }
        else if (logon == logonDepositAcc)
        {
            Actions.Msg = LoginDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonDepositAcc);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");

        }
        else if (logon == logonHistory)
        {
            Actions.Msg = LoginDefaultMsg;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonHistory);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");


        }
        else if (logon == logonNewAcc)
        {
            Console.Clear();
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine(logonNewAcc);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("$------------------------------------------");
            Console.WriteLine($"$ {msg}");
            Console.WriteLine("$------------------------------------------");
        }

    }


}
