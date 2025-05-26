using GeniyIdiotNewConsoleApp;

namespace GeniyIdiotNewWinFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> _questions;
        private Question _currentQuestion;
        private int _questionsCount;
        private User _user;
        private int _questionNumber;     
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            _questions = QuestionsStorage.GetAll();
            _questionsCount = _questions.Count;
            _user = new User("Unknown", "Unknown");
            _questionNumber = 0;

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomQuestionIndex = random.Next(0, _questions.Count);

            _currentQuestion = _questions[randomQuestionIndex];
            questionTextLabel.Text = _currentQuestion.Text;

            _questionNumber++;
            questionNumberLabel.Text = $"Вопрос № {_questionNumber}";
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
            var rightAnswer = _currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                _user.RightAnswersCount++;
            }
            _questions.Remove(_currentQuestion);

            var endTest = _questions.Count == 0;
            if (endTest)
            {
                var diagnosis = DiagnosisCalculator.GetDiagnosis(_user.RightAnswersCount, _questionsCount);
                UserResultsStorage.Save(new UserResult(_user, diagnosis, DateTime.Now));
                MessageBox.Show($"{_user.FirstName}, количество ваших правильных ответов: {_user.RightAnswersCount}\n" +
                    $"Ваш диагноз: {diagnosis}");
                return;
            }
            ShowNextQuestion();
        }
    }
}
