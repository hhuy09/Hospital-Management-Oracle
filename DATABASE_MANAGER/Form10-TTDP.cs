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
    public partial class Form10 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = dt;
            label3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.HSBENHNHAN";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["HOTENBN"].Width = 200;

            try
            {
                string sqlselect2 = "SELECT * FROM QLBENHVIEN.TT_PHIEUKHAMBENH";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["TINHTRANG"].Width = 200;
            }
            catch
            {

            }
            

            string sqlselect3 = "SELECT * FROM QLBENHVIEN.LICHTRUC";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;

            try
            {
                string sqlselect4 = "SELECT * FROM QLBENHVIEN.DP_PHIEUKHAMBENH";
                OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dataGridView4.DataSource = dt4;
                string mapkb = dataGridView4.Rows[0].Cells[0].Value.ToString();
                label21.Text = mapkb;

                string sqlselect5 = "SELECT * FROM QLBENHVIEN.DP_CHITIETKHAM WHERE PHIEUKHAM = '" + mapkb + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;

                string sqlselect6 = "SELECT * FROM QLBENHVIEN.DP_DICHVU";
                OracleCommand cmd6 = new OracleCommand(sqlselect6, con);
                OracleDataReader dr6 = cmd6.ExecuteReader();
                DataTable dt6 = new DataTable();
                dt6.Load(dr6);
                dataGridView6.DataSource = dt6;
                dataGridView6.Columns["TENDV"].Width = 220;
            }
            catch
            {

            }
            

            string sqlselect7 = "SELECT * FROM QLBENHVIEN.LICHTRUC";
            OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
            OracleDataReader dr7 = cmd7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Load(dr7);
            dataGridView7.DataSource = dt7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "SELECT * FROM QLBENHVIEN.HSBENHNHAN WHERE CCCD = '" + textBox2.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

                int result = dataGridView1.Rows.Count - 1;
                if (result < 1)
                {
                    MessageBox.Show("Không tìm thấy thông tin bệnh nhân.");
                }
                else
                {
                    textBox12.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    textBox10.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    textBox11.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    comboBox2.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    textBox8.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                    textBox9.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "SELECT * FROM QLBENHVIEN.HSBENHNHAN";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["HOTENBN"].Width = 200;

            textBox12.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox1.Text = null;
            comboBox2.Text = "Nam";
            textBox8.Text = null;
            textBox9.Text = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox12.Text = row.Cells[0].Value.ToString();
                textBox10.Text = row.Cells[1].Value.ToString();
                textBox11.Text = row.Cells[2].Value.ToString();
                string s = row.Cells[4].Value.ToString();
                int i = s.IndexOf(" ");
                textBox1.Text = s.Remove(i);
                comboBox2.Text = row.Cells[3].Value.ToString();
                textBox8.Text = row.Cells[6].Value.ToString();
                textBox9.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into QLBENHVIEN.hsbenhnhan values ('" + textBox12.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + comboBox1.Text + "', to_date('" + textBox1.Text + "','dd-mm-yyyy'), '" + textBox9.Text + "', '" + textBox8.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox12.Text = null;
                textBox10.Text = null;
                textBox11.Text = null;
                textBox1.Text = null;
                comboBox2.Text = "Nam";
                textBox8.Text = null;
                textBox9.Text = null;

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.HSBENHNHAN";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns["HOTENBN"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete QLBENHVIEN.hsbenhnhan where mabn = '" + textBox12.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox12.Text = null;
                textBox10.Text = null;
                textBox11.Text = null;
                textBox1.Text = null;
                comboBox2.Text = "Nam";
                textBox8.Text = null;
                textBox9.Text = null;

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.HSBENHNHAN";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns["HOTENBN"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.hsbenhnhan set cccd= '" + textBox10.Text + "', hotenbn = '" + textBox11.Text + "', gioitinh = '" + comboBox2.Text + "', ngaysinh = to_date('" + textBox1.Text + "','dd-mm-yyyy'), diachi = '" + textBox9.Text + "', sodt = '" + textBox8.Text + "' where mabn = '" + textBox12.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox12.Text = null;
                textBox10.Text = null;
                textBox11.Text = null;
                textBox1.Text = null;
                comboBox2.Text = "Nam";
                textBox8.Text = null;
                textBox9.Text = null;

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.HSBENHNHAN";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns["HOTENBN"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[1].Value.ToString();
                textBox5.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();
                string s = row.Cells[4].Value.ToString();
                int i = s.IndexOf(" ");
                textBox6.Text = s.Remove(i);
                textBox13.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sqlselect2 = "SELECT * FROM QLBENHVIEN.TT_PHIEUKHAMBENH";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["TINHTRANG"].Width = 200;

            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            comboBox1.Text = null;
            textBox6.Text = null;
            textBox13.Text = null;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into QLBENHVIEN.tt_phieukhambenh values ('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox1.Text + "', to_date('" + textBox6.Text + "','dd-mm-yyyy'), '" + textBox13.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                comboBox1.Text = null;
                textBox6.Text = null;
                textBox13.Text = null;

                string sqlselect2 = "SELECT * FROM QLBENHVIEN.TT_PHIEUKHAMBENH";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["TINHTRANG"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete QLBENHVIEN.tt_phieukhambenh where mapkb = '" + textBox3.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                comboBox1.Text = null;
                textBox6.Text = null;
                textBox13.Text = null;

                string sqlselect2 = "SELECT * FROM QLBENHVIEN.TT_PHIEUKHAMBENH";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["TINHTRANG"].Width = 200;
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
                string sqlselect = "update QLBENHVIEN.tt_phieukhambenh set benhnhan = '" + textBox4.Text + "', bacsidieutrichinh = '" + textBox5.Text + "', nvdieuphoi = '" + comboBox1.Text + "', ngaykham = to_date('" + textBox6.Text + "','dd-mm-yyyy'), tinhtrang = '" + textBox13.Text + "' where mapkb = '" + textBox3.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                comboBox1.Text = null;
                textBox6.Text = null;
                textBox13.Text = null;

                string sqlselect2 = "SELECT * FROM QLBENHVIEN.TT_PHIEUKHAMBENH";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["TINHTRANG"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox5.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                string mapkb = row.Cells[0].Value.ToString();

                label21.Text = mapkb;
                textBox7.Text = null;
                textBox14.Text = null;

                string sqlselect5 = "SELECT * FROM QLBENHVIEN.DP_CHITIETKHAM WHERE PHIEUKHAM = '" + mapkb + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
                label21.Text = row.Cells[0].Value.ToString();
                textBox7.Text = row.Cells[1].Value.ToString();
                textBox14.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "insert into QLBENHVIEN.dp_chitietkham values('" + label21.Text + "', '" + textBox7.Text + "', '" + textBox14.Text + "')";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox7.Text = null;
                textBox14.Text = null;

                string sqlselect5 = "SELECT * FROM QLBENHVIEN.DP_CHITIETKHAM WHERE PHIEUKHAM = '" + label21.Text + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView6.Rows[e.RowIndex];
                textBox7.Text = row.Cells[0].Value.ToString();
            }
        }


        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];
                textBox14.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "delete QLBENHVIEN.DP_CHITIETKHAM WHERE PHIEUKHAM = '" + label21.Text + "' and DICHVU = '" + textBox7.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox7.Text = null;
                textBox14.Text = null;

                string sqlselect5 = "SELECT * FROM QLBENHVIEN.DP_CHITIETKHAM WHERE PHIEUKHAM = '" + label21.Text + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update QLBENHVIEN.DP_CHITIETKHAM set BSTHUCHIEN = '"+ textBox14.Text + "' where PHIEUKHAM = '" + label21.Text + "' and DICHVU = '" + textBox7.Text + "'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                textBox7.Text = null;
                textBox14.Text = null;

                string sqlselect5 = "SELECT * FROM QLBENHVIEN.DP_CHITIETKHAM WHERE PHIEUKHAM = '" + label21.Text + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dataGridView5.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    
