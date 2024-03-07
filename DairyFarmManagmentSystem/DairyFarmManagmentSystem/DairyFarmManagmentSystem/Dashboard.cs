using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Finance();
            Logistic();
            GetMax();
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

        private void Finance()
        {
            // Finance related analytics
            try
            {
                conn.Open();

                // Query for Income
                string incQuery = "SELECT SUM(INC_AMOUNT) FROM INCOME_TBL";
                OracleCommand incCmd = new OracleCommand(incQuery, conn);
                OracleDataAdapter incOda = new OracleDataAdapter(incCmd);

                // Query for Expenditures
                string expQuery = "SELECT SUM(EXP_AMOUNT) FROM EXPENDITURES_TBL";
                OracleCommand expCmd = new OracleCommand(expQuery, conn);
                OracleDataAdapter expOda = new OracleDataAdapter(expCmd);

                // Create DataTables to hold the results
                DataTable incDt = new DataTable();
                DataTable expDt = new DataTable();

                // Fill DataTables with data
                incOda.Fill(incDt);
                expOda.Fill(expDt);

                // Calculate balance
                decimal income = 0;
                decimal expenditures = 0;
                decimal balance = 0;

                if (incDt.Rows.Count > 0 && incDt.Rows[0][0] != DBNull.Value)
                {
                    income = Convert.ToDecimal(incDt.Rows[0][0]);
                }

                if (expDt.Rows.Count > 0 && expDt.Rows[0][0] != DBNull.Value)
                {
                    expenditures = Convert.ToDecimal(expDt.Rows[0][0]);
                }

                balance = income - expenditures;

                // Display the results in labels
                IncomeEgpLbl.Text = income.ToString("N2") + " Egp";
                ExpEgpLbl.Text = expenditures.ToString("N2") + " Egp";
                BalanceEgpLbl.Text = balance.ToString("N2") + " Egp";
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
        private void Logistic()
        {
            // Logistic related analytics
            try
            {
                conn.Open();

                // Query for Cows Num
                string cowNumQuery = "SELECT COUNT(*) FROM COWS_TBL";
                OracleCommand cowNumCmd = new OracleCommand(cowNumQuery, conn);
                OracleDataAdapter cowNumOda = new OracleDataAdapter(cowNumCmd);

                // Query for MilkStock
                string milkStockQuery = "SELECT SUM(TOTAL_MILK) FROM MILK_PRODUCTION_TBL";
                OracleCommand milkStockCmd = new OracleCommand(milkStockQuery, conn);
                OracleDataAdapter milkStockOda = new OracleDataAdapter(milkStockCmd);

                // Query for Total Employees
                string employeesNumQuery = "SELECT COUNT(*) FROM EMP_TBL";
                OracleCommand employeesNumCmd = new OracleCommand(employeesNumQuery, conn);
                OracleDataAdapter employeesNumOda = new OracleDataAdapter(employeesNumCmd);

                // Create DataTables to hold the results
                DataTable cowNumDt = new DataTable();
                DataTable milkStockDt = new DataTable();
                DataTable employeesNumDt = new DataTable();


                // Fill DataTables with data
                cowNumOda.Fill(cowNumDt);
                milkStockOda.Fill(milkStockDt);
                employeesNumOda.Fill(employeesNumDt);


                // Display the results in labels or other UI elements
                CowNumLbl.Text = cowNumDt.Rows[0][0].ToString() + " Cows"; // Assuming you have a label named CowsNumLbl
                MilkStockNumLbl.Text = milkStockDt.Rows[0][0].ToString() + " Liters"; // Assuming you have a label named MilkStockLbl
                EmpNumLbl.Text = employeesNumDt.Rows[0][0].ToString() + " Employee"; // Assuming you have a label named EmployeesNumLbl

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

        private void GetMax()
        {
            try
            {
                conn.Open();

                // Query for Max Sale
                string maxSaleQuery = "SELECT MAX(AMOUNT) AS MAX_SALE, MAX(DATE_OF_SALE) AS MAX_SALE_DATE FROM MILK_SALES_TBL";
                OracleCommand maxSaleCmd = new OracleCommand(maxSaleQuery, conn);
                OracleDataAdapter maxSaleOda = new OracleDataAdapter(maxSaleCmd);

                // Query for Max Expense
                string maxExpQuery = "SELECT MAX(EXP_AMOUNT) AS MAX_EXP, MAX(EXP_DATE) AS MAX_EXP_DATE FROM EXPENDITURES_TBL";
                OracleCommand maxExpCmd = new OracleCommand(maxExpQuery, conn);
                OracleDataAdapter maxExpOda = new OracleDataAdapter(maxExpCmd);

                // Create DataTables to hold the results
                DataTable maxSaleDt = new DataTable();
                DataTable maxExpDt = new DataTable();

                // Fill DataTables with data
                maxSaleOda.Fill(maxSaleDt);
                maxExpOda.Fill(maxExpDt);

                // Display the results in labels
                if (maxSaleDt.Rows.Count > 0 && maxSaleDt.Rows[0]["MAX_SALE"] != DBNull.Value)
                {
                    decimal maxSale = Convert.ToDecimal(maxSaleDt.Rows[0]["MAX_SALE"]);
                    MaxSaleEgpLbl.Text = maxSale.ToString("N2") + " Egp"; // Assuming MaxSaleEgpLbl is a label
                    MaxSaleDateLbl.Text = maxSaleDt.Rows[0]["MAX_SALE_DATE"].ToString(); // Assuming MaxSaleDateLbl is a label
                }

                if (maxExpDt.Rows.Count > 0 && maxExpDt.Rows[0]["MAX_EXP"] != DBNull.Value)
                {
                    decimal maxExp = Convert.ToDecimal(maxExpDt.Rows[0]["MAX_EXP"]);
                    MaxExpEgpLbl.Text = maxExp.ToString("N2") + " Egp"; // Assuming MaxExpEgpLbl is a label
                    MaxExpDateLbl.Text = maxExpDt.Rows[0]["MAX_EXP_DATE"].ToString(); // Assuming MaxExpDateLbl is a label
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

     