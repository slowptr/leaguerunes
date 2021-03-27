using System.Diagnostics;

namespace leaguerunes
{
    public static class ProcessManager
    {
        public static string GetFolderOfProcess(string name)
        {
            var processes = Process.GetProcessesByName(name);
            var processModule = processes[0].MainModule;
            if (processModule != null && processes.Length > 0)
                return processModule.FileName.Split('\\' + name)[0];
            return string.Empty;
        }
    }
}