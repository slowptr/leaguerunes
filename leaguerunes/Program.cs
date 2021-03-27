using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace leaguerunes
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var league = new LeagueConnection(ProcessManager.GetFolderOfProcess("LeagueClient") + "\\lockfile");
            var curPage = league.RuneHandler.GetCurrentRunePage();

            if (args.Length == 0)
            {
                ConfigFile.Initialize(curPage);
                Console.WriteLine("please provide configfile (per drag&drop).");
                return;
            }

            var configfile = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(args[0])); // args[0] = filename

            league.RuneHandler.SetRunePageById(curPage.Id, new LeagueRune()
            {
                Name = configfile.Name,
                PrimaryStyleId = configfile.PrimaryStyleId,
                SubStyleId = configfile.SubStyleId,
                Runes = configfile.Runes
            });
        }
    }
}