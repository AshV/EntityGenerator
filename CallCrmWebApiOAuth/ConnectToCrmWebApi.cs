using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Console;

namespace CallCrmWebApiOAuth
{
    class ConnectToCrmWebApi
    {
        /// <summary>
        /// Holds the Authentication context based on the Authentication URL
        /// </summary>
        static AuthenticationContext authContext;

        /// <summary>
        /// Holds the actual authentication token once after successful authentication
        /// </summary>
        static AuthenticationResult authToken;

        /// <summary>
        /// This is the API data url which we will be using to automatically get the
        ///  a) Resource URL - nothing but the CRM url
        ///  b) Authority URL - the Microsoft Azure URL related to our organization on to which we actually authenticate against
        /// </summary>
        static string apiUrl = "https://coolnotes.crm8.dynamics.com/api/data";

        /// <summary>
        /// Client ID or Application ID of the App registration in Azure
        /// </summary>
        /// Grab your Client ID by following https://ansrikanth.com/2017/02/09/connect-to-dynamics-crm-365-webapi-from-console-application/
        static string clientId = "90f2bc33-8425-40ad-a61e-b17b504b3fe7";


        /// <summary>
        /// The Redirect URL which we defined during the App Registration
        /// </summary>
        static string redirectUrl = "http://ashishvishwakarma.com/";

        static void Main(string[] args)
        {
            GetToken();

            ReadLine();
        }

        internal static async void GetToken()
        {
            try
            {
                // Get the Resource Url & Authority Url using the Api method. This is the best way to get authority URL
                // for any Azure service api.
                AuthenticationParameters ap = AuthenticationParameters.CreateFromResourceUrlAsync(new Uri(apiUrl)).Result;

                string resourceUrl = ap.Resource;
                string authorityUrl = ap.Authority;

                //Generate the Authority context .. For the sake of simplicity for the post, I haven't splitted these
                // in to multiple methods. Ideally, you would want to use some sort of design pattern to generate the context and store
                // till the end of the program.
                authContext = new AuthenticationContext(authorityUrl, false);

                try
                {
                    //Check if we can get the authentication token w/o prompting for credentials.
                    //With this system will try to get the token from the cache if there is any, if it is not there then will throw error
                    authToken = await authContext.AcquireTokenAsync(resourceUrl, clientId, new Uri(redirectUrl), new PlatformParameters(PromptBehavior.Never));
                }
                catch (AdalException e)
                {
                    if (e.ErrorCode == "user_interaction_required")
                    {
                        // We are here means, there is no cached token, So get it from the service.
                        // You should see a prompt for User Id & Password at this place.
                        authToken = await authContext.AcquireTokenAsync(resourceUrl, clientId, new Uri(redirectUrl), new PlatformParameters(PromptBehavior.Auto));
                    }
                    else
                    {
                        throw;
                    }
                }

                WriteLine("Got the authentication token, Getting data from Webapi !!");

                GetData(authToken.AccessToken);

            }
            catch (Exception ex)
            {
                WriteLine($"Some thing unexpected happened here, Please see the exception details : {ex.ToString()}");
            }
        }

        internal static async void GetData(string token)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 2, 0);  // 2 minutes time out period.

                // Pass the Bearer token as part of request headers.
                httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);


                var data = await httpClient.GetAsync("https://coolnotes.crm8.dynamics.com/api/data/v8.2/accounts?$select=name");


                if (data.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // If the status code is success... then print the api output.
                    WriteLine(await data.Content.ReadAsStringAsync());
                }
                else
                {
                    // Failed .. ???
                    WriteLine($"Some thing went wrong with the data retrieval. Error code : {data.StatusCode} ");
                }
                ReadLine();

            }
        }
    }
}