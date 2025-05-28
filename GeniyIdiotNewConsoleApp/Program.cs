using GeniyIdiotNew.Common.Models;
using GeniyIdiotNew.Common.Repositories;
using GeniyIdiotNew.Common.Services;

namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Пройти тест");
                Console.WriteLine("2. Добавить вопрос");
                Console.WriteLine("3. Удалить вопрос");
                Console.WriteLine("4. Показать результаты");
                Console.WriteLine("5. Выход");

                var choice = GetValidatedNumber("Ваш выбор: ", "Некорректный ввод!", 1, 5);

                switch (choice)
                {
                    case 1:
                        var questions = QuestionsRepository.GetAll();
                        User user = GetUserInfo();
                        var testService = new TestService(user, questions);
                        RunTest(testService);
                        break;
                    case 2:
                        AddNewQuestion();
                        break;
                    case 3:
                        RemoveQuestion();
                        break;
                    case 4:
                        ShowResults();
                        break;
                    case 5:
                        Console.WriteLine("\nСпасибо за участие! До новых встреч!");
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда!");
                        break;
                }
            }
        }

        private static User GetUserInfo()
        {
            Console.Write("Введите ваше имя: ");
            var firstName = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            var lastName = Console.ReadLine();
            return new User(firstName, lastName);
        }

        private static void RunTest(TestService testService)
        {
            var questionNumber = 1;

            while (true)
            {
                var currentQuestion = testService.GetNextQuestion();
                if (currentQuestion == null) break;

                Console.WriteLine($"\nВопрос №{questionNumber}:");
                Console.WriteLine(currentQuestion.Text);
                var answer = GetValidatedNumber("Введите правильный ответ (целое число): ",
                "Некорректный формат числа!");
                testService.AcceptAnswer(currentQuestion, answer);
                questionNumber++;
            }

            var diagnosis = TestService.GetDiagnosis(testService.User.RightAnswersCount, testService.TotalQuestions);
            UserResultsRepository.Save(new UserResult(testService.User, diagnosis, DateTime.Now));

            Console.WriteLine($"\n{testService.User.FirstName}, количество ваших правильных ответов: {testService.User.RightAnswersCount}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");
        }

        private static void ShowResults()
        {
            var results = UserResultsRepository.GetAll();

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
                    result.TestDate);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        private static void AddNewQuestion()
        {
            Console.WriteLine("\nДобавление нового вопроса:");

            var questionText = GetValidatedText("Введите текст вопроса: ",
                "Текст вопроса не может быть пустым!");

            var answer = GetValidatedNumber("Введите правильный ответ (целое число): ",
                "Некорректный формат числа!");

            QuestionsRepository.Add(new Question(questionText, answer));
            Console.WriteLine("Вопрос успешно добавлен!");
        }

        private static void RemoveQuestion()
        {
            var questions = QuestionsRepository.GetAll();

            if (questions.Count == 0)
            {
                Console.WriteLine("Список вопросов пуст!");
                return;
            }

            ShowQuestionsList(questions);

            Console.Write("\nВведите номер вопроса для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int questionNumber) &&
                questionNumber >= 1 &&
                questionNumber <= questions.Count)
            {
                QuestionsRepository.Remove(questionNumber - 1);
                Console.WriteLine("Вопрос успешно удален!");
            }
            else
            {
                Console.WriteLine("Некорректный номер вопроса!");
            }
        }

        private static void ShowQuestionsList(List<Question> questions)
        {
            Console.WriteLine("\nСписок доступных вопросов:");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i].Text} (Ответ: {questions[i].Answer})");
            }
        }

        private static string GetValidatedText(string message, string errorMessage)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine(errorMessage);
            }
        }
        private static int GetValidatedNumber(string message, string errorMessage,
                                    int minValue = int.MinValue,
                                    int maxValue = int.MaxValue)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();

                if (int.TryParse(input, out var result) &&
                   result >= minValue &&
                   result <= maxValue)
                {
                    return result;
                }
                Console.WriteLine($"{errorMessage} Допустимый диапазон: {minValue}-{maxValue}");
            }
        }
    }
}