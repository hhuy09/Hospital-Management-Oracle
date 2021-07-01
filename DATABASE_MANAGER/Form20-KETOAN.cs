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
            dataGridView4.DataSource = dt;      
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoResizeColumns();          

            int row = dataGridView4.Rows.Count - 1;
            for (int i = 0; i < row; i++)
            {
                string mans = dataGridView4.Rows[i].Cells[0].Value.ToString();
                if (mans == label2.Text)
                {
                    textBox11.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
                    label3.Text = textBox11.Text;
                    comboBox2.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
                    string ngay = dataGridView4.Rows[i].Cells[3].Value.ToString();
                    ngay = ngay.Substring(0, ngay.IndexOf(" "));
                    textBox7.Text = ngay;
                    textBox9.Text = dataGridView4.Rows[i].Cells[4].Value.ToString();
                    textBox8.Text = dataGridView4.Rows[i].Cells[5].Value.ToString();
                }
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.KT_CHAMCONG";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;

            string sqlselect5 = "SELECT * FROM QLBENHVIEN.NS_CHAMCONG";
            OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
            OracleDataReader dr5 = cmd5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Load(dr5);
            dataGridView5.DataSource = dt5;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoResizeColumns();
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

                string sqlselect = "update QLBENHVIEN.kt_chamcong set nvchamcong = '" + label8.Text + "', songaycong = " + textBox3.Text + ", luongcb = " + textBox4.Text + ", phucap = " + textBox5.Text + ", tongluong = " + label13.Text + " where nhansu = '" + textBox1.Text + "' and thang = " + comboBox1.Text + " and nam = " + textBox2.Text;
                
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.NVBS set HOTENNS = '" + textBox11.Text + "', GIOITINH = '" + comboBox2.Text + "', NGAYSINH = to_date('" + textBox7.Text + "','dd-mm-yyyy'), DIACHI = '" + textBox9.Text + "', SODT = '" + textBox8.Text + "' where MANS = '" + label2.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect4 = "SELECT * FROM QLBENHVIEN.NVBS";
                OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dataGridView4.DataSource = dt4;
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == textBox6.Text && textBox6.Text != null)
            {
                try
                {
                    string sqlselect = "alter user " + label2.Text + " identified by " + textBox6.Text;
                    OracleCommand cmd = new OracleCommand(sqlselect, con);
                    OracleDataReader dr = cmd.ExecuteReader();

                    MessageBox.Show("Đổi mật khẩu thành công. Đăng nhập lại");
                    this.Close();
                    Form1 f1 = new Form1();
                    f1.Show();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không khớp hoặc không hợp lệ");
            }
        }
    }
}
