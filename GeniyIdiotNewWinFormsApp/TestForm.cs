using GeniyIdiotNew.Common.Models;
using GeniyIdiotNew.Common.Repositories;
using GeniyIdiotNew.Common.Services;
using Timer = System.Windows.Forms.Timer;

namespace GeniyIdiotNewWinFormsApp
{
    public partial class TestForm : Form
    {
        private List<Question> _questions;
        private User _user;
        private int _currentQuestionIndex = 1;
        private int _totalQuestions;
        private Question _currentQuestion;
        private Random _random = new Random();
        private Timer _timer;
        private int _timeRemaining = 10;
        private ProgressBar _timerProgressBar;

        public TestForm()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeProgressBar();
            InitializeTest();


        }

        private void InitializeProgressBar()
        {
            _timerProgressBar = new ProgressBar();
            _timerProgressBar.Minimum = 0;
            _timerProgressBar.Maximum = 10;
            _timerProgressBar.Value = 10;
            _timerProgressBar.Style = ProgressBarStyle.Continuous;
            _timerProgressBar.Location = new Point(20, 170);
            _timerProgressBar.Size = new Size(300, 20);
            Controls.Add(_timerProgressBar);
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000; // 1 секунда
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _timeRemaining--;
            _timerProgressBar.Value = _timeRemaining;
            timeRemainingLabel.Text = $"Осталось: {_timeRemaining} сек.";

            if (_timeRemaining <= 0)
            {
                _timer.Stop();
                HandleTimeExpired();
            }
        }

        private void InitializeTest()
        {
            _questions = QuestionsRepository.GetAll();
            _user = GetUserInfo();
            _totalQuestions = _questions.Count;
            var testService = new TestService(_user, _questions);

            ShowNextQuestion();
        }

        private User GetUserInfo()
        {
            using var userInfoForm = new UserInfoForm();
            return userInfoForm.ShowDialog() == DialogResult.OK ?
                new User(userInfoForm.FirstName, userInfoForm.LastName) :
                new User("Аноним", "");
        }

        private void HandleTimeExpired()
        {
            MessageBox.Show("Время вышло! Ответ не засчитан.", "Внимание",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            // Сброс и остановка таймера
            _timer.Stop();
            _timeRemaining = 10;
            _timerProgressBar.Value = 10;
            timeRemainingLabel.Text = $"Осталось: {_timeRemaining} сек.";

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

            _timer.Start();
            _currentQuestionIndex++;
        }

        private void EndTest()
        {
            var diagnosis = TestService.GetDiagnosis(_user.RightAnswersCount, _totalQuestions);
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
            _timer.Stop(); // Остановить таймер при ответе

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

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}