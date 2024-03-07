namespace DairyFarmManagmentSystem
{
    partial class Employees
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employees));
            EmploeesDGV = new DataGridView();
            label13 = new Label();
            label18 = new Label();
            ClearBtn = new Button();
            DeleteBtn = new Button();
            EditBtn = new Button();
            SaveBtn = new Button();
            panel1 = new Panel();
            DoctorsPanel = new Panel();
            pictureBox3 = new PictureBox();
            DoctorsLb = new Label();
            pictureBox8 = new PictureBox();
            ClientsPanel = new Panel();
            pictureBox1 = new PictureBox();
            ClientsLb = new Label();
            EmpPanel = new Panel();
            pictureBox2 = new PictureBox();
            CowsLb = new Label();
            DOBDTP = new DateTimePicker();
            DateDTB = new Label();
            GenderCb = new ComboBox();
            label2 = new Label();
            EmpNameTb = new TextBox();
            label6 = new Label();
            AddressTb = new TextBox();
            PhoneTb = new TextBox();
            label7 = new Label();
            label8 = new Label();
            PassTb = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            pictureBox9 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)EmploeesDGV).BeginInit();
            panel1.SuspendLayout();
            DoctorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ClientsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            EmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // EmploeesDGV
            // 
            EmploeesDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            EmploeesDGV.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            EmploeesDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            EmploeesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            EmploeesDGV.DefaultCellStyle = dataGridViewCellStyle2;
            EmploeesDGV.EnableHeadersVisualStyles = false;
            EmploeesDGV.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EmploeesDGV.Location = new Point(262, 552);
            EmploeesDGV.Name = "EmploeesDGV";
            EmploeesDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gray;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            EmploeesDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            EmploeesDGV.RowHeadersVisible = false;
            EmploeesDGV.RowHeadersWidth = 51;
            EmploeesDGV.RowTemplate.Height = 29;
            EmploeesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EmploeesDGV.Size = new Size(1026, 236);
            EmploeesDGV.TabIndex = 108;
            EmploeesDGV.CellContentClick += EmploeesDGV_CellContentClick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.FromArgb(0, 0, 192);
            label13.Location = new Point(675, 508);
            label13.Name = "label13";
            label13.Size = new Size(217, 41);
            label13.TabIndex = 97;
            label13.Text = "Employees List";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.Blue;
            label18.Location = new Point(570, 62);
            label18.Name = "label18";
            label18.Size = new Size(164, 41);
            label18.TabIndex = 84;
            label18.Text = "Employees";
            // 
            // ClearBtn
            // 
            ClearBtn.BackColor = SystemColors.ControlDark;
            ClearBtn.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ClearBtn.Location = new Point(958, 458);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(177, 47);
            ClearBtn.TabIndex = 96;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = false;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = SystemColors.ControlDark;
            DeleteBtn.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteBtn.Location = new Point(772, 458);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(177, 47);
            DeleteBtn.TabIndex = 95;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.BackColor = SystemColors.ControlDark;
            EditBtn.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            EditBtn.Location = new Point(525, 458);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(177, 47);
            EditBtn.TabIndex = 94;
            EditBtn.Text = "Edit";
            EditBtn.UseVisualStyleBackColor = false;
            EditBtn.Click += EditBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = SystemColors.ControlDark;
            SaveBtn.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            SaveBtn.Location = new Point(336, 458);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(177, 47);
            SaveBtn.TabIndex = 93;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(DoctorsPanel);
            panel1.Controls.Add(pictureBox8);
            panel1.Controls.Add(ClientsPanel);
            panel1.Controls.Add(EmpPanel);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(242, 800);
            panel1.TabIndex = 82;
            // 
            // DoctorsPanel
            // 
            DoctorsPanel.BackColor = SystemColors.ControlDark;
            DoctorsPanel.Controls.Add(pictureBox3);
            DoctorsPanel.Controls.Add(DoctorsLb);
            DoctorsPanel.Location = new Point(22, 430);
            DoctorsPanel.Name = "DoctorsPanel";
            DoctorsPanel.Size = new Size(200, 75);
            DoctorsPanel.TabIndex = 130;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ButtonFace;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(73, 75);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 32;
            pictureBox3.TabStop = false;
            // 
            // DoctorsLb
            // 
            DoctorsLb.AutoSize = true;
            DoctorsLb.Font = new Font("New Gulim", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            DoctorsLb.Location = new Point(75, 28);
            DoctorsLb.Name = "DoctorsLb";
            DoctorsLb.Size = new Size(122, 28);
            DoctorsLb.TabIndex = 31;
            DoctorsLb.Text = "Doctors";
            DoctorsLb.Click += DoctorsLb_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(22, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(204, 107);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 34;
            pictureBox8.TabStop = false;
            // 
            // ClientsPanel
            // 
            ClientsPanel.BackColor = SystemColors.ControlDark;
            ClientsPanel.Controls.Add(pictureBox1);
            ClientsPanel.Controls.Add(ClientsLb);
            ClientsPanel.Location = new Point(22, 285);
            ClientsPanel.Name = "ClientsPanel";
            ClientsPanel.RightToLeft = RightToLeft.No;
            ClientsPanel.Size = new Size(200, 75);
            ClientsPanel.TabIndex = 129;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // ClientsLb
            // 
            ClientsLb.AutoSize = true;
            ClientsLb.Font = new Font("New Gulim", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            ClientsLb.Location = new Point(82, 22);
            ClientsLb.Name = "ClientsLb";
            ClientsLb.Size = new Size(108, 28);
            ClientsLb.TabIndex = 31;
            ClientsLb.Text = "Clients";
            ClientsLb.Click += ClientsLb_Click;
            // 
            // EmpPanel
            // 
            EmpPanel.BackColor = SystemColors.ControlDarkDark;
            EmpPanel.Controls.Add(pictureBox2);
            EmpPanel.Controls.Add(CowsLb);
            EmpPanel.Location = new Point(22, 160);
            EmpPanel.Name = "EmpPanel";
            EmpPanel.Size = new Size(200, 75);
            EmpPanel.TabIndex = 128;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 33;
            pictureBox2.TabStop = false;
            // 
            // CowsLb
            // 
            CowsLb.AutoSize = true;
            CowsLb.BackColor = SystemColors.ControlDarkDark;
            CowsLb.Font = new Font("New Gulim", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            CowsLb.ForeColor = SystemColors.InactiveCaptionText;
            CowsLb.Location = new Point(79, 18);
            CowsLb.Name = "CowsLb";
            CowsLb.Size = new Size(118, 23);
            CowsLb.TabIndex = 31;
            CowsLb.Text = "Employees";
            // 
            // DOBDTP
            // 
            DOBDTP.Location = new Point(579, 230);
            DOBDTP.Name = "DOBDTP";
            DOBDTP.Size = new Size(250, 27);
            DOBDTP.TabIndex = 124;
            // 
            // DateDTB
            // 
            DateDTB.AutoSize = true;
            DateDTB.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            DateDTB.Location = new Point(579, 160);
            DateDTB.Name = "DateDTB";
            DateDTB.Size = new Size(171, 41);
            DateDTB.TabIndex = 123;
            DateDTB.Text = "DateOfBirth";
            // 
            // GenderCb
            // 
            GenderCb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            GenderCb.FormattingEnabled = true;
            GenderCb.Items.AddRange(new object[] { "Male", "Female" });
            GenderCb.Location = new Point(935, 229);
            GenderCb.Name = "GenderCb";
            GenderCb.Size = new Size(197, 49);
            GenderCb.TabIndex = 109;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(333, 160);
            label2.Name = "label2";
            label2.Size = new Size(95, 41);
            label2.TabIndex = 111;
            label2.Text = "Name";
            // 
            // EmpNameTb
            // 
            EmpNameTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            EmpNameTb.Location = new Point(333, 230);
            EmpNameTb.Name = "EmpNameTb";
            EmpNameTb.Size = new Size(227, 48);
            EmpNameTb.TabIndex = 112;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(935, 160);
            label6.Name = "label6";
            label6.Size = new Size(117, 41);
            label6.TabIndex = 110;
            label6.Text = "Gender";
            // 
            // AddressTb
            // 
            AddressTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            AddressTb.Location = new Point(336, 389);
            AddressTb.Name = "AddressTb";
            AddressTb.Size = new Size(227, 48);
            AddressTb.TabIndex = 116;
            // 
            // PhoneTb
            // 
            PhoneTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            PhoneTb.Location = new Point(638, 389);
            PhoneTb.Name = "PhoneTb";
            PhoneTb.Size = new Size(227, 48);
            PhoneTb.TabIndex = 115;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(634, 319);
            label7.Name = "label7";
            label7.Size = new Size(105, 41);
            label7.TabIndex = 114;
            label7.Text = "Phone";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(336, 319);
            label8.Name = "label8";
            label8.Size = new Size(129, 41);
            label8.TabIndex = 113;
            label8.Text = "Address";
            // 
            // PassTb
            // 
            PassTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            PassTb.Location = new Point(923, 389);
            PassTb.Name = "PassTb";
            PassTb.PasswordChar = '*';
            PassTb.Size = new Size(227, 48);
            PassTb.TabIndex = 126;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(923, 319);
            label3.Name = "label3";
            label3.Size = new Size(150, 41);
            label3.TabIndex = 125;
            label3.Text = "Password";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(pictureBox9);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(242, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1058, 55);
            panel3.TabIndex = 127;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = SystemColors.ActiveBorder;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(976, 3);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(29, 31);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 83;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(246, 3);
            label1.Name = "label1";
            label1.Size = new Size(424, 41);
            label1.TabIndex = 83;
            label1.Text = "Dairy Farm Managment System";
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 800);
            Controls.Add(panel3);
            Controls.Add(PassTb);
            Controls.Add(label3);
            Controls.Add(DOBDTP);
            Controls.Add(DateDTB);
            Controls.Add(GenderCb);
            Controls.Add(label2);
            Controls.Add(EmpNameTb);
            Controls.Add(label6);
            Controls.Add(AddressTb);
            Controls.Add(PhoneTb);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(EmploeesDGV);
            Controls.Add(label13);
            Controls.Add(label18);
            Controls.Add(ClearBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(EditBtn);
            Controls.Add(SaveBtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Employees";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employees";
            ((System.ComponentModel.ISupportInitialize)EmploeesDGV).EndInit();
            panel1.ResumeLayout(false);
            DoctorsPanel.ResumeLayout(false);
            DoctorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ClientsPanel.ResumeLayout(false);
            ClientsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            EmpPanel.ResumeLayout(false);
            EmpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView EmploeesDGV;
        private Label label13;
        private Label label18;
        private Button ClearBtn;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button SaveBtn;
        private Panel panel1;
        private PictureBox pictureBox8;
        private DateTimePicker DOBDTP;
        private Label DateDTB;
        private ComboBox GenderCb;
        private Label label2;
        private TextBox EmpNameTb;
        private Label label6;
        private TextBox AddressTb;
        private TextBox PhoneTb;
        private Label label7;
        private Label label8;
        private TextBox PassTb;
        private Label label3;
        private Panel panel3;
        private PictureBox pictureBox9;
        private Label label1;
        private Panel DoctorsPanel;
        private PictureBox pictureBox3;
        private Label DoctorsLb;
        private Panel ClientsPanel;
        private PictureBox pictureBox1;
        private Label ClientsLb;
        private Panel EmpPanel;
        private PictureBox pictureBox2;
        private Label CowsLb;
    }
}