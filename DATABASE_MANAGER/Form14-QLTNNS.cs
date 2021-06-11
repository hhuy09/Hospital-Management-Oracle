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
    public partial class Form14 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;

        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form14_Load(object sender, EventArgs e)
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

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.NHANSU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["HOTENNS"].Width = 250;
            dataGridView1.Columns["DIACHI"].Width = 220;

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.PHONGBAN";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["TENPB"].Width = 135;

            string sqlselect3 = "SELECT * FROM QLBENHVIEN.nv_pb";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;

            string sqlselect4 = "SELECT * FROM QLBENHVIEN.KHOA";
            OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
            OracleDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);
            dataGridView4.DataSource = dt4;
            //dataGridView4.Columns["TENPB"].Width = 130;

            string sqlselect5 = "SELECT * FROM QLBENHVIEN.BS_KH";
            OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
            OracleDataReader dr5 = cmd5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Load(dr5);
            dataGridView5.DataSource = dt5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "SELECT * FROM QLBENHVIEN.NHANSU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["HOTENNS"].Width = 250;
            dataGridView1.Columns["DIACHI"].Width = 220;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            comboBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into qlbenhvien.nhansu values ('"+textBox1.Text+ "', '" + textBox2.Text + "', '" + comboBox1.Text + "', to_date('" + textBox3.Text + "', 'dd-mm-yyyy'), '" + textBox4.Text + "', '" + textBox5.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.NHANSU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete qlbenhvien.nhansu where mans = '" + textBox1.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                comboBox1.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.NHANSU";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update qlbenhvien.nhansu set hotenns = '"+textBox2.Text+ "', gioitinh = '" + comboBox1.Text + "', ngaysinh = to_date('" + textBox3.Text + "', 'dd-mm-yyyy'), diachi = '" + textBox4.Text + "', sodt = '" + textBox5.Text + "' where mans = '" + textBox1.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.NHANSU";
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
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                string s = row.Cells[3].Value.ToString();
                int i = s.IndexOf(" ");
                textBox3.Text = s.Remove(i);
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sqlselect2 = "SELECT * FROM QLBENHVIEN.PHONGBAN";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["TENPB"].Width = 135;

            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into qlbenhvien.phongban values ('" + textBox6.Text + "', '" + textBox8.Text + "', '" + textBox7.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.PHONGBAN";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["TENPB"].Width = 135;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update qlbenhvien.phongban set tenpb = '" + textBox7.Text + "', truongphong = '" + textBox8.Text + "' where mapb = '" + textBox6.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.PHONGBAN";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["TENPB"].Width = 135;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete qlbenhvien.phongban where mapb = '"+textBox6.Text+"'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.PHONGBAN";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["TENPB"].Width = 135;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox8.Text = row.Cells[1].Value.ToString();
                textBox7.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
