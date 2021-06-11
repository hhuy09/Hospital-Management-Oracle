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
    public partial class Form2 : Form
    {
        public string connectionString;
        public string username;
        OracleConnection con;

        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label2.Text = username;
            label1.Text = "---";
          
            OracleCommand cmd = new OracleCommand("LIST_USERS", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adp = new OracleDataAdapter();
            adp.SelectCommand = cmd;
            DataTable tb = new DataTable();
            adp.Fill(tb);
            dataGridView1.DataSource = tb;

            string sqlselect1 = "SELECT USERNAME FROM ALL_USERS";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView4.DataSource = dt1;
            dataGridView4.Columns["USERNAME"].Width = 170;

            string sqlselect2 = "SELECT ROLE FROM DBA_ROLES";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView5.DataSource = dt2;
            dataGridView5.Columns["ROLE"].Width = 170;          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("LIST_USER_SYS_PRIVS", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adp = new OracleDataAdapter();
            adp.SelectCommand = cmd;
            DataTable tb = new DataTable();
            adp.Fill(tb);
            dataGridView2.DataSource = tb;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlselect = "SELECT * FROM USER_TAB_PRIVS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlselect = "SELECT * FROM USER_ROLE_PRIVS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sqlselect = "SELECT * FROM USER_COL_PRIVS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sqlselect = "SELECT * FROM ROLE_TAB_PRIVS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView3.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sqlselect = "SELECT * FROM ROLE_ROLE_PRIVS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView3.DataSource = dt;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string sqlselect = "SELECT * FROM ROLE_SYS_PRIVS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView3.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.connectionString = connectionString;
            f3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label1.Text != "---")
            {
                Form4 f4 = new Form4();
                f4.connectionString = connectionString;
                f4.username = label1.Text;
                f4.dbm = label2.Text;
                f4.Show();
            } 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label1.Text != "---")
            {
                Form5 f5 = new Form5();
                f5.connectionString = connectionString;
                f5.dropusername = label1.Text;
                f5.Show();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label1.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "SELECT USERNAME FROM ALL_USERS";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView4.DataSource = dt1;
            dataGridView4.Columns["USERNAME"].Width = 180;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.connectionString = connectionString;
            f6.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (label3.Text != "---")
            {
                Form7 f7 = new Form7();
                f7.connectionString = connectionString;
                f7.rolename = label3.Text;
                f7.dbm = label2.Text;
                f7.Show();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label3.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (label3.Text != "---")
            {
                Form8 f8 = new Form8();
                f8.connectionString = connectionString;
                f8.droprolename = label3.Text;
                f8.Show();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string sqlselect2 = "SELECT ROLE FROM DBA_ROLES";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView5.DataSource = dt2;
            dataGridView5.Columns["ROLE"].Width = 170;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = null;
            textBox2.Text = null;
            try
            {
                string sql = textBox1.Text;
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                try
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView6.DataSource = dt;
                }
                catch (Exception ex)
                {
                    textBox2.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }

        }
    }
}
