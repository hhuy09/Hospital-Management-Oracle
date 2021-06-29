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
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

    }
}
