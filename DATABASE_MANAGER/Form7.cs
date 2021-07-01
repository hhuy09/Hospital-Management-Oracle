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
            dt4.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
            dataGridView4.DataSource = dt4;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoResizeColumns();

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

            string sqlselect8 = "select TABLE_NAME from all_tables where OWNER = '" + dbm + "'";
            OracleCommand cmd8 = new OracleCommand(sqlselect8, con);
            OracleDataReader dr8 = cmd8.ExecuteReader();
            DataTable dt8 = new DataTable();
            dt8.Load(dr8);
            dt8.Columns.Add(new DataColumn("SELECT", typeof(bool)));
            dt8.Columns.Add(new DataColumn("INSERT", typeof(bool)));
            dt8.Columns.Add(new DataColumn("UPDATE", typeof(bool)));
            dt8.Columns.Add(new DataColumn("DELETE", typeof(bool)));
            dataGridView8.DataSource = dt8;
            dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView8.AutoResizeColumns();

            string sqlselect7 = "SELECT TABLE_NAME, PRIVILEGE, GRANTABLE FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "' AND OWNER = '" + dbm + "' AND COLUMN_NAME IS NULL";
            OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
            OracleDataReader dr7 = cmd7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Load(dr7);
            dt7.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
            dataGridView7.DataSource = dt7;
            dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView7.AutoResizeColumns();

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("PRIVILEGE");

            dt3.Rows.Add("ADMINISTER ANY SQL TUNING SET");
            dt3.Rows.Add("ADMINISTER DATABASE TRIGGER");
            dt3.Rows.Add("ADMINISTER KEY MANAGEMENT");
            dt3.Rows.Add("ADMINISTER RESOURCE MANAGER");
            dt3.Rows.Add("ADMINISTER SQL MANAGEMENT OBJECT");
            dt3.Rows.Add("ADMINISTER SQL TUNING SET");
            dt3.Rows.Add("ADVISOR");
            dt3.Rows.Add("ALTER ANY ANALYTIC VIEW");
            dt3.Rows.Add("ALTER ANY ASSEMBLY");
            dt3.Rows.Add("ALTER ANY ATTRIBUTE DIMENSION");
            dt3.Rows.Add("ALTER ANY CLUSTER");
            dt3.Rows.Add("ALTER ANY CUBE");
            dt3.Rows.Add("ALTER ANY CUBE BUILD PROCESS");
            dt3.Rows.Add("ALTER ANY CUBE DIMENSION");
            dt3.Rows.Add("ALTER ANY DIMENSION");
            dt3.Rows.Add("ALTER ANY EDITION");
            dt3.Rows.Add("ALTER ANY EVALUATION CONTEXT");
            dt3.Rows.Add("ALTER ANY HIERARCHY");
            dt3.Rows.Add("ALTER ANY INDEX");
            dt3.Rows.Add("ALTER ANY INDEXTYPE");
            dt3.Rows.Add("ALTER ANY LIBRARY");
            dt3.Rows.Add("ALTER ANY MATERIALIZED VIEW");
            dt3.Rows.Add("ALTER ANY MEASURE FOLDER");
            dt3.Rows.Add("ALTER ANY MINING MODEL");
            dt3.Rows.Add("ALTER ANY OPERATOR");
            dt3.Rows.Add("ALTER ANY OUTLINE");
            dt3.Rows.Add("ALTER ANY PROCEDURE");
            dt3.Rows.Add("ALTER ANY ROLE");
            dt3.Rows.Add("ALTER ANY RULE");
            dt3.Rows.Add("ALTER ANY RULE SET");
            dt3.Rows.Add("ALTER ANY SEQUENCE");
            dt3.Rows.Add("ALTER ANY SQL PROFILE");
            dt3.Rows.Add("ALTER ANY SQL TRANSLATION PROFILE");
            dt3.Rows.Add("ALTER ANY TABLE");
            dt3.Rows.Add("ALTER ANY TRIGGER");
            dt3.Rows.Add("ALTER ANY TYPE");
            dt3.Rows.Add("ALTER DATABASE");
            dt3.Rows.Add("ALTER DATABASE LINK");
            dt3.Rows.Add("ALTER LOCKDOWN PROFILE");
            dt3.Rows.Add("ALTER PROFILE");
            dt3.Rows.Add("ALTER PUBLIC DATABASE LINK");
            dt3.Rows.Add("ALTER RESOURCE COST");
            dt3.Rows.Add("ALTER ROLLBACK SEGMENT");
            dt3.Rows.Add("ALTER SESSION");
            dt3.Rows.Add("ALTER SYSTEM");
            dt3.Rows.Add("ALTER TABLESPACE");
            dt3.Rows.Add("ALTER USER");
            dt3.Rows.Add("ANALYZE ANY");
            dt3.Rows.Add("ANALYZE ANY DICTIONARY");
            dt3.Rows.Add("AUDIT ANY");
            dt3.Rows.Add("AUDIT SYSTEM");
            dt3.Rows.Add("BACKUP ANY TABLE");
            dt3.Rows.Add("BECOME USER");
            dt3.Rows.Add("CHANGE NOTIFICATION");
            dt3.Rows.Add("COMMENT ANY MINING MODEL");
            dt3.Rows.Add("COMMENT ANY TABLE");
            dt3.Rows.Add("CREATE ANALYTIC VIEW");
            dt3.Rows.Add("CREATE ANY ANALYTIC VIEW");
            dt3.Rows.Add("CREATE ANY ASSEMBLY");
            dt3.Rows.Add("CREATE ANY ATTRIBUTE DIMENSION");
            dt3.Rows.Add("CREATE ANY CLUSTER");
            dt3.Rows.Add("CREATE ANY CONTEXT");
            dt3.Rows.Add("CREATE ANY CREDENTIAL");
            dt3.Rows.Add("CREATE ANY CUBE");
            dt3.Rows.Add("CREATE ANY CUBE BUILD PROCESS");
            dt3.Rows.Add("CREATE ANY CUBE DIMENSION");
            dt3.Rows.Add("CREATE ANY DIMENSION");
            dt3.Rows.Add("CREATE ANY DIRECTORY");
            dt3.Rows.Add("CREATE ANY EDITION");
            dt3.Rows.Add("CREATE ANY EVALUATION CONTEXT");
            dt3.Rows.Add("CREATE ANY HIERARCHY");
            dt3.Rows.Add("CREATE ANY INDEX");
            dt3.Rows.Add("CREATE ANY INDEXTYPE");
            dt3.Rows.Add("CREATE ANY JOB");
            dt3.Rows.Add("CREATE ANY LIBRARY");
            dt3.Rows.Add("CREATE ANY MATERIALIZED VIEW");
            dt3.Rows.Add("CREATE ANY MEASURE FOLDER");
            dt3.Rows.Add("CREATE ANY MINING MODEL");
            dt3.Rows.Add("CREATE ANY OPERATOR");
            dt3.Rows.Add("CREATE ANY OUTLINE");
            dt3.Rows.Add("CREATE ANY PROCEDURE");
            dt3.Rows.Add("CREATE ANY RULE");
            dt3.Rows.Add("CREATE ANY RULE SET");
            dt3.Rows.Add("CREATE ANY SEQUENCE");
            dt3.Rows.Add("CREATE ANY SQL PROFILE");
            dt3.Rows.Add("CREATE ANY SQL TRANSLATION PROFILE");
            dt3.Rows.Add("CREATE ANY SYNONYM");
            dt3.Rows.Add("CREATE ANY TABLE");
            dt3.Rows.Add("CREATE ANY TRIGGER");
            dt3.Rows.Add("CREATE ANY TYPE");
            dt3.Rows.Add("CREATE ANY VIEW");
            dt3.Rows.Add("CREATE ASSEMBLY");
            dt3.Rows.Add("CREATE ATTRIBUTE DIMENSION");
            dt3.Rows.Add("CREATE CLUSTER");
            dt3.Rows.Add("CREATE CREDENTIAL");
            dt3.Rows.Add("CREATE CUBE");
            dt3.Rows.Add("CREATE CUBE BUILD PROCESS");
            dt3.Rows.Add("CREATE CUBE DIMENSION");
            dt3.Rows.Add("CREATE DATABASE LINK");
            dt3.Rows.Add("CREATE DIMENSION");
            dt3.Rows.Add("CREATE EVALUATION CONTEXT");
            dt3.Rows.Add("CREATE EXTERNAL JOB");
            dt3.Rows.Add("CREATE HIERARCHY");
            dt3.Rows.Add("CREATE INDEXTYPE");
            dt3.Rows.Add("CREATE JOB");
            dt3.Rows.Add("CREATE LIBRARY");
            dt3.Rows.Add("CREATE LOCKDOWN PROFILE");
            dt3.Rows.Add("CREATE MATERIALIZED VIEW");
            dt3.Rows.Add("CREATE MEASURE FOLDER");
            dt3.Rows.Add("CREATE MINING MODEL");
            dt3.Rows.Add("CREATE OPERATOR");
            dt3.Rows.Add("CREATE PLUGGABLE DATABASE");
            dt3.Rows.Add("CREATE PROCEDURE");
            dt3.Rows.Add("CREATE PROFILE");
            dt3.Rows.Add("CREATE PUBLIC DATABASE LINK");
            dt3.Rows.Add("CREATE PUBLIC SYNONYM");
            dt3.Rows.Add("CREATE ROLE");
            dt3.Rows.Add("CREATE ROLLBACK SEGMENT");
            dt3.Rows.Add("CREATE RULE");
            dt3.Rows.Add("CREATE RULE SET");
            dt3.Rows.Add("CREATE SEQUENCE");
            dt3.Rows.Add("CREATE SESSION");
            dt3.Rows.Add("CREATE SQL TRANSLATION PROFILE");
            dt3.Rows.Add("CREATE SYNONYM");
            dt3.Rows.Add("CREATE TABLE");
            dt3.Rows.Add("CREATE TABLESPACE");
            dt3.Rows.Add("CREATE TRIGGER");
            dt3.Rows.Add("CREATE TYPE");
            dt3.Rows.Add("CREATE USER");
            dt3.Rows.Add("CREATE VIEW");
            dt3.Rows.Add("DEBUG ANY PROCEDURE");
            dt3.Rows.Add("DEBUG CONNECT ANY");
            dt3.Rows.Add("DEBUG CONNECT SESSION");
            dt3.Rows.Add("DELETE ANY CUBE DIMENSION");
            dt3.Rows.Add("DELETE ANY MEASURE FOLDER");
            dt3.Rows.Add("DELETE ANY TABLE");
            dt3.Rows.Add("DEQUEUE ANY QUEUE");
            dt3.Rows.Add("DROP ANY ANALYTIC VIEW");
            dt3.Rows.Add("DROP ANY ASSEMBLY");
            dt3.Rows.Add("DROP ANY ATTRIBUTE DIMENSION");
            dt3.Rows.Add("DROP ANY CLUSTER");
            dt3.Rows.Add("DROP ANY CONTEXT");
            dt3.Rows.Add("DROP ANY CUBE");
            dt3.Rows.Add("DROP ANY CUBE BUILD PROCESS");
            dt3.Rows.Add("DROP ANY CUBE DIMENSION");
            dt3.Rows.Add("DROP ANY DIMENSION");
            dt3.Rows.Add("DROP ANY DIRECTORY");
            dt3.Rows.Add("DROP ANY EDITION");
            dt3.Rows.Add("DROP ANY EVALUATION CONTEXT");
            dt3.Rows.Add("DROP ANY HIERARCHY");
            dt3.Rows.Add("DROP ANY INDEX");
            dt3.Rows.Add("DROP ANY INDEXTYPE");
            dt3.Rows.Add("DROP ANY LIBRARY");
            dt3.Rows.Add("DROP ANY MATERIALIZED VIEW");
            dt3.Rows.Add("DROP ANY MEASURE FOLDER");
            dt3.Rows.Add("DROP ANY MINING MODEL");
            dt3.Rows.Add("DROP ANY OPERATOR");
            dt3.Rows.Add("DROP ANY OUTLINE");
            dt3.Rows.Add("DROP ANY PROCEDURE");
            dt3.Rows.Add("DROP ANY ROLE");
            dt3.Rows.Add("DROP ANY RULE");
            dt3.Rows.Add("DROP ANY RULE SET");
            dt3.Rows.Add("DROP ANY SEQUENCE");
            dt3.Rows.Add("DROP ANY SQL PROFILE");
            dt3.Rows.Add("DROP ANY SQL TRANSLATION PROFILE");
            dt3.Rows.Add("DROP ANY SYNONYM");
            dt3.Rows.Add("DROP ANY TABLE");
            dt3.Rows.Add("DROP ANY TRIGGER");
            dt3.Rows.Add("DROP ANY TYPE");
            dt3.Rows.Add("DROP ANY VIEW");
            dt3.Rows.Add("DROP LOCKDOWN PROFILE");
            dt3.Rows.Add("DROP PROFILE");
            dt3.Rows.Add("DROP PUBLIC DATABASE LINK");
            dt3.Rows.Add("DROP PUBLIC SYNONYM");
            dt3.Rows.Add("DROP ROLLBACK SEGMENT");
            dt3.Rows.Add("DROP TABLESPACE");
            dt3.Rows.Add("DROP USER");
            dt3.Rows.Add("EM EXPRESS CONNECT");
            dt3.Rows.Add("ENQUEUE ANY QUEUE");
            dt3.Rows.Add("EXECUTE ANY ASSEMBLY");
            dt3.Rows.Add("EXECUTE ANY CLASS");
            dt3.Rows.Add("EXECUTE ANY EVALUATION CONTEXT");
            dt3.Rows.Add("EXECUTE ANY INDEXTYPE");
            dt3.Rows.Add("EXECUTE ANY LIBRARY");
            dt3.Rows.Add("EXECUTE ANY OPERATOR");
            dt3.Rows.Add("EXECUTE ANY PROCEDURE");
            dt3.Rows.Add("EXECUTE ANY PROGRAM");
            dt3.Rows.Add("EXECUTE ANY RULE");
            dt3.Rows.Add("EXECUTE ANY RULE SET");
            dt3.Rows.Add("EXECUTE ANY TYPE");
            dt3.Rows.Add("EXECUTE ASSEMBLY");
            dt3.Rows.Add("EXEMPT ACCESS POLICY");
            dt3.Rows.Add("EXEMPT IDENTITY POLICY");
            dt3.Rows.Add("EXEMPT REDACTION POLICY");
            dt3.Rows.Add("EXPORT FULL DATABASE");
            dt3.Rows.Add("FLASHBACK ANY TABLE");
            dt3.Rows.Add("FLASHBACK ARCHIVE ADMINISTER");
            dt3.Rows.Add("FORCE ANY TRANSACTION");
            dt3.Rows.Add("FORCE TRANSACTION");
            dt3.Rows.Add("GLOBAL QUERY REWRITE");
            dt3.Rows.Add("GRANT ANY OBJECT PRIVILEGE");
            dt3.Rows.Add("GRANT ANY PRIVILEGE");
            dt3.Rows.Add("GRANT ANY ROLE");
            dt3.Rows.Add("IMPORT FULL DATABASE");
            dt3.Rows.Add("INHERIT ANY PRIVILEGES");
            dt3.Rows.Add("INHERIT ANY REMOTE PRIVILEGES");
            dt3.Rows.Add("INSERT ANY CUBE DIMENSION");
            dt3.Rows.Add("INSERT ANY MEASURE FOLDER");
            dt3.Rows.Add("INSERT ANY TABLE");
            dt3.Rows.Add("KEEP DATE TIME");
            dt3.Rows.Add("KEEP SYSGUID");
            dt3.Rows.Add("LOCK ANY TABLE");
            dt3.Rows.Add("LOGMINING");
            dt3.Rows.Add("MANAGE ANY FILE GROUP");
            dt3.Rows.Add("MANAGE ANY QUEUE");
            dt3.Rows.Add("MANAGE FILE GROUP");
            dt3.Rows.Add("MANAGE SCHEDULER");
            dt3.Rows.Add("MANAGE TABLESPACE");
            dt3.Rows.Add("MERGE ANY VIEW");
            dt3.Rows.Add("ON COMMIT REFRESH");
            dt3.Rows.Add("PURGE DBA_RECYCLEBIN");
            dt3.Rows.Add("QUERY REWRITE");
            dt3.Rows.Add("READ ANY ANALYTIC VIEW CACHE");
            dt3.Rows.Add("READ ANY FILE GROUP");
            dt3.Rows.Add("READ ANY TABLE");
            dt3.Rows.Add("REDEFINE ANY TABLE");
            dt3.Rows.Add("RESTRICTED SESSION");
            dt3.Rows.Add("RESUMABLE");
            dt3.Rows.Add("SELECT ANY CUBE");
            dt3.Rows.Add("SELECT ANY CUBE BUILD PROCESS");
            dt3.Rows.Add("SELECT ANY CUBE DIMENSION");
            dt3.Rows.Add("SELECT ANY DICTIONARY");
            dt3.Rows.Add("SELECT ANY MEASURE FOLDER");
            dt3.Rows.Add("SELECT ANY MINING MODEL");
            dt3.Rows.Add("SELECT ANY SEQUENCE");
            dt3.Rows.Add("SELECT ANY TABLE");
            dt3.Rows.Add("SELECT ANY TRANSACTION");
            dt3.Rows.Add("SET CONTAINER");
            dt3.Rows.Add("SYSBACKUP");
            dt3.Rows.Add("SYSDBA");
            dt3.Rows.Add("SYSDG");
            dt3.Rows.Add("SYSKM");
            dt3.Rows.Add("SYSOPER");
            dt3.Rows.Add("SYSRAC");
            dt3.Rows.Add("TEXT DATASTORE ACCESS");
            dt3.Rows.Add("TRANSLATE ANY SQL");
            dt3.Rows.Add("UNDER ANY TABLE");
            dt3.Rows.Add("UNDER ANY TYPE");
            dt3.Rows.Add("UNDER ANY VIEW");
            dt3.Rows.Add("UNLIMITED TABLESPACE");
            dt3.Rows.Add("UPDATE ANY CUBE");
            dt3.Rows.Add("UPDATE ANY CUBE BUILD PROCESS");
            dt3.Rows.Add("UPDATE ANY CUBE DIMENSION");
            dt3.Rows.Add("UPDATE ANY TABLE");
            dt3.Rows.Add("USE ANY JOB RESOURCE");
            dt3.Rows.Add("USE ANY SQL TRANSLATION PROFILE");
            dt3.Columns.Add(new DataColumn("GRANTED", typeof(bool)));
            dt3.Columns.Add(new DataColumn("ADMIN", typeof(bool)));
            dataGridView3.DataSource = dt3;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoResizeColumns();
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
            //if (e.RowIndex >= 0)
            //{
            //    //Lưu lại dòng dữ liệu vừa kích chọn
            //    DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            //    //Đưa dữ liệu vào textbox
            //    label11.Text = row.Cells[0].Value.ToString();
            //}
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    //Lưu lại dòng dữ liệu vừa kích chọn
            //    DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
            //    //Đưa dữ liệu vào textbox
            //    label9.Text = row.Cells[0].Value.ToString();
            //}
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
                        catch (Exception)
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
            int row = dataGridView3.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string privs = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    string granted = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    string admin = dataGridView3.Rows[i].Cells[2].Value.ToString();

                    string sqlgrant = null;
                    if (admin == "True")
                    {
                        sqlgrant = "GRANT " + privs + " TO " + rolename + " WITH ADMIN OPTION";
                    }
                    else if ((admin == "False" || admin == "") && granted == "True")
                    {
                        string sqlrevoke = "REVOKE " + privs + " FROM " + rolename;
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlrevoke, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(error.Message);
                        }

                        sqlgrant = "GRANT " + privs + " TO " + rolename;
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

                string sqlselect4 = "select PRIVILEGE, ADMIN_OPTION from ROLE_SYS_PRIVS where ROLE = '" + rolename + "'";
                OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dt4.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView4.DataSource = dt4;
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.AutoResizeColumns();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = dataGridView4.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string privs = dataGridView4.Rows[i].Cells[0].Value.ToString();
                    string revoke = dataGridView4.Rows[i].Cells[2].Value.ToString();

                    string sqlrevoke = null;
                    if (revoke == "True")
                    {
                        sqlrevoke = "REVOKE " + privs + " FROM " + rolename;
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

                string sqlselect4 = "select PRIVILEGE, ADMIN_OPTION from ROLE_SYS_PRIVS where ROLE = '" + rolename + "'";
                OracleCommand cmd4 = new OracleCommand(sqlselect4, con);
                OracleDataReader dr4 = cmd4.ExecuteReader();
                DataTable dt4 = new DataTable();
                dt4.Load(dr4);
                dt4.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView4.DataSource = dt4;
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.AutoResizeColumns();
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
                        catch (Exception)
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


        private void button8_Click_1(object sender, EventArgs e)
        {
            int row = dataGridView8.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string table = dataGridView8.Rows[i].Cells[0].Value.ToString();
                    string select = dataGridView8.Rows[i].Cells[1].Value.ToString();
                    string insert = dataGridView8.Rows[i].Cells[2].Value.ToString();
                    string update = dataGridView8.Rows[i].Cells[3].Value.ToString();
                    string delete = dataGridView8.Rows[i].Cells[4].Value.ToString();

                    string sqlgrantselect = null;
                    string sqlgrantinsert = null;
                    string sqlgrantupdate = null;
                    string sqlgrantdelete = null;

                    if (select == "True")
                    {
                        sqlgrantselect = "GRANT SELECT ON " + table + " TO " + rolename;
                    }

                    if (insert == "True")
                    {
                        sqlgrantinsert = "GRANT INSERT ON " + table + " TO " + rolename;
                    }

                    if (update == "True")
                    {
                        sqlgrantupdate = "GRANT UPDATE ON " + table + " TO " + rolename;
                    }

                    if (delete == "True")
                    {
                        sqlgrantdelete = "GRANT DELETE ON " + table + " TO " + rolename;
                    }

                    if (checkBox3.Checked)
                    {
                        if (sqlgrantselect != null)
                        {
                            sqlgrantselect += " WITH GRANT OPTION";
                        }

                        if (sqlgrantinsert != null)
                        {
                            sqlgrantinsert += " WITH GRANT OPTION";
                        }

                        if (sqlgrantupdate != null)
                        {
                            sqlgrantupdate += " WITH GRANT OPTION";
                        }

                        if (sqlgrantdelete != null)
                        {
                            sqlgrantdelete += " WITH GRANT OPTION";
                        }
                    }

                    if (sqlgrantselect != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrantselect, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }

                    if (sqlgrantinsert != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrantinsert, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }

                    if (sqlgrantupdate != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrantupdate, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }

                    if (sqlgrantdelete != null)
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sqlgrantdelete, con);
                            OracleDataReader dr = cmd.ExecuteReader();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }

                string sqlselect7 = "SELECT TABLE_NAME, PRIVILEGE, GRANTABLE FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "' AND OWNER = '" + dbm + "'";
                OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
                OracleDataReader dr7 = cmd7.ExecuteReader();
                DataTable dt7 = new DataTable();
                dt7.Load(dr7);
                dt7.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView7.DataSource = dt7;
                dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView7.AutoResizeColumns();
            }

            checkBox3.Checked = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int row = dataGridView7.Rows.Count - 1;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string table = dataGridView7.Rows[i].Cells[0].Value.ToString();
                    string privs = dataGridView7.Rows[i].Cells[1].Value.ToString();
                    string revoke = dataGridView7.Rows[i].Cells[3].Value.ToString();

                    string sqlrevoke = null;

                    if (revoke == "True")
                    {
                        sqlrevoke = "REVOKE " + privs + " ON " + table + " FROM " + rolename;
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

                string sqlselect7 = "SELECT TABLE_NAME, PRIVILEGE, GRANTABLE FROM ROLE_TAB_PRIVS WHERE ROLE = '" + rolename + "' AND OWNER = '" + dbm + "'";
                OracleCommand cmd7 = new OracleCommand(sqlselect7, con);
                OracleDataReader dr7 = cmd7.ExecuteReader();
                DataTable dt7 = new DataTable();
                dt7.Load(dr7);
                dt7.Columns.Add(new DataColumn("REVOKE", typeof(bool)));
                dataGridView7.DataSource = dt7;
                dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView7.AutoResizeColumns();

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string table = label11.Text;
            int start = table.IndexOf(".") + 1;
            int end = table.Length - start;
            table = table.Substring(start, end);
            if (label11.Text != "Column Permission on DBO...")
            {
                Form9 f9 = new Form9();
                f9.connectionString = connectionString;
                f9.name = rolename;
                f9.dbm = dbm;
                f9.type = "roletype";
                f9.tbname = table;
                f9.Show();
            }
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView8.Rows[e.RowIndex];
                string table = row.Cells[0].Value.ToString();
                label11.Text = "Column Permission on DBO." + table;
            }
        }
    }
}
