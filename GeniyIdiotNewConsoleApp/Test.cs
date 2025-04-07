namespace GeniyIdiotNewConsoleApp
{
    public class Test
    {
        private User user;
        private List<Question> questions;
        private Random random = new Random();

        public Test(User user)
        {
            this.user = user;
            questions = new List<Question>(QuestionsStorage.GetAllQuestions());
        }

        public void Run()
        {
            user.RightAnswersCount = 0;
            var questionsCount = questions.Count;

            for (int i = 0; i < questionsCount; i++)
            {
                var question = GetNextQuestion();
                AskQuestion(question, i + 1);
                CheckAnswer(question);
            }
        }

        private Question GetNextQuestion()
        {
            var index = random.Next(0, questions.Count);
            var question = questions[index];
            questions.RemoveAt(index);
            return question;
        }

        private void AskQuestion(Question question, int number)
        {
            Console.WriteLine($"Вопрос №{number}");
            Console.WriteLine(question.Text);
        }

        private void CheckAnswer(Question question)
        {
            var userAnswer = GetNumberInput();
            if (userAnswer == question.Answer) user.RightAnswersCount++;
        }

        private int GetNumberInput()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9!");
                }
            }
        }
    }
}