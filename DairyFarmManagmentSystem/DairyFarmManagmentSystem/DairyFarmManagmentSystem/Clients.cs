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
    public partial class Clients : Form
    {
        public Clients()
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
                string query = "SELECT * FROM CLIENT_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                ClientsDGV.DataSource = ds.Tables[0];
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
            ClientNameTb.Text = "";
            ClientPhoneTb.Text = "";
            ClientAddressTb.Text = "";
            key = 0;

        }




        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ClientNameTb.Text == "" || ClientPhoneTb.Text == "" || ClientAddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO CLIENT_TBL (CLIENT_NAME, CLIENT_PHONE, CLIENT_ADDRESS) " +
                                   "VALUES (:CLIENT_NAME, :CLIENT_PHONE, :CLIENT_ADDRESS)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":CLIENT_NAME", OracleDbType.Varchar2, 50).Value = ClientNameTb.Text;
                    cmd.Parameters.Add(":CLIENT_PHONE", OracleDbType.Varchar2, 50).Value = ClientPhoneTb.Text;
                    cmd.Parameters.Add(":CLIENT_ADDRESS", OracleDbType.Varchar2, 10).Value = ClientAddressTb.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Client Saved Successfully");
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

        private void ClientsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmpLb_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
            this.Hide();
        }

        private void DocLb_Click(object sender, EventArgs e)
        {
            Doctors doctors = new Doctors();
            doctors.Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Client to Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM CLIENT_TBL WHERE CLIENT_ID = :CLIENT_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":CLIENT_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Client Deleted Successfully");
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
        int key = 0;
        private void ClientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientNameTb.Text = ClientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            ClientPhoneTb.Text = ClientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            ClientAddressTb.Text = ClientsDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (ClientNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ClientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClientNameTb.Text) || string.IsNullOrWhiteSpace(ClientPhoneTb.Text) || string.IsNullOrWhiteSpace(ClientAddressTb.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE CLIENT_TBL " +
                                   "SET CLIENT_NAME = :CLIENT_NAME, CLIENT_PHONE = :CLIENT_PHONE, CLIENT_ADDRESS = :CLIENT_ADDRESS " +
                                   "WHERE CLIENT_ID = " + key;

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":CLIENT_NAME", OracleDbType.Varchar2, 50).Value = ClientNameTb.Text;
                        cmd.Parameters.Add(":CLIENT_PHONE", OracleDbType.Varchar2, 50).Value = ClientPhoneTb.Text;
                        cmd.Parameters.Add(":CLIENT_ADDRESS", OracleDbType.Varchar2, 255).Value = ClientAddressTb.Text;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Client Updated Successfully");
                    }
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
    }
}
