using System.Data;
using System.Text;

namespace Winform_01
{
    public partial class Main : Form
    {
        private static Dictionary<Coordinate, object> dataMap = new Dictionary<Coordinate, object>();
        private static DataView dataView = new DataView(); //����������ͼ����
        private static Main main;

        public Main()
        {
            InitializeComponent();
            this.Text = "Ա����Ϣչʾ";
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
        /// ��ʼ��������ͼ
        /// </summary>
        private void ViewBuilder()
        {
            DataSet dataSet = Program.GetDataSet(); //��ȡ����Դ

            staffView.AutoGenerateColumns = false; //����ʾδ�󶨵���

            DataTable staff_join_department = TableJoinInfo.JoinTable("staff_join_department",
                dataSet.Tables["staff"],
                dataSet.Tables["department"],
                "department_id", "department_id",
                null, null, "staff_id"); //ƴ��Ա����+���ű�

            dataView.Table = TableJoinInfo.JoinTable("staff_join_department_join_savings",
                staff_join_department,
                dataSet.Tables["savings"],
                "savings_account_id", "savings_id",
                null, null, "staff_id"); //ƴ��Ա����+���ű�+���ʱ�

            
        }

        /// <summary>
        /// ������ͼ��
        /// </summary>
        private void ViewBind()
        {
            staffView.DataSource = dataView;

            DataSet dataSet = Program.GetDataSet(); //��ȡ����Դ

            //����ͼ�����򣨲��ţ�
            DataGridViewComboBoxColumn column_department_name = (DataGridViewComboBoxColumn)staffView.Columns["department_name"];

            column_department_name.DataPropertyName = "department_name";
            column_department_name.DisplayMember = "department_name";
            column_department_name.ToolTipText = "department_id";

            DataTable department_table = dataSet.Tables["department"];

            column_department_name.DataSource = department_table;
            /*//ƥ��id
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
        /// ��ѯ��ť����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void select_button_Click(object sender, EventArgs e)
        {
            string conditionSymbol = "like";
            string staff_name = input_staff_name.Text; //Ա����
            string staff_phone = input_staff_phone.Text; //Ա������
            string department_name = input_department_name.Text; //������
            string savings_account = input_savings_account.Text; //���п���
            bool is_accurate_find = accurate_select_ceckbox.Checked; //�Ƿ�׼��ѯ

            StringBuilder condition = new StringBuilder(); //��ѯ����

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

            string conditionStr = condition.ToString().Trim(); //��ѯ�����ַ���

            //�Ƿ�����and��ͷ
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

            if (str.StartsWith('^')) str = str.Replace("^", "") + "%"; //��ʲô��ͷ
            if (str.EndsWith('$')) str = "%" + str.Replace("$", ""); //��ʲô��β
        }

        /// <summary>
        /// ���Ա����ť����¼�
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
        /// ��Ӳ��ŵ����ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_department_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.ShowDialog();
        }

        /// <summary>
        /// ��ӿ��Ű�ť����¼�
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
            int x = e.ColumnIndex, y = e.RowIndex; //�洢����

            Coordinate coordinate = Coordinate.builder(x, y); //����������

            if (!dataMap.ContainsKey(coordinate)) return; //�����ڸ���Ϣ

            DataGridViewCell cell = staffView.Rows[y].Cells[x]; //����������

            object value = cell.Value; //��ǰֵ
            object _value = dataMap[coordinate]; //�޸�ǰ��ֵ

            if (_value == value) return; //û�н����޸�

            if (value.GetType() == typeof(string) && ((string) value).Length < 1)
            {
                MessageBox.Show("�����޸�Ϊ���ַ�����", "���󾯸棡");
                cell.Value = _value;
                return;
            }

            string columnName = staffView.Columns[x].Name; //��ȡ��������

            switch (columnName)
            {
                case "staff_phone":
                    if (((string)value).Length != 11)
                    {
                        cell.Value = _value;
                        MessageBox.Show("�ֻ��ű���Ϊ11λ��");
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
                    DataSet dataSet = Program.GetDataSet(); //��ȡ����Դ
                    DataTable t_staff = dataSet.Tables["staff"]; //Ա����
                    DataTable t_department = dataSet.Tables["department"]; //��ȡ���ű�

                    int department_id = -1;

                    foreach (DataRow row in t_department.Rows) if (row[columnName] == value) //�ҵ��޸�֮���id
                        {
                            department_id = (int)row["department_id"];
                            break;
                        }

                    if (department_id < 0) goto default;

                    int staff_id = (int) staffView.Rows[y].Cells["hide_staff_id"].Value; //��ȡ��Ա��id

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
                    DataSet _dataSet = Program.GetDataSet(); //��ȡ����Դ
                    DataTable department_t = _dataSet.Tables["department"]; //��ȡ���ű�

                    string department_name = (string) staffView.Rows[y].Cells["department_name"].Value; //������

                    foreach (DataRow row in department_t.Rows) //����Ҫ�޸ĵ�������
                    {
                        if (department_name == row["department_name"].ToString())
                        {
                            row["department_salary"] = value;
                            goto default;
                        }
                    }
                    break;
                case "savings_balance":
                    DataSet _dataSet_ = Program.GetDataSet(); //��ȡ����Դ

                    DataTable savings_t = _dataSet_.Tables["savings"]; //��ȡ��

                    string savings_account = (string)staffView.Rows[y].Cells["savings_account"].Value; //����

                    foreach (DataRow row in savings_t.Rows) //����Ҫ�޸ĵ�������
                    {
                        if (savings_account == row["savings_account"].ToString())
                        {
                            row["savings_balance"] = value;
                            break;
                        }
                    }
                    break;
                default:
                    dataMap.Remove(coordinate); //ɾ������
                    Main._ViewBuilder();
                    Main._ViewBind();
                    break;
            }
            Program.SerializationDataSet();
        }

        private DataRow getDataRow(Coordinate coordinate, string cellName, string tableName, string? columnName)
        {
            DataSet dataSet = Program.GetDataSet(); //��ȡ����Դ
            
            DataTable dataTable = dataSet.Tables[tableName]; //��ȡ��

            if (dataTable == null) return null;

            if (columnName == null || columnName.Length < 1) columnName = cellName;

            object _value = dataMap[coordinate]; //��ȡ�޸�ǰ��ֵ

            int count = dataTable.Rows.Count; //��ȡ��������

            for (int i = 0; i < count; i++) //�����Ƚ�
            {
                DataRow dataRow = dataTable.Rows[i];
                if (dataRow[columnName] == _value) return dataRow;
            }

            return null;
        }

        private void staffView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex; //�洢����

            object value = staffView.Rows[y].Cells[x].Value; //�洢�޸�ǰ��Ϣ

            Coordinate coordinate = Coordinate.builder(x, y);

            if (!dataMap.ContainsKey(coordinate)) dataMap.Add(coordinate, value);
            else dataMap[coordinate] = value;
        }

        //������
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
        /// �Ҽ�ɾ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow viewRow = null; //������

            for (int i = 0; i < staffView.Rows.Count; i++) //��ȡѡ�е���
            {
                DataGridViewRow row = staffView.Rows[i];
                if (row.Selected)
                {
                    viewRow = staffView.Rows[i];
                    break;
                }

                for (int j = 0; j < row.Cells.Count; j++) //�жϸ����Ƿ����б�ѡ��
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

            string staff_name = viewRow.Cells["staff_name"].Value.ToString(); //��ȡԱ����

            DialogResult result = MessageBox.Show($"�Ƿ�ɾ��{staff_name}����Ϣ��", "������ʾ��", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            DataSet datatSet = Program.GetDataSet(); //��ȡ����Դ

            DataTable staff_table = datatSet.Tables["staff"]; //��ȡԱ����

            int staff_id = (int) viewRow.Cells["hide_staff_id"].Value; //��ȡԱ��id

            for (int i = 0; i < staff_table.Rows.Count; i++) //����������
            {
                DataRow row = staff_table.Rows[i];
                if ((int) row["staff_id"] == staff_id) //ɾ����Ӧ����
                {
                    int account_id = (int)row["savings_account_id"]; //����id

                    if (account_id < 1)
                    {
                        _ViewBuilder();
                        _ViewBind();
                        return;
                    }

                    DataTable savings_table = datatSet.Tables["savings"]; //���ű�

                    foreach (DataRow savings_row in savings_table.Rows)
                    {
                        if ((int)savings_row["savings_id"] == account_id)
                        {
                            savings_row["master_id"] = -1; //��󿨺�
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