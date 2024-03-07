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
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            populate();
            EmpIdCbFill();
            ClientIdCbFill();
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

        private void FainanceLb_Click(object sender, EventArgs e)
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
        private void ClientIdCbFill()
        {
            try
            {
                conn.Open();
                string query = "SELECT CLIENT_ID FROM CLIENT_TBL";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader Odr;
                Odr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CLIENT_ID", typeof(int));
                dt.Load(Odr);
                ClientIdCb.ValueMember = "CLIENT_ID";
                ClientIdCb.DataSource = dt;
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
                string query = "SELECT * FROM MILK_SALES_TBL";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                SalesDGV.DataSource = ds.Tables[0];
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
            PriceTb.Text = "";
            QuantityTb.Text = "";
            TotalTb.Text = "";
        }
        private void SaveTransaction()
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO INCOME_TBL (INC_DATE, INC_PURPOSE, INC_AMOUNT, EMP_ID) " +
                               "VALUES (:INC_DATE, :INC_PURPOSE, :INC_AMOUNT, :EMP_ID)";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":INC_DATE", OracleDbType.Date).Value = DateDTP.Value.Date;
                cmd.Parameters.Add(":INC_PURPOSE", OracleDbType.Varchar2, 50).Value = "Sales";
                cmd.Parameters.Add(":INC_AMOUNT", OracleDbType.Int32).Value = Convert.ToInt32(TotalTb.Text);
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
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpIdCb.SelectedIndex == -1 || PriceTb.Text == "" || ClientIdCb.SelectedIndex == -1 || QuantityTb.Text == "" ||
                TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO MILK_SALES_TBL (DATE_OF_SALE, UNIT_PRICE, EMP_ID, QUANTITY, AMOUNT,CLIENT_ID) " +
                                   "VALUES (:DATE_OF_SALE, :UNIT_PRICE, :EMP_ID, :QUANTITY, :AMOUNT,:CLIENT_ID)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":DATE_OF_SALE", OracleDbType.Date).Value = DateDTP.Value.Date;
                    cmd.Parameters.Add(":UNIT_PRICE", OracleDbType.Int32).Value = Convert.ToInt32(PriceTb.Text);
                    cmd.Parameters.Add(":CLIENT_ID", OracleDbType.Int32).Value = Convert.ToInt32(ClientIdCb.SelectedValue);
                    cmd.Parameters.Add(":EMP_ID", OracleDbType.Int32).Value = Convert.ToInt32(EmpIdCb.SelectedValue);
                    cmd.Parameters.Add(":QUANTITY", OracleDbType.Int32).Value = Convert.ToInt32(QuantityTb.Text);
                    cmd.Parameters.Add(":AMOUNT", OracleDbType.Int32).Value = Convert.ToInt32(TotalTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sale Record Saved Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                    SaveTransaction();
                    clear();
                    populate();
                }
            }
        }

        private void QuantityTb_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(PriceTb.Text, out int price) && int.TryParse(QuantityTb.Text, out int quantity))
            {
                int total = price * quantity;
                TotalTb.Text = "" + total;
            }
            else
            {

                TotalTb.Text = "0";
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
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
