namespace Winform_01
{
    partial class AddStaffForm
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
            this.txt_staff_name = new System.Windows.Forms.Label();
            this.txt_prompt = new System.Windows.Forms.Label();
            this.input_staff_name = new System.Windows.Forms.TextBox();
            this.txt_staff_age = new System.Windows.Forms.Label();
            this.txt_staff_sex = new System.Windows.Forms.Label();
            this.txt_staff_phone = new System.Windows.Forms.Label();
            this.input_staff_phone = new System.Windows.Forms.TextBox();
            this.txt_department_name = new System.Windows.Forms.Label();
            this.txt_savings_account = new System.Windows.Forms.Label();
            this.input_staff_age = new System.Windows.Forms.NumericUpDown();
            this.input_staff_sex = new System.Windows.Forms.ComboBox();
            this.input_department_name = new System.Windows.Forms.ComboBox();
            this.input_savings_account = new System.Windows.Forms.ComboBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input_staff_age)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_staff_name
            // 
            this.txt_staff_name.AutoSize = true;
            this.txt_staff_name.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_staff_name.Location = new System.Drawing.Point(71, 73);
            this.txt_staff_name.Name = "txt_staff_name";
            this.txt_staff_name.Size = new System.Drawing.Size(42, 21);
            this.txt_staff_name.TabIndex = 0;
            this.txt_staff_name.Text = "姓名";
            // 
            // txt_prompt
            // 
            this.txt_prompt.AutoSize = true;
            this.txt_prompt.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_prompt.Location = new System.Drawing.Point(131, 9);
            this.txt_prompt.Name = "txt_prompt";
            this.txt_prompt.Size = new System.Drawing.Size(146, 41);
            this.txt_prompt.TabIndex = 1;
            this.txt_prompt.Text = "员工信息";
            // 
            // input_staff_name
            // 
            this.input_staff_name.Location = new System.Drawing.Point(119, 73);
            this.input_staff_name.Name = "input_staff_name";
            this.input_staff_name.PlaceholderText = "请输入员工姓名";
            this.input_staff_name.Size = new System.Drawing.Size(233, 23);
            this.input_staff_name.TabIndex = 2;
            // 
            // txt_staff_age
            // 
            this.txt_staff_age.AutoSize = true;
            this.txt_staff_age.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_staff_age.Location = new System.Drawing.Point(71, 114);
            this.txt_staff_age.Name = "txt_staff_age";
            this.txt_staff_age.Size = new System.Drawing.Size(42, 21);
            this.txt_staff_age.TabIndex = 0;
            this.txt_staff_age.Text = "年龄";
            // 
            // txt_staff_sex
            // 
            this.txt_staff_sex.AutoSize = true;
            this.txt_staff_sex.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_staff_sex.Location = new System.Drawing.Point(71, 154);
            this.txt_staff_sex.Name = "txt_staff_sex";
            this.txt_staff_sex.Size = new System.Drawing.Size(42, 21);
            this.txt_staff_sex.TabIndex = 0;
            this.txt_staff_sex.Text = "性别";
            // 
            // txt_staff_phone
            // 
            this.txt_staff_phone.AutoSize = true;
            this.txt_staff_phone.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_staff_phone.Location = new System.Drawing.Point(55, 191);
            this.txt_staff_phone.Name = "txt_staff_phone";
            this.txt_staff_phone.Size = new System.Drawing.Size(58, 21);
            this.txt_staff_phone.TabIndex = 0;
            this.txt_staff_phone.Text = "手机号";
            // 
            // input_staff_phone
            // 
            this.input_staff_phone.Location = new System.Drawing.Point(119, 192);
            this.input_staff_phone.Name = "input_staff_phone";
            this.input_staff_phone.PlaceholderText = "请输入员工手机号";
            this.input_staff_phone.Size = new System.Drawing.Size(233, 23);
            this.input_staff_phone.TabIndex = 2;
            // 
            // txt_department_name
            // 
            this.txt_department_name.AutoSize = true;
            this.txt_department_name.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_department_name.Location = new System.Drawing.Point(71, 230);
            this.txt_department_name.Name = "txt_department_name";
            this.txt_department_name.Size = new System.Drawing.Size(42, 21);
            this.txt_department_name.TabIndex = 0;
            this.txt_department_name.Text = "部门";
            // 
            // txt_savings_account
            // 
            this.txt_savings_account.AutoSize = true;
            this.txt_savings_account.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_savings_account.Location = new System.Drawing.Point(71, 268);
            this.txt_savings_account.Name = "txt_savings_account";
            this.txt_savings_account.Size = new System.Drawing.Size(42, 21);
            this.txt_savings_account.TabIndex = 0;
            this.txt_savings_account.Text = "卡号";
            // 
            // input_staff_age
            // 
            this.input_staff_age.Location = new System.Drawing.Point(119, 114);
            this.input_staff_age.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input_staff_age.Name = "input_staff_age";
            this.input_staff_age.Size = new System.Drawing.Size(233, 23);
            this.input_staff_age.TabIndex = 3;
            this.input_staff_age.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // input_staff_sex
            // 
            this.input_staff_sex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.input_staff_sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_staff_sex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.input_staff_sex.FormattingEnabled = true;
            this.input_staff_sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.input_staff_sex.Location = new System.Drawing.Point(119, 152);
            this.input_staff_sex.Name = "input_staff_sex";
            this.input_staff_sex.Size = new System.Drawing.Size(233, 25);
            this.input_staff_sex.TabIndex = 4;
            // 
            // input_department_name
            // 
            this.input_department_name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.input_department_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_department_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.input_department_name.FormattingEnabled = true;
            this.input_department_name.Location = new System.Drawing.Point(119, 230);
            this.input_department_name.MaxDropDownItems = 4;
            this.input_department_name.Name = "input_department_name";
            this.input_department_name.Size = new System.Drawing.Size(233, 25);
            this.input_department_name.TabIndex = 4;
            // 
            // input_savings_account
            // 
            this.input_savings_account.Cursor = System.Windows.Forms.Cursors.Hand;
            this.input_savings_account.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_savings_account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.input_savings_account.FormattingEnabled = true;
            this.input_savings_account.Location = new System.Drawing.Point(119, 268);
            this.input_savings_account.MaxDropDownItems = 4;
            this.input_savings_account.Name = "input_savings_account";
            this.input_savings_account.Size = new System.Drawing.Size(233, 25);
            this.input_savings_account.TabIndex = 4;
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(236, 323);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(92, 33);
            this.button_submit.TabIndex = 5;
            this.button_submit.Text = "提交";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(131, 323);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(92, 33);
            this.button_reset.TabIndex = 5;
            this.button_reset.Text = "重填";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // AddStaffForm
            // 
            this.AcceptButton = this.button_submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_reset;
            this.ClientSize = new System.Drawing.Size(431, 388);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.input_department_name);
            this.Controls.Add(this.input_savings_account);
            this.Controls.Add(this.input_staff_sex);
            this.Controls.Add(this.input_staff_age);
            this.Controls.Add(this.txt_savings_account);
            this.Controls.Add(this.input_staff_phone);
            this.Controls.Add(this.txt_department_name);
            this.Controls.Add(this.txt_staff_phone);
            this.Controls.Add(this.txt_staff_sex);
            this.Controls.Add(this.input_staff_name);
            this.Controls.Add(this.txt_staff_age);
            this.Controls.Add(this.txt_prompt);
            this.Controls.Add(this.txt_staff_name);
            this.Name = "AddStaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加员工";
            ((System.ComponentModel.ISupportInitialize)(this.input_staff_age)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txt_staff_name;
        private Label txt_prompt;
        private TextBox input_staff_name;
        private Label txt_staff_age;
        private Label txt_staff_sex;
        private Label txt_staff_phone;
        private TextBox input_staff_phone;
        private Label txt_department_name;
        private Label txt_savings_account;
        private NumericUpDown input_staff_age;
        private ComboBox input_staff_sex;
        private ComboBox input_department_name;
        private ComboBox input_savings_account;
        private Button button_submit;
        private Button button_reset;
    }
}