namespace GeniyIdiotNewWinFormsApp
{
    partial class TestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            questionNumberLabel = new Label();
            questionTextLabel = new Label();
            answerTextBox = new TextBox();
            nextButton = new Button();
            SuspendLayout();

            // questionNumberLabel
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            questionNumberLabel.Location = new Point(20, 20);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(200, 25);

            // questionTextLabel
            questionTextLabel.Font = new Font("Microsoft Sans Serif", 10F);
            questionTextLabel.Location = new Point(20, 60);
            questionTextLabel.Size = new Size(600, 150);
            questionTextLabel.TabIndex = 1;

            // answerTextBox
            answerTextBox.Location = new Point(20, 220);
            answerTextBox.Size = new Size(200, 27);

            // nextButton
            nextButton.Text = "Далее";
            nextButton.Location = new Point(240, 220);
            nextButton.Click += nextButton_Click;

            // TestForm
            ClientSize = new Size(640, 300);
            Controls.Add(questionNumberLabel);
            Controls.Add(questionTextLabel);
            Controls.Add(answerTextBox);
            Controls.Add(nextButton);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox answerTextBox;
        private Button nextButton;
    }
}