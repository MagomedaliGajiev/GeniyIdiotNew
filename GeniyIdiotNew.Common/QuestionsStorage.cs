using GeniyIdiotNew.Common;

namespace GeniyIdiotNewConsoleApp
{
    public static class QuestionsStorage
    {
        private const string QuestionsFileName = "questions.json";

        static QuestionsStorage()
        {
            if (!FileProvider.Exists(QuestionsFileName))
            {
                var defaultQuestions = new List<Question>
                {
                    new Question("Сколько будет два плюс два умноженное на два?", 6),
                    new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
                    new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                    new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
                    new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
                };
                FileProvider.Save(QuestionsFileName, defaultQuestions);
            }
        }

        public static List<Question> GetAll()
        {
            return FileProvider.Load<List<Question>>(QuestionsFileName);
        }

        public static void Add(Question newQuestion)
        {
            var questions = GetAll();
            questions.Add(newQuestion);
            FileProvider.Save(QuestionsFileName, questions);
        }

        public static void Remove(int index)
        {
            var questions = GetAll();
            if (index >= 0 && index < questions.Count)
            {
                questions.RemoveAt(index);
                FileProvider.Save(QuestionsFileName, questions);
            }
        }
    }
}