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
    public partial class Form16 : Form
    {
        public string username;
        public string password;
        public string connectionString;
        OracleConnection con;

        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
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

            string sqlselect1 = "SELECT * FROM QLBENHVIEN.CM_BACSI";
            OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = dt1;
            string mabs = dataGridView1.Rows[0].Cells[0].Value.ToString();

            string sqlselect2 = "SELECT * FROM QLBENHVIEN.CM_KHAMCHINH WHERE BACSIDIEUTRICHINH = '" + mabs + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dataGridView2.DataSource = dt2;
            string mapkb = dataGridView2.Rows[0].Cells[0].Value.ToString();

            string sqlselect3 = "SELECT * FROM QLBENHVIEN.CM_KHAMDV WHERE BSTHUCHIEN = '" + mabs + "'";
            OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            dataGridView3.DataSource = dt3;

            string sqlselect4 = "SELECT * FROM QLBENHVIEN.CM_DONTHUOC WHERE PHIEUKHAM = '" + mapkb + "'";
            OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
            OracleDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);
            dataGridView4.DataSource = dt4;
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
                string mabs = row.Cells[0].Value.ToString();

                string sqlselect2 = "SELECT * FROM QLBENHVIEN.CM_KHAMCHINH WHERE BACSIDIEUTRICHINH = '" + mabs + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView2.DataSource = dt2;
                string mapkb = dataGridView2.Rows[0].Cells[0].Value.ToString();

                string sqlselect3 = "SELECT * FROM QLBENHVIEN.CM_KHAMDV WHERE BSTHUCHIEN = '" + mabs + "'";
                OracleCommand cmd3 = new OracleCommand(sqlselect3, con);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                dataGridView3.DataSource = dt3;

                string sqlselect4 = "SELECT * FROM QLBENHVIEN.CM_DONTHUOC WHERE PHIEUKHAM = '" + mapkb + "'";
                OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dataGridView4.DataSource = dt4;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                string mapkb = row.Cells[0].Value.ToString();

                string sqlselect4 = "SELECT * FROM QLBENHVIEN.CM_DONTHUOC WHERE PHIEUKHAM = '" + mapkb + "'";
                OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dataGridView4.DataSource = dt4;
            }
        }
    }
}
