using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAT
{
    public partial class PatientsHistory : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["sqlitedb"].ConnectionString;
        private int PatientID = 0;
        public PatientsHistory()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }

        public PatientsHistory(int vPatientID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gv_history.DataSource = GetPatientsHistoryLists(vPatientID);

            gv_history.Columns[0].Width = 225;
            gv_history.Columns[1].Width = 155;

        }

        private void loadhistory()
        {
            //gv_history.DataSource = GetPatientsHistoryLists(); 
        }

        public List<Patients_History> GetPatientsHistoryLists(int langId)
        {
            List<Patients_History> langs = new List<Patients_History>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Patients_History WHERE PatientId = " + langId;
                    if (langId == 0)
                    {
                        sql = "SELECT * FROM Patients_History";
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patients_History la = new Patients_History();
                                //la.ID = Int32.Parse(reader["ID"].ToString());
                                la.Message = reader["Message"].ToString();
                                la.UpdatedOn = reader["cDate"].ToString();
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
