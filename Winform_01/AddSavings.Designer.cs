namespace Winform_01
{
    partial class AddSavings
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
            this.txt_savings_account = new System.Windows.Forms.Label();
            this.input_savings_account = new System.Windows.Forms.TextBox();
            this.txt_savings_balance = new System.Windows.Forms.Label();
            this.input_savings_balance = new System.Windows.Forms.NumericUpDown();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input_savings_balance)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_title.Location = new System.Drawing.Point(92, 24);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(110, 31);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "卡号信息";
            // 
            // txt_savings_account
            // 
            this.txt_savings_account.AutoSize = true;
            this.txt_savings_account.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_savings_account.Location = new System.Drawing.Point(49, 82);
            this.txt_savings_account.Name = "txt_savings_account";
            this.txt_savings_account.Size = new System.Drawing.Size(37, 20);
            this.txt_savings_account.TabIndex = 1;
            this.txt_savings_account.Text = "卡号";
            // 
            // input_savings_account
            // 
            this.input_savings_account.Location = new System.Drawing.Point(92, 81);
            this.input_savings_account.Name = "input_savings_account";
            this.input_savings_account.PlaceholderText = "请输入账户";
            this.input_savings_account.Size = new System.Drawing.Size(176, 23);
            this.input_savings_account.TabIndex = 2;
            // 
            // txt_savings_balance
            // 
            this.txt_savings_balance.AutoSize = true;
            this.txt_savings_balance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_savings_balance.Location = new System.Drawing.Point(21, 122);
            this.txt_savings_balance.Name = "txt_savings_balance";
            this.txt_savings_balance.Size = new System.Drawing.Size(65, 20);
            this.txt_savings_balance.TabIndex = 1;
            this.txt_savings_balance.Text = "卡中余额";
            // 
            // input_savings_balance
            // 
            this.input_savings_balance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.input_savings_balance.Location = new System.Drawing.Point(92, 122);
            this.input_savings_balance.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.input_savings_balance.Name = "input_savings_balance";
            this.input_savings_balance.Size = new System.Drawing.Size(176, 23);
            this.input_savings_balance.TabIndex = 3;
            this.input_savings_balance.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(158, 175);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(67, 31);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "提交";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(71, 175);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(67, 31);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // AddSavings
            // 
            this.AcceptButton = this.btn_submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(319, 245);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.input_savings_balance);
            this.Controls.Add(this.input_savings_account);
            this.Controls.Add(this.txt_savings_balance);
            this.Controls.Add(this.txt_savings_account);
            this.Controls.Add(this.txt_title);
            this.Name = "AddSavings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工资卡账户添加";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSavings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.input_savings_balance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txt_title;
        private Label txt_savings_account;
        private TextBox input_savings_account;
        private Label txt_savings_balance;
        private NumericUpDown input_savings_balance;
        private Button btn_submit;
        private Button btn_cancel;
    }
}