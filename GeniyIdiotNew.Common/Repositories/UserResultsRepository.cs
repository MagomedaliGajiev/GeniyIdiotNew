using GeniyIdiotNew.Common.Infrastructure;
using GeniyIdiotNew.Common.Models;

namespace GeniyIdiotNew.Common.Repositories
{
    public static class UserResultsRepository
    {
        private const string ResultsFileName = "results.json";

        public static void Save(UserResult userResult)
        {
            FileProvider.Append(ResultsFileName, userResult);
        }

        public static List<UserResult> GetAll()
        {
            return FileProvider.Load<List<UserResult>>(ResultsFileName);
        }
    }
}