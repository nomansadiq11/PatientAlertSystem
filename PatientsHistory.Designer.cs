namespace PAT
{
    partial class PatientsHistory
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
            this.gv_history = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gv_history)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_history
            // 
            this.gv_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_history.Location = new System.Drawing.Point(0, 0);
            this.gv_history.Name = "gv_history";
            this.gv_history.Size = new System.Drawing.Size(434, 311);
            this.gv_history.TabIndex = 0;
            // 
            // PatientsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.gv_history);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientsHistory";
            this.Text = "View Patient History";
            ((System.ComponentModel.ISupportInitialize)(this.gv_history)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_history;
    }
}