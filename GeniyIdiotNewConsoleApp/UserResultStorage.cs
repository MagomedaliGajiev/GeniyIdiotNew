using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
    public static class UserResultStorage
    {
        private const string ResultsFileName = "results.json";

        public static List<UserResult> GetAllResults()
        {
            return FileProvider.LoadFromFile<List<UserResult>>(ResultsFileName);
        }

        public static void SaveResult(UserResult result)
        {
            FileProvider.AppendToFile(ResultsFileName, result);
        }
    }
}