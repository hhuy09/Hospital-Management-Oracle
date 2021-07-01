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
    public partial class Form17 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label2.Text = username;
            label12.Text = username;

            string sqlselect = "SELECT * FROM QLBENHVIEN.NVBS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView4.DataSource = dt;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoResizeColumns();
            int row = dataGridView4.Rows.Count - 1;

            for (int j = 0; j < row; j++)
            {
                string mans = dataGridView4.Rows[j].Cells[0].Value.ToString();
                if (mans == label2.Text)
                {
                    textBox11.Text = dataGridView4.Rows[j].Cells[1].Value.ToString();
                    label3.Text = textBox11.Text;
                    comboBox2.Text = dataGridView4.Rows[j].Cells[2].Value.ToString();
                    string ngay = dataGridView4.Rows[j].Cells[3].Value.ToString();
                    ngay = ngay.Substring(0, ngay.IndexOf(" "));
                    textBox4.Text = ngay;
                    textBox9.Text = dataGridView4.Rows[j].Cells[4].Value.ToString();
                    textBox8.Text = dataGridView4.Rows[j].Cells[5].Value.ToString();
                }
            }


            string sqlselect1 = "SELECT * FROM QLBENHVIEN.PHIEUKHAMBENH";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns();

            label6.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.TV_CHITIETKHAM WHERE PHIEUKHAM = '" + label6.Text + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoResizeColumns();
            int i = dataGridView2.Rows.Count - 1;
            if (i > 0)
            {
                label7.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
            }

            string sqlselect3 = "select * from QLBENHVIEN.DICHVU";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoResizeColumns();

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
                label6.Text = row.Cells[0].Value.ToString();

                string sqlselect2 = "SELECT * FROM QLBENHVIEN.TV_CHITIETKHAM WHERE PHIEUKHAM = '" + label6.Text + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;

                int i = dataGridView2.Rows.Count - 1;
                if (i > 0)
                {
                    label7.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                    textBox1.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
                    int s = 0;
                    for(int j = 0; j < i; j++)
                    {
                        string num = dataGridView2.Rows[j].Cells[3].Value.ToString();
                        if(num == "")
                        {
                            s += 0;
                        }
                        else
                        {
                            s += int.Parse(num);
                        }
                        
                    }
                    label10.Text = s.ToString();
                }
                else
                {
                    label7.Text = "none";
                    textBox1.Text = null;
                    label10.Text = "0";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                label7.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.TV_CHITIETKHAM set tienkham = " + textBox1.Text + " where phieukham = '" + label6.Text + "' and dichvu = '" + label7.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.TV_CHITIETKHAM WHERE PHIEUKHAM = '" + label6.Text + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;

            int i = dataGridView2.Rows.Count - 1;
            if (i > 0)
            {
                label7.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
                int s = 0;
                for (int j = 0; j < i; j++)
                {
                    if(dataGridView2.Rows[j].Cells[3].Value.ToString() != "")
                    {
                        s += int.Parse(dataGridView2.Rows[j].Cells[3].Value.ToString());
                    }                
                }
                label10.Text = s.ToString();
            }
            else
            {
                label7.Text = "none";
                textBox1.Text = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.phieukhambenh set chiphikham = " + label10.Text + ", nvthuphi = '" + label12.Text + "' where mapkb = '" + label6.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.PHIEUKHAMBENH";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;

            label6.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.TV_CHITIETKHAM WHERE PHIEUKHAM = '" + label6.Text + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            int i = dataGridView2.Rows.Count - 1;
            if (i > 0)
            {
                label7.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
            }
            else
            {
                label7.Text = "none";
                textBox1.Text = null;
                label10.Text = "0";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == textBox10.Text && textBox5.Text != null)
            {
                try
                {
                    string sqlselect = "alter user " + label2.Text + " identified by " + textBox5.Text;
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
        }
    }
}
