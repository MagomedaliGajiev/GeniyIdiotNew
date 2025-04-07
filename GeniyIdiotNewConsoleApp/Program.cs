namespace GeniyIdiotNewConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя (или команду: 'история', 'добавить'): ");
            var input = Console.ReadLine().Trim();

            if (input.ToLower() == "история")
            {
                ShowHistory();
                return;
            }
            else if (input.ToLower() == "добавить")
            {
                AddNewQuestion();
                return;
            }

            var user = new User(input);
            bool playAgain;

            do
            {
                new Test(user).Run();
                SaveTestResult(user);
                ShowTestResult(user);

                playAgain = GetUserChoice("\nХотите пройти тест еще раз?");
            }
            while (playAgain);

            Console.WriteLine("\nСпасибо за участие! До новых встреч!");
        }

        private static void AddNewQuestion()
        {
            Console.WriteLine("\nДобавление нового вопроса:");

            // Ввод текста вопроса
            string questionText;
            do
            {
                Console.Write("Введите текст вопроса: ");
                questionText = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(questionText))
                {
                    Console.WriteLine("Текст вопроса не может быть пустым!");
                }
            } while (string.IsNullOrEmpty(questionText));

            // Ввод ответа
            int answer;
            bool isValid;
            do
            {
                Console.Write("Введите правильный ответ (целое число): ");
                var input = Console.ReadLine();
                isValid = int.TryParse(input, out answer);

                if (!isValid)
                {
                    Console.WriteLine("Некорректный формат числа! Пожалуйста, введите целое число.");
                }
            } while (!isValid);

            // Добавление и сохранение
            var newQuestion = new Question(questionText, answer);
            var questions = QuestionsStorage.GetAll();
            questions.Add(newQuestion);
            QuestionsStorage.SaveAll(questions);

            Console.WriteLine("\nВопрос успешно добавлен! Новый список вопросов:");
            foreach (var question in QuestionsStorage.GetAll())
            {
                Console.WriteLine($"- {question.Text} ({question.Answer})");
            }
        }

        private static void ShowHistory()
        {
            var results = UserResultStorage.GetAllResults();

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
                Console.WriteLine("| {0,-20} | {1,-25} | {2,-10} | {3,-20:dd.MM.yyyy HH:mm:ss} |",
                    result.UserName,
                    result.CorrectAnswersCount,
                    result.Diagnosis,
                    result.TestDateTime);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        private static void SaveTestResult(User user)
        {
            var diagnosis = DiagnosisCalculator.GetDiagnosis(
                user.RightAnswersCount,
                QuestionsStorage.GetAllQuestions().Count
            );

            UserResultStorage.SaveResult(new UserResult(
                user.Name,
                user.RightAnswersCount,
                diagnosis,
                DateTime.Now
            ));
        }

        private static void ShowTestResult(User user)
        {
            Console.WriteLine($"\n{user.Name}, количество ваших правильных ответов: {user.RightAnswersCount}");
            Console.WriteLine($"Ваш диагноз: {DiagnosisCalculator.GetDiagnosis(
                user.RightAnswersCount,
                QuestionsStorage.GetAllQuestions().Count
            )}");
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