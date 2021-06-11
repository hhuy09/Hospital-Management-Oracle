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
    public partial class Form3 : Form
    {
        OracleConnection con;
        public string connectionString;
        public Form3()
        {
            InitializeComponent();            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //string sqlselect = "select ROLE from DBA_ROLES";
            //OracleCommand cmd = new OracleCommand(sqlselect, con);
            //OracleDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dataGridView1.Columns["ROLE"].Width = 200;

            //DataGridViewTextBoxColumn sysprivs = new DataGridViewTextBoxColumn();
            //sysprivs.HeaderText = "PRIVILEGE";
            //sysprivs.Width = 200;
            //DataGridViewCheckBoxColumn grant = new DataGridViewCheckBoxColumn();
            //grant.HeaderText = "GRANT";
            //DataGridViewCheckBoxColumn adoption = new DataGridViewCheckBoxColumn();
            //adoption.HeaderText = "ADMIN OPTION";

            //dataGridView3.Columns.Add(sysprivs);
            //dataGridView3.Columns.Add(grant);
            //dataGridView3.Columns.Add(adoption);

            //dataGridView3.Rows.Add("CREATE ANY INDEX", false, false);
            //dataGridView3.Rows.Add("ALTER ANY INDEX", false, false);
            //dataGridView3.Rows.Add("DROP ANY INDEX", false, false);
            //dataGridView3.Rows.Add("CREATE TABLE", false, false);
            //dataGridView3.Rows.Add("CREATE ANY TABLE", false, false);
            //dataGridView3.Rows.Add("ALTER ANY TABLE", false, false);
            //dataGridView3.Rows.Add("DROP ANY TABLE", false, false);
            //dataGridView3.Rows.Add("SELECT ANY TABLE", false, false);
            //dataGridView3.Rows.Add("UPDATE ANY TABLE", false, false);
            //dataGridView3.Rows.Add("DELETE ANY TABLE", false, false);
            //dataGridView3.Rows.Add("CREATE SESSION", false, false);
            //dataGridView3.Rows.Add("ALTER SESSION", false, false);
            //dataGridView3.Rows.Add("RESTRICTED SESSION", false, false);
            //dataGridView3.Rows.Add("CREATE TABLESPACE", false, false);
            //dataGridView3.Rows.Add("ALTER TABLESPACE", false, false);
            //dataGridView3.Rows.Add("DROP TABLESPACE", false, false);
            //dataGridView3.Rows.Add("UNLIMITED TABLESPACE", false, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != textBox3.Text)
                    MessageBox.Show("Error: Password is not match");
                else
                {
                    OracleCommand cmd = new OracleCommand("create_client", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("USER_NAME", OracleDbType.Varchar2).Value = textBox1.Text;
                    cmd.Parameters.Add("U_PASSWORD", OracleDbType.Varchar2).Value = textBox2.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Created successfully");
                    this.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("ERROR");
            }

        }

    }
}
