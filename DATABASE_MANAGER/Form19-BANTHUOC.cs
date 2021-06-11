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
    public partial class Form19 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
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

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.BT_DONTHUOC";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            label7.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.THUOC";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;

            string sqlselect3 = "SELECT * FROM QLBENHVIEN.BT_CTDT WHERE DONTHUOC = '" + label7.Text + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;
            dataGridView3.DataSource = dt3;
            int r = dataGridView3.Rows.Count - 1;
            int total = 0;
            if (r > 0)
            {
                for (int i = 0; i < r; i++)
                {
                    total += int.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString());
                }

                label6.Text = total.ToString();
            }
            else
            {
                label6.Text = "0";
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
                label7.Text = row.Cells[0].Value.ToString();

                string sqlselect3 = "SELECT * FROM QLBENHVIEN.BT_CTDT WHERE DONTHUOC = '" + label7.Text + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;
                int r = dataGridView3.Rows.Count - 1;
                int total = 0;
                if (r > 0)
                {
                    for (int i = 0; i < r; i++)
                    {
                        total += int.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString());
                    }

                    label6.Text = total.ToString();
                }
                else
                {
                    label6.Text = "0";
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect = "update qlbenhvien.bt_donthuoc set tiendonthuoc = "+label6.Text+", nvbanthuoc = '"+label2.Text+"' where madt = '"+label7.Text+"'";
                OracleCommand cmd = new OracleCommand(sqlselect, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect1 = "SELECT * FROM QLBENHVIEN.BT_DONTHUOC";
                OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                OracleDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(dr1);
                dataGridView1.DataSource = dt1;
                label7.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

                string sqlselect3 = "SELECT * FROM QLBENHVIEN.BT_CTDT WHERE DONTHUOC = '" + label7.Text + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;
                dataGridView3.DataSource = dt3;
                int r = dataGridView3.Rows.Count - 1;
                int total = 0;
                if (r > 0)
                {
                    for (int i = 0; i < r; i++)
                    {
                        total += int.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString());
                    }

                    label6.Text = total.ToString();
                }
                else
                {
                    label6.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
