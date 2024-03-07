using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyFarmManagmentSystem
{
    public partial class Login : Form
    {
        OracleConnection conn = new OracleConnection("DATA SOURCE=Yousef-MSI:1521/XE;TNS_ADMIN=C:\\Users\\NV\\Oracle\\network\\admin;USER ID=DAIRYFARMDB;PASSWORD=mohsen123");

        public Login()
        {
            InitializeComponent();
        }

        private void ResetLbl_Click(object sender, EventArgs e)
        {
            UserNameTb.Text = "";
            PasswordTb.Text = ""; // Fixed the control name
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Role");
                return; // Added to exit the method if Role is not selected
            }

            if (string.IsNullOrWhiteSpace(UserNameTb.Text) || string.IsNullOrWhiteSpace(PasswordTb.Text))
            {
                MessageBox.Show("Enter User Name and Password");
                return; // Added to exit the method if UserName or Password is empty
            }

            try
            {
                conn.Open();

                string role = RoleCb.SelectedItem.ToString();

                if (role == "Admin")
                {
                    if (UserNameTb.Text == "Admin" && PasswordTb.Text == "Admin")
                    // Handle Admin login
                    {
                        Employees emp = new Employees();
                        emp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong User Name or Password");

                    }
                }
                else if (role == "Employee")
                {
                    // Handle Employee login
                    string query = "SELECT COUNT(*) FROM STAFF_TBL WHERE STAFF_NAME = :username AND STAFF_PASS = :password";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = UserNameTb.Text;
                    cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = PasswordTb.Text;

                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);

                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                    {
                        Cows cows = new Cows();
                        cows.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong User Name or Password");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Role");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
