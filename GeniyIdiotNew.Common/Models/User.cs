namespace GeniyIdiotNew.Common.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentAnswer { get; set; }
        public int RightAnswersCount { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}