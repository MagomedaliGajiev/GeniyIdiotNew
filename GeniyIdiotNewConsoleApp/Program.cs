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
            Console.Clear();
            Console.WriteLine("Внимание! На каждый ответ дается 10 секунд.\n");
            Console.WriteLine("Нажмите Enter чтобы начать...");
            Console.ReadLine();

            var questionNumber = 1;
            var totalQuestions = testService.TotalQuestions;

            while (testService.RemainingQuestions > 0)
            {
                var currentQuestion = testService.GetNextQuestion();
                if (currentQuestion == null) break;

                Console.Clear();
                Console.WriteLine($"Вопрос {questionNumber} из {totalQuestions}:");
                Console.WriteLine(currentQuestion.Text);

                // Настройка таймера
                var timeLeft = 10;
                bool timeExpired = false;
                Console.Write($"\nОсталось времени: {new string('█', timeLeft)}] {timeLeft} сек. ");
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                Console.Write("Ваш ответ: ");

                // Позиция для ввода ответа
                var inputLeft = Console.CursorLeft;
                var inputTop = Console.CursorTop;
                var input = string.Empty;

                // Запуск отсчета времени
                var startTime = DateTime.Now;
                while ((DateTime.Now - startTime).TotalSeconds < 10)
                {
                    // Обновление таймера
                    var newTimeLeft = 10 - (int)(DateTime.Now - startTime).TotalSeconds;
                    if (newTimeLeft != timeLeft)
                    {
                        timeLeft = newTimeLeft;
                        Console.SetCursorPosition(0, inputTop - 1);
                        Console.Write($"Осталось времени: {new string('█', timeLeft)}{new string(' ', 10 - timeLeft)}] {timeLeft} сек. ");
                        Console.SetCursorPosition(inputLeft, inputTop);
                        Console.Write(input + new string(' ', 10 - input.Length)); // Очистка старых символов
                        Console.SetCursorPosition(inputLeft + input.Length, inputTop);
                    }

                    // Обработка ввода
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter && input.Length > 0)
                        {
                            break;
                        }
                        else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                        {
                            input = input[0..^1];
                            Console.SetCursorPosition(inputLeft, inputTop);
                            Console.Write(input + " ");
                            Console.SetCursorPosition(inputLeft + input.Length, inputTop);
                        }
                        else if (char.IsDigit(key.KeyChar))
                        {
                            input += key.KeyChar;
                            Console.SetCursorPosition(inputLeft, inputTop);
                            Console.Write(input);
                        }
                    }

                    Thread.Sleep(50);
                }

                // Обработка по истечении времени
                if (string.IsNullOrEmpty(input))
                {
                    timeExpired = true;
                    Console.SetCursorPosition(0, inputTop + 1);
                    Console.WriteLine("\nВремя вышло! Ответ не засчитан.");
                    Thread.Sleep(1500);
                }

                // Проверка ответа
                if (!timeExpired && int.TryParse(input, out int userAnswer))
                {
                    testService.AcceptAnswer(currentQuestion, userAnswer);
                }

                questionNumber++;
            }

            // Вывод результатов
            var diagnosis = TestService.GetDiagnosis(testService.User.RightAnswersCount, totalQuestions);
            UserResultsRepository.Save(new UserResult(testService.User, diagnosis, DateTime.Now));

            Console.WriteLine($"\n{testService.User.FirstName}, количество правильных ответов: {testService.User.RightAnswersCount}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");
            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
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
                var fullName = $"{result.User.LastName} {result.User.FirstName}";
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-10} | {3,-20} |",
                    fullName.Length > 20 ? fullName[..17] + "..." : fullName,
                    result.User.RightAnswersCount,
                    result.Diagnosis,
                    result.TestDate.ToString("dd.MM.yyyy HH:mm"));
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