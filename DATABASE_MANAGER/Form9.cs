using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DATABASE_MANAGER
{
    public partial class Form9 : Form
    {
        public string connectionString;
        public string name;
        public string dbm;
        public string tbname;
        public string permiss;
        string col;
        OracleConnection con;
        public Form9()
        {
            InitializeComponent();
            if (permiss == "Select")
            {
                tabPage2.Hide();
            }
            else if (permiss == "Update")
            {
                tabPage1.Hide();
            }
        }


        private void Form9_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label10.Text = tbname;

            string sqlselect1 = "select COLUMN_NAME from ALL_TAB_COLUMNS where owner = '" + dbm + "' and TABLE_NAME = '" + tbname + "'";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dt1.Columns.Add(new DataColumn("SELECT", typeof(bool)));
            dataGridView1.DataSource = dt1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns();

            string sqlselect2 = "select TABLE_NAME , GRANTABLE from USER_TAB_PRIVS where PRIVILEGE = 'SELECT' AND TYPE = 'VIEW' AND GRANTEE = '" + name + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dt2.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
            dataGridView2.DataSource = dt2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoResizeColumns();

            string sqlselect3 = "select COLUMN_NAME, PRIVILEGE , GRANTABLE from USER_COL_PRIVS WHERE TABLE_NAME = '" + tbname + "' AND GRANTEE = '" + name + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dt3.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
            dataGridView3.DataSource = dt3;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoResizeColumns();

            string sqlselect4 = "select COLUMN_NAME from ALL_TAB_COLUMNS where owner = '" + dbm + "' and TABLE_NAME = '" + tbname + "'";
            OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
            OracleDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);
            dt4.Columns.Add(new DataColumn("INSERT", typeof(bool)));
            dt4.Columns.Add(new DataColumn("UPDATE", typeof(bool)));
            dataGridView4.DataSource = dt4;           
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoResizeColumns();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }



    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlgrant = "REVOKE UPDATE ON " + label10.Text + " FROM " + name;
                OracleCommand cmd = new OracleCommand(sqlgrant, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect2 = "select COLUMN_NAME, PRIVILEGE , GRANTABLE from DBA_COL_PRIVS where owner = '" + dbm + "' and TABLE_NAME = '" + tbname + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.Rows.Count - 1;
            string viewname = textBox1.Text;
            string selectview = null;

            if (row > 0)
            {
                int col = 0;
                selectview = "create view " + viewname + " as select ";

                for (int i = 0; i < row;i++)
                {
                    string colname = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string select = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (select == "True")
                    {
                        selectview += colname + ", ";
                        col++;
                    }
                }

                selectview = selectview.Substring(0, selectview.Length - 2);
                selectview += " from " + tbname;

                if (selectview != null)
                {
                    try
                    {
                        OracleCommand cmd = new OracleCommand(selectview, con);
                        OracleDataReader dr = cmd.ExecuteReader();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    

                    string sqlselect = "grant select on ";
                    if (checkBox1.Checked)
                    {
                        sqlselect += viewname + " to " + name + " with grant option";
                    }
                    else
                    {
                        sqlselect += viewname + " to " + name;
                    }

                    try
                    {
                        OracleCommand cmd1 = new OracleCommand(sqlselect, con);
                        OracleDataReader dr1 = cmd1.ExecuteReader();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    
                }

                string sqlselect2 = "select TABLE_NAME , GRANTABLE from USER_TAB_PRIVS where PRIVILEGE = 'SELECT' AND TYPE = 'VIEW' AND GRANTEE = '" + name + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dt2.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView2.DataSource = dt2;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoResizeColumns();

            }

            checkBox1.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = dataGridView2.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string view = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string revoke = dataGridView2.Rows[i].Cells[2].Value.ToString();

                    if (revoke == "True")
                    {
                        string sqlrevoke = "DROP VIEW " + view;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect2 = "select TABLE_NAME , GRANTABLE from USER_TAB_PRIVS where PRIVILEGE = 'SELECT' AND TYPE = 'VIEW' AND GRANTEE = '" + name + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dt2.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView2.DataSource = dt2;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoResizeColumns();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int row = dataGridView3.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string privs = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    string revoke = dataGridView3.Rows[i].Cells[3].Value.ToString();

                    string sqlrevoke = null;

                    if (revoke == "True")
                    {
                        sqlrevoke = "REVOKE " + privs + " ON " + tbname + " FROM " + name;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect3 = "select COLUMN_NAME, PRIVILEGE , GRANTABLE from USER_COL_PRIVS WHERE TABLE_NAME = '" + tbname + "' AND GRANTEE = '" + name + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dt3.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView3.DataSource = dt3;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.AutoResizeColumns();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int row = dataGridView4.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string col = dataGridView4.Rows[i].Cells[0].Value.ToString();
                    string insert = dataGridView4.Rows[i].Cells[1].Value.ToString();
                    string update = dataGridView4.Rows[i].Cells[2].Value.ToString();

                    string sqlgrantinsert = null;
                    string sqlgrantupdate = null;

                    if (insert == "True")
                    {
                        sqlgrantinsert = "GRANT INSERT(" + col + ") ON " + tbname + " TO " + name;
                    }

                    if (update == "True")
                    {
                        sqlgrantupdate = "GRANT UPDATE(" + col + ") ON " + tbname + " TO " + name;
                    }

                    if (checkBox2.Checked)
                    { 
                        if (sqlgrantinsert != null)
                        {
                            sqlgrantinsert += " WITH GRANT OPTION";
                        }

                        if (sqlgrantupdate != null)
                        {
                            sqlgrantupdate += " WITH GRANT OPTION";
                        }
                    }

                    if (sqlgrantinsert != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrantinsert, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }

                    if (sqlgrantupdate != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrantupdate, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }

                }

                string sqlselect3 = "select COLUMN_NAME, PRIVILEGE , GRANTABLE from USER_COL_PRIVS WHERE TABLE_NAME = '" + tbname + "' AND GRANTEE = '" + name + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dt3.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView3.DataSource = dt3;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.AutoResizeColumns();
            }

            checkBox2.Checked = false;
        }
    }
}
