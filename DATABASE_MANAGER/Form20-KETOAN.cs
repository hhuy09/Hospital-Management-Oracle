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
    public partial class Form20 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;

        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label2.Text = username;
            label8.Text = username;

            string sqlselect = "SELECT * FROM QLBENHVIEN.NVBS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            label3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.KT_CHAMCONG";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                label8.Text = row.Cells[3].Value.ToString();
                if(label8.Text == "")
                {
                    label8.Text = username;
                }
                textBox3.Text = row.Cells[4].Value.ToString();
                int ngay = int.Parse(textBox3.Text);
                textBox4.Text = row.Cells[5].Value.ToString();
                int lgcb = int.Parse(textBox4.Text);
                textBox5.Text = row.Cells[6].Value.ToString();
                int pc = int.Parse(textBox5.Text);
                label13.Text = (ngay * lgcb + pc).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            textBox2.Text = null;
            label8.Text = username;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            label13.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int ngay = int.Parse(textBox3.Text);
                int lgcb = int.Parse(textBox4.Text);
                int pc = int.Parse(textBox5.Text);
                label13.Text = (ngay * lgcb + pc).ToString();

                string sqlselect = "insert into QLBENHVIEN.kt_chamcong values ('" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox2.Text + "', '" + label8.Text + "', " + textBox3.Text + ", " + textBox4.Text + ", " + textBox5.Text + ", " + label13.Text + ")";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.KT_CHAMCONG";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.kt_chamcong set tongluong = "+label13.Text+" where nhansu = '"+ textBox1.Text + "' and thang = "+ comboBox1.Text + " and nam = "+textBox2.Text+"";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox1.Text = null;
                comboBox1.Text = null;
                textBox2.Text = null;
                label8.Text = username;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                label13.Text = "0";

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.KT_CHAMCONG";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int ngay = int.Parse(textBox3.Text);
                int lgcb = int.Parse(textBox4.Text);
                int pc = int.Parse(textBox5.Text);
                label13.Text = (ngay * lgcb + pc).ToString();

                string sqlselect = "update QLBENHVIEN.kt_chamcong set songaycong = " + textBox3.Text + ", luongcb = " + textBox4.Text + ", phucap = " + textBox5.Text + ", tongluong = " + label13.Text + " where nhansu = '" + textBox1.Text + "' and thang = " + comboBox1.Text + " and nam = " + textBox2.Text;
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.KT_CHAMCONG";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete QLBENHVIEN.kt_chamcong where nhansu = '" + textBox1.Text + "' and thang = " + comboBox1.Text + " and nam = " + textBox2.Text;
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox1.Text = null;
                comboBox1.Text = null;
                textBox2.Text = null;
                label8.Text = username;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                label13.Text = "0";

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.KT_CHAMCONG";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
