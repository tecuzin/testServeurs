using System;
using System.IO;
using System.Net;

namespace checkDataServers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vérification du status des sites de test");

            string[] Lignes = null;

            try
            {
                Lignes = File.ReadAllLines("urls.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("T'as oublié la liste des URL !");
            }

            for (int i = 1; i < Lignes.Length - 1; i++) // De la ligne 2 a la dernière
            {
                Console.WriteLine(Lignes[i]);
                Console.WriteLine(value: WebSiteIsAvailable(Lignes[i]));
            }
        }

        public static bool WebSiteIsAvailable(string Url)
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
