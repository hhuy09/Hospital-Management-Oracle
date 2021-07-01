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
    public partial class Form18 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label2.Text = username;

            string sqlselect = "SELECT * FROM QLBENHVIEN.NVBS";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView4.DataSource = dt;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoResizeColumns();

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.BS_PHIEUKHAMBENH";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns();
            label6.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.BSC_CHITIETKHAM WHERE PHIEUKHAM = '" + label6.Text + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoResizeColumns();

            string sqlselect3 = "select * from QLBENHVIEN.bs_donthuoc where phieukham = '" + label6.Text + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoResizeColumns();

            int count = dataGridView3.Rows.Count - 1;
            if (count > 0)
            {
                label8.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
                label13.Text = label8.Text;

                sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
                cmd3 = new OracleCommand(sqlselect3, con);
                dr3 = cmd3.ExecuteReader();
                dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.AutoResizeColumns();
            }

            textBox1.Text = label8.Text;

            string sqlselect5 = "SELECT * FROM QLBENHVIEN.NS_CHAMCONG";
            OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
            OracleDataReader dr5 = cmd5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Load(dr5);
            dataGridView5.DataSource = dt5;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoResizeColumns();

            string sqlselect6 = "SELECT * FROM QLBENHVIEN.BS_THUOC";
            OracleCommand cmd6 = new OracleCommand(sqlselect6, con);
            OracleDataReader dr6 = cmd6.ExecuteReader();
            DataTable dt6 = new DataTable();
            dt6.Load(dr6);
            dataGridView6.DataSource = dt6;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView6.AutoResizeColumns();

            string sqlselect7 = "select * from QLBENHVIEN.bs_chitietkham";
            OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
            OracleDataReader dr7 = cmd7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Load(dr7);
            dataGridView7.DataSource = dt7;
            dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView7.AutoResizeColumns();

            string sqlselect8 = "select * from QLBENHVIEN.bs_dichvu";
            OracleCommand cmd8 = new OracleCommand(sqlselect8, con);
            OracleDataReader dr8 = cmd8.ExecuteReader();
            DataTable dt8 = new DataTable();
            dt8.Load(dr8);
            dataGridView8.DataSource = dt8;
            dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView8.AutoResizeColumns();

            int row = dataGridView4.Rows.Count - 1;
            for(int i = 0; i< row; i++)
            {
                string mans = dataGridView4.Rows[i].Cells[0].Value.ToString();
                if(mans == label2.Text)
                {
                    textBox11.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
                    label3.Text = textBox11.Text;
                    comboBox2.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
                    string ngay = dataGridView4.Rows[i].Cells[3].Value.ToString();
                    ngay = ngay.Substring(0, ngay.IndexOf(" "));
                    textBox4.Text = ngay;
                    textBox9.Text = dataGridView4.Rows[i].Cells[4].Value.ToString();
                    textBox8.Text = dataGridView4.Rows[i].Cells[5].Value.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                label6.Text = row.Cells[0].Value.ToString();

                string sqlselect2 = "SELECT * FROM QLBENHVIEN.BSC_CHITIETKHAM WHERE PHIEUKHAM = '" + label6.Text + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;

                string sqlselect3 = "select * from QLBENHVIEN.bs_donthuoc where phieukham = '" + label6.Text + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;

                int count = dataGridView3.Rows.Count - 1;
                if (count > 0)
                {
                    label8.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
                    label13.Text = label8.Text;
                }
                else
                {
                    label8.Text = "(none)";
                }

                if(label8.Text == "(none)")
                {
                    textBox1.Text = null;
                }
                else
                {
                    textBox1.Text = label8.Text;
                }
                

                sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
                cmd3 = new OracleCommand(sqlselect3, con);
                dr3 = cmd3.ExecuteReader();
                dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;

                label12.Text = "(none)";
                
                textBox2.Text = null;
                textBox3.Text = null;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(label8.Text == "(none)" && textBox1.Text != "")
            {
                try
                {
                    string sqlselect = "insert into QLBENHVIEN.BS_DONTHUOC values ('" + textBox1.Text + "', '" + label6.Text + "')";
                    OracleCommand cmd = new OracleCommand(sqlselect, con);
                    OracleDataReader dr = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string sqlselect3 = "select * from QLBENHVIEN.bs_donthuoc where phieukham = '" + label6.Text + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;

                int count = dataGridView3.Rows.Count - 1;
                if (count > 0)
                {
                    label8.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
                    label13.Text = label8.Text;

                    sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
                    cmd3 = new OracleCommand(sqlselect3, con);
                    dr3 = cmd3.ExecuteReader();
                    dt3 = new DataTable();
                    dt3.Load(dr3);
                    dataGridView3.DataSource = dt3;
                }
            }
            else
            {
                MessageBox.Show("Phiếu khám đã có đơn thuốc.");
            }
            
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView6.Rows[e.RowIndex];
                label12.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into qlbenhvien.BS_CTDT (donthuoc, thuoc, soluong, lieudung) values ('" + textBox1.Text + "', '" + label12.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                label12.Text = "(none)";
                textBox2.Text = null;
                textBox3.Text = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sqlselect3 = "select * from QLBENHVIEN.bs_donthuoc where phieukham = '" + label6.Text + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;

            int count = dataGridView3.Rows.Count - 1;
            if (count > 0)
            {
                label8.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();

                sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
                cmd3 = new OracleCommand(sqlselect3, con);
                dr3 = cmd3.ExecuteReader();
                dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;
            }

            textBox1.Text = label8.Text;
            label12.Text = "(none)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete QLBENHVIEN.BS_CTDT where donthuoc = '"+label8.Text+"' and thuoc = '"+label12.Text+"'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                label12.Text = row.Cells[1].Value.ToString();
                label13.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.BS_CTDT set soluong = " + textBox2.Text + ", lieudung = '" + textBox3.Text + "' where donthuoc = '" + label8.Text + "' and thuoc = '" + label12.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            label12.Text = "(none)";
            textBox2.Text = null;
            textBox3.Text = null;

            string sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];            
                textBox6.Text = row.Cells[3].Value.ToString();
                textBox7.Text = row.Cells[4].Value.ToString();
                label23.Text = row.Cells[0].Value.ToString();
                label24.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.bs_chitietkham set chandoan = '" + textBox6.Text + "', ycbacsi = '" + textBox7.Text + "' where phieukham = '" + label23.Text + "' and dichvu = '" + label24.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect7 = "select * from QLBENHVIEN.bs_chitietkham";
                OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
                OracleDataReader dr7 = cmd7.ExecuteReader();
                DataTable dt7 = new DataTable();
                dt7.Load(dr7);
                dataGridView7.DataSource = dt7;
                dataGridView7.Columns["CHANDOAN"].Width = 120;
                dataGridView7.Columns["YCBACSI"].Width = 270;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label8.Text != "(none)")
            {
                try
                {
                    string sqlselect = "delete QLBENHVIEN.BS_DONTHUOC where madt = '" + label8.Text + "'";
                    OracleCommand cmd = new OracleCommand(sqlselect, con);
                    OracleDataReader dr = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string sqlselect3 = "select * from QLBENHVIEN.bs_donthuoc where phieukham = '" + label6.Text + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;

                int count = dataGridView3.Rows.Count - 1;
                if (count > 0)
                {
                    label8.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
                    label13.Text = label8.Text;

                    sqlselect3 = "select * from QLBENHVIEN.BS_CTDT where donthuoc = '" + label8.Text + "'";
                    cmd3 = new OracleCommand(sqlselect3, con);
                    dr3 = cmd3.ExecuteReader();
                    dt3 = new DataTable();
                    dt3.Load(dr3);
                    dataGridView3.DataSource = dt3;
                }
            }
            else
            {
                MessageBox.Show("Phiếu khám chưa có đơn thuốc.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.NVBS set HOTENNS = '" + textBox1.Text + "', GIOITINH = '" + comboBox2.Text + "', NGAYSINH = to_date('" + textBox4.Text + "','dd-mm-yyyy'), DIACHI = '" + textBox9.Text + "', SODT = '" + textBox8.Text + "' where MANS = '" + label2.Text+"'";
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
            if(textBox5.Text == textBox10.Text && textBox5.Text != null)
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
            else
            {
                MessageBox.Show("Mật khẩu không khớp hoặc không hợp lệ");
            }
        }
    }
}
