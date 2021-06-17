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
    public partial class Form15 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label2.Text = username;

            string sqlselect = "SELECT * FROM QLBENHVIEN.NHANSU WHERE MANS = '" + username + "'";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            label3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.DICHVU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["TENDV"].Width = 200;

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.THUOC";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "SELECT * FROM QLBENHVIEN.DICHVU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["TENDV"].Width = 200;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into qlbenhvien.dichvu values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.DICHVU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["TENDV"].Width = 200;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update qlbenhvien.dichvu set tendv = '" + textBox2.Text + "', giadv = " + textBox3.Text + " where madv = '" + textBox1.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.DICHVU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["TENDV"].Width = 200;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete qlbenhvien.dichvu where madv = '" + textBox1.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.DICHVU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["TENDV"].Width = 200;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sqlselect2 = "SELECT * FROM QLBENHVIEN.THUOC";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;

            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into qlbenhvien.thuoc values ('" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.THUOC";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update qlbenhvien.thuoc set tenthuoc = '"+textBox5.Text+ "', chidinh = '" + textBox6.Text + "', dongia = " + textBox7.Text + " where mathuoc = '" + textBox4.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.THUOC";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete qlbenhvien.thuoc where mathuoc = '" + textBox4.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.THUOC";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox5.Text = row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
