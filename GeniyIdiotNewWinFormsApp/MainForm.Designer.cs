namespace GeniyIdiotNewWinFormsApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nextButton = new Button();
            questionNumberLabel = new Label();
            questionTextLabel = new Label();
            userAnswerTextBox = new TextBox();
            SuspendLayout();
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextButton.Location = new Point(54, 312);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(423, 101);
            nextButton.TabIndex = 0;
            nextButton.Text = "Далее";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionNumberLabel.Location = new Point(44, 46);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(190, 45);
            questionNumberLabel.TabIndex = 1;
            questionNumberLabel.Text = "Вопрос №1";
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            questionTextLabel.Location = new Point(44, 116);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(240, 45);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Текст вопроса";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(44, 202);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(433, 39);
            userAnswerTextBox.TabIndex = 3;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 450);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButton);
            Name = "mainForm";
            Text = "Гений Идиот";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox userAnswerTextBox;
    }
}
