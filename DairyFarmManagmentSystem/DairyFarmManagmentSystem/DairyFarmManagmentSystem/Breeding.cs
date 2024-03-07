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
    public partial class Breeding : Form
    {
        public Breeding()
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

        private void ProductionLb_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
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
                string query = "SELECT * FROM BREED_TBL";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                OracleCommandBuilder builder = new OracleCommandBuilder(oda);
                var ds = new DataSet();
                oda.Fill(ds);
                CowBreedDGV.DataSource = ds.Tables[0];
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
            RemarksTb.Text = "";
            CowAgeTb.Text = "";
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
                    CowAgeTb.Text = dr["AGE"].ToString();
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

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || RemarksTb.Text == "" || CowAgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO BREED_TBL (COW_ID, COW_NAME, HEAT_DATE, BREED_DATE, PREGNANCY_DATE, TO_CALVE_DATE, CALVE_DATE, COW_AGE, REMARKS) " +
                                   "VALUES (:COW_ID, :COW_NAME, :HEAT_DATE, :BREED_DATE, :PREGNANCY_DATE, :TO_CALVE_DATE, :CALVE_DATE, :COW_AGE, :REMARKS)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_ID", OracleDbType.Int32).Value = Convert.ToInt32(CowIdCb.SelectedValue);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":HEAT_DATE", OracleDbType.Date).Value = HeatDTB.Value.Date;
                    cmd.Parameters.Add(":BREED_DATE", OracleDbType.Date).Value = BreedDTB.Value.Date;
                    cmd.Parameters.Add(":PREGNANCY_DATE", OracleDbType.Date).Value = PregnancyDTB.Value.Date;
                    cmd.Parameters.Add(":TO_CALVE_DATE", OracleDbType.Date).Value = DateToCalveDTB.Value.Date;
                    cmd.Parameters.Add(":CALVE_DATE", OracleDbType.Date).Value = CalveDTB.Value.Date;
                    cmd.Parameters.Add(":COW_AGE", OracleDbType.Int32).Value = Convert.ToInt32(CowAgeTb.Text);
                    cmd.Parameters.Add(":REMARKS", OracleDbType.Varchar2, 255).Value = RemarksTb.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Breeding Record Saved Successfully");
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
                    string query = "DELETE FROM BREED_TBL WHERE BREED_ID = :BREED_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":BREED_ID", OracleDbType.Int32).Value = key;

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
                    string query = "UPDATE BREED_TBL " +
                                   "SET COW_ID = :COW_ID, COW_NAME = :COW_NAME, HEAT_DATE = :HEAT_DATE, " +
                                   "    BREED_DATE = :BREED_DATE, PREGNANCY_DATE = :PREGNANCY_DATE, " +
                                   "    TO_CALVE_DATE = :TO_CALVE_DATE, CALVE_DATE = :CALVE_DATE, " +
                                   "    COW_AGE = :COW_AGE, REMARKS = :REMARKS " +
                                   "WHERE BREED_ID = :BREED_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":COW_ID", OracleDbType.Int32).Value = Convert.ToInt32(CowIdCb.SelectedValue);
                    cmd.Parameters.Add(":COW_NAME", OracleDbType.Varchar2, 50).Value = CowNameTb.Text;
                    cmd.Parameters.Add(":HEAT_DATE", OracleDbType.Date).Value = HeatDTB.Value.Date;
                    cmd.Parameters.Add(":BREED_DATE", OracleDbType.Date).Value = BreedDTB.Value.Date;
                    cmd.Parameters.Add(":PREGNANCY_DATE", OracleDbType.Date).Value = PregnancyDTB.Value.Date;
                    cmd.Parameters.Add(":TO_CALVE_DATE", OracleDbType.Date).Value = DateToCalveDTB.Value.Date;
                    cmd.Parameters.Add(":CALVE_DATE", OracleDbType.Date).Value = CalveDTB.Value.Date;
                    cmd.Parameters.Add(":COW_AGE", OracleDbType.Int32).Value = Convert.ToInt32(CowAgeTb.Text);
                    cmd.Parameters.Add(":REMARKS", OracleDbType.Varchar2, 255).Value = RemarksTb.Text;
                    cmd.Parameters.Add(":BREED_ID", OracleDbType.Int32).Value = key;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Breeding Record Updated Successfully");
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
        private void CowBreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HeatDTB.Text = CowBreedDGV.SelectedRows[0].Cells[4].Value.ToString();
            BreedDTB.Text = CowBreedDGV.SelectedRows[0].Cells[6].Value.ToString();
            PregnancyDTB.Text = CowBreedDGV.SelectedRows[0].Cells[5].Value.ToString();
            DateToCalveDTB.Text = CowBreedDGV.SelectedRows[0].Cells[7].Value.ToString();
            CalveDTB.Text = CowBreedDGV.SelectedRows[0].Cells[3].Value.ToString();

            CowIdCb.SelectedValue = CowBreedDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = CowBreedDGV.SelectedRows[0].Cells[2].Value.ToString();
            CowAgeTb.Text = CowBreedDGV.SelectedRows[0].Cells[8].Value.ToString();
            RemarksTb.Text = CowBreedDGV.SelectedRows[0].Cells[9].Value.ToString();

            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CowBreedDGV.SelectedRows[0].Cells[0].Value.ToString());
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
