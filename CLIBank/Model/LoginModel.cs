using CLIBank.Controller;
using CLIBank.Views.Templates;
using System.Runtime.CompilerServices;

namespace CLIBank.Model;

public class LoginModel
{


    public static bool loginAuthentication(int account_id, string tokenInputed, string msg = null)
    {

        string? token = ApiQuery.getValue(Convert.ToInt32(account_id), "token");


        if (tokenInputed == token)
        {
            return true;
        }



       


        return false;
        
    }


}
