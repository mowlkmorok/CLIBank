using CLIBank.Model;
using System.Globalization;

namespace CLIBank.Views.Templates;

public class AddAccount
{
    
    public static (string, string, string) showFields()
    {
        string? document_id;
        string? your_name;
        string? password;

        Console.Write("Type your document id: ");

        document_id = Console.ReadLine() ?? string.Empty;




        Console.Write("Type your document name: ");
        your_name = Console.ReadLine() ?? string.Empty;


        Console.Write("Type your passowrd: ");
        password = Console.ReadLine() ?? string.Empty;


       

        return (document_id, your_name, password);

    }




    public static void postNewAccOptions(string msg)
    {
        
        string[] menuOptions = new string[] { "   LOGIN", "   EXIT" };
        int menuSelect = 0;

        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            // Add account return message

            MyBanners.showBanner(MyBanners.logonNewAcc, msg);

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
                        Login.loginTemplate();
                        break;
                    case 1:

                        break;
                }
            }
        }
    }

}
