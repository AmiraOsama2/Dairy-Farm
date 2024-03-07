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

namespace DairyFarmManagmentSystem
{
    public partial class Finances : Form
    {
        public Finances()
        {
            InitializeComponent();
            populateExpDGV();
            populateIncDGV();
            EmpIdCbFill();
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

        private void Sales_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void DashboardLb_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
        private void EmpIdCbFill()
        {
            try
            {
                conn.Open();
                string query = "SELECT EMP_ID FROM EMP_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader Odr;
                Odr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("EMP_ID", typeof(int));
                dt.Load(Odr);
                EmpIdCb.ValueMember = "EMP_ID";
                EmpIdCb.DataSource = dt;
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
        private void populateExpDGV()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM EXPENDITURES_TBL";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                ExpenditureDGV.DataSource = ds.Tables[0];
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
        private void populateIncDGV()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM INCOME_TBL";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                IncomeDGV.DataSource = ds.Tables[0];
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
        private void ClearExp()
        {
            ExpAmountTb.Text = "";

        }
        private void IncClear()
        {
            IncomeTypeCb.SelectedIndex = -1;
            IncAmountTb.Text = "";
        }
        private void ExpSaveBtn_Click(object sender, EventArgs e)
        {
            if (ExpPurCb.SelectedIndex == -1 || ExpAmountTb.Text == "" || EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO EXPENDITURES_TBL (EXP_DATE, EXP_PURPOSE, EXP_AMOUNT, EMP_ID) " +
                                   "VALUES (:EXP_DATE, :EXP_PURPOSE, :EXP_AMOUNT, :EMP_ID)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":EXP_DATE", OracleDbType.Date).Value = ExpDTP.Value.Date;
                    cmd.Parameters.Add(":EXP_PURPOSE", OracleDbType.Varchar2, 50).Value = ExpPurCb.SelectedItem.ToString();
                    cmd.Parameters.Add(":EXP_AMOUNT", OracleDbType.Int32).Value = Convert.ToInt32(ExpAmountTb.Text);
                    cmd.Parameters.Add(":EMP_ID", OracleDbType.Int32).Value = Convert.ToInt32(EmpIdCb.SelectedValue);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Expenditures Record Saved Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    ClearExp();
                    populateExpDGV();
                }
            }
        }

        private void IncSaveBtn_Click(object sender, EventArgs e)
        {
            if (IncomeTypeCb.SelectedIndex == -1 || IncAmountTb.Text == "" || EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO INCOME_TBL (INC_DATE, INC_PURPOSE, INC_AMOUNT, EMP_ID) " +
                                   "VALUES (:INC_DATE, :INC_PURPOSE, :INC_AMOUNT, :EMP_ID)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":INC_DATE", OracleDbType.Date).Value = IncomeDTP.Value.Date;
                    cmd.Parameters.Add(":INC_PURPOSE", OracleDbType.Varchar2, 50).Value = IncomeTypeCb.SelectedItem.ToString();
                    cmd.Parameters.Add(":INC_AMOUNT", OracleDbType.Int32).Value = Convert.ToInt32(IncAmountTb.Text);
                    cmd.Parameters.Add(":EMP_ID", OracleDbType.Int32).Value = Convert.ToInt32(EmpIdCb.SelectedValue);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Income Record Saved Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    IncClear();
                    populateIncDGV();
                }
            }
        }

        private void IncFilterDTP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM INCOME_TBL WHERE INC_DATE = :INC_DATE";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":INC_DATE", OracleDbType.Date).Value = IncFilterDTP.Value.Date;
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                IncomeDGV.DataSource = ds.Tables[0];
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

        private void ExpFilterDTP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM EXPENDITURES_TBL WHERE EXP_DATE = :EXP_DATE";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":EXP_DATE", OracleDbType.Date).Value = ExpFilterDTP.Value.Date;
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                ExpenditureDGV.DataSource = ds.Tables[0];
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populateIncDGV();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            populateExpDGV();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
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
