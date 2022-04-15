using System.Data;
using System.Text;
using System.Timers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Winform_01
{

    internal static class Program
    {
        private const string logFilename = "log.text"; //日志文件名
        private const string dataFilename = "datasource.data"; //文件名
        private const string executableDirectory = "bin"; //可执行文件目录名;

        private static bool initiallyTimer = true; //是否需要初始化定时器
        private static string directoryPath; //文件目录字符串
        private static DataSet dataSet = new DataSet(); //数据源
        private static System.Timers.Timer timer = new System.Timers.Timer(); //创建定时器

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitiallyFilePath(); //初始化路径

            if (!DeserializationDataSet()) //反序列化失败
            {
                Initially(); //生成初始数据
                SerializationDataSet(); //序列化DataSet
            }

            //初始化定时器
            TimerSerializationDataSet(null,null);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }

        /// <summary>
        /// 定时序列化DataSet对象
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void TimerSerializationDataSet(object? source, ElapsedEventArgs? e)
        {
            if (initiallyTimer)
            {
                timer.Enabled = true; //开启
                timer.Interval = 1000 * 60 * 10; //每十分钟执行一次
                timer.Start(); //启动
                timer.Elapsed += new ElapsedEventHandler(TimerSerializationDataSet);
                initiallyTimer = false;
                return;
            }

            SerializationDataSet(); //序列化DataSet
        }

        /// <summary>
        /// 初始序列化文件路径
        /// </summary>
        private static void InitiallyFilePath()
        {
            char stratumSymbol = '/'; //默认目录分隔符

            string currentDirectory = Directory.GetCurrentDirectory(); //获取当前工作路径

            int bin_index = currentDirectory.LastIndexOf(executableDirectory); //获取可执行文件存放目录位置

            //文件目录对象
            DirectoryInfo exeDirectory = Directory.CreateDirectory(currentDirectory.Substring(0, bin_index + executableDirectory.Length));

            directoryPath = exeDirectory.Parent.FullName; //获取上一级目录

            if (!directoryPath.Contains(stratumSymbol)) stratumSymbol = '\\';

            if (!directoryPath.EndsWith(stratumSymbol)) directoryPath += stratumSymbol;
        }

        /// <summary>
        /// 序列化数据源
        /// </summary>
        public static void SerializationDataSet()
        {
            IFormatter formatter = new BinaryFormatter(); //二进制序列化对象
            try
            {
                using(Stream stream = new FileStream(directoryPath + dataFilename, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    formatter.Serialize(stream, dataSet); //序列化对象
                }
            }catch (Exception ex)
            {
                log($"序列化DataSet对象为{directoryPath + dataFilename}文件失败！\n详细信息：\n{ex.Message}");
            }

            log($"序列化DataSet对象为{directoryPath+dataFilename}文件成功！");
        }

        /// <summary>
        /// 日志记录文件
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public static void log(string logContent)
        {
            DateTime dateTime = DateTime.Now; //获取当前时间
            //创建日志
            Stream stream = new FileStream(directoryPath + logFilename, FileMode.Append, FileAccess.Write, FileShare.Read);
            logContent = $"[ {dateTime} ]：{logContent}\n";
            byte[] bytes = Encoding.UTF8.GetBytes(logContent);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        /// <summary>
        /// 反序列化数据源
        /// </summary>
        /// <returns>是否反序列化成功</returns>
        public static bool DeserializationDataSet()
        {
            IFormatter formatter = new BinaryFormatter();

            try
            {
                using (Stream stream = new FileStream(directoryPath + dataFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    dataSet = (DataSet)formatter.Deserialize(stream);
                    log($"反序列化{directoryPath + dataFilename}文件为DataSet成功！");
                }
            }catch (Exception ex)
            {
                //反序列失败
                log("反序列化失败！\n"+ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取数据源对象
        /// </summary>
        /// <returns>数据源对象</returns>
        public static DataSet GetDataSet()
        {
            return dataSet;
        }

        /// <summary>
        /// DataSet初始数据
        /// </summary>
        private static void Initially()
        {
            DataTable department = new DataTable("department"); //部门表

            DataColumn department_id = new DataColumn("department_id"); //部门id
            department_id.DataType = typeof(int);
            department_id.AutoIncrement = true;
            department_id.Unique = true;
            department_id.AllowDBNull = false;
            department_id.AutoIncrementStep = 1;
            department_id.AutoIncrementSeed = 1;

            DataColumn department_name = new DataColumn("department_name"); //部门名
            department_name.DataType = typeof(string);
            department_name.Unique = true;
            department_name.AllowDBNull = false;

            DataColumn department_salary = new DataColumn("department_salary"); //部门工资
            department_salary.DefaultValue = 3000;
            department_salary.DataType = typeof(string);
            department_salary.AllowDBNull = false;

            //添加列到表中
            department.Columns.Add(department_id);
            department.Columns.Add(department_name);
            department.Columns.Add(department_salary);
            department.PrimaryKey = new DataColumn[] { department_id }; //设置主键

            //创建数据行
            DataRow department_row_01 = department.NewRow();
            department_row_01["department_name"] = "人事部";
            department_row_01["department_salary"] = 4000;
            DataRow department_row_02 = department.NewRow();
            department_row_02["department_name"] = "财务部";
            department_row_02["department_salary"] = 4500;
            DataRow department_row_03 = department.NewRow();
            department_row_03["department_name"] = "开发部";
            department_row_03["department_salary"] = 8000;
            DataRow department_row_04 = department.NewRow();
            department_row_04["department_name"] = "测试部";
            department_row_04["department_salary"] = 7500;

            //填充数据
            department.Rows.Add(department_row_01);
            department.Rows.Add(department_row_02);
            department.Rows.Add(department_row_03);
            department.Rows.Add(department_row_04);

            dataSet.Tables.Add(department); //存储到数据集中

            DataTable savings = new DataTable("savings"); //储蓄卡表

            DataColumn savings_id = new DataColumn("savings_id"); //卡号id
            savings_id.DataType = typeof(int);
            savings_id.AllowDBNull = false;
            savings_id.AutoIncrement = true;
            savings_id.AutoIncrementSeed = 1;
            savings_id.AutoIncrementStep = 1;

            DataColumn savings_account = new DataColumn("savings_account"); //储蓄卡账户
            savings_account.MaxLength = 18;
            savings_account.DataType = typeof(string);
            savings_account.Unique = true;
            savings_account.AllowDBNull = false;

            DataColumn savings_balance = new DataColumn("savings_balance"); //卡余额
            savings_balance.AllowDBNull = false;
            savings_balance.DefaultValue = 0;
            savings_balance.DataType = typeof(string);

            DataColumn savings_master = new DataColumn("master_id"); //持卡人
            savings_master.DataType = typeof(int);
            savings_master.DefaultValue = -1;
            savings_master.AllowDBNull = false;

            //将列添加到表中
            savings.Columns.Add(savings_id);
            savings.Columns.Add(savings_account);
            savings.Columns.Add(savings_balance);
            savings.Columns.Add(savings_master);
            savings.PrimaryKey = new DataColumn[] { savings_id }; //设置主键

            //创建数据行
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

            //填充数据
            savings.Rows.Add(savings_row_01);
            savings.Rows.Add(savings_row_02);
            savings.Rows.Add(savings_row_03);
            savings.Rows.Add(savings_row_04);
            savings.Rows.Add(savings_row_05);
            savings.Rows.Add(savings_row_06);
            savings.Rows.Add(savings_row_07);

            dataSet.Tables.Add(savings); //添加储蓄卡表

            DataTable staff = new DataTable("staff"); //员工表

            DataColumn staff_id = new DataColumn("staff_id"); //员工id
            staff_id.Unique = true;
            staff_id.AllowDBNull = false;
            staff_id.DataType = typeof(int);
            staff_id.AutoIncrement = true;
            staff_id.AutoIncrementSeed = 1;
            staff_id.AutoIncrementStep = 1;

            DataColumn staff_name = new DataColumn("staff_name"); //员工名
            staff_name.DataType = typeof(string);
            staff_name.AllowDBNull = false;

            DataColumn staff_sex = new DataColumn("staff_sex"); //员工性别
            staff_sex.DataType = typeof(string);
            staff_sex.DefaultValue = "男";
            staff_sex.AllowDBNull = false;

            DataColumn staff_age = new DataColumn("staff_age"); //员工年龄
            staff_age.DefaultValue = 18;
            staff_age.AllowDBNull = false;
            staff_age.DataType = typeof(string);

            DataColumn staff_phone = new DataColumn("staff_phone"); //员工手机号
            staff_phone.DataType = typeof(string);
            staff_phone.Unique = true;
            staff_phone.MaxLength = 11;
            staff_phone.AllowDBNull = false;

            DataColumn staff_department_id = new DataColumn("department_id"); //员工所在部门
            staff_department_id.AllowDBNull = false;
            staff_department_id.DataType = typeof(int);

            DataColumn staff_savings_account = new DataColumn("savings_account_id"); //员工储蓄卡账户
            staff_savings_account.DataType = typeof(int);
            staff_savings_account.AllowDBNull = true;
            staff_savings_account.Unique = true;

            //添加列到表中
            staff.Columns.Add(staff_id);
            staff.Columns.Add(staff_name);
            staff.Columns.Add(staff_sex);
            staff.Columns.Add(staff_age);
            staff.Columns.Add(staff_phone);
            staff.Columns.Add(staff_department_id);
            staff.Columns.Add(staff_savings_account);
            staff.PrimaryKey = new DataColumn[] { staff_id }; //设置主键

            //创建数据行
            DataRow staff_row_01 = staff.NewRow();
            staff_row_01["staff_name"] = "张三";
            staff_row_01["staff_age"] = 25;
            staff_row_01["staff_phone"] = "13678230934";
            staff_row_01["department_id"] = 3;
            staff_row_01["savings_account_id"] = 1;
            DataRow staff_row_02 = staff.NewRow();
            staff_row_02["staff_name"] = "李四";
            staff_row_02["staff_age"] = 23;
            staff_row_02["staff_phone"] = "13667450934";
            staff_row_02["department_id"] = 4;
            staff_row_02["savings_account_id"] = 2;
            DataRow staff_row_03 = staff.NewRow();
            staff_row_03["staff_name"] = "王五";
            staff_row_03["staff_age"] = 29;
            staff_row_03["staff_phone"] = "13786544534";
            staff_row_03["department_id"] = 1;
            staff_row_03["savings_account_id"] = 3;
            DataRow staff_row_04 = staff.NewRow();
            staff_row_04["staff_name"] = "赵六";
            staff_row_04["staff_age"] = 25;
            staff_row_04["staff_phone"] = "13436348954";
            staff_row_04["department_id"] = 2;
            staff_row_04["savings_account_id"] = 4;
            DataRow staff_row_05 = staff.NewRow();
            staff_row_05["staff_name"] = "刘七";
            staff_row_05["staff_age"] = 21;
            staff_row_05["staff_phone"] = "13765654634";
            staff_row_05["department_id"] = 3;
            staff_row_05["savings_account_id"] = 5;
            DataRow staff_row_06 = staff.NewRow();
            staff_row_06["staff_name"] = "老八";
            staff_row_06["staff_age"] = 25;
            staff_row_06["staff_phone"] = "13649836984";
            staff_row_06["department_id"] = 4;
            staff_row_06["savings_account_id"] = 6;

            //填充数据
            staff.Rows.Add(staff_row_01);
            staff.Rows.Add(staff_row_02);
            staff.Rows.Add(staff_row_03);
            staff.Rows.Add(staff_row_04);
            staff.Rows.Add(staff_row_05);
            staff.Rows.Add(staff_row_06);

            dataSet.Tables.Add(staff); //添加员工表

            //创建外键
            DataRelation staff_join_savings = new DataRelation("staff_join_savings", savings_id, staff_savings_account);
            DataRelation staff_join_department = new DataRelation("staff_join_department", department_id, staff_department_id);

            //添加外键
            dataSet.Relations.Add(staff_join_savings);
            dataSet.Relations.Add(staff_join_department);

            log($"通过{typeof(Program).FullName}.Initially()方法生成DataSet初始数据！");
        }
    }

    /// <summary>
    /// 表连接信息
    /// </summary>
    public static class TableJoinInfo
    {
        private static DataSet dataSet = new DataSet(); //拼接后表存储集

        /// <summary>
        /// 拼接表方法
        /// </summary>
        /// <param name="tableName">拼接后表名</param>
        /// <param name="sourcePrimaryTable">主表</param>
        /// <param name="sourceSecondaryTable">副表</param>
        /// <param name="primaryJoinField">主表连接字段</param>
        /// <param name="secondaryJoinField">副表连接字段</param>
        /// <param name="joinColumnMap">副表要拼接字段</param>
        /// <param name="rejectColumnMap">主表要剔除的字段</param>
        /// <param name="primaryKeyName">新表主键字段名</param>
        /// <returns>新表</returns>
        public static DataTable JoinTable(string tableName,
            DataTable sourcePrimaryTable, DataTable sourceSecondaryTable,
            string primaryJoinField, string secondaryJoinField,
            Dictionary<string, string?> joinColumnMap, Dictionary<string, string?> rejectColumnMap,
            string primaryKeyName)
        {
            const string separator = "&"; //分割符

            if (sourcePrimaryTable == null || sourceSecondaryTable == null) throw new TableJoinException("主表和副表不能为空！");

            DataTable primaryTable = sourcePrimaryTable.Clone(); //克隆数据结构
            DataTable secondaryTable = sourceSecondaryTable.Clone(); //克隆数据结构

            if (string.IsNullOrEmpty(tableName)) tableName = $"{primaryTable.TableName}_join_{secondaryTable.TableName}"; //默认表名为主表表名_join_副表表名

            if (string.IsNullOrEmpty(primaryJoinField)) //默认使用主键连接，不存在主键就使用第一列连接
            {
                DataColumn[] columns = primaryTable.PrimaryKey;
                if (columns.Length > 0) primaryJoinField = columns[0].ColumnName;
                else primaryJoinField = primaryTable.Columns[0].ColumnName;
            }

            if (string.IsNullOrEmpty(secondaryJoinField)) //默认使用主键连接，不存在主键就使用第一列连接
            {
                DataColumn[] columns = secondaryTable.PrimaryKey;
                if (columns.Length > 0) secondaryJoinField = columns[0].ColumnName;
                else secondaryJoinField = primaryTable.Columns[0].ColumnName;
            }

            Dictionary<string, string> tableFieldMap = new Dictionary<string, string>(); //新旧表字段映射信息

            //初始映射信息
            for (int i = 0; i < primaryTable.Columns.Count; i++) tableFieldMap.Add($"{sourcePrimaryTable.TableName}{separator}{i}", primaryTable.Columns[i].ColumnName);

            primaryTable.TableName = tableName;

            //解除外键
            ClearRelations(primaryTable, secondaryTable.TableName);
            ClearRelations(secondaryTable, primaryTable.TableName);

            //清除原表主键
            primaryTable.PrimaryKey = new DataColumn[0];
            secondaryTable.PrimaryKey = new DataColumn[0];

            if (rejectColumnMap != null) //有需要移除或改名的
            {
                Dictionary<string, string?>.Enumerator reject_enumerator = rejectColumnMap.GetEnumerator(); //获取迭代器
                while (reject_enumerator.MoveNext())
                {
                    string columnName = reject_enumerator.Current.Key; //获取列名
                    DataColumn? column = primaryTable.Columns[columnName]; //获取列

                    if (column == null) throw new TableJoinException($"{primaryTable.TableName}表中不存在名为：{columnName}的列！");

                    string? columnAlias = reject_enumerator.Current.Value;

                    string tableMapKey = $"{sourcePrimaryTable.TableName}{separator}{TableColumnIndexOf(sourcePrimaryTable, columnName)}";

                    //列改名或移除
                    if (columnAlias != null)
                    {
                        column.ColumnName = columnAlias;
                        tableFieldMap[tableMapKey] = columnAlias; //重设映射信息
                    }
                    else
                    {
                        primaryTable.Columns.Remove(column);
                        tableFieldMap.Remove(tableMapKey); //删除该映射
                    }
                }
            }

            //为空默认获取副表所有列
            if (joinColumnMap == null || joinColumnMap.Count < 1)
            {
                joinColumnMap = new Dictionary<string, string?>();

                //遍历副表所有字段
                foreach (DataColumn column in secondaryTable.Columns)
                {
                    string columnName = column.ColumnName;
                    joinColumnMap.Add(columnName, null);
                }
            }

            Dictionary<string, string?>.Enumerator join_enumerator = joinColumnMap.GetEnumerator(); //获取迭代器

            while (join_enumerator.MoveNext())
            {
                string columnName = join_enumerator.Current.Key; //获取列名
                DataColumn? column = secondaryTable.Columns[columnName]; //获取列

                if (column == null) throw new TableJoinException($"{secondaryTable.TableName}表中不存在名为：{columnName}的列！");

                string? columnAlias = join_enumerator.Current.Value;

                if (columnAlias != null) column.ColumnName = columnAlias; //更换列名

                string tableMapKey = $"{sourceSecondaryTable.TableName}{separator}{TableColumnIndexOf(sourceSecondaryTable, columnName)}";

                tableFieldMap.Add(tableMapKey, columnName);

                //添加映射信息

                DataColumn dataColumn = DataColumnClone(column);//克隆列对象
                dataColumn.Unique = false; //去除唯一约束

                try
                {
                    //添加列
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
            { //设置表主键
                DataColumn? primaryColumn = primaryTable.Columns[primaryKeyName];
                if (primaryColumn != null) primaryTable.PrimaryKey = new DataColumn[] { primaryColumn };
            }

            int tableRowCount = sourcePrimaryTable.Rows.Count; //获取数据总行数
            int primaryIndex = TableColumnIndexOf(sourcePrimaryTable, primaryJoinField); //检索主表要比较的列
            int secondaryIndex = TableColumnIndexOf(sourceSecondaryTable, secondaryJoinField); //检索副表要比较的列
            for (int i = 0; i < tableRowCount; i++)
            {
                DataRow dataRow = primaryTable.NewRow(); //创建数据行
                Dictionary<string, string>.Enumerator enumerator = tableFieldMap.GetEnumerator(); //获取迭代器
                while (enumerator.MoveNext())
                {
                    string[] map = enumerator.Current.Key.Split(separator); //切割
                    string dataSourceTableName = map[0]; //数据源表名
                    int dataSourceTableIndex = Convert.ToInt32(map[1]); //数据源列数
                    string primaryTableKey = enumerator.Current.Value; //新表该列的列名

                    //主表数据，可直接添加
                    if (sourcePrimaryTable.TableName == dataSourceTableName) dataRow[primaryTableKey] = sourcePrimaryTable.Rows[i][dataSourceTableIndex];
                    else //副表数据，连接添加
                    {
                        object primary_value = sourcePrimaryTable.Rows[i][primaryIndex]; //主表外键值
                        string sourcePrimaryTableJoinValue = primary_value == null ? "" : Convert.ToString(primary_value);

                        int secondaryDataRowCount = sourceSecondaryTable.Rows.Count; //副表总数据行
                        for (int j = 0; j < secondaryDataRowCount; j++)
                        {
                            object secondary_value = sourceSecondaryTable.Rows[j][secondaryIndex];
                            string secondaryTableJoinValue = secondary_value == null ? "" : Convert.ToString(secondary_value);

                            //获取连接成功后的值
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
        /// 检索指定列名下标
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="columnName">列名</param>
        /// <returns>下标，不存在返回-1</returns>
        /// <exception cref="TableJoinException">数据表为空</exception>
        public static int TableColumnIndexOf(DataTable dataTable,string columnName)
        {
            if (dataTable == null) throw new TableJoinException("数据表不能为空！");
            if (columnName == null) return -1;

            //遍历检索
            for (int i = 0; i < dataTable.Columns.Count; i++) if (dataTable.Columns[i].ColumnName == columnName) return i;

            return -1;
        }

        /// <summary>
        /// 克隆列
        /// </summary>
        /// <param name="dataColumn">源对象</param>
        public static DataColumn DataColumnClone(DataColumn dataColumn)
        {
            if (dataColumn == null) return new DataColumn();

            DataColumn column = new DataColumn();

            //克隆信息
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
        /// 清除父子表关系
        /// </summary>
        /// <param name="dataTable">要清除关系的表</param>
        /// <param name="tableName">要清除和那张表的表名</param>
        public static void ClearRelations(DataTable dataTable,string tableName)
        {
            if (dataTable == null || tableName == null) return;

            DataRelationCollection conllection = dataTable.ChildRelations; //获取约束关系列表

            foreach (DataRelation relation in conllection) //遍历关系
            {
                string relationName = relation.RelationName; //获取关系名

                if (relationName == null) continue;

                DataTable childTable = relation.ChildTable; //获取约束的子表

                if (childTable == null) continue;

                if (childTable.TableName != tableName) continue; //不是要解除关系的表

                childTable.Constraints.Remove(relationName); //删除关系
            }
        }

        /// <summary>
        /// 获取对应表名的DataTable对象
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>DataTable对象</returns>
        public static DataTable? GetDataTable(string tableName)
        {
            return tableName != null ? dataSet.Tables[tableName] : null;
        }

        /// <summary>
        /// 删除DataSet中的表
        /// </summary>
        /// <param name="tableName">要删除的表名</param>
        public static void DeleteDataTable(string tableName)
        {
            dataSet.Tables.Remove(tableName);
        }

        /// <summary>
        /// 表为空异常
        /// </summary>
        public class TableJoinException : Exception
        {
            public TableJoinException(string message) : base(message) { }
        }
    }
}