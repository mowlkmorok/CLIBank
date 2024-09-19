using CLIBank.Model;
using System.Data;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml.Linq;

namespace CLIBank.Controller
{
    public class ApiQuery
    {




        public static int getTotalID()
        {

            string filePath = @"C:\Users\windaodamassa\AppData\Local\Temp\test00\";
            string[] fileList = Directory.GetFiles(filePath, "*.json");

            return fileList.Length;
        }




        public static bool checkDocumentID(string document_id)
        {
            bool result = false;

            string rootPath = @"C:\Users\windaodamassa\AppData\Local\Temp\test00\";
            string[] fileList = Directory.GetFiles(rootPath, "*.json");

            //Console.WriteLine(textList.Length);

            foreach (string text in fileList)
            {


                // READING FILE JSON
                string dataFile = File.ReadAllText(text);
                JsonDocument jsonDataFile = JsonDocument.Parse(dataFile);
                JsonElement root = jsonDataFile.RootElement;

                //GET A SPECIFIC VALUE IN JSON FILE
                var value = root.GetProperty("document_id").GetString();
                //Console.WriteLine($"\n\n------------document_id: {value}");

                if (document_id == value) result = true;

            }

            return result;
        }



        public static Dictionary<string, object> saveAccount(string document_id, string your_name, string password)
        {

            Dictionary<string, object> result = new Dictionary<string, object>();


            try
            {

                int accountID = getTotalID() + 1;

                string rootPath = $@"C:\Users\windaodamassa\AppData\Local\Temp\test00\{accountID}.json";



                string logs = $"DocumentID {document_id} was created at - {DateTime.Now}\n";
                float balance = 200.30f;


                Dictionary<string, object> dicData = new Dictionary<string, object>
                {
                    {"accountID", accountID},
                    {"document_id", document_id },
                    {"token", password},
                    {"your_name", your_name},
                    {"balance", $"{balance:0.00}" },
                    {"logsAcc", logs},
                    {"count", 0},
                    {"block", 0}
                };






                string json = JsonSerializer.Serialize(dicData);


                if (!File.Exists(rootPath))
                {
                    using (StreamWriter sr = File.CreateText(rootPath))
                    {      
                        sr.WriteLine(json);
                    }
                }


                result.Add("result", true);
                result.Add("message", "success");


            }
            catch (Exception errorMsg)
            {
                result.Add("result", false);
                result.Add("message", errorMsg);

                return result;
            }
            return result;

        }



        public static int getId(string document_id)
        {



            bool checkResult = false;

            string rootPath = @"C:\Users\windaodamassa\AppData\Local\Temp\test00\";
            string[] fileList = Directory.GetFiles(rootPath, "*.json");

            //Console.WriteLine(textList.Length);

            foreach (string text in fileList)
            {


                // READING FILE JSON
                string dataFile = File.ReadAllText(text);
                JsonDocument jsonDataFile = JsonDocument.Parse(dataFile);
                JsonElement root = jsonDataFile.RootElement;

                //GET A SPECIFIC VALUE IN JSON FILE
                var value = root.GetProperty("document_id").GetString();


                //Console.WriteLine($"\n\n------------document_id: {returnValue}");




                if (document_id == value)
                {

                    checkResult = true;
                    var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataFile);

                    // Try get value
                    if (jsonObject.TryGetValue("accountID", out object obje))
                    {
                        int test = int.Parse(obje.ToString());

                        return test;

                    }

                    break;
                }

            }

            return 0;


        }




        public static string getBlance(string account_id)
        {


            string filePath = @$"C:\Users\windaodamassa\AppData\Local\Temp\test00\{account_id}.json";


            //Console.WriteLine(textList.Length);


            // READING FILE JSON
            try
            {
                string dataFile = File.ReadAllText(filePath);
                JsonDocument jsonDataFile = JsonDocument.Parse(dataFile);
                JsonElement root = jsonDataFile.RootElement;

                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataFile);

                // Try get value
                if (jsonObject.TryGetValue("balance", out object returnResult))
                {
                    //int test = int.Parse(obje.ToString());

                    //Console.WriteLine(returnResult);

                    return returnResult.ToString();

                }
            }
            catch (Exception)
            {

            }

            return null;

        }

        public static string getName(int account_id)
        {


            {


                string filePath = @$"C:\Users\windaodamassa\AppData\Local\Temp\test00\{account_id}.json";


                //Console.WriteLine(textList.Length);


                // READING FILE JSON
                try
                {
                    string dataFile = File.ReadAllText(filePath);
                    JsonDocument jsonDataFile = JsonDocument.Parse(dataFile);
                    JsonElement root = jsonDataFile.RootElement;

                    var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataFile);

                    // Try get value
                    if (jsonObject.TryGetValue("your_name", out object returnResult))
                    {
                        //int test = int.Parse(obje.ToString());

                        //Console.WriteLine(returnResult);

                        return returnResult.ToString();

                    }
                }
                catch (Exception)
                {

                }

                return null;

            }

        }
    
       
        public static string getValue(int account_id, string field)
        {

            {


                string filePath = @$"C:\Users\windaodamassa\AppData\Local\Temp\test00\{account_id}.json";


                //Console.WriteLine(textList.Length);


                // READING FILE JSON
                try
                {
                    string dataFile = File.ReadAllText(filePath);
                    JsonDocument jsonDataFile = JsonDocument.Parse(dataFile);
                    JsonElement root = jsonDataFile.RootElement;

                    var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataFile);

                    // Try get value
                    if (jsonObject.TryGetValue(field, out object returnResult))
                    {
                        //int test = int.Parse(obje.ToString());

                        //Console.WriteLine(returnResult);

                        return returnResult.ToString();

                    }
                }
                catch (Exception)
                {

                }

                return null;

            }
        }


        public static void updateValueFromAcc(string account_id, string field, string updatedValue)
        {


            int returnValue = 0;

            bool checkResult = false;

            string rootPath = @$"C:\Users\windaodamassa\AppData\Local\Temp\test00\{account_id}.json";


            // READING FILE JSON
            string dataFile = File.ReadAllText(rootPath);
            JsonDocument jsonDataFile = JsonDocument.Parse(dataFile);

            //GET A SPECIFIC VALUE IN JSON FILE

            checkResult = true;
            var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataFile);

            // Try get value
            if (jsonObject.TryGetValue(field, out object value))
            {
                jsonObject[field] = updatedValue;

                string updatedJson = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(rootPath, updatedJson);
                checkResult = true;
            }

            



            
        }
    }
}
