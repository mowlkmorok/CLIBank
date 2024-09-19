using CLIBank.Model;

namespace CLIBank.Views.Templates;

public class Login
{

    public static string Document_id { get; set; }
    public static string Token { get; set; }

    public static (string,string) loginTemplate(string msg = "Type your document id")
    {
        

        Console.CursorVisible = true;


        MyBanners.showBanner(MyBanners.logonLogin, msg);
        while (true)
        {

            Console.Write("\nYour ID: ");

            Document_id = Console.ReadLine() ?? string.Empty;



            Console.Clear();
            MyBanners.showBanner(MyBanners.logonLogin, "Type your password");
            Console.Write("\nPassowrd: ");

            Token = Console.ReadLine() ?? string.Empty;



            return (Document_id, Token);

        }

    }


    public static int loginError(string msg)
    {
        
        string[] menuOptions = new string[] { "   TRY AGAIN", "   EXIT" };
        int menuSelect = 0;

        while (true)
        {
            Console.CursorVisible = false;
            Console.Clear();
            // Add account return message

            MyBanners.showBanner(MyBanners.logonLogin, msg);

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













}
