using CLIBank.Controller;
using System.Text;



namespace CLIBank.Model;





public class addAccModel
{
    public string Document_id { get; set; }
    public string Document_name { get; set; }
    public string Password { get; set; }

    public addAccModel(string document_id, string your_name, string password)
    {
        Document_id = document_id;
        Document_name = your_name;
        Password = password;
    }










    public Dictionary<string, object> addAccount()
    {
        Dictionary<string, object> finalResult = new Dictionary<string, object>();

        //bool res = AddAccController.newAccount(Document_id, Document_name, Password);

        bool checkDocId= ApiQuery.checkDocumentID(Document_id);


        switch (checkDocId)
        {
            case true:
                finalResult.Add("result", false);
                finalResult.Add("message", "Document ID already exist");

                return finalResult;

            case false:

                // Hashing the document_id and passowrd as a token to access account 
                string strToToken = Actions.makeSha256Hash(Document_id+Password);
                //Console.WriteLine(strToToken);

                ApiQuery.saveAccount(Document_id, Document_name, strToToken);
                finalResult.Add("result", true);
                finalResult.Add("message", "Account was created !");


                return finalResult;

        }




        if (ApiQuery.checkDocumentID(Document_id))
        {


        }
        else
        {

        }

    }







}
