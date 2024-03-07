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
    public partial class CowHealth : Form
    {
        public CowHealth()
        {
            InitializeComponent();
            CowIdCbFill();
            SetVetName();
            populate();

        }
        OracleConnection conn = new OracleConnection("DATA SOURCE=Yousef-MSI:1521/XE;TNS_ADMIN=C:\\Users\\NV\\Oracle\\network\\admin;USER ID=DAIRYFARMDB;PASSWORD=mohsen123");


        private void CowsLb_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void ProductionLb_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void BreedingLb_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void SalesLb_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void FinanceLb_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        private void DashboardLb_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
        private void CowIdCbFill()
        {
            try
            {
                conn.Open();
                string query = "SELECT COW_ID FROM COWS_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader Odr;
                Odr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("COW_ID", typeof(int));
                dt.Load(Odr);
                CowIdCb.ValueMember = "COW_ID";
                CowIdCb.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void populate()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM EXAMINATION_RECORD";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                CowHealthDGV.DataSource = ds.Tables[0];
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
            CowNameTb.Text = "";
            EventTb.Text = "";
            DaignosisTb.Text = "";
            TreatmentTb.Text = "";
            CostOfTreatmentTb.Text = "";
            key = 0;
        }
        private void GetCowName()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM COWS_TBL WHERE COW_ID = " + CowIdCb.SelectedValue.ToString() + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                DataTable dt = new DataTable();
                OracleDataAdapter Oda = new OracleDataAdapter(cmd);
                Oda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    CowNameTb.Text = dr["COW_NAME"].ToString();
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
        private void SetVetName()
        {
            try
            {
                conn.Open();
                string query = "SELECT VET_NAME FROM DOCTORS_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader Odr;
                Odr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("VET_NAME", typeof(string)); // Corrected data type to string
                dt.Load(Odr);
                VetNameCb.ValueMember = "VET_NAME";
                VetNameCb.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || DaignosisTb.Text == "" || TreatmentTb.Text == "" ||
                CostOfTreatmentTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO EXAMINATION_RECORD (COW_ID, COW_NAME, REP_DATE, EVENT, DAIGNOSIS, TREATMENT, COST, VET_NAME) " +
                                   "VALUES (:COW_ID, :COW_NAME, :REP_DATE, :EVENT, :DAIGNOSIS, :TREATMENT, :COST, :VET_NAME)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_ID", OracleDbType.Int32).Value = Convert.ToInt32(CowIdCb.SelectedValue);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":REP_DATE", OracleDbType.Date).Value = DateDTP.Value.Date; // Assuming REP_DATE is a date field
                    cmd.Parameters.Add(":EVENT", OracleDbType.Varchar2, 50).Value = EventTb.Text;
                    cmd.Parameters.Add(":DAIGNOSIS", OracleDbType.Varchar2, 50).Value = DaignosisTb.Text;
                    cmd.Parameters.Add(":TREATMENT", OracleDbType.Varchar2, 50).Value = TreatmentTb.Text;
                    cmd.Parameters.Add(":COST", OracleDbType.Int32).Value = Convert.ToInt32(CostOfTreatmentTb.Text);
                    cmd.Parameters.Add(":VET_NAME", OracleDbType.Varchar2, 50).Value = VetNameCb.SelectedValue;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Health Record Saved Successfully");
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


        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        int key = 0;
        private void CowHealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = CowHealthDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = CowHealthDGV.SelectedRows[0].Cells[2].Value.ToString();
            DateDTP.Text = CowHealthDGV.SelectedRows[0].Cells[3].Value.ToString();
            EventTb.Text = CowHealthDGV.SelectedRows[0].Cells[4].Value.ToString();
            DaignosisTb.Text = CowHealthDGV.SelectedRows[0].Cells[5].Value.ToString();
            TreatmentTb.Text = CowHealthDGV.SelectedRows[0].Cells[6].Value.ToString();
            CostOfTreatmentTb.Text = CowHealthDGV.SelectedRows[0].Cells[7].Value.ToString();
            VetNameCb.SelectedValue = CowHealthDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CowHealthDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Record to Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM EXAMINATION_RECORD WHERE REP_ID = :REP_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":REP_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Deleted Successfully");
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
                MessageBox.Show("Select A Record to Edit");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE EXAMINATION_RECORD " +
                                   "SET COW_ID = :COW_ID, COW_NAME = :COW_NAME, " +
                                   "    REP_DATE = :REP_DATE, EVENT = :EVENT, " +
                                   "    DAIGNOSIS = :DAIGNOSIS, TREATMENT = :TREATMENT, " +
                                   "    COST = :COST, VET_NAME = :VET_NAME " +
                                   "WHERE REP_ID = :REP_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_ID", OracleDbType.Int32).Value = Convert.ToInt32(CowIdCb.SelectedValue);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":REP_DATE", OracleDbType.Date).Value = DateDTP.Value.Date;
                    cmd.Parameters.Add(":EVENT", OracleDbType.Varchar2, 50).Value = EventTb.Text;
                    cmd.Parameters.Add(":DAIGNOSIS", OracleDbType.Varchar2, 50).Value = DaignosisTb.Text;
                    cmd.Parameters.Add(":TREATMENT", OracleDbType.Varchar2, 50).Value = TreatmentTb.Text;
                    cmd.Parameters.Add(":COST", OracleDbType.Int32).Value = Convert.ToInt32(CostOfTreatmentTb.Text);
                    cmd.Parameters.Add(":VET_NAME", OracleDbType.Varchar2, 50).Value = VetNameCb.SelectedValue;
                    cmd.Parameters.Add(":REP_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Updated Successfully");
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
