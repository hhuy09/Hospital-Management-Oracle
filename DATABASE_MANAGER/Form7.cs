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
    public partial class Form7 : Form
    {
        public string connectionString;
        public string rolename;
        public string dbm;
        OracleConnection con;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            label4.Text = rolename;

            string sqlselect = "SELECT ROLE FROM DBA_ROLES";
            OracleCommand cmd = new OracleCommand(sqlselect, con);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dt.Columns.Add(new DataColumn("GRANTED", typeof(bool)));
            dt.Columns.Add(new DataColumn("ADMIN", typeof(bool)));
            dataGridView1.DataSource = dt;  
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns();


            string sqlselect2 = "select GRANTED_ROLE, ADMIN_OPTION from ROLE_ROLE_PRIVS where ROLE = '" + rolename + "'";
            OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dt2.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
            dataGridView2.DataSource = dt2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoResizeColumns();


            string sqlselect4 = "select PRIVILEGE, ADMIN_OPTION from ROLE_SYS_PRIVS where ROLE = '" + rolename + "'";
            OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
            OracleDataReader dr4 = cmd4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr4);
            dataGridView4.DataSource = dt4;
            dataGridView4.Columns["PRIVILEGE"].Width = 225;

            string sqlselect6 = "SELECT USERNAME FROM LIST_USER";
            OracleCommand cmd6 = new OracleCommand(sqlselect6, con);
            OracleDataReader dr6 = cmd6.ExecuteReader();
            DataTable dt6 = new DataTable();
            dt6.Load(dr6);
            dt6.Columns.Add(new DataColumn("GRANTED", typeof(bool)));
            dt6.Columns.Add(new DataColumn("ADMIN", typeof(bool)));
            dataGridView6.DataSource = dt6;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView6.AutoResizeColumns();

            string sqlselect5 = "SELECT GRANTEE, ADMIN_OPTION FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE = '" + rolename + "'";
            OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
            OracleDataReader dr5 = cmd5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Load(dr5);
            dt5.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
            dataGridView5.DataSource = dt5;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoResizeColumns();

            string sqlselect8 = "select OWNER, TABLE_NAME from all_tables where OWNER = '" + dbm + "'";
            OracleCommand cmd8 = new OracleCommand(sqlselect8, con);
            OracleDataReader dr8 = cmd8.ExecuteReader();
            DataTable dt8 = new DataTable();
            dt8.Load(dr8);
            dataGridView8.DataSource = dt8;
            dataGridView8.Columns["TABLE_NAME"].Width = 120;

            string sqlselect7 = "SELECT TABLE_NAME, PRIVILEGE, GRANTABLE FROM DBA_TAB_PRIVS WHERE OWNER = '" + dbm + "' AND GRANTEE = '" + rolename + "'";
            OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
            OracleDataReader dr7 = cmd7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Load(dr7);
            dataGridView7.DataSource = dt7;



            //DataGridViewCheckBoxColumn dgvcS = new DataGridViewCheckBoxColumn();
            //dgvcS.HeaderText = "SELECT";
            //DataGridViewCheckBoxColumn dgvcU = new DataGridViewCheckBoxColumn();
            //dgvcU.HeaderText = "UPDATE";
            //DataGridViewCheckBoxColumn dgvcI = new DataGridViewCheckBoxColumn();
            //dgvcI.HeaderText = "INSERT";
            //DataGridViewCheckBoxColumn dgvcD = new DataGridViewCheckBoxColumn();
            //dgvcD.HeaderText = "DELETE";
            //DataGridViewCheckBoxColumn dgvcAo = new DataGridViewCheckBoxColumn();
            //dgvcAo.HeaderText = "GRAND OPTION";


            DataGridViewTextBoxColumn sysprivs = new DataGridViewTextBoxColumn();
            sysprivs.HeaderText = "PRIVILEGE";



            dataGridView3.Columns.Add(sysprivs);
            sysprivs.Width = 225;


            dataGridView3.Rows.Add("ADMINISTER ANY SQL TUNING SET");
            dataGridView3.Rows.Add("ADMINISTER DATABASE TRIGGER");
            dataGridView3.Rows.Add("ADMINISTER KEY MANAGEMENT");
            dataGridView3.Rows.Add("ADMINISTER RESOURCE MANAGER");
            dataGridView3.Rows.Add("ADMINISTER SQL MANAGEMENT OBJECT");
            dataGridView3.Rows.Add("ADMINISTER SQL TUNING SET");
            dataGridView3.Rows.Add("ADVISOR");
            dataGridView3.Rows.Add("ALTER ANY ANALYTIC VIEW");
            dataGridView3.Rows.Add("ALTER ANY ASSEMBLY");
            dataGridView3.Rows.Add("ALTER ANY ATTRIBUTE DIMENSION");
            dataGridView3.Rows.Add("ALTER ANY CLUSTER");
            dataGridView3.Rows.Add("ALTER ANY CUBE");
            dataGridView3.Rows.Add("ALTER ANY CUBE BUILD PROCESS");
            dataGridView3.Rows.Add("ALTER ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("ALTER ANY DIMENSION");
            dataGridView3.Rows.Add("ALTER ANY EDITION");
            dataGridView3.Rows.Add("ALTER ANY EVALUATION CONTEXT");
            dataGridView3.Rows.Add("ALTER ANY HIERARCHY");
            dataGridView3.Rows.Add("ALTER ANY INDEX");
            dataGridView3.Rows.Add("ALTER ANY INDEXTYPE");
            dataGridView3.Rows.Add("ALTER ANY LIBRARY");
            dataGridView3.Rows.Add("ALTER ANY MATERIALIZED VIEW");
            dataGridView3.Rows.Add("ALTER ANY MEASURE FOLDER");
            dataGridView3.Rows.Add("ALTER ANY MINING MODEL");
            dataGridView3.Rows.Add("ALTER ANY OPERATOR");
            dataGridView3.Rows.Add("ALTER ANY OUTLINE");
            dataGridView3.Rows.Add("ALTER ANY PROCEDURE");
            dataGridView3.Rows.Add("ALTER ANY ROLE");
            dataGridView3.Rows.Add("ALTER ANY RULE");
            dataGridView3.Rows.Add("ALTER ANY RULE SET");
            dataGridView3.Rows.Add("ALTER ANY SEQUENCE");
            dataGridView3.Rows.Add("ALTER ANY SQL PROFILE");
            dataGridView3.Rows.Add("ALTER ANY SQL TRANSLATION PROFILE");
            dataGridView3.Rows.Add("ALTER ANY TABLE");
            dataGridView3.Rows.Add("ALTER ANY TRIGGER");
            dataGridView3.Rows.Add("ALTER ANY TYPE");
            dataGridView3.Rows.Add("ALTER DATABASE");
            dataGridView3.Rows.Add("ALTER DATABASE LINK");
            dataGridView3.Rows.Add("ALTER LOCKDOWN PROFILE");
            dataGridView3.Rows.Add("ALTER PROFILE");
            dataGridView3.Rows.Add("ALTER PUBLIC DATABASE LINK");
            dataGridView3.Rows.Add("ALTER RESOURCE COST");
            dataGridView3.Rows.Add("ALTER ROLLBACK SEGMENT");
            dataGridView3.Rows.Add("ALTER SESSION");
            dataGridView3.Rows.Add("ALTER SYSTEM");
            dataGridView3.Rows.Add("ALTER TABLESPACE");
            dataGridView3.Rows.Add("ALTER USER");
            dataGridView3.Rows.Add("ANALYZE ANY");
            dataGridView3.Rows.Add("ANALYZE ANY DICTIONARY");
            dataGridView3.Rows.Add("AUDIT ANY");
            dataGridView3.Rows.Add("AUDIT SYSTEM");
            dataGridView3.Rows.Add("BACKUP ANY TABLE");
            dataGridView3.Rows.Add("BECOME USER");
            dataGridView3.Rows.Add("CHANGE NOTIFICATION");
            dataGridView3.Rows.Add("COMMENT ANY MINING MODEL");
            dataGridView3.Rows.Add("COMMENT ANY TABLE");
            dataGridView3.Rows.Add("CREATE ANALYTIC VIEW");
            dataGridView3.Rows.Add("CREATE ANY ANALYTIC VIEW");
            dataGridView3.Rows.Add("CREATE ANY ASSEMBLY");
            dataGridView3.Rows.Add("CREATE ANY ATTRIBUTE DIMENSION");
            dataGridView3.Rows.Add("CREATE ANY CLUSTER");
            dataGridView3.Rows.Add("CREATE ANY CONTEXT");
            dataGridView3.Rows.Add("CREATE ANY CREDENTIAL");
            dataGridView3.Rows.Add("CREATE ANY CUBE");
            dataGridView3.Rows.Add("CREATE ANY CUBE BUILD PROCESS");
            dataGridView3.Rows.Add("CREATE ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("CREATE ANY DIMENSION");
            dataGridView3.Rows.Add("CREATE ANY DIRECTORY");
            dataGridView3.Rows.Add("CREATE ANY EDITION");
            dataGridView3.Rows.Add("CREATE ANY EVALUATION CONTEXT");
            dataGridView3.Rows.Add("CREATE ANY HIERARCHY");
            dataGridView3.Rows.Add("CREATE ANY INDEX");
            dataGridView3.Rows.Add("CREATE ANY INDEXTYPE");
            dataGridView3.Rows.Add("CREATE ANY JOB");
            dataGridView3.Rows.Add("CREATE ANY LIBRARY");
            dataGridView3.Rows.Add("CREATE ANY MATERIALIZED VIEW");
            dataGridView3.Rows.Add("CREATE ANY MEASURE FOLDER");
            dataGridView3.Rows.Add("CREATE ANY MINING MODEL");
            dataGridView3.Rows.Add("CREATE ANY OPERATOR");
            dataGridView3.Rows.Add("CREATE ANY OUTLINE");
            dataGridView3.Rows.Add("CREATE ANY PROCEDURE");
            dataGridView3.Rows.Add("CREATE ANY RULE");
            dataGridView3.Rows.Add("CREATE ANY RULE SET");
            dataGridView3.Rows.Add("CREATE ANY SEQUENCE");
            dataGridView3.Rows.Add("CREATE ANY SQL PROFILE");
            dataGridView3.Rows.Add("CREATE ANY SQL TRANSLATION PROFILE");
            dataGridView3.Rows.Add("CREATE ANY SYNONYM");
            dataGridView3.Rows.Add("CREATE ANY TABLE");
            dataGridView3.Rows.Add("CREATE ANY TRIGGER");
            dataGridView3.Rows.Add("CREATE ANY TYPE");
            dataGridView3.Rows.Add("CREATE ANY VIEW");
            dataGridView3.Rows.Add("CREATE ASSEMBLY");
            dataGridView3.Rows.Add("CREATE ATTRIBUTE DIMENSION");
            dataGridView3.Rows.Add("CREATE CLUSTER");
            dataGridView3.Rows.Add("CREATE CREDENTIAL");
            dataGridView3.Rows.Add("CREATE CUBE");
            dataGridView3.Rows.Add("CREATE CUBE BUILD PROCESS");
            dataGridView3.Rows.Add("CREATE CUBE DIMENSION");
            dataGridView3.Rows.Add("CREATE DATABASE LINK");
            dataGridView3.Rows.Add("CREATE DIMENSION");
            dataGridView3.Rows.Add("CREATE EVALUATION CONTEXT");
            dataGridView3.Rows.Add("CREATE EXTERNAL JOB");
            dataGridView3.Rows.Add("CREATE HIERARCHY");
            dataGridView3.Rows.Add("CREATE INDEXTYPE");
            dataGridView3.Rows.Add("CREATE JOB");
            dataGridView3.Rows.Add("CREATE LIBRARY");
            dataGridView3.Rows.Add("CREATE LOCKDOWN PROFILE");
            dataGridView3.Rows.Add("CREATE MATERIALIZED VIEW");
            dataGridView3.Rows.Add("CREATE MEASURE FOLDER");
            dataGridView3.Rows.Add("CREATE MINING MODEL");
            dataGridView3.Rows.Add("CREATE OPERATOR");
            dataGridView3.Rows.Add("CREATE PLUGGABLE DATABASE");
            dataGridView3.Rows.Add("CREATE PROCEDURE");
            dataGridView3.Rows.Add("CREATE PROFILE");
            dataGridView3.Rows.Add("CREATE PUBLIC DATABASE LINK");
            dataGridView3.Rows.Add("CREATE PUBLIC SYNONYM");
            dataGridView3.Rows.Add("CREATE ROLE");
            dataGridView3.Rows.Add("CREATE ROLLBACK SEGMENT");
            dataGridView3.Rows.Add("CREATE RULE");
            dataGridView3.Rows.Add("CREATE RULE SET");
            dataGridView3.Rows.Add("CREATE SEQUENCE");
            dataGridView3.Rows.Add("CREATE SESSION");
            dataGridView3.Rows.Add("CREATE SQL TRANSLATION PROFILE");
            dataGridView3.Rows.Add("CREATE SYNONYM");
            dataGridView3.Rows.Add("CREATE TABLE");
            dataGridView3.Rows.Add("CREATE TABLESPACE");
            dataGridView3.Rows.Add("CREATE TRIGGER");
            dataGridView3.Rows.Add("CREATE TYPE");
            dataGridView3.Rows.Add("CREATE USER");
            dataGridView3.Rows.Add("CREATE VIEW");
            dataGridView3.Rows.Add("DEBUG ANY PROCEDURE");
            dataGridView3.Rows.Add("DEBUG CONNECT ANY");
            dataGridView3.Rows.Add("DEBUG CONNECT SESSION");
            dataGridView3.Rows.Add("DELETE ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("DELETE ANY MEASURE FOLDER");
            dataGridView3.Rows.Add("DELETE ANY TABLE");
            dataGridView3.Rows.Add("DEQUEUE ANY QUEUE");
            dataGridView3.Rows.Add("DROP ANY ANALYTIC VIEW");
            dataGridView3.Rows.Add("DROP ANY ASSEMBLY");
            dataGridView3.Rows.Add("DROP ANY ATTRIBUTE DIMENSION");
            dataGridView3.Rows.Add("DROP ANY CLUSTER");
            dataGridView3.Rows.Add("DROP ANY CONTEXT");
            dataGridView3.Rows.Add("DROP ANY CUBE");
            dataGridView3.Rows.Add("DROP ANY CUBE BUILD PROCESS");
            dataGridView3.Rows.Add("DROP ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("DROP ANY DIMENSION");
            dataGridView3.Rows.Add("DROP ANY DIRECTORY");
            dataGridView3.Rows.Add("DROP ANY EDITION");
            dataGridView3.Rows.Add("DROP ANY EVALUATION CONTEXT");
            dataGridView3.Rows.Add("DROP ANY HIERARCHY");
            dataGridView3.Rows.Add("DROP ANY INDEX");
            dataGridView3.Rows.Add("DROP ANY INDEXTYPE");
            dataGridView3.Rows.Add("DROP ANY LIBRARY");
            dataGridView3.Rows.Add("DROP ANY MATERIALIZED VIEW");
            dataGridView3.Rows.Add("DROP ANY MEASURE FOLDER");
            dataGridView3.Rows.Add("DROP ANY MINING MODEL");
            dataGridView3.Rows.Add("DROP ANY OPERATOR");
            dataGridView3.Rows.Add("DROP ANY OUTLINE");
            dataGridView3.Rows.Add("DROP ANY PROCEDURE");
            dataGridView3.Rows.Add("DROP ANY ROLE");
            dataGridView3.Rows.Add("DROP ANY RULE");
            dataGridView3.Rows.Add("DROP ANY RULE SET");
            dataGridView3.Rows.Add("DROP ANY SEQUENCE");
            dataGridView3.Rows.Add("DROP ANY SQL PROFILE");
            dataGridView3.Rows.Add("DROP ANY SQL TRANSLATION PROFILE");
            dataGridView3.Rows.Add("DROP ANY SYNONYM");
            dataGridView3.Rows.Add("DROP ANY TABLE");
            dataGridView3.Rows.Add("DROP ANY TRIGGER");
            dataGridView3.Rows.Add("DROP ANY TYPE");
            dataGridView3.Rows.Add("DROP ANY VIEW");
            dataGridView3.Rows.Add("DROP LOCKDOWN PROFILE");
            dataGridView3.Rows.Add("DROP PROFILE");
            dataGridView3.Rows.Add("DROP PUBLIC DATABASE LINK");
            dataGridView3.Rows.Add("DROP PUBLIC SYNONYM");
            dataGridView3.Rows.Add("DROP ROLLBACK SEGMENT");
            dataGridView3.Rows.Add("DROP TABLESPACE");
            dataGridView3.Rows.Add("DROP USER");
            dataGridView3.Rows.Add("EM EXPRESS CONNECT");
            dataGridView3.Rows.Add("ENQUEUE ANY QUEUE");
            dataGridView3.Rows.Add("EXECUTE ANY ASSEMBLY");
            dataGridView3.Rows.Add("EXECUTE ANY CLASS");
            dataGridView3.Rows.Add("EXECUTE ANY EVALUATION CONTEXT");
            dataGridView3.Rows.Add("EXECUTE ANY INDEXTYPE");
            dataGridView3.Rows.Add("EXECUTE ANY LIBRARY");
            dataGridView3.Rows.Add("EXECUTE ANY OPERATOR");
            dataGridView3.Rows.Add("EXECUTE ANY PROCEDURE");
            dataGridView3.Rows.Add("EXECUTE ANY PROGRAM");
            dataGridView3.Rows.Add("EXECUTE ANY RULE");
            dataGridView3.Rows.Add("EXECUTE ANY RULE SET");
            dataGridView3.Rows.Add("EXECUTE ANY TYPE");
            dataGridView3.Rows.Add("EXECUTE ASSEMBLY");
            dataGridView3.Rows.Add("EXEMPT ACCESS POLICY");
            dataGridView3.Rows.Add("EXEMPT IDENTITY POLICY");
            dataGridView3.Rows.Add("EXEMPT REDACTION POLICY");
            dataGridView3.Rows.Add("EXPORT FULL DATABASE");
            dataGridView3.Rows.Add("FLASHBACK ANY TABLE");
            dataGridView3.Rows.Add("FLASHBACK ARCHIVE ADMINISTER");
            dataGridView3.Rows.Add("FORCE ANY TRANSACTION");
            dataGridView3.Rows.Add("FORCE TRANSACTION");
            dataGridView3.Rows.Add("GLOBAL QUERY REWRITE");
            dataGridView3.Rows.Add("GRANT ANY OBJECT PRIVILEGE");
            dataGridView3.Rows.Add("GRANT ANY PRIVILEGE");
            dataGridView3.Rows.Add("GRANT ANY ROLE");
            dataGridView3.Rows.Add("IMPORT FULL DATABASE");
            dataGridView3.Rows.Add("INHERIT ANY PRIVILEGES");
            dataGridView3.Rows.Add("INHERIT ANY REMOTE PRIVILEGES");
            dataGridView3.Rows.Add("INSERT ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("INSERT ANY MEASURE FOLDER");
            dataGridView3.Rows.Add("INSERT ANY TABLE");
            dataGridView3.Rows.Add("KEEP DATE TIME");
            dataGridView3.Rows.Add("KEEP SYSGUID");
            dataGridView3.Rows.Add("LOCK ANY TABLE");
            dataGridView3.Rows.Add("LOGMINING");
            dataGridView3.Rows.Add("MANAGE ANY FILE GROUP");
            dataGridView3.Rows.Add("MANAGE ANY QUEUE");
            dataGridView3.Rows.Add("MANAGE FILE GROUP");
            dataGridView3.Rows.Add("MANAGE SCHEDULER");
            dataGridView3.Rows.Add("MANAGE TABLESPACE");
            dataGridView3.Rows.Add("MERGE ANY VIEW");
            dataGridView3.Rows.Add("ON COMMIT REFRESH");
            dataGridView3.Rows.Add("PURGE DBA_RECYCLEBIN");
            dataGridView3.Rows.Add("QUERY REWRITE");
            dataGridView3.Rows.Add("READ ANY ANALYTIC VIEW CACHE");
            dataGridView3.Rows.Add("READ ANY FILE GROUP");
            dataGridView3.Rows.Add("READ ANY TABLE");
            dataGridView3.Rows.Add("REDEFINE ANY TABLE");
            dataGridView3.Rows.Add("RESTRICTED SESSION");
            dataGridView3.Rows.Add("RESUMABLE");
            dataGridView3.Rows.Add("SELECT ANY CUBE");
            dataGridView3.Rows.Add("SELECT ANY CUBE BUILD PROCESS");
            dataGridView3.Rows.Add("SELECT ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("SELECT ANY DICTIONARY");
            dataGridView3.Rows.Add("SELECT ANY MEASURE FOLDER");
            dataGridView3.Rows.Add("SELECT ANY MINING MODEL");
            dataGridView3.Rows.Add("SELECT ANY SEQUENCE");
            dataGridView3.Rows.Add("SELECT ANY TABLE");
            dataGridView3.Rows.Add("SELECT ANY TRANSACTION");
            dataGridView3.Rows.Add("SET CONTAINER");
            dataGridView3.Rows.Add("SYSBACKUP");
            dataGridView3.Rows.Add("SYSDBA");
            dataGridView3.Rows.Add("SYSDG");
            dataGridView3.Rows.Add("SYSKM");
            dataGridView3.Rows.Add("SYSOPER");
            dataGridView3.Rows.Add("SYSRAC");
            dataGridView3.Rows.Add("TEXT DATASTORE ACCESS");
            dataGridView3.Rows.Add("TRANSLATE ANY SQL");
            dataGridView3.Rows.Add("UNDER ANY TABLE");
            dataGridView3.Rows.Add("UNDER ANY TYPE");
            dataGridView3.Rows.Add("UNDER ANY VIEW");
            dataGridView3.Rows.Add("UNLIMITED TABLESPACE");
            dataGridView3.Rows.Add("UPDATE ANY CUBE");
            dataGridView3.Rows.Add("UPDATE ANY CUBE BUILD PROCESS");
            dataGridView3.Rows.Add("UPDATE ANY CUBE DIMENSION");
            dataGridView3.Rows.Add("UPDATE ANY TABLE");
            dataGridView3.Rows.Add("USE ANY JOB RESOURCE");
            dataGridView3.Rows.Add("USE ANY SQL TRANSLATION PROFILE");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label5.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label6.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label11.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label9.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string role = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string granted = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string admin = dataGridView1.Rows[i].Cells[2].Value.ToString();

                    string sqlgrant = null;
                    if (admin == "True")
                    {
                        sqlgrant = "GRANT " + role + " TO " + rolename + " WITH ADMIN OPTION";
                    }
                    else if ((admin == "False" || admin == "") && granted == "True")
                    {
                        string sqlrevoke = "REVOKE " + role + " FROM " + rolename;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            //MessageBox.Show(error.Message);
                        }

                        sqlgrant = "GRANT " + role + " TO " + rolename;
                    }

                    if (sqlgrant != null)
                    {
                        try
                        {
                            MessageBox.Show(sqlgrant);
                            OracleCommand cmd = new OracleCommand(sqlgrant, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect2 = "select GRANTED_ROLE, ADMIN_OPTION from ROLE_ROLE_PRIVS where ROLE = '" + rolename + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dt2.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView2.DataSource = dt2;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoResizeColumns();

            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlgrant = "GRANT ";
                if (checkBox2.Checked)
                {
                    sqlgrant += label11.Text + " TO " + label4.Text + " WITH ADMIN OPTION";
                    checkBox2.Checked = false;
                }
                else
                {
                    sqlgrant += label11.Text + " TO " + label4.Text;
                }
                OracleCommand cmd = new OracleCommand(sqlgrant, con);
                OracleDataReader dr = cmd.ExecuteReader();


                string sqlselect2 = "select Privilege, admin_option from dba_sys_privs where grantee = '" + rolename + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView4.DataSource = dt2;
                dataGridView4.Columns["PRIVILEGE"].Width = 120;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlgrant = "REVOKE " + label9.Text + " FROM " + label4.Text;
                OracleCommand cmd = new OracleCommand(sqlgrant, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect2 = "select Privilege, admin_option from dba_sys_privs where grantee = '" + rolename + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dataGridView4.DataSource = dt2;
                dataGridView4.Columns["PRIVILEGE"].Width = 120;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView2.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string role = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string revoke = dataGridView2.Rows[i].Cells[2].Value.ToString();

                    string sqlrevoke = null;
                    if (revoke == "True")
                    {
                        sqlrevoke = "REVOKE " + role + " FROM " + rolename;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect2 = "select GRANTED_ROLE, ADMIN_OPTION from ROLE_ROLE_PRIVS where ROLE = '" + rolename + "'";
                OracleCommand cmd2 = new OracleCommand(sqlselect2, con);
                OracleDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dt2.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView2.DataSource = dt2;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoResizeColumns();

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int row = dataGridView6.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string user = dataGridView6.Rows[i].Cells[0].Value.ToString();
                    string granted = dataGridView6.Rows[i].Cells[1].Value.ToString();
                    string admin = dataGridView6.Rows[i].Cells[2].Value.ToString();

                    string sqlgrant = null;
                    if (admin == "True")
                    {
                        sqlgrant = "GRANT " + rolename + " TO " + user + " WITH ADMIN OPTION";
                    }
                    else if ((admin == "False" || admin == "") && granted == "True")
                    {
                        string sqlrevoke = "REVOKE " + rolename + " FROM " + user;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            //MessageBox.Show(error.Message);
                        }

                        sqlgrant = "GRANT " + rolename + " TO " + user;
                    }

                    if (sqlgrant != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrant, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect5 = "SELECT GRANTEE, ADMIN_OPTION FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE = '" + rolename + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dt5.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView5.DataSource = dt5;
                dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView5.AutoResizeColumns();

            }
        }





        private void button6_Click(object sender, EventArgs e)
        {
            int row = dataGridView5.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string user = dataGridView5.Rows[i].Cells[0].Value.ToString();
                    string revoke = dataGridView5.Rows[i].Cells[2].Value.ToString();

                    string sqlrevoke = null;
                    if (revoke == "True")
                    {
                        sqlrevoke = "REVOKE " + rolename + " FROM " + user;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect5 = "SELECT GRANTEE, ADMIN_OPTION FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE = '" + rolename + "'";
                OracleCommand cmd5 = new OracleCommand(sqlselect5, con);
                OracleDataReader dr5 = cmd5.ExecuteReader();
                DataTable dt5 = new DataTable();
                dt5.Load(dr5);
                dt5.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView5.DataSource = dt5;
                dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView5.AutoResizeColumns();
            }          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlgrant = "GRANT ";
                if (checkBox4.Checked)
                {
                    sqlgrant += comboBox1.Text + " ON " + label17.Text + " TO " + rolename + " WITH GRANT OPTION";
                    checkBox4.Checked = false;
                }
                else
                {
                    sqlgrant += comboBox1.Text + " ON " + label17.Text + " TO " + rolename;
                }

                OracleCommand cmd = new OracleCommand(sqlgrant, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect7 = "SELECT TABLE_NAME, PRIVILEGE, GRANTABLE FROM DBA_TAB_PRIVS WHERE OWNER = '" + dbm + "' AND GRANTEE = '" + rolename + "' AND TYPE = 'TABLE'";
                OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
                OracleDataReader dr7 = cmd7.ExecuteReader();
                DataTable dt7 = new DataTable();
                dt7.Load(dr7);
                dataGridView7.DataSource = dt7;
            }
            catch(Exception)
            {
                MessageBox.Show("ERROR");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlgrant = "REVOKE " + label21.Text + " ON " + label15.Text + " FROM " + rolename;
                OracleCommand cmd = new OracleCommand(sqlgrant, con);
                OracleDataReader dr = cmd.ExecuteReader();

                string sqlselect7 = "SELECT TABLE_NAME, PRIVILEGE, GRANTABLE FROM DBA_TAB_PRIVS WHERE OWNER = '" + dbm + "' AND GRANTEE = '" + rolename + "' and TYPE = 'TABLE'";
                OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
                OracleDataReader dr7 = cmd7.ExecuteReader();
                DataTable dt7 = new DataTable();
                dt7.Load(dr7);
                dataGridView7.DataSource = dt7;

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView8.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label17.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                label15.Text = row.Cells[0].Value.ToString();
                label21.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(label17.Text != "---")
            {
                Form9 f9 = new Form9();
                f9.connectionString = connectionString;
                f9.name = rolename;
                f9.dbm = dbm;
                f9.permiss = comboBox1.Text;
                f9.tbname = label17.Text;
                f9.Show();
            }
                      
        }
    }
}
