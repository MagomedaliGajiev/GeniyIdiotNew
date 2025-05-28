using GeniyIdiotNew.Common;
using GeniyIdiotNew.Common.Models;
using GeniyIdiotNew.Common.Repositories;

namespace GeniyIdiotNewWinFormsApp
{
    public partial class TestForm : Form
    {
        private List<Question> _questions;
        private User _user;
        private int _currentQuestionIndex;
        private int _totalQuestions;
        private Question _currentQuestion;
        private Random _random = new Random();

        public TestForm()
        {
            InitializeComponent();
            InitializeTest();
        }

        private void InitializeTest()
        {
            _questions = QuestionsRepository.GetAll();
            _totalQuestions = _questions.Count;
            _currentQuestionIndex = 1;
            _user = GetUserInfo();

            ShowNextQuestion();
        }

        private User GetUserInfo()
        {
            using var userInfoForm = new UserInfoForm();
            return userInfoForm.ShowDialog() == DialogResult.OK ?
                new User(userInfoForm.FirstName, userInfoForm.LastName) :
                new User("Аноним", "");
        }

        private void ShowNextQuestion()
        {
            if (_questions.Count == 0)
            {
                EndTest();
                return;
            }

            var question = _questions[_random.Next(_questions.Count)];
            _currentQuestion = question;
            _questions.Remove(question);

            questionNumberLabel.Text = $"Вопрос {_currentQuestionIndex} из {_totalQuestions}";
            questionTextLabel.Text = question.Text;
            answerTextBox.Clear();

            _currentQuestionIndex++;
        }

        private void EndTest()
        {
            var diagnosis = DiagnosisCalculator.GetDiagnosis(_user.RightAnswersCount, _totalQuestions);
            UserResultsRepository.Save(new UserResult(_user, diagnosis, DateTime.Now));

            MessageBox.Show($"Количество правильных ответов: {_user.RightAnswersCount}\n" +
                            $"Ваш диагноз: {diagnosis}",
                            "Результат теста",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(answerTextBox.Text, out int userAnswer))
            {
                if (userAnswer == _currentQuestion.Answer) _user.RightAnswersCount++;
                ShowNextQuestion();
            }
            else
            {
                MessageBox.Show("Введите корректное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}