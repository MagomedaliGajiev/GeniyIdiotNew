using GeniyIdiotNew.Common;

namespace GeniyIdiotNewWinFormsApp
{
    public partial class AddQuestionForm : Form
    {
        public Question Question { get; private set; }
        public AddQuestionForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionTextBox.Text))
            {
                MessageBox.Show("Введите текст вопроса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Question = new Question(questionTextBox.Text.Trim(), (int)answerNumeric.Value);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

