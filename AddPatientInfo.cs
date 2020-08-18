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
        public AddPatientInfo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Clears();

        }

        public AddPatientInfo(int PatientID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Clears();

            List<Patient> patients = GetPatientsLists(PatientID);

            txt_MRN.Text = patients[0].MRN;
            txt_name.Text = patients[0].Name;
            txt_mobile.Text = patients[0].Mobile;
            txt_NRD.Text = patients[0].NDR;
            txt_NRDB.Text = patients[0].NDRB;
            txt_Address.Text = patients[0].Address;
            txt_Medicine.Text = patients[0].Medicine;
            txt_splcomments.Text = patients[0].SplComments;



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

        public static int AddPatient(string MRN, string Name, string Mobile, int NDR, int NDRB, string Address, string Medicine, string SplComments, out string vError)
        {
            int result = -1;
            vError = "";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {

                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO Patients(MRN, Name, Mobile,NDR,NDRB,Address,Medicine,SplComments, reminderDate) VALUES (@MRN, @Name, @Mobile, @NDR, @NDRB, @Address, @Medicine, @SplComments, Date('now', '+" + NDR + " day'))";
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string verror = "";
            int val = AddPatient(txt_MRN.Text.Trim(), txt_name.Text.Trim(), txt_mobile.Text.Trim(), Convert.ToInt32(txt_NRD.Text.Trim()), Convert.ToInt32(txt_NRDB.Text.Trim()), txt_Address.Text.Trim(), txt_Medicine.Text.Trim(), txt_splcomments.Text.Trim(), out verror);
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
    }
}
