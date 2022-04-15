using System.Data;

namespace Winform_01
{
    public partial class AddDepartment : Form
    {
        private bool isChanage;

        public AddDepartment()
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
            DataSet dataSet = Program.GetDataSet(); //数据源

            string department_name = input_department_name.Text; //部门名
            string department_salary = input_department_salary.Text; //部门薪资
            
            if (department_name.Length < 1)
            {
                MessageBox.Show("请输入部门名！", "错误提示！");
                input_department_name.Focus();
                return;
            }

            DataTable t_department = dataSet.Tables["department"]; //获取部门表

            DataRow dataRow = t_department.NewRow(); //创建新行

            dataRow["department_name"] = department_name;
            dataRow["department_salary"] = department_salary;

            try
            {
                t_department.Rows.Add(dataRow); //添加到表
            }catch (ConstraintException ex)
            {
                if (ex.Message.StartsWith("Column 'department_name' is constrained"))
                {
                    MessageBox.Show("部门以存在！", "错误提示！");
                    input_department_name.Focus();
                    return;
                }
            }

            MessageBox.Show($"部门：{department_name} 添加成功！", "提示！");
            isChanage = true;
            input_department_name.Focus();
        }

        private void AddDepartment_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;

            if (isChanage)
            {
                Main._ViewBuilder();
                Main._ViewBind();
                Program.SerializationDataSet();
            }
        }
    }
}
