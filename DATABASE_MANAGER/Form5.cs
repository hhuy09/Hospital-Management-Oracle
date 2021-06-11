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
    public partial class Form5 : Form
    {
        public string connectionString;
        public string dropusername;
        OracleConnection con;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
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
            try
            {
                OracleCommand cmd = new OracleCommand("DROP_CLIENT", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("INUSER", OracleDbType.Varchar2).Value = dropusername;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dropped succesfully");

                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
}
    }
}
