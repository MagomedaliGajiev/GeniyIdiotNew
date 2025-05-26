namespace GeniyIdiotNewConsoleApp
{
    public static class UserResultsStorage
    {
        private const string ResultsFileName = "results.json";

        public static void SaveResult(UserResult userResult)
        {
            FileProvider.Append(ResultsFileName, userResult);
        }

        public static List<UserResult> GetAll()
        {
            return FileProvider.Load<List<UserResult>>(ResultsFileName);
        }
    }
}