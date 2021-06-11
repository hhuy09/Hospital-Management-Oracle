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

            string sqlselect = "select COLUMN_NAME from ALL_TAB_COLUMNS where owner = '" + dbm + "' and TABLE_NAME = '" + tbname + "'";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dataGridView4.DataSource = dt;


            string sqlselect5 = "select TABLE_NAME , GRANTABLE from DBA_TAB_PRIVS where PRIVILEGE = 'SELECT' AND owner = '" + dbm + "' AND TYPE = 'VIEW' AND GRANTEE = '" + name + "'";
            OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
            OracleDataReader dr5 = cmd5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Load(dr5);
            dataGridView5.DataSource = dt5;


            string sqlselect2 = "select COLUMN_NAME, PRIVILEGE , GRANTABLE from DBA_COL_PRIVS where owner = '" + dbm + "' and TABLE_NAME = '" + tbname + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;


        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label6.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlgrant = "GRANT UPDATE (";
                if (checkBox3.Checked)
                {
                    sqlgrant += label6.Text + ") ON " + label10.Text + " TO " + name + " WITH GRANT OPTION";
                    checkBox3.Checked = false;
                }
                else
                {
                    sqlgrant += label6.Text + ") ON " + label10.Text + " TO " + name; 
                }
                OracleCommand cmd = new OracleCommand(sqlgrant, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect2 = "select COLUMN_NAME, PRIVILEGE , GRANTABLE from DBA_COL_PRIVS where owner = '" + dbm + "' and TABLE_NAME = '" + tbname + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;

            }
            catch
            {
                MessageBox.Show("ERROR");
            }
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label8.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                col = row.Cells[0].Value.ToString();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect2 = "create view " + textBox2.Text + " as select ";
                for(int i = 0; i< listBox1.Items.Count; i++)
                {
                    sqlselect2 += listBox1.Items[i];
                    if (i != listBox1.Items.Count - 1)
                    {
                        sqlselect2 += ", ";
                    }
                }

                sqlselect2 += " from " + label10.Text;
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();

                //MessageBox.Show(sqlselect2);

                string sqlselect = "grant select on ";
                if (checkBox1.Checked)
                {
                    sqlselect += textBox2.Text + " to " + name+" with grant option";
                    
                }
                else
                {
                    sqlselect = "grant select on " + textBox2.Text + " to " + name;
                    
                }

                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect5 = "select TABLE_NAME , GRANTABLE from DBA_TAB_PRIVS where PRIVILEGE = 'SELECT' AND owner = '" + dbm + "' AND TYPE = 'VIEW' AND GRANTEE = '" + name + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;
            }
            catch
            {
                string sqlselect2 = "drop view " + textBox2.Text;
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
            }
        }


        private void dataGridView5_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string tb = null;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                tb = row.Cells[0].Value.ToString();

                label1.Text = tb;
            }

            string sqlselect2 = "select * from " + tb;
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView6.DataSource = dt2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                string sqlselect2 = "REVOKE SELECT ON " + label1.Text + " FROM " + name;
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();

                string sqlselect5 = "select TABLE_NAME , GRANTABLE from DBA_TAB_PRIVS where PRIVILEGE = 'SELECT' AND owner = '" + dbm + "' AND TYPE = 'VIEW'  AND GRANTEE = '" + name + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;
            //}
            //catch(Exception )
            //{
            //    MessageBox.Show();
            //}
        }

        private void dataGridView4_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                listBox1.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
