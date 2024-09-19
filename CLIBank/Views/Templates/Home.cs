using CLIBank.Model;

namespace CLIBank.Views.Templates;

public class Home
{

    public static int homeTemplate(string msg)
    {
        string[] menuOptions = new string[] { "    LOGIN", "    NEW ACCOUNT", "    EXIT" };
        int menuSelect = 0;

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine("++++++++++++++++++++++++++|");
            Console.WriteLine("+  Wellcome to CLI Bank  +|");
            Console.WriteLine("++++++++++++++++++++++++++|");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$|");
            Console.WriteLine($"\n{msg}");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "------->" : "") + menuOptions[i] + (i == menuSelect ? "" : ""));
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
                        //Actions.checkAuthentication();
                        
                    case 1:
                        return 1;
                        //Actions actions = new Actions();
                        //actions.addNewAccount();

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }


    public static void login()
    {
        Console.Clear();
        //MyBanners.showLoginBanner();
        Console.ReadLine();
    }

    public static void addAccount()
    {
        Console.Clear();
        //MyBanners.showAddAccountBanner();

        Console.ReadLine();
    }

    public static void exit()
    {
        Console.WriteLine("Exit ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }

    public static void Reparation()
    {
        Console.WriteLine("Reparation ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }

    public static void Garantie()
    {
        Console.WriteLine("Garantie ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }

}
