﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAT
{
    public class Patient
    {
        public int ID { get; set; }
        public string MRN { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string NDR { get; set; }
        public string NDRB { get; set; }
        public string Address { get; set; }
        public string Medicine { get; set; }
        public string SplComments { get; set; }



        public string ReminderDate { get; set; }

        public DateTime ReminderDate2 { get; set; }

        public int ideleted { get; set; }
    }

    public class Patients_History
    {
        public string Message { get; set; }
        public string UpdatedOn { get; set; }
        
    }
}
