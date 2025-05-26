using GeniyIdiotNew.Common;

namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            var firstName = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            var lastName = Console.ReadLine();

            var user = new User(firstName, lastName);

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
                        RunTest(user);
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
            UserResultsStorage.Save(new UserResult(user, diagnosis, DateTime.Now));

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

        private static void AddNewQuestion()
        {
            Console.WriteLine("\nДобавление нового вопроса:");

            var questionText = GetValidatedText("Введите текст вопроса: ",
                "Текст вопроса не может быть пустым!");

            var answer = GetValidatedNumber("Введите правильный ответ (целое число): ",
                "Некорректный формат числа!");

            QuestionsStorage.Add(new Question(questionText, answer));
            Console.WriteLine("Вопрос успешно добавлен!");
        }

        private static void RemoveQuestion()
        {
            var questions = QuestionsStorage.GetAll();

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
                QuestionsStorage.Remove(questionNumber - 1);
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