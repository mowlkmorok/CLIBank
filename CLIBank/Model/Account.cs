using CLIBank.Controller;
using CLIBank.Views;
using CLIBank.Views.Templates;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CLIBank.Model;

public class Account
{

    public int Account_ID { get; set; }
    public string? Document_ID { get; set; }

    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Balance { get; set; }
    public string? Logs { get; set; }
    public int AttemptCount { get; set; }
    public int Block { get; set; }


    public Dictionary<string, object> transferValue(string document_id, string inputedValue)
    {

        Dictionary<string, object> returnMsg = new Dictionary<string, object>();



        string account_id = ApiQuery.getId(document_id).ToString();
        string destinationName = ApiQuery.getValue(Convert.ToInt32(account_id), "your_name");


        if (Convert.ToInt32(account_id) == 0)
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Fail to transfer [!]");
            return returnMsg;
        }

        

        // -destination values/balance
        float balance = float.Parse(ApiQuery.getBlance(account_id), CultureInfo.InvariantCulture);
        float value = float.Parse(inputedValue, CultureInfo.InvariantCulture);
        
        
        //---verify update my balance
        string myBalance = ApiQuery.getValue(Account_ID, "balance");
        float myBalanceFloat = float.Parse(myBalance, CultureInfo.InvariantCulture);



       
        //------------------




        float myUpdatedBalance = myBalanceFloat - value;



        if (myUpdatedBalance <= 0f)
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Insufficient Funds [!]");
            return returnMsg;
        }

        string myNewBalance = myUpdatedBalance.ToString("F2", CultureInfo.InvariantCulture);


        float plusBalance = balance + value;
        string newBalance = plusBalance.ToString("F2", CultureInfo.InvariantCulture);
     

        try
        {
            switch (HomeAccount.youSureTransfer("", inputedValue, destinationName))
            {
                case true:
                    ApiQuery.updateValueFromAcc(account_id, "balance", newBalance);
                    ApiQuery.updateValueFromAcc(Account_ID.ToString(), "balance", myNewBalance);

                    returnMsg.Add("result", true);
                    returnMsg.Add("message", "  Transfer Success !");

                    setLog($"{MyBanners.tranferSetLogs, -15}-\t{"Value "+value.ToString("F2", CultureInfo.InvariantCulture)+"$  to -> ", -15} {destinationName, -20} -\t");

                    return returnMsg;


                case false:

                    returnMsg.Add("result", false);
                    returnMsg.Add("message", "  Fail to transfer [!]");


                    return returnMsg;
                default:
            }
           ;

            



            return returnMsg;

        }
        catch (Exception)
        {

            throw;
        }


    }


    public Dictionary<string, object> withdraw(string inputedValue)
    {
        Dictionary<string, object> returnMsg = new Dictionary<string, object>();

        
        if (Convert.ToInt32(Account_ID) == 0)
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Withdraw Fail [!]");
            return returnMsg;
        }

 

        float balance = float.Parse(ApiQuery.getBlance(Account_ID.ToString()), CultureInfo.InvariantCulture);
        float value = float.Parse(inputedValue, CultureInfo.InvariantCulture);



        float lessBalance = balance - value;

        if (lessBalance <= 0)
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Insufficient Funds [!]\n$ Please deposit founds to proceed");
            return returnMsg;
        }



        string newBalance = lessBalance.ToString("F2", CultureInfo.InvariantCulture);


        try
        {

            ApiQuery.updateValueFromAcc(Account_ID.ToString(), "balance", newBalance);
            returnMsg.Add("result", true);
            returnMsg.Add("message", "Withdraw Success !");

            setLog($"{MyBanners.withdrawSetLogs, -15}-\t{"Value "+value.ToString("F2", CultureInfo.InvariantCulture)+"$", -40} -\t");


            return returnMsg;

        }
        catch (Exception)
        {

            returnMsg.Add("result", false);
            returnMsg.Add("message", "Withdraw Fail [!]");
            return returnMsg;


            throw;
        }





    }



    public Dictionary<string, object> depositModel(string inputedValue)
    {
        Dictionary<string, object> returnMsg = new Dictionary<string, object>();


        try
        {
            float inputCheck = float.Parse(inputedValue);
        }
        catch (Exception)
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Type a value to deposit [!]");
            return returnMsg;
        }
        



        if (string.IsNullOrEmpty(inputedValue))
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Type a value to deposit [!]");
            return returnMsg;
        }




        //int account_id = ApiQuery.getId(this.Document_ID);

        string destinationName = ApiQuery.getName(Account_ID);


        if (Convert.ToInt32(Account_ID) == 0)
        {
            returnMsg.Add("result", false);
            returnMsg.Add("message", "Deposit Fail [!]");
            return returnMsg;
        }



        float balance = float.Parse(ApiQuery.getBlance(Account_ID.ToString()), CultureInfo.InvariantCulture);
        float value = float.Parse(inputedValue, CultureInfo.InvariantCulture);



        float plusBalance = balance + value;
        string newBalance = plusBalance.ToString("F2", CultureInfo.InvariantCulture);


        try
        {

            ApiQuery.updateValueFromAcc(Account_ID.ToString(), "balance", newBalance);
            returnMsg.Add("result", true);
            returnMsg.Add("message", "Deposit Success !");
            setLog($"{MyBanners.depositSetLogs, -15}-\t{"Value "+value.ToString("F2", CultureInfo.InvariantCulture)+"$", -40} -\t");
            return returnMsg;

        }
        catch (Exception)
        {

            returnMsg.Add("result", false);
            returnMsg.Add("message", "Deposit Fail [!]");
            return returnMsg;


            throw;
        }





    }


    public bool confirmAuthentication(string password)
    {
        string account_id = ApiQuery.getId(Document_ID).ToString();

        string inputedToken = Actions.makeSha256Hash(Document_ID + password);

        string? token = ApiQuery.getValue(Convert.ToInt32(account_id), "token");

        if (inputedToken != token)
        {
            //AttemptCount = Convert.ToInt32(ApiQuery.getValue(Account_ID, "count"));
            //AttemptCount++;
            return false;
        }
        return true;

    }



    public int showTransactionsHistory(string msg)
    {
        Console.Clear();
        MyBanners.showBanner(MyBanners.logonHistory, msg);
        string historyData = ApiQuery.getValue(Account_ID, "logsAcc");
        Console.WriteLine(historyData);

        int result = HomeAccount.backHome();

        return result;

    }


    public void setLog(string msg)
    {
        string logData = ApiQuery.getValue(Account_ID, "logsAcc");


        string newLog = logData + msg + $"{DateTime.Now}\n";

        try
        {
            ApiQuery.updateValueFromAcc(Account_ID.ToString(), "logsAcc", newLog);
        }
        catch (Exception)
        {

            throw;
        }

    }



}
