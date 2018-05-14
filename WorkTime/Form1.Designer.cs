namespace WorkTime
{
    partial class TimeTable
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ShowButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Deptbutton = new System.Windows.Forms.Button();
			this.EmpButton = new System.Windows.Forms.Button();
			this.buttonbuttonRefresh = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(81, 11);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
			this.comboBox2.Location = new System.Drawing.Point(81, 38);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Department";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Period";
			// 
			// ShowButton
			// 
			this.ShowButton.Location = new System.Drawing.Point(13, 72);
			this.ShowButton.Name = "ShowButton";
			this.ShowButton.Size = new System.Drawing.Size(189, 23);
			this.ShowButton.TabIndex = 4;
			this.ShowButton.Text = "Show";
			this.ShowButton.UseVisualStyleBackColor = true;
			this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 408);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "label3";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dataGridView1);
			this.panel1.Location = new System.Drawing.Point(13, 102);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(775, 211);
			this.panel1.TabIndex = 6;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(775, 211);
			this.dataGridView1.TabIndex = 0;
			// 
			// Deptbutton
			// 
			this.Deptbutton.Location = new System.Drawing.Point(699, 9);
			this.Deptbutton.Name = "Deptbutton";
			this.Deptbutton.Size = new System.Drawing.Size(89, 23);
			this.Deptbutton.TabIndex = 7;
			this.Deptbutton.Text = "Departments";
			this.Deptbutton.UseVisualStyleBackColor = true;
			this.Deptbutton.Click += new System.EventHandler(this.Deptbutton_Click);
			// 
			// EmpButton
			// 
			this.EmpButton.Location = new System.Drawing.Point(699, 38);
			this.EmpButton.Name = "EmpButton";
			this.EmpButton.Size = new System.Drawing.Size(89, 23);
			this.EmpButton.TabIndex = 8;
			this.EmpButton.Text = "Employees";
			this.EmpButton.UseVisualStyleBackColor = true;
			this.EmpButton.Click += new System.EventHandler(this.EmpButton_Click);
			// 
			// buttonbuttonRefresh
			// 
			this.buttonbuttonRefresh.Location = new System.Drawing.Point(699, 68);
			this.buttonbuttonRefresh.Name = "buttonbuttonRefresh";
			this.buttonbuttonRefresh.Size = new System.Drawing.Size(89, 23);
			this.buttonbuttonRefresh.TabIndex = 9;
			this.buttonbuttonRefresh.Text = "Refresh";
			this.buttonbuttonRefresh.UseVisualStyleBackColor = true;
			this.buttonbuttonRefresh.Click += new System.EventHandler(this.buttonbuttonRefresh_Click);
			// 
			// TimeTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonbuttonRefresh);
			this.Controls.Add(this.EmpButton);
			this.Controls.Add(this.Deptbutton);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ShowButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Name = "TimeTable";
			this.Text = "TimeTable";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeTable_FormClosing);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Deptbutton;
        private System.Windows.Forms.Button EmpButton;
        private System.Windows.Forms.Button buttonbuttonRefresh;
    }
}

