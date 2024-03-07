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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DairyFarmManagmentSystem
{
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            CowIdCbFill();
            populate();
        }
        OracleConnection conn = new OracleConnection("DATA SOURCE=Yousef-MSI:1521/XE;TNS_ADMIN=C:\\Users\\NV\\Oracle\\network\\admin;USER ID=DAIRYFARMDB;PASSWORD=mohsen123");

        private void CowsLb_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
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
                string query = "SELECT * FROM MILK_PRODUCTION_TBL";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                DailyMilkDGV.DataSource = ds.Tables[0];
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
            AmMilkTb.Text = "";
            NoonMilkTb.Text = "";
            PmMilkTb.Text = "";
            TotalMilkTb.Text = "";
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



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AmMilkTb.Text == "" || NoonMilkTb.Text == "" || PmMilkTb.Text == "" ||
                TotalMilkTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO MILK_PRODUCTION_TBL (COW_ID, COW_NAME, AM_MILK, NOON_MILK, PM_MILK, TOTAL_MILK, DATE_OF_PROD) " +
                                   "VALUES (:COW_ID, :COW_NAME, :AM_MILK, :NOON_MILK, :PM_MILK, :TOTAL_MILK, :DATE_OF_PROD)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_ID", OracleDbType.Int32).Value = Convert.ToInt32(CowIdCb.SelectedValue);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":AM_MILK", OracleDbType.Varchar2, 50).Value = AmMilkTb.Text;
                    cmd.Parameters.Add(":NOON_MILK", OracleDbType.Varchar2, 50).Value = NoonMilkTb.Text;
                    cmd.Parameters.Add(":PM_MILK", OracleDbType.Varchar2, 50).Value = PmMilkTb.Text;
                    cmd.Parameters.Add(":TOTAL_MILK", OracleDbType.Varchar2, 50).Value = TotalMilkTb.Text;
                    cmd.Parameters.Add(":DATE_OF_PROD", OracleDbType.Date).Value = DateTime.Now; // Assuming DATE_OF_PROD is a date field

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Milk Production Saved Successfully");
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

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void AmMilkTb_TextChanged(object sender, EventArgs e)
        {
            TotalMilkTb.Text = AmMilkTb.Text;
            UpdateTotalMilk();
        }

        private void NoonMilkTb_TextChanged(object sender, EventArgs e)
        {
            TotalMilkTb.Text = NoonMilkTb.Text;
            UpdateTotalMilk();
        }

        private void PmMilkTb_TextChanged(object sender, EventArgs e)
        {
            TotalMilkTb.Text += PmMilkTb.Text;
            UpdateTotalMilk();
        }

        private void UpdateTotalMilk()
        {

            if (int.TryParse(AmMilkTb.Text, out int amMilk))
            {
                int totalMilk = amMilk;

                if (int.TryParse(NoonMilkTb.Text, out int noonMilk))
                {
                    totalMilk += noonMilk;
                }

                if (int.TryParse(PmMilkTb.Text, out int pmMilk))
                {
                    totalMilk += pmMilk;
                }

                TotalMilkTb.Text = totalMilk.ToString();
            }
            else
            {

                TotalMilkTb.Text = "0";
            }
        }
        int key;
        private void DailyMilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = DailyMilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = DailyMilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            AmMilkTb.Text = DailyMilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            NoonMilkTb.Text = DailyMilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmMilkTb.Text = DailyMilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalMilkTb.Text = DailyMilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateDTP.Text = DailyMilkDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DailyMilkDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Milk Production to Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM MILK_PRODUCTION_TBL WHERE M_ID = :M_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":M_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product Deleted Successfully");
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
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AmMilkTb.Text == "" || NoonMilkTb.Text == "" || PmMilkTb.Text == "" ||
                TotalMilkTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE MILK_PRODUCTION_TBL " +
                                   "SET COW_ID = :COW_ID, COW_NAME = :COW_NAME, AM_MILK = :AM_MILK, " +
                                   "    NOON_MILK = :NOON_MILK, PM_MILK = :PM_MILK, TOTAL_MILK = :TOTAL_MILK, " +
                                   "    DATE_OF_PROD = :DATE_OF_PROD " +
                                   "WHERE M_ID = " + key;

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_ID", OracleDbType.Int32).Value = CowIdCb.SelectedIndex;
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":AM_MLIK", OracleDbType.Int32).Value = AmMilkTb.Text;
                    cmd.Parameters.Add(":NOON_MILK", OracleDbType.Int32).Value = NoonMilkTb.Text;
                    cmd.Parameters.Add(":PM_MILK", OracleDbType.Int32).Value = PmMilkTb.Text;
                    cmd.Parameters.Add(":TOTAL_MILK", OracleDbType.Int32).Value = TotalMilkTb.Text;
                    cmd.Parameters.Add(":DATE_OF_PROD", OracleDbType.Date).Value = DateDTP.Value.Date;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product Updated Successfully");
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