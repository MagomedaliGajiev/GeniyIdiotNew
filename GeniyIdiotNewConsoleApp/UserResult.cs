namespace GeniyIdiotNewConsoleApp
{
    public class UserResult
    {
        public User User { get; set; }
        public int CorrectAnswersCount { get; set; }
        public string Diagnosis { get; set; }
        public DateTime TestDateTime { get; set; }

        public UserResult() { }

        public UserResult(User user, int correctAnswersCount, string diagnosis, DateTime testDateTime)
        {
            User = user;
            CorrectAnswersCount = correctAnswersCount;
            Diagnosis = diagnosis;
            TestDateTime = testDateTime;
        }
    }
}