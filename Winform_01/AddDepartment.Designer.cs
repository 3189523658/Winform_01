namespace Winform_01
{
    partial class AddDepartment
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
            this.txt_title = new System.Windows.Forms.Label();
            this.input_department_name = new System.Windows.Forms.TextBox();
            this.txt_department_name = new System.Windows.Forms.Label();
            this.txt_department_salary = new System.Windows.Forms.Label();
            this.input_department_salary = new System.Windows.Forms.NumericUpDown();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input_department_salary)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_title.Location = new System.Drawing.Point(89, 9);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(110, 31);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "部门信息";
            // 
            // input_department_name
            // 
            this.input_department_name.Location = new System.Drawing.Point(104, 57);
            this.input_department_name.Name = "input_department_name";
            this.input_department_name.PlaceholderText = "请输入部门名";
            this.input_department_name.Size = new System.Drawing.Size(153, 23);
            this.input_department_name.TabIndex = 1;
            // 
            // txt_department_name
            // 
            this.txt_department_name.AutoSize = true;
            this.txt_department_name.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_department_name.Location = new System.Drawing.Point(47, 58);
            this.txt_department_name.Name = "txt_department_name";
            this.txt_department_name.Size = new System.Drawing.Size(51, 20);
            this.txt_department_name.TabIndex = 2;
            this.txt_department_name.Text = "部门名";
            // 
            // txt_department_salary
            // 
            this.txt_department_salary.AutoSize = true;
            this.txt_department_salary.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_department_salary.Location = new System.Drawing.Point(33, 101);
            this.txt_department_salary.Name = "txt_department_salary";
            this.txt_department_salary.Size = new System.Drawing.Size(65, 20);
            this.txt_department_salary.TabIndex = 2;
            this.txt_department_salary.Text = "部门薪资";
            // 
            // input_department_salary
            // 
            this.input_department_salary.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.input_department_salary.Location = new System.Drawing.Point(104, 101);
            this.input_department_salary.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.input_department_salary.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.input_department_salary.Name = "input_department_salary";
            this.input_department_salary.Size = new System.Drawing.Size(153, 23);
            this.input_department_salary.TabIndex = 3;
            this.input_department_salary.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(75, 156);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(71, 31);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(171, 156);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(71, 31);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "提交";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // AddDepartment
            // 
            this.AcceptButton = this.btn_submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(314, 246);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.input_department_salary);
            this.Controls.Add(this.txt_department_salary);
            this.Controls.Add(this.txt_department_name);
            this.Controls.Add(this.input_department_name);
            this.Controls.Add(this.txt_title);
            this.Name = "AddDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门添加";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddDepartment_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.input_department_salary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txt_title;
        private TextBox input_department_name;
        private Label txt_department_name;
        private Label txt_department_salary;
        private NumericUpDown input_department_salary;
        private Button btn_cancel;
        private Button btn_submit;
    }
}