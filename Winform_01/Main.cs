using System.Data;
using System.Text;

namespace Winform_01
{
    public partial class Main : Form
    {
        private static Dictionary<Coordinate, object> dataMap = new Dictionary<Coordinate, object>();
        private static DataView dataView = new DataView(); //创建数据视图对象
        private static Main main;

        public Main()
        {
            InitializeComponent();
            this.Text = "员工信息展示";
            ViewBuilder();
            ViewBind();
            main = this;
            staffView.DataError += delegate (object? sender, DataGridViewDataErrorEventArgs e) { };
        }

        public static void _ViewBuilder()
        {
            main.ViewBuilder();
        }

        public static void _ViewBind()
        {
            main.ViewBind();
        }

        /// <summary>
        /// 初始化数据视图
        /// </summary>
        private void ViewBuilder()
        {
            DataSet dataSet = Program.GetDataSet(); //获取数据源

            staffView.AutoGenerateColumns = false; //不显示未绑定的列

            DataTable staff_join_department = TableJoinInfo.JoinTable("staff_join_department",
                dataSet.Tables["staff"],
                dataSet.Tables["department"],
                "department_id", "department_id",
                null, null, "staff_id"); //拼接员工表+部门表

            dataView.Table = TableJoinInfo.JoinTable("staff_join_department_join_savings",
                staff_join_department,
                dataSet.Tables["savings"],
                "savings_account_id", "savings_id",
                null, null, "staff_id"); //拼接员工表+部门表+工资表

            
        }

        /// <summary>
        /// 数据视图绑定
        /// </summary>
        private void ViewBind()
        {
            staffView.DataSource = dataView;

            DataSet dataSet = Program.GetDataSet(); //获取数据源

            //绑定视图下拉框（部门）
            DataGridViewComboBoxColumn column_department_name = (DataGridViewComboBoxColumn)staffView.Columns["department_name"];

            column_department_name.DataPropertyName = "department_name";
            column_department_name.DisplayMember = "department_name";
            column_department_name.ToolTipText = "department_id";

            DataTable department_table = dataSet.Tables["department"];

            column_department_name.DataSource = department_table;
            /*//匹配id
            int rowCount = staffView.Rows.Count;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < department_table.Rows.Count; j++)
                {
                    DataGridViewCell viewCell = staffView.Rows[i].Cells["department_name"];
                    DataRow dataRow = department_table.Rows[j];
                    if (viewCell.ToolTipText == dataRow["department_name"].ToString()) viewCell.ToolTipText = dataRow["department_id"].ToString();
                }
            }*/
        }

        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void select_button_Click(object sender, EventArgs e)
        {
            string conditionSymbol = "like";
            string staff_name = input_staff_name.Text; //员工名
            string staff_phone = input_staff_phone.Text; //员工号码
            string department_name = input_department_name.Text; //部门名
            string savings_account = input_savings_account.Text; //银行卡号
            bool is_accurate_find = accurate_select_ceckbox.Checked; //是否精准查询

            StringBuilder condition = new StringBuilder(); //查询条件

            if (is_accurate_find) conditionSymbol = "=";

            if (staff_name != null && staff_name.Length > 0)
            {
                if (!is_accurate_find) ExpressionParse(ref staff_name);

                condition.Append($"staff_name {conditionSymbol} '{staff_name}' ");
            }

            if (staff_phone != null && staff_phone.Length > 0)
            {
                if (!is_accurate_find) ExpressionParse(ref staff_phone);

                condition.Append($"and staff_phone {conditionSymbol} '{staff_phone}' ");
            }

            if (department_name != null && department_name.Length > 0)
            {
                if (!is_accurate_find) ExpressionParse(ref department_name);

                condition.Append($"and department_name {conditionSymbol} '{department_name}' ");
            }

            if (savings_account != null && savings_account.Length > 0)
            {
                if (!is_accurate_find) ExpressionParse(ref savings_account);

                condition.Append($"and savings_account {conditionSymbol} '{savings_account}'");
            }

            string conditionStr = condition.ToString().Trim(); //查询条件字符串

            //是否是以and开头
            if (conditionStr.StartsWith("and") && conditionStr.ToCharArray()[3] == ' ') conditionStr = conditionStr.Substring(4);
            
            dataView.RowFilter = conditionStr;

            ViewBind();
        }

        private void ExpressionParse(ref string str)
        {
            if (str == null) return;

            if (!str.StartsWith('^') && !str.EndsWith('$'))
            {
                str = $"%{str}%";
                return;
            }

            if (str.StartsWith('^') && str.EndsWith('$'))
            {
                str = str.Replace("^", "");
                str = str.Replace("$", "").Trim();
                return;
            }

            if (str.StartsWith('^')) str = str.Replace("^", "") + "%"; //以什么开头
            if (str.EndsWith('$')) str = "%" + str.Replace("$", ""); //以什么结尾
        }

        /// <summary>
        /// 添加员工按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_staff_button_Click(object sender, EventArgs e)
        {
            AddStaffForm addStaffForm = new AddStaffForm();
            if (addStaffForm.initiallySuccess) addStaffForm.ShowDialog();
            else addStaffForm.Close();
        }

        /// <summary>
        /// 添加部门点击按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_department_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.ShowDialog();
        }

        /// <summary>
        /// 添加卡号按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_savings_Click(object sender, EventArgs e)
        {
            AddSavings addSavings = new AddSavings();
            addSavings.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            Program.SerializationDataSet();
        }

        private void alter(object obj)
        {
            if (obj == null) obj = "^null";
            MessageBox.Show(obj.ToString());
        }

        private void staffView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex; //存储坐标

            Coordinate coordinate = Coordinate.builder(x, y); //构造坐标类

            if (!dataMap.ContainsKey(coordinate)) return; //不存在该信息

            DataGridViewCell cell = staffView.Rows[y].Cells[x]; //被操作的列

            object value = cell.Value; //当前值
            object _value = dataMap[coordinate]; //修改前的值

            if (_value == value) return; //没有进行修改

            if (value.GetType() == typeof(string) && ((string) value).Length < 1)
            {
                MessageBox.Show("不能修改为空字符串！", "错误警告！");
                cell.Value = _value;
                return;
            }

            string columnName = staffView.Columns[x].Name; //获取该列列名

            switch (columnName)
            {
                case "staff_phone":
                    if (((string)value).Length != 11)
                    {
                        cell.Value = _value;
                        MessageBox.Show("手机号必须为11位！");
                        break;
                    }
                    goto case "staff_name";
                case "staff_name":
                case "staff_sex":
                case "staff_age":
                    DataRow dataRow = getDataRow(coordinate, columnName, "staff", null);
                    if (dataRow != null) dataRow[columnName] = value;
                    else goto default;
                    break;
                case "department_name":
                    DataSet dataSet = Program.GetDataSet(); //获取数据源
                    DataTable t_staff = dataSet.Tables["staff"]; //员工表
                    DataTable t_department = dataSet.Tables["department"]; //获取部门表

                    int department_id = -1;

                    foreach (DataRow row in t_department.Rows) if (row[columnName] == value) //找到修改之后的id
                        {
                            department_id = (int)row["department_id"];
                            break;
                        }

                    if (department_id < 0) goto default;

                    int staff_id = (int) staffView.Rows[y].Cells["hide_staff_id"].Value; //获取该员工id

                    foreach (DataRow row in t_staff.Rows)
                    {
                        if ((int)row["staff_id"] == staff_id)
                        {
                            row["department_id"] = department_id;
                            goto default;
                        }
                    }
                    break;
                case "department_salary":
                    DataSet _dataSet = Program.GetDataSet(); //获取数据源
                    DataTable department_t = _dataSet.Tables["department"]; //获取部门表

                    string department_name = (string) staffView.Rows[y].Cells["department_name"].Value; //部门名

                    foreach (DataRow row in department_t.Rows) //遍历要修改的数据行
                    {
                        if (department_name == row["department_name"].ToString())
                        {
                            row["department_salary"] = value;
                            goto default;
                        }
                    }
                    break;
                case "savings_balance":
                    DataSet _dataSet_ = Program.GetDataSet(); //获取数据源

                    DataTable savings_t = _dataSet_.Tables["savings"]; //获取表

                    string savings_account = (string)staffView.Rows[y].Cells["savings_account"].Value; //卡号

                    foreach (DataRow row in savings_t.Rows) //遍历要修改的数据行
                    {
                        if (savings_account == row["savings_account"].ToString())
                        {
                            row["savings_balance"] = value;
                            break;
                        }
                    }
                    break;
                default:
                    dataMap.Remove(coordinate); //删除坐标
                    Main._ViewBuilder();
                    Main._ViewBind();
                    break;
            }
            Program.SerializationDataSet();
        }

        private DataRow getDataRow(Coordinate coordinate, string cellName, string tableName, string? columnName)
        {
            DataSet dataSet = Program.GetDataSet(); //获取数据源
            
            DataTable dataTable = dataSet.Tables[tableName]; //获取表

            if (dataTable == null) return null;

            if (columnName == null || columnName.Length < 1) columnName = cellName;

            object _value = dataMap[coordinate]; //获取修改前的值

            int count = dataTable.Rows.Count; //获取数据行数

            for (int i = 0; i < count; i++) //遍历比较
            {
                DataRow dataRow = dataTable.Rows[i];
                if (dataRow[columnName] == _value) return dataRow;
            }

            return null;
        }

        private void staffView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex; //存储坐标

            object value = staffView.Rows[y].Cells[x].Value; //存储修改前信息

            Coordinate coordinate = Coordinate.builder(x, y);

            if (!dataMap.ContainsKey(coordinate)) dataMap.Add(coordinate, value);
            else dataMap[coordinate] = value;
        }

        //坐标类
        private class Coordinate : IEquatable<Coordinate?>
        {
            private int x, y;

            private Coordinate(int x, int y)
            {
                this.x = x; 
                this.y = y;
            }

            public int getX { get { return x; } }
            public int getY { get { return y; } }

            public static Coordinate builder(int x, int y)
            {
                return new Coordinate(x, y);
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as Coordinate);
            }

            public bool Equals(Coordinate? other)
            {
                return other != null &&
                       x == other.x &&
                       y == other.y &&
                       getX == other.getX &&
                       getY == other.getY;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(x, y, getX, getY);
            }
        }

        /// <summary>
        /// 右键删除点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow viewRow = null; //数据行

            for (int i = 0; i < staffView.Rows.Count; i++) //获取选中的行
            {
                DataGridViewRow row = staffView.Rows[i];
                if (row.Selected)
                {
                    viewRow = staffView.Rows[i];
                    break;
                }

                for (int j = 0; j < row.Cells.Count; j++) //判断该行是否有列被选择
                {
                    if (row.Cells[j].Selected)
                    {
                        viewRow = row;
                        i = staffView.Rows.Count;
                        break;
                    }
                }
            }

            if (viewRow == null)
            {
                _ViewBuilder();
                _ViewBind();
                return;
            }

            string staff_name = viewRow.Cells["staff_name"].Value.ToString(); //获取员工名

            DialogResult result = MessageBox.Show($"是否删除{staff_name}的信息！", "操作提示！", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            DataSet datatSet = Program.GetDataSet(); //获取数据源

            DataTable staff_table = datatSet.Tables["staff"]; //获取员工表

            int staff_id = (int) viewRow.Cells["hide_staff_id"].Value; //获取员工id

            for (int i = 0; i < staff_table.Rows.Count; i++) //遍历表数据
            {
                DataRow row = staff_table.Rows[i];
                if ((int) row["staff_id"] == staff_id) //删除对应数据
                {
                    int account_id = (int)row["savings_account_id"]; //卡号id

                    if (account_id < 1)
                    {
                        _ViewBuilder();
                        _ViewBind();
                        return;
                    }

                    DataTable savings_table = datatSet.Tables["savings"]; //卡号表

                    foreach (DataRow savings_row in savings_table.Rows)
                    {
                        if ((int)savings_row["savings_id"] == account_id)
                        {
                            savings_row["master_id"] = -1; //解绑卡号
                            break;
                        }
                    }

                    staff_table.Rows.RemoveAt(i);
                    break;
                }
            }

            _ViewBuilder();
            _ViewBind();
            Program.SerializationDataSet();
        }
    }
}