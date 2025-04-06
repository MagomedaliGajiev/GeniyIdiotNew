namespace GeniyIdiotNewConsoleApp
{
    public class UserResult
    {
        public string UserName { get; set; }
        public int CorrectAnswersCount { get; set; }
        public string Diagnosis { get; set; }
        public DateTime TestDateTime { get; set; }

        public UserResult() { }

        public UserResult(string userName, int correctAnswersCount, string diagnosis, DateTime testDateTime)
        {
            UserName = userName;
            CorrectAnswersCount = correctAnswersCount;
            Diagnosis = diagnosis;
            TestDateTime = testDateTime;
        }
    }
}