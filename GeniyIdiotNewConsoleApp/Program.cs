using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
    public class Test
    {
        private User _user;
        private List<Question> _questions;
        private Random _random = new Random();

        public Test(User user)
        {
            _user = user;
            _questions = QuestionsStorage.GetAll();
        }

        public void Run()
        {
            _user.RightAnswersCount = 0;
            var questionsCount = _questions.Count;

            for (int i = 0; i < questionsCount; i++)
            {
                var question = GetNextQuestion();
                AskQuestion(question, i + 1);
                CheckUserAnswer(question);
            }

        }

        private void CheckUserAnswer(Question question)
        {
            if (_user.CurrentAnswer == question.Answer)
            {
                _user.RightAnswersCount++;
            }
        }

        private string AskQuestion(Question question, int number)
        {
            return($"Вопрос №{number}\n{question.Text}");
            
        }

        private Question GetNextQuestion()
        {
            var index = _random.Next(0, _questions.Count);
            var question = _questions[index];
            _questions.RemoveAt(index);
            return question;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя:");
            var firsName = Console.ReadLine();
            Console.Write("\nВведите вашу фамилию:");
            var lastName = Console.ReadLine();

            var user = new User(firsName, lastName);
            
            bool playAgain;
            do
            {
                playAgain = RunTest(user);
            }
            while (playAgain);
            
            Console.WriteLine("\nСпасибо за участие! До новых встреч!");
            
        }

        private static bool RunTest(User user)
        {
            var questions = QuestionsStorage.GetAll();

            user.RightAnswersCount = 0;
            var questionsCount = questions.Count;
            var random = new Random();

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                var randomQuestionIndex = random.Next(0, questions.Count);
                Console.WriteLine(questions[randomQuestionIndex].Text);

                var userAnswer = GetUserAnswer();
                var rightAnswer = questions[randomQuestionIndex].Answer;

                if (userAnswer == rightAnswer)
                {
                    user.RightAnswersCount++;
                }
                questions.RemoveAt(randomQuestionIndex);
            }

            var diagnosis = DiagnosisCalculator.GetDiagnosis(user.RightAnswersCount, questionsCount);
            UserResultsStorage.SaveResult(new UserResult(user, diagnosis, DateTime.Now));

            Console.WriteLine($"\n{user.FirstName}, количество ваших правильных ответов: {user.RightAnswersCount}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");

            var message = "\nХотите пройти тест еще раз?";
            return GetUserChoice(message);
        }

        private static void ShowHistory()
        {
            var results = UserResultsStorage.GetAll();

            if (results.Count == 0)
            {
                Console.WriteLine("История результатов пуста.");
                return;
            }

            Console.WriteLine("\nИстория результатов:");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,-20} | {1,-25} | {2,-10} | {3,-20} |",
                "ФИО", "Кол-во правильных ответов", "Диагноз", "Дата и время теста");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            foreach (var result in results)
            {
                var fullName = $"{result.User.LastName} {result.User.FirstName[0]}.";
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-10} | {3,-20:dd.MM.yyyy HH:mm:ss} |",
                    $"{fullName}",
                    result.User.RightAnswersCount   ,
                    result.Diagnosis,
                    result.TestDateTime);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }
        private static int GetUserAnswer()
        {

            while (true)
            {
                var input = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(input);
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

        private static bool GetUserChoice(string message)
        {
            while (true)
            {
                Console.Write($"{message} (да/нет): ");
                var answer = Console.ReadLine()?.ToLower();

                if (answer == "да" || answer == "д") return true;
                if (answer == "нет" || answer == "н") return false;

                Console.WriteLine("Не понял ваш ответ. Пожалуйста, введите 'да' или 'нет'.");
            }
        }
    }
}