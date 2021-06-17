using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;


namespace DATABASE_MANAGER
{
    public partial class Form1 : Form
    {
        string connectionString;
        OracleConnection con;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            username = username.ToUpper();
            string password = textBox2.Text;
            connectionString = "DATA SOURCE = localhost:1521/xe; user id = " + username + "; PASSWORD = " + password + "";

            if(username == "QLBENHVIEN")
            {
                try
                {
                    con = new OracleConnection();
                    con.ConnectionString = connectionString;
                    con.Open();
                    con.Close();

                    Form2 f2 = new Form2();
                    f2.connectionString = connectionString;
                    f2.username = username;
                    this.Hide();
                    f2.Show();
                    con.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Error ecountered: Invalid username/password; logon denied");
                }
            }
            else
            {
                try
                {
                    con = new OracleConnection();
                    con.ConnectionString = connectionString;
                    con.Open();
                    string us = username.ToLower();
                    con.Close();

                    connectionString = "DATA SOURCE = localhost:1521/xe; user id = QLBENHVIEN; PASSWORD = 123456";
                    con.ConnectionString = connectionString;
                    con.Open();

                    string sqlselect1 = "select UF_('" + us + "') from dual";
                    OracleCommand cmd1 = new OracleCommand(sqlselect1, con);
                    OracleDataReader dr1 = cmd1.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    dataGridView1.DataSource = dt1;

                    string type = dataGridView1.Rows[0].Cells[0].Value.ToString();

                    connectionString = "DATA SOURCE = localhost:1521/xe; user id = " + username + "; PASSWORD = " + password + "";

                    if(type == "0")
                    {
                        MessageBox.Show("Error ecountered: Invalid username/password; logon denied");
                    }
                    else if (type == "1") //bacsi
                    {
                        Form18 bacsi = new Form18();
                        bacsi.connectionString = connectionString;
                        bacsi.username = us;
                        bacsi.password = password;
                        this.Hide();
                        bacsi.Show();
                    }
                    else if(type == "2") //tieptandieuphoi
                    {
                        Form10 ttdp = new Form10();
                        ttdp.connectionString = connectionString;
                        ttdp.username = us;
                        ttdp.password = password;
                        this.Hide();
                        ttdp.Show();
                    }
                    else if(type == "3") //ban thuoc
                    {
                        Form19 tv = new Form19();
                        tv.connectionString = connectionString;
                        tv.username = us;
                        tv.password = password;
                        this.Hide();
                        tv.Show();
                    }
                    else if(type == "4") //taivu
                    {
                        Form17 tv = new Form17();
                        tv.connectionString = connectionString;
                        tv.username = us;
                        tv.password = password;
                        this.Hide();
                        tv.Show();
                    }
                    else if(type == "5") //ke toan
                    {
                        Form20 kt = new Form20();
                        kt.connectionString = connectionString;
                        kt.username = us;
                        kt.password = password;
                        this.Hide();
                        kt.Show();
                    }
                    else if (type == "6") //qltnns
                    {
                        Form14 kt = new Form14();
                        kt.connectionString = connectionString;
                        kt.username = us;
                        kt.password = password;
                        this.Hide();
                        kt.Show();
                    }
                    else if (type == "7") //qltv
                    {
                        Form15 kt = new Form15();
                        kt.connectionString = connectionString;
                        kt.username = us;
                        kt.password = password;
                        this.Hide();
                        kt.Show();
                    }
                    else if (type == "8") //qlcm
                    {
                        Form16 kt = new Form16();
                        kt.connectionString = connectionString;
                        kt.username = us;
                        kt.password = password;
                        this.Hide();
                        kt.Show();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error ecountered: Invalid username/password; logon denied");
                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //con.Close();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //con.ConnectionString = connectionString;
            //con.Open();
        }


    }
}
