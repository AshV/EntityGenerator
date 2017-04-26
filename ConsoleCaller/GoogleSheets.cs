using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleCaller
{
    public class GoogleSheets
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Entity Generator";

        string _spreadsheetId;

        public string spreadsheetId
        {
            get
            {
                return this._spreadsheetId;
            }
            set
            {
                this._spreadsheetId = new Func<string[], string>((a) =>
                {
                    var maxLen = "";
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i].Length > maxLen.Length)
                            maxLen = a[i];
                    }
                    return maxLen;
                }).Invoke(value.Split('/'));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hi");
            
        }

        public SheetsService InitService()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.CurrentDirectory;
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                       GoogleClientSecrets.Load(stream).Secrets,
                       Scopes,
                       "user",
                       CancellationToken.None,
                       new FileDataStore(credPath, true)).Result;
            }
            
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        public List<string> GetAllSheetNames(SheetsService service, string spreadsheetId)
        {
            var response = service.Spreadsheets.Get(spreadsheetId).Execute();
            var sheetList = new List<string>();
            foreach (var s in response.Sheets)
            {
                sheetList.Add(s.Properties.Title);
            }

            return sheetList;
        }

        public IList<IList<Object>> SheetData(SheetsService service,string range)
        {
            var response = service.Spreadsheets.Values.Get(spreadsheetId, range).Execute();
            return response.Values;
        }
    }
}