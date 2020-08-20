using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace PAT
{
    public partial class AddPatientInfo : Form
    {
        public static string connectionString = @"Data Source=.\PAT.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
        private int PatientID = 0;

        public AddPatientInfo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Clears();
            txt_patientid.Visible = false;

        }

        public AddPatientInfo(int PatientID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Clears();
            txt_patientid.Visible = false;

            List<Patient> patients = GetPatientsLists(PatientID);

            txt_patientid.Text = patients[0].ID.ToString();
            txt_MRN.Text = patients[0].MRN;
            txt_name.Text = patients[0].Name;
            txt_mobile.Text = patients[0].Mobile;
            txt_NRD.Text = patients[0].NDR;
            txt_NRDB.Text = patients[0].NDRB;
            txt_Address.Text = patients[0].Address;
            txt_Medicine.Text = patients[0].Medicine;
            txt_splcomments.Text = patients[0].SplComments;
            txt_savemessage.Text = "";




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

        public int AddPatient(int vPatientID, string MRN, string Name, string Mobile, int NDR, int NDRB, string Address, string Medicine, string SplComments, out string vError)
        {
            int result = -1;
            vError = "";
            string sql = "INSERT INTO Patients(MRN, Name, Mobile,NDR,NDRB,Address,Medicine,SplComments, reminderDate, cdate) VALUES (@MRN, @Name, @Mobile, @NDR, @NDRB, @Address, @Medicine, @SplComments, Date('now', '+" + NDR + " day'), Datetime('now'))";

            if (vPatientID > 0)
            {
                sql = "update Patients set MRN = @MRN, Name = @Name, Mobile = @Mobile, NDR = @NDR, NDRB  = @NDRB,Address = @Address, Medicine  = @Medicine , SplComments =  @SplComments, reminderDate = Date('now', '+" + NDR + " day') where ID = " + vPatientID;
            }



            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {

                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = sql;
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@MRN", MRN);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@NDR", NDR);
                    cmd.Parameters.AddWithValue("@NDRB", NDRB);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Medicine", Medicine);
                    cmd.Parameters.AddWithValue("@SplComments", SplComments);
                    //cmd.Parameters.AddWithValue("@reminderDate", "Date(now, '+"+ NDR +" day')");

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        AddPatientHistory(txt_savemessage.Text.Trim(), vPatientID);




                    }
                    catch (SQLiteException e)
                    {
                        vError = e.Message;
                    }
                }
                conn.Close();
            }
            return result;
        }

        private void AddPatientHistory(string Message, int vPatientID)
        {
            int result = -1;

            if (vPatientID == 0)
            {
                vPatientID = GetSeqID("Patients");
            }

            string sql = "INSERT INTO Patients_History(Message, PatientID, cdate) VALUES (@Message, @PatientID, Datetime('now'))";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {

                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = sql;
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@Message", Message);
                    cmd.Parameters.AddWithValue("@PatientID", vPatientID);

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

        private void btn_Save_Click(object sender, EventArgs e)
        {

            if (txt_MRN.Text.Trim() == "")
            {
                MessageBox.Show("Please enter MRN", "Alert", MessageBoxButtons.OK);
                return;
            }
            if (txt_NRD.Text.Trim() == "" || txt_NRD.Text.Trim() == "0")
            {
                MessageBox.Show("Please enter No of days refilled", "Alert", MessageBoxButtons.OK);
                return;
            }
            if (txt_NRDB.Text.Trim() == "" || txt_NRDB.Text.Trim() == "0")
            {
                MessageBox.Show("Please enter No of days before reminder?", "Alert", MessageBoxButtons.OK);
                return;
            }

            if (txt_savemessage.Text.Trim() == "")
            {
                MessageBox.Show("Please enter save message", "Alert", MessageBoxButtons.OK);
                return;
            }

            string verror = "";
            if (txt_patientid.Text != "")
            {
                PatientID = Convert.ToInt32(txt_patientid.Text);
            }

            int val = AddPatient(PatientID, txt_MRN.Text.Trim(), txt_name.Text.Trim(), txt_mobile.Text.Trim(), Convert.ToInt32(txt_NRD.Text.Trim()), Convert.ToInt32(txt_NRDB.Text.Trim()), txt_Address.Text.Trim(), txt_Medicine.Text.Trim(), txt_splcomments.Text.Trim(), out verror);
            if (val == 1)
            {
                Clears();
                MessageBox.Show("Record has been saved successfully", "Alert", MessageBoxButtons.OK);
            }
            if (val == -1)
            {
                MessageBox.Show("Unexpected error :" + verror, "Alert", MessageBoxButtons.OK);
            }
        }

        private void Clears()
        {
            txt_MRN.Text = "";
            txt_name.Text = "";
            txt_mobile.Text = "";
            txt_NRD.Text = "0";
            txt_NRDB.Text = "0";
            txt_Address.Text = "";
            txt_Medicine.Text = "";
            txt_splcomments.Text = "";
        }

        private void txt_NRD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_NRDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_history_Click(object sender, EventArgs e)
        {
            if (txt_patientid.Text != "")
            {
                PatientID = Convert.ToInt32(txt_patientid.Text);
            }

            PatientsHistory patientsHistory = new PatientsHistory(PatientID);
            patientsHistory.ShowDialog();
        }
    }
}
