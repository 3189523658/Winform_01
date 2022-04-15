using System.Data;

namespace Winform_01
{
    public partial class AddSavings : Form
    {
        private bool isChanage;
        public AddSavings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 提交按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_submit_Click(object sender, EventArgs e)
        {
            string savings_account = input_savings_account.Text; //卡号
            string savings_balance = input_savings_balance.Text; //卡中余额
            
            if (savings_account.Length < 1)
            {
                MessageBox.Show("请输入卡号！", "错误提示！");
                input_savings_account.Focus();
                return;
            }

            if (savings_account.Length != 18)
            {
                MessageBox.Show("卡号必须为18位！", "错误提示！");
                input_savings_account.Focus();
                return;
            }

            DataSet dataSet = Program.GetDataSet(); //获取数据源

            DataTable savings = dataSet.Tables["savings"];

            DataRow dataRow = savings.NewRow(); //创建数据行
            dataRow["savings_account"] = savings_account;
            dataRow["savings_balance"] = savings_balance;

            try
            {
                savings.Rows.Add(dataRow);
            }catch (ConstraintException ex)
            {
                if (ex.Message.StartsWith("Column 'savings_account' is constrained"))
                {
                    MessageBox.Show($"储蓄卡号以存在！", "错误信息提醒！");
                    input_savings_account.Focus();
                    return;
                }
            }

            MessageBox.Show($"储蓄卡：{savings_account} 添加成功！", "操作信息提醒！");
            isChanage = true;
            input_savings_account.Focus();
        }

        private void AddSavings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;

            if(isChanage) Program.SerializationDataSet();
        }
    }
}
