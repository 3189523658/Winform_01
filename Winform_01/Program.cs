using System.Data;
using System.Text;
using System.Timers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Winform_01
{

    internal static class Program
    {
        private const string logFilename = "log.text"; //��־�ļ���
        private const string dataFilename = "datasource.data"; //�ļ���
        private const string executableDirectory = "bin"; //��ִ���ļ�Ŀ¼��;

        private static bool initiallyTimer = true; //�Ƿ���Ҫ��ʼ����ʱ��
        private static string directoryPath; //�ļ�Ŀ¼�ַ���
        private static DataSet dataSet = new DataSet(); //����Դ
        private static System.Timers.Timer timer = new System.Timers.Timer(); //������ʱ��

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitiallyFilePath(); //��ʼ��·��

            if (!DeserializationDataSet()) //�����л�ʧ��
            {
                Initially(); //���ɳ�ʼ����
                SerializationDataSet(); //���л�DataSet
            }

            //��ʼ����ʱ��
            TimerSerializationDataSet(null,null);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }

        /// <summary>
        /// ��ʱ���л�DataSet����
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void TimerSerializationDataSet(object? source, ElapsedEventArgs? e)
        {
            if (initiallyTimer)
            {
                timer.Enabled = true; //����
                timer.Interval = 1000 * 60 * 10; //ÿʮ����ִ��һ��
                timer.Start(); //����
                timer.Elapsed += new ElapsedEventHandler(TimerSerializationDataSet);
                initiallyTimer = false;
                return;
            }

            SerializationDataSet(); //���л�DataSet
        }

        /// <summary>
        /// ��ʼ���л��ļ�·��
        /// </summary>
        private static void InitiallyFilePath()
        {
            char stratumSymbol = '/'; //Ĭ��Ŀ¼�ָ���

            string currentDirectory = Directory.GetCurrentDirectory(); //��ȡ��ǰ����·��

            int bin_index = currentDirectory.LastIndexOf(executableDirectory); //��ȡ��ִ���ļ����Ŀ¼λ��

            //�ļ�Ŀ¼����
            DirectoryInfo exeDirectory = Directory.CreateDirectory(currentDirectory.Substring(0, bin_index + executableDirectory.Length));

            directoryPath = exeDirectory.Parent.FullName; //��ȡ��һ��Ŀ¼

            if (!directoryPath.Contains(stratumSymbol)) stratumSymbol = '\\';

            if (!directoryPath.EndsWith(stratumSymbol)) directoryPath += stratumSymbol;
        }

        /// <summary>
        /// ���л�����Դ
        /// </summary>
        public static void SerializationDataSet()
        {
            IFormatter formatter = new BinaryFormatter(); //���������л�����
            try
            {
                using(Stream stream = new FileStream(directoryPath + dataFilename, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    formatter.Serialize(stream, dataSet); //���л�����
                }
            }catch (Exception ex)
            {
                log($"���л�DataSet����Ϊ{directoryPath + dataFilename}�ļ�ʧ�ܣ�\n��ϸ��Ϣ��\n{ex.Message}");
            }

            log($"���л�DataSet����Ϊ{directoryPath+dataFilename}�ļ��ɹ���");
        }

        /// <summary>
        /// ��־��¼�ļ�
        /// </summary>
        /// <param name="logContent">��־����</param>
        public static void log(string logContent)
        {
            DateTime dateTime = DateTime.Now; //��ȡ��ǰʱ��
            //������־
            Stream stream = new FileStream(directoryPath + logFilename, FileMode.Append, FileAccess.Write, FileShare.Read);
            logContent = $"[ {dateTime} ]��{logContent}\n";
            byte[] bytes = Encoding.UTF8.GetBytes(logContent);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        /// <summary>
        /// �����л�����Դ
        /// </summary>
        /// <returns>�Ƿ����л��ɹ�</returns>
        public static bool DeserializationDataSet()
        {
            IFormatter formatter = new BinaryFormatter();

            try
            {
                using (Stream stream = new FileStream(directoryPath + dataFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    dataSet = (DataSet)formatter.Deserialize(stream);
                    log($"�����л�{directoryPath + dataFilename}�ļ�ΪDataSet�ɹ���");
                }
            }catch (Exception ex)
            {
                //������ʧ��
                log("�����л�ʧ�ܣ�\n"+ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// ��ȡ����Դ����
        /// </summary>
        /// <returns>����Դ����</returns>
        public static DataSet GetDataSet()
        {
            return dataSet;
        }

        /// <summary>
        /// DataSet��ʼ����
        /// </summary>
        private static void Initially()
        {
            DataTable department = new DataTable("department"); //���ű�

            DataColumn department_id = new DataColumn("department_id"); //����id
            department_id.DataType = typeof(int);
            department_id.AutoIncrement = true;
            department_id.Unique = true;
            department_id.AllowDBNull = false;
            department_id.AutoIncrementStep = 1;
            department_id.AutoIncrementSeed = 1;

            DataColumn department_name = new DataColumn("department_name"); //������
            department_name.DataType = typeof(string);
            department_name.Unique = true;
            department_name.AllowDBNull = false;

            DataColumn department_salary = new DataColumn("department_salary"); //���Ź���
            department_salary.DefaultValue = 3000;
            department_salary.DataType = typeof(string);
            department_salary.AllowDBNull = false;

            //����е�����
            department.Columns.Add(department_id);
            department.Columns.Add(department_name);
            department.Columns.Add(department_salary);
            department.PrimaryKey = new DataColumn[] { department_id }; //��������

            //����������
            DataRow department_row_01 = department.NewRow();
            department_row_01["department_name"] = "���²�";
            department_row_01["department_salary"] = 4000;
            DataRow department_row_02 = department.NewRow();
            department_row_02["department_name"] = "����";
            department_row_02["department_salary"] = 4500;
            DataRow department_row_03 = department.NewRow();
            department_row_03["department_name"] = "������";
            department_row_03["department_salary"] = 8000;
            DataRow department_row_04 = department.NewRow();
            department_row_04["department_name"] = "���Բ�";
            department_row_04["department_salary"] = 7500;

            //�������
            department.Rows.Add(department_row_01);
            department.Rows.Add(department_row_02);
            department.Rows.Add(department_row_03);
            department.Rows.Add(department_row_04);

            dataSet.Tables.Add(department); //�洢�����ݼ���

            DataTable savings = new DataTable("savings"); //�����

            DataColumn savings_id = new DataColumn("savings_id"); //����id
            savings_id.DataType = typeof(int);
            savings_id.AllowDBNull = false;
            savings_id.AutoIncrement = true;
            savings_id.AutoIncrementSeed = 1;
            savings_id.AutoIncrementStep = 1;

            DataColumn savings_account = new DataColumn("savings_account"); //����˻�
            savings_account.MaxLength = 18;
            savings_account.DataType = typeof(string);
            savings_account.Unique = true;
            savings_account.AllowDBNull = false;

            DataColumn savings_balance = new DataColumn("savings_balance"); //�����
            savings_balance.AllowDBNull = false;
            savings_balance.DefaultValue = 0;
            savings_balance.DataType = typeof(string);

            DataColumn savings_master = new DataColumn("master_id"); //�ֿ���
            savings_master.DataType = typeof(int);
            savings_master.DefaultValue = -1;
            savings_master.AllowDBNull = false;

            //������ӵ�����
            savings.Columns.Add(savings_id);
            savings.Columns.Add(savings_account);
            savings.Columns.Add(savings_balance);
            savings.Columns.Add(savings_master);
            savings.PrimaryKey = new DataColumn[] { savings_id }; //��������

            //����������
            DataRow savings_row_01 = savings.NewRow();
            savings_row_01["savings_account"] = "348761827498348164";
            savings_row_01["savings_balance"] = 800;
            savings_row_01["master_id"] = 1;
            DataRow savings_row_02 = savings.NewRow();
            savings_row_02["savings_account"] = "348761826523448164";
            savings_row_02["savings_balance"] = 3400;
            savings_row_02["master_id"] = 2;
            DataRow savings_row_03 = savings.NewRow();
            savings_row_03["savings_account"] = "383467954872348164";
            savings_row_03["savings_balance"] = 8600;
            savings_row_03["master_id"] = 3;
            DataRow savings_row_04 = savings.NewRow();
            savings_row_04["savings_account"] = "348897566458348164";
            savings_row_04["savings_balance"] = 2800;
            savings_row_04["master_id"] = 4;
            DataRow savings_row_05 = savings.NewRow();
            savings_row_05["savings_account"] = "348675783489563164";
            savings_row_05["savings_balance"] = 5600;
            savings_row_05["master_id"] = 5;
            DataRow savings_row_06 = savings.NewRow();
            savings_row_06["savings_account"] = "348468748947658164";
            savings_row_06["savings_balance"] = 2300;
            savings_row_06["master_id"] = 6;
            DataRow savings_row_07 = savings.NewRow();
            savings_row_07["savings_account"] = "348468543877658164";
            savings_row_07["savings_balance"] = 2630;

            //�������
            savings.Rows.Add(savings_row_01);
            savings.Rows.Add(savings_row_02);
            savings.Rows.Add(savings_row_03);
            savings.Rows.Add(savings_row_04);
            savings.Rows.Add(savings_row_05);
            savings.Rows.Add(savings_row_06);
            savings.Rows.Add(savings_row_07);

            dataSet.Tables.Add(savings); //��Ӵ����

            DataTable staff = new DataTable("staff"); //Ա����

            DataColumn staff_id = new DataColumn("staff_id"); //Ա��id
            staff_id.Unique = true;
            staff_id.AllowDBNull = false;
            staff_id.DataType = typeof(int);
            staff_id.AutoIncrement = true;
            staff_id.AutoIncrementSeed = 1;
            staff_id.AutoIncrementStep = 1;

            DataColumn staff_name = new DataColumn("staff_name"); //Ա����
            staff_name.DataType = typeof(string);
            staff_name.AllowDBNull = false;

            DataColumn staff_sex = new DataColumn("staff_sex"); //Ա���Ա�
            staff_sex.DataType = typeof(string);
            staff_sex.DefaultValue = "��";
            staff_sex.AllowDBNull = false;

            DataColumn staff_age = new DataColumn("staff_age"); //Ա������
            staff_age.DefaultValue = 18;
            staff_age.AllowDBNull = false;
            staff_age.DataType = typeof(string);

            DataColumn staff_phone = new DataColumn("staff_phone"); //Ա���ֻ���
            staff_phone.DataType = typeof(string);
            staff_phone.Unique = true;
            staff_phone.MaxLength = 11;
            staff_phone.AllowDBNull = false;

            DataColumn staff_department_id = new DataColumn("department_id"); //Ա�����ڲ���
            staff_department_id.AllowDBNull = false;
            staff_department_id.DataType = typeof(int);

            DataColumn staff_savings_account = new DataColumn("savings_account_id"); //Ա������˻�
            staff_savings_account.DataType = typeof(int);
            staff_savings_account.AllowDBNull = true;
            staff_savings_account.Unique = true;

            //����е�����
            staff.Columns.Add(staff_id);
            staff.Columns.Add(staff_name);
            staff.Columns.Add(staff_sex);
            staff.Columns.Add(staff_age);
            staff.Columns.Add(staff_phone);
            staff.Columns.Add(staff_department_id);
            staff.Columns.Add(staff_savings_account);
            staff.PrimaryKey = new DataColumn[] { staff_id }; //��������

            //����������
            DataRow staff_row_01 = staff.NewRow();
            staff_row_01["staff_name"] = "����";
            staff_row_01["staff_age"] = 25;
            staff_row_01["staff_phone"] = "13678230934";
            staff_row_01["department_id"] = 3;
            staff_row_01["savings_account_id"] = 1;
            DataRow staff_row_02 = staff.NewRow();
            staff_row_02["staff_name"] = "����";
            staff_row_02["staff_age"] = 23;
            staff_row_02["staff_phone"] = "13667450934";
            staff_row_02["department_id"] = 4;
            staff_row_02["savings_account_id"] = 2;
            DataRow staff_row_03 = staff.NewRow();
            staff_row_03["staff_name"] = "����";
            staff_row_03["staff_age"] = 29;
            staff_row_03["staff_phone"] = "13786544534";
            staff_row_03["department_id"] = 1;
            staff_row_03["savings_account_id"] = 3;
            DataRow staff_row_04 = staff.NewRow();
            staff_row_04["staff_name"] = "����";
            staff_row_04["staff_age"] = 25;
            staff_row_04["staff_phone"] = "13436348954";
            staff_row_04["department_id"] = 2;
            staff_row_04["savings_account_id"] = 4;
            DataRow staff_row_05 = staff.NewRow();
            staff_row_05["staff_name"] = "����";
            staff_row_05["staff_age"] = 21;
            staff_row_05["staff_phone"] = "13765654634";
            staff_row_05["department_id"] = 3;
            staff_row_05["savings_account_id"] = 5;
            DataRow staff_row_06 = staff.NewRow();
            staff_row_06["staff_name"] = "�ϰ�";
            staff_row_06["staff_age"] = 25;
            staff_row_06["staff_phone"] = "13649836984";
            staff_row_06["department_id"] = 4;
            staff_row_06["savings_account_id"] = 6;

            //�������
            staff.Rows.Add(staff_row_01);
            staff.Rows.Add(staff_row_02);
            staff.Rows.Add(staff_row_03);
            staff.Rows.Add(staff_row_04);
            staff.Rows.Add(staff_row_05);
            staff.Rows.Add(staff_row_06);

            dataSet.Tables.Add(staff); //���Ա����

            //�������
            DataRelation staff_join_savings = new DataRelation("staff_join_savings", savings_id, staff_savings_account);
            DataRelation staff_join_department = new DataRelation("staff_join_department", department_id, staff_department_id);

            //������
            dataSet.Relations.Add(staff_join_savings);
            dataSet.Relations.Add(staff_join_department);

            log($"ͨ��{typeof(Program).FullName}.Initially()��������DataSet��ʼ���ݣ�");
        }
    }

    /// <summary>
    /// ��������Ϣ
    /// </summary>
    public static class TableJoinInfo
    {
        private static DataSet dataSet = new DataSet(); //ƴ�Ӻ��洢��

        /// <summary>
        /// ƴ�ӱ���
        /// </summary>
        /// <param name="tableName">ƴ�Ӻ����</param>
        /// <param name="sourcePrimaryTable">����</param>
        /// <param name="sourceSecondaryTable">����</param>
        /// <param name="primaryJoinField">���������ֶ�</param>
        /// <param name="secondaryJoinField">���������ֶ�</param>
        /// <param name="joinColumnMap">����Ҫƴ���ֶ�</param>
        /// <param name="rejectColumnMap">����Ҫ�޳����ֶ�</param>
        /// <param name="primaryKeyName">�±������ֶ���</param>
        /// <returns>�±�</returns>
        public static DataTable JoinTable(string tableName,
            DataTable sourcePrimaryTable, DataTable sourceSecondaryTable,
            string primaryJoinField, string secondaryJoinField,
            Dictionary<string, string?> joinColumnMap, Dictionary<string, string?> rejectColumnMap,
            string primaryKeyName)
        {
            const string separator = "&"; //�ָ��

            if (sourcePrimaryTable == null || sourceSecondaryTable == null) throw new TableJoinException("����͸�����Ϊ�գ�");

            DataTable primaryTable = sourcePrimaryTable.Clone(); //��¡���ݽṹ
            DataTable secondaryTable = sourceSecondaryTable.Clone(); //��¡���ݽṹ

            if (string.IsNullOrEmpty(tableName)) tableName = $"{primaryTable.TableName}_join_{secondaryTable.TableName}"; //Ĭ�ϱ���Ϊ�������_join_�������

            if (string.IsNullOrEmpty(primaryJoinField)) //Ĭ��ʹ���������ӣ�������������ʹ�õ�һ������
            {
                DataColumn[] columns = primaryTable.PrimaryKey;
                if (columns.Length > 0) primaryJoinField = columns[0].ColumnName;
                else primaryJoinField = primaryTable.Columns[0].ColumnName;
            }

            if (string.IsNullOrEmpty(secondaryJoinField)) //Ĭ��ʹ���������ӣ�������������ʹ�õ�һ������
            {
                DataColumn[] columns = secondaryTable.PrimaryKey;
                if (columns.Length > 0) secondaryJoinField = columns[0].ColumnName;
                else secondaryJoinField = primaryTable.Columns[0].ColumnName;
            }

            Dictionary<string, string> tableFieldMap = new Dictionary<string, string>(); //�¾ɱ��ֶ�ӳ����Ϣ

            //��ʼӳ����Ϣ
            for (int i = 0; i < primaryTable.Columns.Count; i++) tableFieldMap.Add($"{sourcePrimaryTable.TableName}{separator}{i}", primaryTable.Columns[i].ColumnName);

            primaryTable.TableName = tableName;

            //������
            ClearRelations(primaryTable, secondaryTable.TableName);
            ClearRelations(secondaryTable, primaryTable.TableName);

            //���ԭ������
            primaryTable.PrimaryKey = new DataColumn[0];
            secondaryTable.PrimaryKey = new DataColumn[0];

            if (rejectColumnMap != null) //����Ҫ�Ƴ��������
            {
                Dictionary<string, string?>.Enumerator reject_enumerator = rejectColumnMap.GetEnumerator(); //��ȡ������
                while (reject_enumerator.MoveNext())
                {
                    string columnName = reject_enumerator.Current.Key; //��ȡ����
                    DataColumn? column = primaryTable.Columns[columnName]; //��ȡ��

                    if (column == null) throw new TableJoinException($"{primaryTable.TableName}���в�������Ϊ��{columnName}���У�");

                    string? columnAlias = reject_enumerator.Current.Value;

                    string tableMapKey = $"{sourcePrimaryTable.TableName}{separator}{TableColumnIndexOf(sourcePrimaryTable, columnName)}";

                    //�и������Ƴ�
                    if (columnAlias != null)
                    {
                        column.ColumnName = columnAlias;
                        tableFieldMap[tableMapKey] = columnAlias; //����ӳ����Ϣ
                    }
                    else
                    {
                        primaryTable.Columns.Remove(column);
                        tableFieldMap.Remove(tableMapKey); //ɾ����ӳ��
                    }
                }
            }

            //Ϊ��Ĭ�ϻ�ȡ����������
            if (joinColumnMap == null || joinColumnMap.Count < 1)
            {
                joinColumnMap = new Dictionary<string, string?>();

                //�������������ֶ�
                foreach (DataColumn column in secondaryTable.Columns)
                {
                    string columnName = column.ColumnName;
                    joinColumnMap.Add(columnName, null);
                }
            }

            Dictionary<string, string?>.Enumerator join_enumerator = joinColumnMap.GetEnumerator(); //��ȡ������

            while (join_enumerator.MoveNext())
            {
                string columnName = join_enumerator.Current.Key; //��ȡ����
                DataColumn? column = secondaryTable.Columns[columnName]; //��ȡ��

                if (column == null) throw new TableJoinException($"{secondaryTable.TableName}���в�������Ϊ��{columnName}���У�");

                string? columnAlias = join_enumerator.Current.Value;

                if (columnAlias != null) column.ColumnName = columnAlias; //��������

                string tableMapKey = $"{sourceSecondaryTable.TableName}{separator}{TableColumnIndexOf(sourceSecondaryTable, columnName)}";

                tableFieldMap.Add(tableMapKey, columnName);

                //���ӳ����Ϣ

                DataColumn dataColumn = DataColumnClone(column);//��¡�ж���
                dataColumn.Unique = false; //ȥ��ΨһԼ��

                try
                {
                    //�����
                    primaryTable.Columns.Add(dataColumn);
                }
                catch (DuplicateNameException)
                {
                    columnAlias = secondaryTable.TableName + "@" + dataColumn;
                    primaryTable.Columns.Add(columnAlias);
                    tableFieldMap.Remove(tableMapKey);
                    tableFieldMap.Add(tableMapKey, columnAlias);
                }
            }

            if (primaryKeyName != null)
            { //���ñ�����
                DataColumn? primaryColumn = primaryTable.Columns[primaryKeyName];
                if (primaryColumn != null) primaryTable.PrimaryKey = new DataColumn[] { primaryColumn };
            }

            int tableRowCount = sourcePrimaryTable.Rows.Count; //��ȡ����������
            int primaryIndex = TableColumnIndexOf(sourcePrimaryTable, primaryJoinField); //��������Ҫ�Ƚϵ���
            int secondaryIndex = TableColumnIndexOf(sourceSecondaryTable, secondaryJoinField); //��������Ҫ�Ƚϵ���
            for (int i = 0; i < tableRowCount; i++)
            {
                DataRow dataRow = primaryTable.NewRow(); //����������
                Dictionary<string, string>.Enumerator enumerator = tableFieldMap.GetEnumerator(); //��ȡ������
                while (enumerator.MoveNext())
                {
                    string[] map = enumerator.Current.Key.Split(separator); //�и�
                    string dataSourceTableName = map[0]; //����Դ����
                    int dataSourceTableIndex = Convert.ToInt32(map[1]); //����Դ����
                    string primaryTableKey = enumerator.Current.Value; //�±���е�����

                    //�������ݣ���ֱ�����
                    if (sourcePrimaryTable.TableName == dataSourceTableName) dataRow[primaryTableKey] = sourcePrimaryTable.Rows[i][dataSourceTableIndex];
                    else //�������ݣ��������
                    {
                        object primary_value = sourcePrimaryTable.Rows[i][primaryIndex]; //�������ֵ
                        string sourcePrimaryTableJoinValue = primary_value == null ? "" : Convert.ToString(primary_value);

                        int secondaryDataRowCount = sourceSecondaryTable.Rows.Count; //������������
                        for (int j = 0; j < secondaryDataRowCount; j++)
                        {
                            object secondary_value = sourceSecondaryTable.Rows[j][secondaryIndex];
                            string secondaryTableJoinValue = secondary_value == null ? "" : Convert.ToString(secondary_value);

                            //��ȡ���ӳɹ����ֵ
                            if (sourcePrimaryTableJoinValue == secondaryTableJoinValue)
                            {
                                dataRow[primaryTableKey] = sourceSecondaryTable.Rows[j][dataSourceTableIndex];
                                break;
                            }
                        }
                    }
                }

                primaryTable.Rows.Add(dataRow);
            }

            if(dataSet.Tables.Contains(primaryTable.TableName)) dataSet.Tables.Remove(primaryTable.TableName);

            dataSet.Tables.Add(primaryTable);

            return primaryTable;
        }

        /// <summary>
        /// ����ָ�������±�
        /// </summary>
        /// <param name="dataTable">���ݱ�</param>
        /// <param name="columnName">����</param>
        /// <returns>�±꣬�����ڷ���-1</returns>
        /// <exception cref="TableJoinException">���ݱ�Ϊ��</exception>
        public static int TableColumnIndexOf(DataTable dataTable,string columnName)
        {
            if (dataTable == null) throw new TableJoinException("���ݱ���Ϊ�գ�");
            if (columnName == null) return -1;

            //��������
            for (int i = 0; i < dataTable.Columns.Count; i++) if (dataTable.Columns[i].ColumnName == columnName) return i;

            return -1;
        }

        /// <summary>
        /// ��¡��
        /// </summary>
        /// <param name="dataColumn">Դ����</param>
        public static DataColumn DataColumnClone(DataColumn dataColumn)
        {
            if (dataColumn == null) return new DataColumn();

            DataColumn column = new DataColumn();

            //��¡��Ϣ
            column.ColumnName = dataColumn.ColumnName;
            column.DataType = dataColumn.DataType;
            column.DefaultValue = dataColumn.DefaultValue;
            column.Unique = dataColumn.Unique;
            column.ColumnMapping = dataColumn.ColumnMapping;
            column.AllowDBNull = dataColumn.AllowDBNull;
            column.AutoIncrement = dataColumn.AutoIncrement;
            column.AutoIncrementSeed = dataColumn.AutoIncrementSeed;
            column.MaxLength = dataColumn.MaxLength;
            column.AutoIncrementStep = dataColumn.AutoIncrementStep;
            column.Caption = dataColumn.Caption;
            column.DateTimeMode = dataColumn.DateTimeMode;
            column.Namespace = dataColumn.Namespace;
            column.Site = dataColumn.Site;
            column.ReadOnly = dataColumn.ReadOnly;
            column.Expression = dataColumn.Expression;
            column.Prefix = dataColumn.Prefix;

            return column;
        }

        /// <summary>
        /// ������ӱ��ϵ
        /// </summary>
        /// <param name="dataTable">Ҫ�����ϵ�ı�</param>
        /// <param name="tableName">Ҫ��������ű�ı���</param>
        public static void ClearRelations(DataTable dataTable,string tableName)
        {
            if (dataTable == null || tableName == null) return;

            DataRelationCollection conllection = dataTable.ChildRelations; //��ȡԼ����ϵ�б�

            foreach (DataRelation relation in conllection) //������ϵ
            {
                string relationName = relation.RelationName; //��ȡ��ϵ��

                if (relationName == null) continue;

                DataTable childTable = relation.ChildTable; //��ȡԼ�����ӱ�

                if (childTable == null) continue;

                if (childTable.TableName != tableName) continue; //����Ҫ�����ϵ�ı�

                childTable.Constraints.Remove(relationName); //ɾ����ϵ
            }
        }

        /// <summary>
        /// ��ȡ��Ӧ������DataTable����
        /// </summary>
        /// <param name="tableName">����</param>
        /// <returns>DataTable����</returns>
        public static DataTable? GetDataTable(string tableName)
        {
            return tableName != null ? dataSet.Tables[tableName] : null;
        }

        /// <summary>
        /// ɾ��DataSet�еı�
        /// </summary>
        /// <param name="tableName">Ҫɾ���ı���</param>
        public static void DeleteDataTable(string tableName)
        {
            dataSet.Tables.Remove(tableName);
        }

        /// <summary>
        /// ��Ϊ���쳣
        /// </summary>
        public class TableJoinException : Exception
        {
            public TableJoinException(string message) : base(message) { }
        }
    }
}