using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PAT
{
    public partial class Form1 : Form
    {
        public static string connectionString = @"Data Source=.\PAT.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
        private int rowIndex = 0;
        private int PatientID = 0;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadComboSearchCritera();
            LoadPatients();
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contexMenu_ItemClicked);
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddPatientInfo addPatientInfo = new AddPatientInfo();
            addPatientInfo.ShowDialog();
        }

        public static DataTable GetPatients(int langId, out string vError)
        {
            DataTable dt = new DataTable();
            vError = "";
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT *, (NDR - NDRB) as FinalDay FROM Patients WHERE Id = " + langId;
                    if (langId == 0)
                    {
                        sql = "SELECT * FROM Patients";
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                vError = e.Message;
            }
            return dt;
        }


        private void LoadPatients()
        {
            //string vError = "";
            //DataTable dt = GetPatients(0, out vError);
            //if (dt.Rows.Count > 0)
            //{
            //    dg_patients.DataSource = dt;

            //}


            //dg_patients.ColumnCount = 3;
            //dg_patients.Columns[0].Name = "Product ID";


            //dg_patients.Columns[1].Name = "Product Name";
            //dg_patients.Columns[2].Name = "Product Price";


            List<Patient> patients = GetPatientsLists(0);
            if (cb_search.SelectedIndex == 0)
            {
                patients = patients.Where(a => a.ideleted == 0).ToList();
            }
            if (cb_search.SelectedIndex == 1)
            {
                patients = patients.Where(a => a.ReminderDate2 == DateTime.Now && a.ideleted == 0).ToList();
            }
            if (cb_search.SelectedIndex == 2)
            {
                patients = patients.Where(a => a.ReminderDate2 < DateTime.Now && a.ideleted == 0).ToList();
            }
            if (cb_search.SelectedIndex == 3)
            {
                patients = patients.Where(a => a.ideleted == 1).ToList();
            }

            dg_patients.DataSource = patients;
            dg_patients.Columns[1].Width = 224;
            dg_patients.Columns[2].Width = 224;
            dg_patients.Columns[3].Width = 224;
            dg_patients.Columns[4].Width = 169;

            dg_patients.Columns[4].HeaderText = "No. of Days Refil";

            dg_patients.Columns[0].Visible = false;
            dg_patients.Columns[5].Visible = false;
            dg_patients.Columns[6].Visible = false;
            dg_patients.Columns[7].Visible = false;
            dg_patients.Columns[8].Visible = false;
            //dg_patients.Columns[9].Visible = false;
            dg_patients.Columns[10].Visible = false;
            dg_patients.Columns[11].Visible = false;


        }

        private void LoadComboSearchCritera()
        {
            cb_search.Items.Insert(0, "All");
            cb_search.Items.Insert(1, "Due Today");
            cb_search.Items.Insert(2, "Overdue by Today");
            cb_search.Items.Insert(3, "Deleted");
            cb_search.SelectedIndex = 0;

        }


        public static List<Patient> GetPatientsLists(int langId)
        {
            List<Patient> langs = new List<Patient>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Patients WHERE Id = " + langId;
                    if (langId == 0)
                    {
                        sql = "SELECT * FROM Patients";
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient la = new Patient();
                                la.ID = Int32.Parse(reader["ID"].ToString());
                                la.MRN = reader["MRN"].ToString();
                                la.Name = reader["Name"].ToString();
                                la.Mobile = reader["Mobile"].ToString();
                                la.NDR = reader["NDR"].ToString();
                                la.NDRB = reader["NDRB"].ToString();
                                la.Address = reader["Address"].ToString();
                                la.Medicine = reader["Medicine"].ToString();
                                la.SplComments = reader["SplComments"].ToString();
                                la.ideleted = Int32.Parse(reader["idelete"].ToString());
                                la.ReminderDate = DateTime.Now.AddDays(Int32.Parse(reader["NDR"].ToString())).AddDays(-Int32.Parse(reader["NDRB"].ToString())).ToString("dd-MM-yyyy");
                                la.ReminderDate2 = DateTime.Now.AddDays(Int32.Parse(reader["NDR"].ToString())).AddDays(-Int32.Parse(reader["NDRB"].ToString()));
                                langs.Add(la);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {

            }
            return langs;
        }

        private void dg_patients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                try
                {
                    PatientID = Convert.ToInt32(this.dg_patients.Rows[e.RowIndex].Cells[0].Value);
                    this.dg_patients.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    this.dg_patients.CurrentCell = this.dg_patients.Rows[e.RowIndex].Cells[1];
                    this.contextMenuStrip1.Show(this.dg_patients, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
                catch (Exception ex)
                {

                }

            }

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {


            //var clickedMenuItem = sender as ContextMenuStrip;
            //var menuText = clickedMenuItem.Text;

            //switch (menuText)
            //{
            //    case "Update":
            //        MessageBox.Show(menuText); 
            //        break;
            //    case "Delete":
            //        break;

            //}


            //if (!this.dg_patients.Rows[this.rowIndex].IsNewRow)
            //{
            //    this.dg_patients.Rows.RemoveAt(this.rowIndex);
            //}
        }

        void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text == "Update")
            {
                AddPatientInfo addPatientInfo = new AddPatientInfo(PatientID);
                addPatientInfo.ShowDialog();
            }
            if (item.Text == "Delete")
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeletePatient(PatientID);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }



            }
            if (item.Text == "History")
            {
                PatientsHistory patientsHistory = new PatientsHistory(PatientID);
                patientsHistory.ShowDialog();
            }


        }

        private void DeletePatient(int vPatientID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {

                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "update patients set idelete = 1 where id = " + vPatientID;
                    cmd.Prepare();
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        AddPatientHistory("deleted patient", vPatientID);
                        MessageBox.Show("Deleted successfully", "Alert", MessageBoxButtons.OK);
                        LoadPatients();
                    }
                    catch (SQLiteException e)
                    {
                        MessageBox.Show("Unable to delete " + e.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                conn.Close();
            }
        }


        public static int GetSeqID(string tablename)
        {
            int seqID = 0;
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            try
            {

                conn.Open();
                string sql = "SELECT seq FROM sqlite_sequence WHERE Name = '" + tablename + "' ";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                }

                if (dt.Rows.Count > 0)
                {
                    seqID = Convert.ToInt32(dt.Rows[0]["seq"]);
                }
            }
            catch (SQLiteException e)
            {
                seqID = 0;
            }
            finally
            {
                conn.Close();
            }
            return seqID;
        }

        private void AddPatientHistory(string Message, int vPatentID)
        {
            int result = -1;

            string sql = "INSERT INTO Patients_History(Message, PatientID, cdate) VALUES (@Message, @PatientID, Datetime('now'))";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {

                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = sql;
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@Message", Message);
                    cmd.Parameters.AddWithValue("@PatientID", vPatentID);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {

                    }
                }
                conn.Close();
            }


        }

    }
}
