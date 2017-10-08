using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TestForm
{
    class DBHandler
    {
        private string sql_db = "PwdKeep.sqlite";
        private string sql_table1 = "MASTER_ACC";
        private string sql_table2 = "ACCOUNTS";
        string sql;
        SQLiteCommand command;
        SQLiteConnection m_dbConnection;

        public bool loginSuccess = false;

        public void fetchConnection(string db_name)
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + "; Version=3;");
            m_dbConnection.Open();
        }

        public void createTables()
        {
            sql = "create table if not exists " + sql_table1 +
            " (account_name varchar(300), " +
            "account_password varchar(300))";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table if not exists " + sql_table2 +
            " (seq_no integer primary key not null unique, " +
            "acc_desc varchar(300), " +
            "acc_name varchar(300), " +
            "acc_pass varchar(300), " +
            "rec_timestamp datetime default current_timestamp)";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void createDB()
        {
            fetchConnection(sql_db);
            createTables();
        }

        public void insert(Accounts obj)
        {
            fetchConnection(sql_db);
            if (query_account_exists(obj.acc_desc) < 1)
            {
                sql = "INSERT INTO " + sql_table2 + 
                    "(acc_desc, acc_name, acc_pass) " +
                    " VALUES ('" + obj.acc_desc.ToString() + "','" + obj.acc_name.ToString() + "','" + obj.acc_pass.ToString() + "')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Duplicate account detected!");
            }
        }

        public void update(Accounts obj)
        {
            fetchConnection(sql_db);
            sql = "UPDATE " + sql_table2 +
                " SET acc_desc = '" + obj.acc_desc + "', " +
                "acc_name = '" + obj.acc_name + "', " +
                "acc_pass = '" + obj.acc_pass + "' " +
                "WHERE seq_no = " + obj.seq_no;            
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void delete(int p_seq_no)
        {
            fetchConnection(sql_db);
            sql = "DELETE FROM " + sql_table2 + 
                " WHERE seq_no = " + p_seq_no;
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void query_master_acc(string username, string password)
        {
            createDB();
            sql = "SELECT * FROM " + sql_table1 + 
                " WHERE account_name = '" + username.ToString() + "'";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (username == reader["account_name"].ToString() && password == reader["account_password"].ToString())
                {
                    loginSuccess = true;
                }
                else
                {
                    loginSuccess = false;
                }
            }
        }

        public int count_master_rows ()
        {
            int w_count = 0;
            fetchConnection(sql_db);
            sql = "SELECT count(*) row_count FROM " + sql_table1;
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                w_count += int.Parse((reader["row_count"]).ToString());
            }
            return w_count;
        }

        public int query_account_exists(string acc_desc)
        {
            int w_count = 0;
            fetchConnection(sql_db);
            sql = "SELECT count(*) row_count FROM " + sql_table2 + " WHERE acc_desc = '" + acc_desc.ToString() + "'";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                w_count += int.Parse((reader["row_count"]).ToString());
            }
            return w_count;
        }

        public List<Accounts> query_all_accounts()
        {
            var list = new List<Accounts>();
            fetchConnection(sql_db);
            sql = "SELECT * FROM " + sql_table2;
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Accounts(int.Parse(reader["seq_no"].ToString()), reader["acc_desc"].ToString(), reader["acc_name"].ToString(), reader["acc_pass"].ToString()));
            }
            return list;
        }

        public void insert_master_acc(string p_master_user, string p_master_pass)
        {
            createDB();
            sql = "INSERT INTO " + sql_table1 +
                  "(account_name, account_password) " +
                  " VALUES ('" + p_master_user.ToString() + "','" + p_master_pass.ToString() + "')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

    }
}
