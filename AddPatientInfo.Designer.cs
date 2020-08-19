namespace PAT
{
    partial class AddPatientInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MRN = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_mobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NRD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NRDB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.RichTextBox();
            this.txt_Medicine = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_splcomments = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_patientid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "MRN";
            // 
            // txt_MRN
            // 
            this.txt_MRN.Location = new System.Drawing.Point(144, 9);
            this.txt_MRN.MaxLength = 35;
            this.txt_MRN.Name = "txt_MRN";
            this.txt_MRN.Size = new System.Drawing.Size(224, 20);
            this.txt_MRN.TabIndex = 1;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(144, 35);
            this.txt_name.MaxLength = 35;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(224, 20);
            this.txt_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(600, 339);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(140, 50);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_mobile
            // 
            this.txt_mobile.Location = new System.Drawing.Point(144, 61);
            this.txt_mobile.MaxLength = 35;
            this.txt_mobile.Name = "txt_mobile";
            this.txt_mobile.Size = new System.Drawing.Size(224, 20);
            this.txt_mobile.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mobile";
            // 
            // txt_NRD
            // 
            this.txt_NRD.Location = new System.Drawing.Point(648, 12);
            this.txt_NRD.MaxLength = 5;
            this.txt_NRD.Name = "txt_NRD";
            this.txt_NRD.Size = new System.Drawing.Size(92, 20);
            this.txt_NRD.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(500, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "No. of Days refill";
            // 
            // txt_NRDB
            // 
            this.txt_NRDB.Location = new System.Drawing.Point(648, 37);
            this.txt_NRDB.MaxLength = 5;
            this.txt_NRDB.Name = "txt_NRDB";
            this.txt_NRDB.Size = new System.Drawing.Size(92, 20);
            this.txt_NRDB.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "No. of Days Reminder before";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(144, 87);
            this.txt_Address.MaxLength = 500;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(596, 78);
            this.txt_Address.TabIndex = 6;
            this.txt_Address.Text = "";
            // 
            // txt_Medicine
            // 
            this.txt_Medicine.Location = new System.Drawing.Point(144, 171);
            this.txt_Medicine.MaxLength = 500;
            this.txt_Medicine.Name = "txt_Medicine";
            this.txt_Medicine.Size = new System.Drawing.Size(596, 78);
            this.txt_Medicine.TabIndex = 7;
            this.txt_Medicine.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Medicine";
            // 
            // txt_splcomments
            // 
            this.txt_splcomments.Location = new System.Drawing.Point(144, 255);
            this.txt_splcomments.MaxLength = 500;
            this.txt_splcomments.Name = "txt_splcomments";
            this.txt_splcomments.Size = new System.Drawing.Size(596, 78);
            this.txt_splcomments.TabIndex = 8;
            this.txt_splcomments.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 22);
            this.label8.TabIndex = 16;
            this.label8.Text = "Spl. Comments";
            // 
            // txt_patientid
            // 
            this.txt_patientid.Location = new System.Drawing.Point(2, 369);
            this.txt_patientid.Name = "txt_patientid";
            this.txt_patientid.Size = new System.Drawing.Size(100, 20);
            this.txt_patientid.TabIndex = 17;
            // 
            // AddPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 401);
            this.Controls.Add(this.txt_patientid);
            this.Controls.Add(this.txt_splcomments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Medicine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_NRDB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_NRD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_mobile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_MRN);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPatientInfo";
            this.Text = "Add Patient Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MRN;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_mobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NRD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NRDB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txt_Address;
        private System.Windows.Forms.RichTextBox txt_Medicine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txt_splcomments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_patientid;
    }
}