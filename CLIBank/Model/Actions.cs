using CLIBank.Views;
using CLIBank.Views.Templates;
using System.Text;
using System.Security.Cryptography;
using CLIBank.Controller;
using System.ComponentModel;


namespace CLIBank.Model;

public class Actions
{
    public Account _account = new Account();
    HomeAccount homeAccount = new HomeAccount();
    public static string? Msg { get; set; }

    private bool saveAccountTest { get; set; }



    public static string makeSha256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);

            StringBuilder hashStringBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashStringBuilder.Append(b.ToString("x2"));
            }

            return hashStringBuilder.ToString();
        }
    }



    public void addNewAccount()
    {

        Console.CursorVisible = true;
        int rateLimit = 0;

        while (true)
        {
            Console.Clear();


            if (rateLimit == 0)
            {
                MyBanners.firstBannerNewAcc();
            }
            else
            {
                MyBanners.showBanner(MyBanners.logonNewAcc, Msg);
            }



            // Get values from new account template 
            (string? document_id, string? your_name, string? password) = AddAccount.showFields();

            addAccModel newAccValues = new addAccModel(document_id, your_name, password);

            Dictionary<string, object> newAccount = newAccValues.addAccount();



            // Clear console
            Console.Clear();
            Actions.Msg = newAccount["message"].ToString();



            bool saveAccountTest = Convert.ToBoolean(newAccount["result"]);

            // IF yes, will save
            if (saveAccountTest)
            {
                Msg = "Account was created !";
                home();
                //Console.WriteLine(Msg);
            }
            

            rateLimit++;

        }

        

    }


    public void checkAuthentication()
    {

        (string document_id, string password) = Login.loginTemplate();

        string token = makeSha256Hash(document_id+password);
        _account.Account_ID = ApiQuery.getId(document_id);


        bool result = LoginModel.loginAuthentication(_account.Account_ID, token);

        switch (result)
        {
            case true:
                _account.Document_ID = document_id;
                accountHomeOptions();
                break;
            default:
                int logErrorOptions = Login.loginError("ID or pass is incorrect!");

                Console.WriteLine(_account.AttemptCount);

                _account.AttemptCount++;


                if (_account.AttemptCount > 2)
                {
                    Msg = "Attempts limit exceed [!]\n";
                    home();

                }

                if (logErrorOptions == 0) checkAuthentication();
                if (logErrorOptions == 1) checkAuthentication();

                break;
        }


    }



    public void postNewAccOptions()
    {

        AddAccount.postNewAccOptions(Msg);
    }



    public void moneyTransfer()
    {
        
        (string document_id, string value) = HomeAccount.transferTemplate();

        if (document_id == null || document_id == "" || document_id == _account.Document_ID)
        {
            Msg = "Invalid Operaion [!]";
            accountHomeOptions();
            return;
        }



        int account_id = ApiQuery.getId(document_id);


        Dictionary<string, object> trasnferResult = _account.transferValue(document_id, value);

        Msg = trasnferResult["message"].ToString();
        accountHomeOptions();
        
        

    }




    public void moneyWithdraw()
    {
       
        int rateLimit = 0;

        Msg = "Confirm authentication";

        while (true)
        {
            Console.Clear();
            if (rateLimit >= 5)
            {
                Msg = "You have exceeded request limit [!]";
                homeAccount.accOptionsTemplate(Msg);
            }
            else if (rateLimit >= 1 && rateLimit < 5)
            {
                Msg = "Authentication error [!]";
            }
            (_account.Document_ID, _account.Password) = HomeAccount.confirmAuthTemplate(Msg);
            if (_account.confirmAuthentication(_account.Password)) break; ;
            rateLimit++;
            
        }

        string value = HomeAccount.withdrowTemplate();

        int confirm = HomeAccount.confirmOperation(MyBanners.logonWithdrawAcc, value);
        if (confirm == 1) accountHomeOptions();

        Dictionary<string, object> withdrawResult =  _account.withdraw(value);

        Msg = withdrawResult["message"].ToString();


        accountHomeOptions();

    }


    public void deposit()
    {
        string depositValue = HomeAccount.depositTemplate();

        Dictionary<string, object> depositResult = _account.depositModel(depositValue);

        bool result = Convert.ToBoolean(depositResult["result"]);

        switch (result)
        {
            case true:
                Msg = depositResult["message"].ToString();
                accountHomeOptions();
                break;
            case false:
                Msg = depositResult["message"].ToString();
                accountHomeOptions();
                break;
        }


    }




    public void accountHomeOptions()
    {

        _account.Balance = ApiQuery.getValue(_account.Account_ID, "balance"); ;


        string total_balance = _account.Balance;


        if (Msg == null) Msg = " TOTAL BALANCE: " + _account.Balance + "$";
        

        int homeOpt = homeAccount.accOptionsTemplate(Msg);
        switch (homeOpt)
        {
            case 0:
                accountHomeOptions();
                break;
            case 1:
                deposit();
                break;
            case 2:
                moneyWithdraw();
                break;
            case 3:
                moneyTransfer();
                break;
            case 4:
                int result = _account.showTransactionsHistory("Transaction History");
                if (result == 0) accountHomeOptions();
                break;
            case 5:
                home();
                break;
            default:
                break;
        }
    }




    public void home()
    {
        int homeOpt = Home.homeTemplate(Msg);

        switch (homeOpt)
        {
            case 0:
                checkAuthentication();
                break;
            case 1:
                addNewAccount();
                break;
            case 2:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }



}

