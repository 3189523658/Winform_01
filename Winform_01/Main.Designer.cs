namespace Winform_01
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.viewBox = new System.Windows.Forms.GroupBox();
            this.staffView = new System.Windows.Forms.DataGridView();
            this.staff_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hide_staff_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_sex = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.staff_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hide_department_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.department_salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hide_savings_account_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.savings_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.savings_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_staff_button = new System.Windows.Forms.Button();
            this.add_department = new System.Windows.Forms.Button();
            this.add_savings = new System.Windows.Forms.Button();
            this.input_staff_name = new System.Windows.Forms.TextBox();
            this.input_department_name = new System.Windows.Forms.TextBox();
            this.input_savings_account = new System.Windows.Forms.TextBox();
            this.accurate_select_ceckbox = new System.Windows.Forms.CheckBox();
            this.select_button = new System.Windows.Forms.Button();
            this.input_staff_phone = new System.Windows.Forms.TextBox();
            this.viewBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffView)).BeginInit();
            this.staffViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewBox
            // 
            this.viewBox.AutoSize = true;
            this.viewBox.Controls.Add(this.staffView);
            this.viewBox.Location = new System.Drawing.Point(0, 74);
            this.viewBox.Name = "viewBox";
            this.viewBox.Size = new System.Drawing.Size(1244, 731);
            this.viewBox.TabIndex = 0;
            this.viewBox.TabStop = false;
            // 
            // staffView
            // 
            this.staffView.AllowUserToAddRows = false;
            this.staffView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.staffView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.staffView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staffView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.staff_id,
            this.hide_staff_id,
            this.staff_name,
            this.staff_sex,
            this.staff_age,
            this.staff_phone,
            this.hide_department_id,
            this.department_name,
            this.department_salary,
            this.hide_savings_account_id,
            this.savings_account,
            this.savings_balance});
            this.staffView.ContextMenuStrip = this.staffViewMenuStrip;
            this.staffView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.staffView.Location = new System.Drawing.Point(3, 19);
            this.staffView.MultiSelect = false;
            this.staffView.Name = "staffView";
            this.staffView.RowTemplate.Height = 25;
            this.staffView.Size = new System.Drawing.Size(1238, 709);
            this.staffView.TabIndex = 0;
            this.staffView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.staffView_CellBeginEdit);
            this.staffView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.staffView_CellEndEdit);
            // 
            // staff_id
            // 
            this.staff_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.staff_id.DataPropertyName = "staff_id";
            this.staff_id.Frozen = true;
            this.staff_id.HeaderText = "编号";
            this.staff_id.Name = "staff_id";
            this.staff_id.ReadOnly = true;
            this.staff_id.Width = 57;
            // 
            // hide_staff_id
            // 
            this.hide_staff_id.DataPropertyName = "staff_id";
            this.hide_staff_id.HeaderText = "员工id";
            this.hide_staff_id.Name = "hide_staff_id";
            this.hide_staff_id.ReadOnly = true;
            this.hide_staff_id.Visible = false;
            this.hide_staff_id.Width = 68;
            // 
            // staff_name
            // 
            this.staff_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.staff_name.DataPropertyName = "staff_name";
            this.staff_name.HeaderText = "姓名";
            this.staff_name.Name = "staff_name";
            this.staff_name.Width = 57;
            // 
            // staff_sex
            // 
            this.staff_sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.staff_sex.DataPropertyName = "staff_sex";
            this.staff_sex.HeaderText = "性别";
            this.staff_sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.staff_sex.Name = "staff_sex";
            this.staff_sex.Width = 38;
            // 
            // staff_age
            // 
            this.staff_age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.staff_age.DataPropertyName = "staff_age";
            this.staff_age.HeaderText = "年龄";
            this.staff_age.Name = "staff_age";
            this.staff_age.Width = 57;
            // 
            // staff_phone
            // 
            this.staff_phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.staff_phone.DataPropertyName = "staff_phone";
            this.staff_phone.HeaderText = "手机号码";
            this.staff_phone.Name = "staff_phone";
            this.staff_phone.Width = 81;
            // 
            // hide_department_id
            // 
            this.hide_department_id.DataPropertyName = "department_id";
            this.hide_department_id.HeaderText = "部门id";
            this.hide_department_id.Name = "hide_department_id";
            this.hide_department_id.ReadOnly = true;
            this.hide_department_id.Visible = false;
            this.hide_department_id.Width = 68;
            // 
            // department_name
            // 
            this.department_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.department_name.HeaderText = "部门名";
            this.department_name.Name = "department_name";
            this.department_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.department_name.Width = 50;
            // 
            // department_salary
            // 
            this.department_salary.DataPropertyName = "department_salary";
            this.department_salary.HeaderText = "部门工资";
            this.department_salary.Name = "department_salary";
            this.department_salary.Width = 81;
            // 
            // hide_savings_account_id
            // 
            this.hide_savings_account_id.DataPropertyName = "savings_id";
            this.hide_savings_account_id.HeaderText = "卡号id";
            this.hide_savings_account_id.Name = "hide_savings_account_id";
            this.hide_savings_account_id.ReadOnly = true;
            this.hide_savings_account_id.Visible = false;
            this.hide_savings_account_id.Width = 68;
            // 
            // savings_account
            // 
            this.savings_account.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.savings_account.DataPropertyName = "savings_account";
            this.savings_account.HeaderText = "工资卡号";
            this.savings_account.Name = "savings_account";
            this.savings_account.ReadOnly = true;
            this.savings_account.Width = 81;
            // 
            // savings_balance
            // 
            this.savings_balance.DataPropertyName = "savings_balance";
            this.savings_balance.HeaderText = "卡余额";
            this.savings_balance.Name = "savings_balance";
            this.savings_balance.Width = 69;
            // 
            // staffViewMenuStrip
            // 
            this.staffViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.staffViewMenuStrip.Name = "staffViewMenuStrip";
            this.staffViewMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // add_staff_button
            // 
            this.add_staff_button.Location = new System.Drawing.Point(77, 12);
            this.add_staff_button.Name = "add_staff_button";
            this.add_staff_button.Size = new System.Drawing.Size(87, 56);
            this.add_staff_button.TabIndex = 1;
            this.add_staff_button.Text = "添加员工";
            this.add_staff_button.UseVisualStyleBackColor = true;
            this.add_staff_button.Click += new System.EventHandler(this.add_staff_button_Click);
            // 
            // add_department
            // 
            this.add_department.Location = new System.Drawing.Point(200, 12);
            this.add_department.Name = "add_department";
            this.add_department.Size = new System.Drawing.Size(87, 56);
            this.add_department.TabIndex = 1;
            this.add_department.Text = "添加部门";
            this.add_department.UseVisualStyleBackColor = true;
            this.add_department.Click += new System.EventHandler(this.add_department_Click);
            // 
            // add_savings
            // 
            this.add_savings.Location = new System.Drawing.Point(323, 12);
            this.add_savings.Name = "add_savings";
            this.add_savings.Size = new System.Drawing.Size(87, 56);
            this.add_savings.TabIndex = 1;
            this.add_savings.Text = "添加卡号";
            this.add_savings.UseVisualStyleBackColor = true;
            this.add_savings.Click += new System.EventHandler(this.add_savings_Click);
            // 
            // input_staff_name
            // 
            this.input_staff_name.Location = new System.Drawing.Point(482, 12);
            this.input_staff_name.Name = "input_staff_name";
            this.input_staff_name.PlaceholderText = "请输入员工姓名";
            this.input_staff_name.Size = new System.Drawing.Size(183, 23);
            this.input_staff_name.TabIndex = 2;
            // 
            // input_department_name
            // 
            this.input_department_name.Location = new System.Drawing.Point(860, 12);
            this.input_department_name.Name = "input_department_name";
            this.input_department_name.PlaceholderText = "请输入部门名";
            this.input_department_name.Size = new System.Drawing.Size(183, 23);
            this.input_department_name.TabIndex = 2;
            // 
            // input_savings_account
            // 
            this.input_savings_account.Location = new System.Drawing.Point(1049, 12);
            this.input_savings_account.Name = "input_savings_account";
            this.input_savings_account.PlaceholderText = "请输入卡号";
            this.input_savings_account.Size = new System.Drawing.Size(183, 23);
            this.input_savings_account.TabIndex = 2;
            // 
            // accurate_select_ceckbox
            // 
            this.accurate_select_ceckbox.AutoSize = true;
            this.accurate_select_ceckbox.Location = new System.Drawing.Point(704, 43);
            this.accurate_select_ceckbox.Name = "accurate_select_ceckbox";
            this.accurate_select_ceckbox.Size = new System.Drawing.Size(75, 21);
            this.accurate_select_ceckbox.TabIndex = 3;
            this.accurate_select_ceckbox.Text = "精准查询";
            this.accurate_select_ceckbox.UseVisualStyleBackColor = true;
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(801, 41);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(117, 23);
            this.select_button.TabIndex = 4;
            this.select_button.Text = "查询";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // input_staff_phone
            // 
            this.input_staff_phone.Location = new System.Drawing.Point(671, 12);
            this.input_staff_phone.Name = "input_staff_phone";
            this.input_staff_phone.PlaceholderText = "请输入员工号码";
            this.input_staff_phone.Size = new System.Drawing.Size(183, 23);
            this.input_staff_phone.TabIndex = 2;
            // 
            // Main
            // 
            this.AcceptButton = this.select_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1244, 806);
            this.Controls.Add(this.select_button);
            this.Controls.Add(this.accurate_select_ceckbox);
            this.Controls.Add(this.input_savings_account);
            this.Controls.Add(this.input_department_name);
            this.Controls.Add(this.input_staff_phone);
            this.Controls.Add(this.input_staff_name);
            this.Controls.Add(this.add_savings);
            this.Controls.Add(this.add_department);
            this.Controls.Add(this.add_staff_button);
            this.Controls.Add(this.viewBox);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.viewBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffView)).EndInit();
            this.staffViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox viewBox;
        private DataGridView staffView;
        private Button add_staff_button;
        private Button add_department;
        private Button add_savings;
        private TextBox input_staff_name;
        private TextBox input_department_name;
        private TextBox input_savings_account;
        private CheckBox accurate_select_ceckbox;
        private Button select_button;
        private TextBox input_staff_phone;
        private DataGridViewTextBoxColumn staff_id;
        private DataGridViewTextBoxColumn hide_staff_id;
        private DataGridViewTextBoxColumn staff_name;
        private DataGridViewComboBoxColumn staff_sex;
        private DataGridViewTextBoxColumn staff_age;
        private DataGridViewTextBoxColumn staff_phone;
        private DataGridViewTextBoxColumn hide_department_id;
        private DataGridViewComboBoxColumn department_name;
        private DataGridViewTextBoxColumn department_salary;
        private DataGridViewTextBoxColumn hide_savings_account_id;
        private DataGridViewTextBoxColumn savings_account;
        private DataGridViewTextBoxColumn savings_balance;
        private ContextMenuStrip staffViewMenuStrip;
        private ToolStripMenuItem 删除ToolStripMenuItem;
    }
}