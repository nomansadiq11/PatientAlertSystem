namespace PAT
{
    partial class Form1
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
            this.dg_patients = new System.Windows.Forms.DataGridView();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_search = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_patients)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_patients
            // 
            this.dg_patients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_patients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_patients.Location = new System.Drawing.Point(0, 0);
            this.dg_patients.Name = "dg_patients";
            this.dg_patients.Size = new System.Drawing.Size(984, 541);
            this.dg_patients.TabIndex = 0;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(710, 94);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(140, 76);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dg_patients);
            this.panel1.Location = new System.Drawing.Point(12, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 541);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient Alert System";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(856, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 76);
            this.button1.TabIndex = 4;
            this.button1.Text = "+ Add Patient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cb_search
            // 
            this.cb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_search.FormattingEnabled = true;
            this.cb_search.Location = new System.Drawing.Point(150, 130);
            this.cb_search.Name = "cb_search";
            this.cb_search.Size = new System.Drawing.Size(291, 28);
            this.cb_search.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Criteria";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_search);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_search);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Patient Alert System";
            ((System.ComponentModel.ISupportInitialize)(this.dg_patients)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_patients;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_search;
        private System.Windows.Forms.Label label2;
    }
}

