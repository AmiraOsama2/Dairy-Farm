namespace DairyFarmManagmentSystem
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            UserNameTb = new TextBox();
            PasswordTb = new TextBox();
            LoginBtn = new Button();
            RoleCb = new ComboBox();
            ResetLbl = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(799, 254);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // UserNameTb
            // 
            UserNameTb.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            UserNameTb.Location = new Point(46, 332);
            UserNameTb.Name = "UserNameTb";
            UserNameTb.PlaceholderText = "User Name";
            UserNameTb.Size = new Size(227, 34);
            UserNameTb.TabIndex = 6;
            UserNameTb.TextAlign = HorizontalAlignment.Center;
            // 
            // PasswordTb
            // 
            PasswordTb.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordTb.Location = new Point(532, 332);
            PasswordTb.Multiline = true;
            PasswordTb.Name = "PasswordTb";
            PasswordTb.PlaceholderText = "Password";
            PasswordTb.Size = new Size(227, 34);
            PasswordTb.TabIndex = 7;
            PasswordTb.TextAlign = HorizontalAlignment.Center;
            PasswordTb.UseSystemPasswordChar = true;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = SystemColors.ActiveCaptionText;
            LoginBtn.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            LoginBtn.ForeColor = SystemColors.ButtonHighlight;
            LoginBtn.Location = new Point(305, 309);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(197, 129);
            LoginBtn.TabIndex = 8;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // RoleCb
            // 
            RoleCb.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            RoleCb.FormattingEnabled = true;
            RoleCb.Items.AddRange(new object[] { "Admin", "Employee" });
            RoleCb.Location = new Point(305, 269);
            RoleCb.Name = "RoleCb";
            RoleCb.Size = new Size(197, 34);
            RoleCb.TabIndex = 9;
            RoleCb.Text = "Select Role";
            // 
            // ResetLbl
            // 
            ResetLbl.AutoSize = true;
            ResetLbl.BackColor = Color.LightBlue;
            ResetLbl.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ResetLbl.ForeColor = SystemColors.ActiveCaptionText;
            ResetLbl.Location = new Point(697, 412);
            ResetLbl.Name = "ResetLbl";
            ResetLbl.Size = new Size(62, 26);
            ResetLbl.TabIndex = 10;
            ResetLbl.Text = "Reset";
            ResetLbl.Click += ResetLbl_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(747, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(173, 216, 230);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(ResetLbl);
            Controls.Add(RoleCb);
            Controls.Add(LoginBtn);
            Controls.Add(PasswordTb);
            Controls.Add(UserNameTb);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private TextBox UserNameTb;
        private TextBox PasswordTb;
        private Button LoginBtn;
        private ComboBox RoleCb;
        private Label ResetLbl;
        private PictureBox pictureBox2;
    }
}