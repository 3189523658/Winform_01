using System.Data;

namespace Winform_01
{
    public partial class AddStaffForm : Form
    {
        private static DataSet dataSet = Program.GetDataSet();
        public bool initiallySuccess;

        public AddStaffForm()
        {
            InitializeComponent();

            initiallySuccess = initiallyData();
        }

        /// <summary>
        /// 初始化表单信息
        /// </summary>
        private bool initiallyData ()
        {
            input_staff_sex.SelectedIndex = 0; //性别默认选择男

            //绑定数据
            input_department_name.DataSource = dataSet.Tables["department"];
            input_department_name.ValueMember = "department_id";
            input_department_name.DisplayMember = "department_name";

            DataView dataView = dataSet.Tables["savings"].AsDataView();
            dataView.RowFilter = "master_id = -1"; //过滤已被使用的卡

            if (dataView.Count < 1)
            {
                MessageBox.Show("没有工资卡账户了，请先创建工资卡账户再添加员工！", "提示信息！");
                this.Close();
                return false;
            }

            input_savings_account.DataSource = dataView;
            input_savings_account.ValueMember = "savings_id";
            input_savings_account.DisplayMember = "savings_account";

            return true;
        }

        /// <summary>
        /// 重置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_reset_Click(object sender, EventArgs e)
        {
            input_staff_name.Text = "";
            input_staff_age.Value = 18;
            input_staff_phone.Text = "";
            input_staff_sex.SelectedIndex = 0;
            input_department_name.SelectedIndex = 0;
            try
            {
                input_savings_account.SelectedIndex = 0;
            }catch (Exception)
            {
                MessageBox.Show("没有工资卡账户了，请先创建工资卡账户再添加员工！", "提示信息！");
                this.Close();
                return ;
            }

            input_staff_name.Focus();
        }

        /// <summary>
        /// 提交按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_submit_Click(object sender, EventArgs e)
        {
            string staff_name = input_staff_name.Text; //员工姓名
            string staff_phone = input_staff_phone.Text; //手机号

            if (staff_name == "")
            {
                MessageBox.Show("请输入员工姓名！", "错误提示");
                input_staff_name.Focus();
                return;
            }

            if (staff_phone == "")
            {
                MessageBox.Show("请输入员工手机号！", "错误提示");
                input_staff_phone.Focus();
                return;
            }

            if (staff_phone.Length != 11)
            {
                MessageBox.Show("请输入正确的手机号！", "错误提示");
                input_staff_phone.Focus();
                return;
            }

            DataTable staff = dataSet.Tables["staff"];

            DataRow staff_row = staff.NewRow();

            staff_row["staff_name"] = staff_name;
            staff_row["staff_age"] = input_staff_age.Value; //员工年龄
            staff_row["staff_sex"] = input_staff_sex.Text; //员工性别
            staff_row["staff_phone"] = staff_phone;
            staff_row["department_id"] = input_department_name.SelectedValue; //部门id

            object savings_id = input_savings_account.SelectedValue; //卡号id
            if (savings_id != null) staff_row["savings_account_id"] = savings_id;

            try
            {
                staff.Rows.Add(staff_row); //添加
            }catch (ConstraintException ex)
            {
                if (ex.Message.StartsWith("Column 'staff_phone'"))
                {
                    MessageBox.Show($"手机号：{staff_phone} 以被使用，请输入其它号码！", "错误信息！");
                    input_staff_phone.Focus();
                    return;
                }
            }

            if (savings_id != null) {
                //更新卡信息
                DataTable savings = dataSet.Tables["savings"];
                DataRow savings_row = savings.Rows.Find(staff_row["savings_account_id"]);

                savings_row["master_id"] = staff_row["staff_id"];
            }

            Main._ViewBuilder();
            Main._ViewBind();

            MessageBox.Show($"添加员工：{staff_name} 成功！");

            Program.SerializationDataSet();

            if (initiallyData()) button_reset_Click(sender, e);
        }
    }
}
