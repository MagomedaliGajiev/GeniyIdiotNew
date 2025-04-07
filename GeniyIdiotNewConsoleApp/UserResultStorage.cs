using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
    public static class UserResultStorage
    {
        private const string ResultsFileName = "results.json";

        public static void SaveResult(UserResult result)
        {
            var results = GetAllResults();
            results.Add(result);
            Save(results);
        }

        public static List<UserResult> GetAllResults()
        {
            if (File.Exists(ResultsFileName))
            {
                var json = File.ReadAllText(ResultsFileName);
                return JsonConvert.DeserializeObject<List<UserResult>>(json) ?? new List<UserResult>();
            }
            return new List<UserResult>();
        }

        private static void Save(List<UserResult> results)
        {
            var json = JsonConvert.SerializeObject(results, Formatting.Indented);
            File.WriteAllText(ResultsFileName, json);
        }
    }
}