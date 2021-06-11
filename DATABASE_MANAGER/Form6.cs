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
    public partial class Form6 : Form
    {
        OracleConnection con;
        public string connectionString;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            {
                OracleCommand cmd = new OracleCommand("CREATE_ROLE", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("ROLE_NAME", OracleDbType.Varchar2).Value = textBox1.Text;              
                cmd.ExecuteNonQuery();
                MessageBox.Show("Created successfully");
                this.Close();
                //string sqlselect = "CREATE ROLE " + textBox1.Text;
                //OracleCommand cmd = new OracleCommand(sqlselect, con);
                //OracleDataReader dr = cmd.ExecuteReader();
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("ERROR");
            //}
        }
    }
}
