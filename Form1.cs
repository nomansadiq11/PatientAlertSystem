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

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadComboSearchCritera();
            LoadPatients();
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


            List<Patient> patients = GetLanguages(0);
            if (cb_search.SelectedIndex == 1)
            {
                patients = patients.Where(a => a.ReminderDate2 == DateTime.Now).ToList();
            }
            if (cb_search.SelectedIndex == 2)
            {
                patients = patients.Where(a => a.ReminderDate2 < DateTime.Now).ToList();
            }

            dg_patients.DataSource = patients;


        }

        private void LoadComboSearchCritera()
        {
            cb_search.Items.Insert(0, "All");
            cb_search.Items.Insert(1, "Due Today");
            cb_search.Items.Insert(2, "Overdue by Today");
            cb_search.SelectedIndex = 0;

        }


        public static List<Patient> GetLanguages(int langId)
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
                                la.MRN = reader["MRN"].ToString();
                                la.Name = reader["Name"].ToString();
                                la.Mobile = reader["Mobile"].ToString();
                                la.NDR = reader["NDR"].ToString();
                                la.NDRB = reader["NDRB"].ToString();
                                la.Address = reader["Address"].ToString();
                                la.Medicine = reader["Medicine"].ToString();
                                la.SplComments = reader["SplComments"].ToString();
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


    }
}
