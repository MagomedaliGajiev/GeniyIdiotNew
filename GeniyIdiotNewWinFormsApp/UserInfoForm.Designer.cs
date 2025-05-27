namespace GeniyIdiotNewWinFormsApp
{
    partial class UserInfoForm
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
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            confirmButton = new Button();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(38, 52);
            firstNameLabel.Margin = new Padding(9, 0, 9, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(320, 45);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "Введите ваше имя:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstNameTextBox.Location = new Point(465, 52);
            firstNameTextBox.Margin = new Padding(9, 10, 9, 10);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(625, 50);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(38, 142);
            lastNameLabel.Margin = new Padding(9, 0, 9, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(411, 45);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Введите вашу фамилию:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lastNameTextBox.Location = new Point(465, 132);
            lastNameTextBox.Margin = new Padding(9, 10, 9, 10);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(625, 50);
            lastNameTextBox.TabIndex = 3;
            // 
            // confirmButton
            // 
            confirmButton.DialogResult = DialogResult.OK;
            confirmButton.Location = new Point(861, 242);
            confirmButton.Margin = new Padding(9, 10, 9, 10);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(237, 80);
            confirmButton.TabIndex = 4;
            confirmButton.Text = "OK";
            confirmButton.UseVisualStyleBackColor = true;
            // 
            // UserInfoForm
            // 
            AcceptButton = confirmButton;
            AutoScaleDimensions = new SizeF(19F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 363);
            Controls.Add(confirmButton);
            Controls.Add(lastNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(9, 10, 9, 10);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserInfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Информация о пользователе";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Button confirmButton;
    }
}