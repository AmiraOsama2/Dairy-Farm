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
namespace DairyFarmManagmentSystem
{

    public partial class Cows : Form
    {

        public Cows()
        {
            InitializeComponent();
            populate();
        }
        OracleConnection conn = new OracleConnection("DATA SOURCE=Yousef-MSI:1521/XE;TNS_ADMIN=C:\\Users\\NV\\Oracle\\network\\admin;USER ID=DAIRYFARMDB;PASSWORD=mohsen123");


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
        private void populate()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM COWS_TBL";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder();
                var ds = new DataSet();
                oda.Fill(ds);
                CowsListDGV.DataSource = ds.Tables[0];
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
            EarTagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            AgeTb.Text = "";
            WeightAtBirthTb.Text = "";
            key = 0;
        }
        int age = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" ||
                WeightAtBirthTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO COWS_TBL (COW_NAME, EAR_TAG, COLOR, BREED, AGE, WIEGHT_AT_BIRTH) " +
                                   "VALUES (:COW_NAME, :EAR_TAG, :COLOR, :BREED, :AGE, :WIEGHT_AT_BIRTH)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":EAR_TAG", OracleDbType.Varchar2, 50).Value = EarTagTb.Text;
                    cmd.Parameters.Add(":COLOR", OracleDbType.Varchar2, 50).Value = ColorTb.Text;
                    cmd.Parameters.Add(":BREED", OracleDbType.Varchar2, 50).Value = BreedTb.Text;
                    cmd.Parameters.Add(":AGE", OracleDbType.Int32).Value = age;
                    cmd.Parameters.Add(":WIEGHT_AT_BIRTH", OracleDbType.Int32).Value = Convert.ToInt32(WeightAtBirthTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cow Saved Successfully");
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

        private void DobDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Today; // Use DateTime.Today instead of DateTime.Now
            int days = (int)(DateTime.Today - DobDate.Value.Date).TotalDays; // Calculate days using TotalDays property

            // Calculate age in years (assuming DobDate is a DateTimePicker)
            age = (int)(days / 365.25); // Consider leap years

        }

        private void DobDate_MouseLeave(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Today; // Use DateTime.Today instead of DateTime.Now
            int days = (int)(DateTime.Today - DobDate.Value.Date).TotalDays; // Calculate days using TotalDays property

            // Calculate age in years (assuming DobDate is a DateTimePicker)
            age = (int)(days / 365.25); // Consider leap years
            AgeTb.Text = "" + age;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        int key = 0;
        private void CowsListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowNameTb.Text = CowsListDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTb.Text = CowsListDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowsListDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text = CowsListDGV.SelectedRows[0].Cells[4].Value.ToString();
            WeightAtBirthTb.Text = CowsListDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;
                age = 0;
            }
            else
            {
                key = Convert.ToInt32(CowsListDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowsListDGV.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Cow to Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM COWS_TBL WHERE COW_ID = :CowID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":CowID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cow Deleted Successfully");
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" ||
                WeightAtBirthTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE COWS_TBL " +
                                   "SET COW_NAME = :COW_NAME, EAR_TAG = :EAR_TAG, COLOR = :COLOR, " +
                                   "    BREED = :BREED, AGE = :AGE, WIEGHT_AT_BIRTH = :WIEGHT_AT_BIRTH " +
                                   "WHERE COW_ID = " + key;

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":EAR_TAG", OracleDbType.Varchar2, 50).Value = EarTagTb.Text;
                    cmd.Parameters.Add(":COLOR", OracleDbType.Varchar2, 50).Value = ColorTb.Text;
                    cmd.Parameters.Add(":BREED", OracleDbType.Varchar2, 50).Value = BreedTb.Text;
                    cmd.Parameters.Add(":AGE", OracleDbType.Int32).Value = Convert.ToInt32(AgeTb.Text);
                    cmd.Parameters.Add(":WIEGHT_AT_BIRTH", OracleDbType.Int32).Value = Convert.ToInt32(WeightAtBirthTb.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cow Updated Successfully");
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

        private void ExaminationLb_Click(object sender, EventArgs e)
        {
            CowHealth cowHealth = new CowHealth();
            cowHealth.Show();
            this.Hide();
        }
    }
}
