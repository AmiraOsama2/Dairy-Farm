namespace DairyFarmManagmentSystem
{
    partial class Clients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel3 = new Panel();
            pictureBox9 = new PictureBox();
            label1 = new Label();
            DoctorsPanel = new Panel();
            pictureBox3 = new PictureBox();
            DocLb = new Label();
            ClientsPanel = new Panel();
            pictureBox1 = new PictureBox();
            ProductionLb = new Label();
            label2 = new Label();
            ClientNameTb = new TextBox();
            ClientAddressTb = new TextBox();
            EmpPanel = new Panel();
            pictureBox2 = new PictureBox();
            EmpLb = new Label();
            ClientPhoneTb = new TextBox();
            label7 = new Label();
            pictureBox8 = new PictureBox();
            label8 = new Label();
            ClientsDGV = new DataGridView();
            label13 = new Label();
            label18 = new Label();
            ClearBtn = new Button();
            DeleteBtn = new Button();
            EditBtn = new Button();
            SaveBtn = new Button();
            panel1 = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            DoctorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ClientsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            EmpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
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
            panel3.TabIndex = 148;
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
            // DoctorsPanel
            // 
            DoctorsPanel.BackColor = SystemColors.ControlDark;
            DoctorsPanel.Controls.Add(pictureBox3);
            DoctorsPanel.Controls.Add(DocLb);
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
            // DocLb
            // 
            DocLb.AutoSize = true;
            DocLb.Font = new Font("New Gulim", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            DocLb.Location = new Point(75, 28);
            DocLb.Name = "DocLb";
            DocLb.Size = new Size(122, 28);
            DocLb.TabIndex = 31;
            DocLb.Text = "Doctors";
            DocLb.Click += DocLb_Click;
            // 
            // ClientsPanel
            // 
            ClientsPanel.BackColor = SystemColors.ControlDarkDark;
            ClientsPanel.Controls.Add(pictureBox1);
            ClientsPanel.Controls.Add(ProductionLb);
            ClientsPanel.Location = new Point(22, 285);
            ClientsPanel.Name = "ClientsPanel";
            ClientsPanel.RightToLeft = RightToLeft.No;
            ClientsPanel.Size = new Size(200, 75);
            ClientsPanel.TabIndex = 129;
            ClientsPanel.Paint += ClientsPanel_Paint;
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
            // ProductionLb
            // 
            ProductionLb.AutoSize = true;
            ProductionLb.Font = new Font("New Gulim", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            ProductionLb.Location = new Point(82, 22);
            ProductionLb.Name = "ProductionLb";
            ProductionLb.Size = new Size(108, 28);
            ProductionLb.TabIndex = 31;
            ProductionLb.Text = "Clients";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(333, 160);
            label2.Name = "label2";
            label2.Size = new Size(95, 41);
            label2.TabIndex = 138;
            label2.Text = "Name";
            // 
            // ClientNameTb
            // 
            ClientNameTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ClientNameTb.Location = new Point(333, 230);
            ClientNameTb.Name = "ClientNameTb";
            ClientNameTb.Size = new Size(227, 48);
            ClientNameTb.TabIndex = 139;
            // 
            // ClientAddressTb
            // 
            ClientAddressTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ClientAddressTb.Location = new Point(958, 230);
            ClientAddressTb.Name = "ClientAddressTb";
            ClientAddressTb.Size = new Size(227, 48);
            ClientAddressTb.TabIndex = 143;
            // 
            // EmpPanel
            // 
            EmpPanel.BackColor = SystemColors.ControlDark;
            EmpPanel.Controls.Add(pictureBox2);
            EmpPanel.Controls.Add(EmpLb);
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
            // EmpLb
            // 
            EmpLb.AutoSize = true;
            EmpLb.BackColor = SystemColors.ControlDark;
            EmpLb.Font = new Font("New Gulim", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            EmpLb.ForeColor = SystemColors.InactiveCaptionText;
            EmpLb.Location = new Point(79, 18);
            EmpLb.Name = "EmpLb";
            EmpLb.Size = new Size(118, 23);
            EmpLb.TabIndex = 31;
            EmpLb.Text = "Employees";
            EmpLb.Click += EmpLb_Click;
            // 
            // ClientPhoneTb
            // 
            ClientPhoneTb.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ClientPhoneTb.Location = new Point(631, 230);
            ClientPhoneTb.Name = "ClientPhoneTb";
            ClientPhoneTb.Size = new Size(227, 48);
            ClientPhoneTb.TabIndex = 142;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(627, 160);
            label7.Name = "label7";
            label7.Size = new Size(105, 41);
            label7.TabIndex = 141;
            label7.Text = "Phone";
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(958, 160);
            label8.Name = "label8";
            label8.Size = new Size(129, 41);
            label8.TabIndex = 140;
            label8.Text = "Address";
            // 
            // ClientsDGV
            // 
            ClientsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ClientsDGV.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ClientsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ClientsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ClientsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            ClientsDGV.EnableHeadersVisualStyles = false;
            ClientsDGV.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ClientsDGV.Location = new Point(262, 552);
            ClientsDGV.Name = "ClientsDGV";
            ClientsDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gray;
            dataGridViewCellStyle3.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            ClientsDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ClientsDGV.RowHeadersVisible = false;
            ClientsDGV.RowHeadersWidth = 51;
            ClientsDGV.RowTemplate.Height = 29;
            ClientsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClientsDGV.Size = new Size(1026, 236);
            ClientsDGV.TabIndex = 135;
            ClientsDGV.CellContentClick += ClientsDGV_CellContentClick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.FromArgb(0, 0, 192);
            label13.Location = new Point(675, 508);
            label13.Name = "label13";
            label13.Size = new Size(162, 41);
            label13.TabIndex = 134;
            label13.Text = "Clients List";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.Blue;
            label18.Location = new Point(675, 69);
            label18.Name = "label18";
            label18.Size = new Size(109, 41);
            label18.TabIndex = 129;
            label18.Text = "Clients";
            // 
            // ClearBtn
            // 
            ClearBtn.BackColor = SystemColors.ControlDark;
            ClearBtn.Font = new Font("PT Bold Heading", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ClearBtn.Location = new Point(958, 458);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(177, 47);
            ClearBtn.TabIndex = 133;
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
            DeleteBtn.TabIndex = 132;
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
            EditBtn.TabIndex = 131;
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
            SaveBtn.TabIndex = 130;
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
            panel1.TabIndex = 128;
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 800);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(ClientNameTb);
            Controls.Add(ClientAddressTb);
            Controls.Add(ClientPhoneTb);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(ClientsDGV);
            Controls.Add(label13);
            Controls.Add(label18);
            Controls.Add(ClearBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(EditBtn);
            Controls.Add(SaveBtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Clients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clients";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            DoctorsPanel.ResumeLayout(false);
            DoctorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ClientsPanel.ResumeLayout(false);
            ClientsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            EmpPanel.ResumeLayout(false);
            EmpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox9;
        private Label label1;
        private Panel DoctorsPanel;
        private PictureBox pictureBox3;
        private Label DocLb;
        private Panel ClientsPanel;
        private PictureBox pictureBox1;
        private Label ProductionLb;
        private Label label2;
        private TextBox ClientNameTb;
        private TextBox ClientAddressTb;
        private Panel EmpPanel;
        private PictureBox pictureBox2;
        private Label EmpLb;
        private TextBox ClientPhoneTb;
        private Label label7;
        private PictureBox pictureBox8;
        private Label label8;
        private DataGridView ClientsDGV;
        private Label label13;
        private Label label18;
        private Button ClearBtn;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button SaveBtn;
        private Panel panel1;
    }
}