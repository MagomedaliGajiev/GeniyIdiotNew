namespace GeniyIdiotNew.Common.Models
{
    public class UserResult
    {
        public User User { get; }
        public int RightAnswersCount { get; }
        public string Diagnosis { get; }
        public DateTime TestDate { get; }

        public UserResult(User user, string diagnosis, DateTime testDate)
        {
            User = user;
            RightAnswersCount = user.RightAnswersCount;
            Diagnosis = diagnosis;
            TestDate = testDate;
        }
    }
}