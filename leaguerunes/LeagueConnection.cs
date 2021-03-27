using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace leaguerunes
{
    public class LeagueConnection
    {
        public readonly LeagueRuneManager RuneHandler;
        private string _token;
        private Uri _address;

        public LeagueConnection(string path)
        {
            if (!SetCredsFromLockfile(path))
            {
                throw new Exception("couldn't set credentials.");
            }
            
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => true
            };
            var client = new HttpClient(handler) {BaseAddress = _address};
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _token);
            RuneHandler = new LeagueRuneManager(client);
        }

        private bool SetCredsFromLockfile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("couldn't find lockfile.");
            }

            var stream = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            var line = stream.ReadToEnd();
            stream.Dispose();

            if (string.IsNullOrEmpty(line)) return false;
            var splitted = line.Split(":");
            _token = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("riot:" + splitted[3]));
            _address = new Uri("https://127.0.0.1:" + splitted[2]);
            return true;
        }
    }
}