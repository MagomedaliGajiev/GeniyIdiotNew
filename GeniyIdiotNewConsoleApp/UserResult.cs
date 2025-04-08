namespace GeniyIdiotNewConsoleApp
{
    public class UserResult
    {
        public User User { get; set; }
        public int RightAnswersCount { get; set; }
        public string Diagnosis { get; set; }
        public DateTime TestDateTime { get; set; }

        public UserResult() { }

        public UserResult(User user, string diagnosis, DateTime testDateTime)
        {
            User = user;
            RightAnswersCount = user.RightAnswersCount;
            Diagnosis = diagnosis;
            TestDateTime = testDateTime;
        }
    }
}