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
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DairyFarmManagmentSystem
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }
        OracleConnection conn = new OracleConnection("DATA SOURCE=Yousef-MSI:1521/XE;TNS_ADMIN=C:\\Users\\NV\\Oracle\\network\\admin;USER ID=DAIRYFARMDB;PASSWORD=mohsen123");
        private void populate()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM EMP_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                EmploeesDGV.DataSource = ds.Tables[0];
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
        private void clear()
        {
            GenderCb.SelectedItem = -1;
            EmpNameTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";
            PassTb.Text = "";
            key = 0;

        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (GenderCb.SelectedIndex == -1 || EmpNameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || DOBDTP.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO EMP_TBL (EMP_NAME, EMP_DOB, GENDER, EMP_PHONE, EMP_ADDRESS,EMP_PASS) " +
                                   "VALUES (:EMP_NAME, :EMP_DOB, :GENDER, :EMP_PHONE, :EMP_ADDRESS,:EMP_PASS)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":EMP_NAME", OracleDbType.Varchar2, 50).Value = EmpNameTb.Text;
                    cmd.Parameters.Add(":EMP_DOB", OracleDbType.Date, 50).Value = DOBDTP.Value.Date;
                    cmd.Parameters.Add(":GENDER", OracleDbType.Varchar2, 10).Value = GenderCb.SelectedItem;
                    cmd.Parameters.Add(":EMP_PHONE", OracleDbType.Varchar2, 50).Value = PhoneTb.Text;
                    cmd.Parameters.Add(":EMP_ADDRESS", OracleDbType.Varchar2, 50).Value = AddressTb.Text;
                    cmd.Parameters.Add(":EMP_PASS", OracleDbType.Varchar2, 50).Value = PassTb.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Employee Saved Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    clear();
                    populate();
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        int key = 0;
        private void EmploeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmploeesDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOBDTP.Text = EmploeesDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.SelectedItem = EmploeesDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = EmploeesDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmploeesDGV.SelectedRows[0].Cells[5].Value.ToString();
            PassTb.Text = EmploeesDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmploeesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select An Employee to Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM EMP_TBL WHERE EMP_ID = :EMP_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":EMP_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Employee Deleted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    clear();
                    populate();
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (GenderCb.SelectedIndex == -1 || EmpNameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || DOBDTP.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE EMP_TBL " +
                                   "SET EMP_NAME = :EMP_NAME, EMP_DOB = :EMP_DOB, GENDER = :GENDER, " +
                                   "    EMP_PHONE = :EMP_PHONE, EMP_ADDRESS = :EMP_ADDRESS, EMP_PASS = :EMP_PASS " +
                                   "WHERE EMP_ID = " + key;

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":EMP_NAME", OracleDbType.Varchar2, 50).Value = EmpNameTb.Text;
                    cmd.Parameters.Add(":EMP_DOB", OracleDbType.Date).Value = DOBDTP.Value.Date;
                    cmd.Parameters.Add(":GENDER", OracleDbType.Varchar2, 10).Value = GenderCb.SelectedItem;
                    cmd.Parameters.Add(":EMP_PHONE", OracleDbType.Varchar2, 50).Value = PhoneTb.Text;
                    cmd.Parameters.Add(":EMP_ADDRESS", OracleDbType.Varchar2, 50).Value = AddressTb.Text;
                    cmd.Parameters.Add(":EMP_PASS", OracleDbType.Varchar2, 50).Value = PassTb.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Employee Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    clear();
                    populate();
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClientsLb_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Hide();
        }

        private void DoctorsLb_Click(object sender, EventArgs e)
        {
            Doctors doctors = new Doctors();
            doctors.Show();
            this.Hide();
        }
    }
}
