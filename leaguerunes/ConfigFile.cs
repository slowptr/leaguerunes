using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace leaguerunes
{
    public class ConfigFile
    {
        public string Name { get; set; }
        public int PrimaryStyleId { get; set; }
        public int SubStyleId { get; set; }
        public List<int> Runes { get; set; }

        public static void Initialize(LeagueRune curPage)
        {
            // if (File.Exists(configfilename)) return;
            File.WriteAllText(curPage.Name + ".json", JsonConvert.SerializeObject(new ConfigFile
            {
                Name = curPage.Name,
                PrimaryStyleId = curPage.PrimaryStyleId,
                SubStyleId = curPage.SubStyleId,
                Runes = curPage.Runes
            }, Formatting.Indented));
            Console.WriteLine("current runepage created.");
        }
    }
}