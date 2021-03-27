using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace leaguerunes
{
    public class LeagueRuneManager
    {
        private readonly HttpClient _client;
        public LeagueRuneManager(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<LeagueRune> GetAllRunePages()
        {
            var response = _client.GetAsync("lol-perks/v1/pages").Result;
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<List<LeagueRune>>(response.Content.ReadAsStringAsync().Result);
        }

        public bool SetRunePageById(int id, LeagueRune content)
        {
            var response = _client.PutAsync($"lol-perks/v1/pages/{id}",
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")).Result;
            return response.IsSuccessStatusCode;
        }

        public LeagueRune GetRunePageById(int id)
        {
            var response = _client.GetAsync($"lol-perks/v1/pages/{id}").Result;
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<LeagueRune>(response.Content.ReadAsStringAsync().Result);
        }

        public LeagueRune GetCurrentRunePage()
        {
            var response = _client.GetAsync($"lol-perks/v1/currentpage").Result;
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<LeagueRune>(response.Content.ReadAsStringAsync().Result);
        }
    }
}