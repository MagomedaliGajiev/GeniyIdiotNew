using Newtonsoft.Json;

namespace GeniyIdiotNewConsoleApp
{
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
            
            var message = "\nХотите посмотреть резултыты тестов?";
            if (GetUserChoice(message))
            {
                ShowResults();
            }

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

        private static void ShowResults()
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