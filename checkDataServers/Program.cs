using System;
using 


namespace checkDataServers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vérification du status des sites de test");

            var Lignes = System.IO.File.ReadAllLines("Questions.txt");

            for (int i = 2; i < Lignes.Length - 1; i++) // De la ligne 3 a la dernière
            {
                Console.WriteLine(Lignes[i]);
                Console.WriteLine(WebSiteIsAvailable(Lignes[i]);
            }

        }

        public override bool WebSiteIsAvailable(string Url)
        {
            string Message = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

            // Set the credentials to the current user account
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Do nothing; we're only testing to see if we can get the response
                }
            }
            catch (WebException ex)
            {
                Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
            }

            return (Message.Length == 0);
        }
    }
}
