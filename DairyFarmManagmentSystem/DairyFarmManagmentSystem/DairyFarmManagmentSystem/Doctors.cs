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
    public partial class Doctors : Form
    {
        public Doctors()
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
                string query = "SELECT * FROM DOCTORS_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                VetDoctorDGV.DataSource = ds.Tables[0];
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
            VetNameTb.Text = "";
            VetPhoneTb.Text = "";
            VetAddressTb.Text = "";
            key = 0;

        }

        private void ClientsLb_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Hide();
        }

        private void EmpLb_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
            this.Hide();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (VetNameTb.Text == "" || VetPhoneTb.Text == "" || VetAddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO DOCTORS_TBL (VET_NAME, VET_PHONE, VET_ADDRESS) " +
                                   "VALUES (:VET_NAME, :VET_PHONE, :VET_ADDRESS)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":VET_NAME", OracleDbType.Varchar2, 50).Value = VetNameTb.Text;
                    cmd.Parameters.Add(":VET_PHONE", OracleDbType.Varchar2, 50).Value = VetPhoneTb.Text;
                    cmd.Parameters.Add(":VET_ADDRESS", OracleDbType.Varchar2, 10).Value = VetAddressTb.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vet Doctor Saved Successfully");
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Doctor to Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM DOCTORS_TBL WHERE DOCTOR_ID = :DOCTOR_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":DOCTOR_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Doctor Deleted Successfully");
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
            if (key == 0)
            {
                MessageBox.Show("Select A Doctor to Edit");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(VetNameTb.Text) || string.IsNullOrWhiteSpace(VetPhoneTb.Text) || string.IsNullOrWhiteSpace(VetAddressTb.Text))
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE DOCTORS_TBL " +
                                       "SET VET_NAME = :VET_NAME, VET_PHONE = :VET_PHONE, VET_ADDRESS = :VET_ADDRESS " +
                                       "WHERE DOCTOR_ID = " + key;

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(":VET_NAME", OracleDbType.Varchar2, 50).Value = VetNameTb.Text;
                            cmd.Parameters.Add(":VET_PHONE", OracleDbType.Varchar2, 50).Value = VetPhoneTb.Text;
                            cmd.Parameters.Add(":VET_ADDRESS", OracleDbType.Varchar2, 255).Value = VetAddressTb.Text;

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Doctor Updated Successfully");
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
        }

        int key = 0;
        private void VetDoctorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VetNameTb.Text = VetDoctorDGV.SelectedRows[0].Cells[1].Value.ToString();
            VetPhoneTb.Text = VetDoctorDGV.SelectedRows[0].Cells[2].Value.ToString();
            VetAddressTb.Text = VetDoctorDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (VetNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(VetDoctorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
