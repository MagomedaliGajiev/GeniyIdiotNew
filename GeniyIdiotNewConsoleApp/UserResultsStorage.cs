namespace GeniyIdiotNewConsoleApp
{
    public static class UserResultsStorage
    {
        private const string ResultsFileName = "results.json";

        public static void SaveResult(UserResult userResult)
        {
            FileProvider.AppendToFile(ResultsFileName, userResult);
        }

        public static List<UserResult> GetAll()
        {
            return FileProvider.LoadFromFile<List<UserResult>>(ResultsFileName);
        }
    }
}