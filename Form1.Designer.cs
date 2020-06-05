namespace UnikeyAutoSwitch
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.pathsLv = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addBtn = new System.Windows.Forms.Button();
            this.eRb = new System.Windows.Forms.RadioButton();
            this.vRb = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.altzRb = new System.Windows.Forms.RadioButton();
            this.ctrlshiftRb = new System.Windows.Forms.RadioButton();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.setERb = new System.Windows.Forms.RadioButton();
            this.setVRb = new System.Windows.Forms.RadioButton();
            this.blackLv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addBlackListBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(936, 350);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(353, 101);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pathsLv
            // 
            this.pathsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName});
            this.pathsLv.Location = new System.Drawing.Point(16, 21);
            this.pathsLv.Margin = new System.Windows.Forms.Padding(4);
            this.pathsLv.Name = "pathsLv";
            this.pathsLv.Size = new System.Drawing.Size(664, 240);
            this.pathsLv.TabIndex = 1;
            this.pathsLv.UseCompatibleStateImageBehavior = false;
            this.pathsLv.View = System.Windows.Forms.View.Details;
            this.pathsLv.SelectedIndexChanged += new System.EventHandler(this.pathsLv_SelectedIndexChanged);
            this.pathsLv.DoubleClick += new System.EventHandler(this.pathsLv_DoubleClick);
            this.pathsLv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pathsLv_KeyDown);
            // 
            // clmName
            // 
            this.clmName.Text = "Danh sách chương trình";
            this.clmName.Width = 500;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(688, 21);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(58, 122);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Thêm";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // eRb
            // 
            this.eRb.AutoSize = true;
            this.eRb.Checked = true;
            this.eRb.Location = new System.Drawing.Point(52, 28);
            this.eRb.Margin = new System.Windows.Forms.Padding(4);
            this.eRb.Name = "eRb";
            this.eRb.Size = new System.Drawing.Size(38, 21);
            this.eRb.TabIndex = 4;
            this.eRb.TabStop = true;
            this.eRb.Text = "E";
            this.eRb.UseVisualStyleBackColor = true;
            this.eRb.CheckedChanged += new System.EventHandler(this.eRb_CheckedChanged);
            // 
            // vRb
            // 
            this.vRb.AutoSize = true;
            this.vRb.Location = new System.Drawing.Point(52, 57);
            this.vRb.Margin = new System.Windows.Forms.Padding(4);
            this.vRb.Name = "vRb";
            this.vRb.Size = new System.Drawing.Size(38, 21);
            this.vRb.TabIndex = 5;
            this.vRb.Text = "V";
            this.vRb.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vRb);
            this.groupBox1.Controls.Add(this.eRb);
            this.groupBox1.Location = new System.Drawing.Point(16, 444);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(148, 89);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trạng thái Unikey";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.altzRb);
            this.groupBox2.Controls.Add(this.ctrlshiftRb);
            this.groupBox2.Location = new System.Drawing.Point(181, 444);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(192, 89);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phím tắt chuyển Unikey";
            // 
            // altzRb
            // 
            this.altzRb.AutoSize = true;
            this.altzRb.Location = new System.Drawing.Point(52, 57);
            this.altzRb.Margin = new System.Windows.Forms.Padding(4);
            this.altzRb.Name = "altzRb";
            this.altzRb.Size = new System.Drawing.Size(62, 21);
            this.altzRb.TabIndex = 5;
            this.altzRb.Text = "Alt+Z";
            this.altzRb.UseVisualStyleBackColor = true;
            // 
            // ctrlshiftRb
            // 
            this.ctrlshiftRb.AutoSize = true;
            this.ctrlshiftRb.Checked = true;
            this.ctrlshiftRb.Location = new System.Drawing.Point(52, 28);
            this.ctrlshiftRb.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlshiftRb.Name = "ctrlshiftRb";
            this.ctrlshiftRb.Size = new System.Drawing.Size(86, 21);
            this.ctrlshiftRb.TabIndex = 4;
            this.ctrlshiftRb.TabStop = true;
            this.ctrlshiftRb.Text = "Ctrl+Shift";
            this.ctrlshiftRb.UseVisualStyleBackColor = true;
            this.ctrlshiftRb.CheckedChanged += new System.EventHandler(this.ctrlshiftRb_CheckedChanged);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(532, 444);
            this.pauseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(215, 44);
            this.pauseBtn.TabIndex = 8;
            this.pauseBtn.Text = "Tạm dừng";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.setERb);
            this.groupBox3.Controls.Add(this.setVRb);
            this.groupBox3.Location = new System.Drawing.Point(388, 444);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(136, 89);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trong danh sách";
            // 
            // setERb
            // 
            this.setERb.AutoSize = true;
            this.setERb.Location = new System.Drawing.Point(28, 28);
            this.setERb.Margin = new System.Windows.Forms.Padding(4);
            this.setERb.Name = "setERb";
            this.setERb.Size = new System.Drawing.Size(63, 21);
            this.setERb.TabIndex = 5;
            this.setERb.Text = "Set E";
            this.setERb.UseVisualStyleBackColor = true;
            // 
            // setVRb
            // 
            this.setVRb.AutoSize = true;
            this.setVRb.Checked = true;
            this.setVRb.Location = new System.Drawing.Point(28, 57);
            this.setVRb.Margin = new System.Windows.Forms.Padding(4);
            this.setVRb.Name = "setVRb";
            this.setVRb.Size = new System.Drawing.Size(63, 21);
            this.setVRb.TabIndex = 4;
            this.setVRb.TabStop = true;
            this.setVRb.Text = "Set V";
            this.setVRb.UseVisualStyleBackColor = true;
            this.setVRb.CheckedChanged += new System.EventHandler(this.onRb_CheckedChanged);
            // 
            // blackLv
            // 
            this.blackLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.blackLv.Location = new System.Drawing.Point(16, 269);
            this.blackLv.Margin = new System.Windows.Forms.Padding(4);
            this.blackLv.Name = "blackLv";
            this.blackLv.Size = new System.Drawing.Size(664, 167);
            this.blackLv.TabIndex = 9;
            this.blackLv.UseCompatibleStateImageBehavior = false;
            this.blackLv.View = System.Windows.Forms.View.Details;
            this.blackLv.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.blackLv.DoubleClick += new System.EventHandler(this.blackLv_DoubleClick);
            this.blackLv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.blackLv_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh sách không ảnh hưởng";
            this.columnHeader1.Width = 500;
            // 
            // addBlackListBtn
            // 
            this.addBlackListBtn.Location = new System.Drawing.Point(688, 269);
            this.addBlackListBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addBlackListBtn.Name = "addBlackListBtn";
            this.addBlackListBtn.Size = new System.Drawing.Size(58, 81);
            this.addBlackListBtn.TabIndex = 10;
            this.addBlackListBtn.Text = "Thêm";
            this.addBlackListBtn.UseVisualStyleBackColor = true;
            this.addBlackListBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 496);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 37);
            this.button3.TabIndex = 11;
            this.button3.Text = "Thông tin";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(688, 151);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 110);
            this.button4.TabIndex = 12;
            this.button4.Text = "Chi tiết";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(689, 355);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 81);
            this.button5.TabIndex = 13;
            this.button5.Text = "Chi tiết";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 544);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.addBlackListBtn);
            this.Controls.Add(this.blackLv);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.pathsLv);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển đổi tự động Unikey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView pathsLv;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.RadioButton eRb;
        private System.Windows.Forms.RadioButton vRb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton altzRb;
        private System.Windows.Forms.RadioButton ctrlshiftRb;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton setERb;
        private System.Windows.Forms.RadioButton setVRb;
        private System.Windows.Forms.ListView blackLv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button addBlackListBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

