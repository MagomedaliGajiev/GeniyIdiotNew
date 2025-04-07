namespace GeniyIdiotNewConsoleApp
{
    public class User
    {
        public string Name { get; set; }
        public int RightAnswersCount { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }
}