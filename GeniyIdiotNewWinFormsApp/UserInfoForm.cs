namespace GeniyIdiotNewWinFormsApp
{
    public partial class UserInfoForm : Form
    {
        public string FirstName => firstNameTextBox.Text.Trim();
        public string LastName => lastNameTextBox.Text.Trim();

        public UserInfoForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}