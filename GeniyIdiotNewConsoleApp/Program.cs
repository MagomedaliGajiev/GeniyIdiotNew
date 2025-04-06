namespace GeniyIdiotNewConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var countQuestions = 5;
            var questions = GetQuestions(countQuestions);
            var answers = GetAnswers(countQuestions);

            var rightAnswerscount = 0;

            Random random = new Random();

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                var randomQuestionIndex = random.Next(0, countQuestions);
                Console.WriteLine(questions[randomQuestionIndex]);

                var userAnswer = Convert.ToInt32(Console.ReadLine());

                var rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer)
                {
                    rightAnswerscount++;
                }
            }
            var diagnosis = GetDiagnosis(rightAnswerscount);

            Console.WriteLine($"Количество правильных ответов: {rightAnswerscount}");
            Console.WriteLine($"Ваш диагноз:{diagnosis}");
        }
        private static string[] GetQuestions(int countQuestions)
        {
            var questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        private static int[] GetAnswers(int countQuestions)
        {
            var answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        private static string GetDiagnosis(int rightAnswersCount)
        {
            var diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";

            return diagnoses[rightAnswersCount];
        }
    }
}
