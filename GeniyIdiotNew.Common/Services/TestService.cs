using GeniyIdiotNew.Common.Models;

namespace GeniyIdiotNew.Common.Services
{
    public class TestService
    {
        private readonly List<Question> _questions;
        private readonly Random _random = new();

        public User User { get; }
        public int QuestionsCount => _questions.Count;
        public int CurrentQuestionNumber { get; private set; } = 1;

        public TestService(User user, List<Question> questions)
        {
            User = user;
            _questions = new List<Question>(questions);
        }

        public Question GetNextQuestion()
        {
            if (_questions.Count == 0) return null;

            var randomIndex = _random.Next(0, QuestionsCount);
            var question = _questions[randomIndex];
            _questions.RemoveAt(randomIndex);

            CurrentQuestionNumber++;
            return question;
        }

        public void AcceptAnswer(Question question, int userAnswer)
        {
            if (userAnswer == question.Answer)
                User.RightAnswersCount++;
        }

        public static string GetDiagnosis(int rightAnswers, int totalQuestions)
        {
            var diagnoses = new[] { "кретин", "идиот", "дурак", "нормальный", "талант", "гений" };
            var percentage = (double)rightAnswers / totalQuestions * 100;
            var step = 100 / diagnoses.Length;
            var index = Math.Min((int)percentage / step, diagnoses.Length - 1);
            return diagnoses[index];
        }
    }
}
