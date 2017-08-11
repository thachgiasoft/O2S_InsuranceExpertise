namespace O2S_InsuranceExpertise.GUI.CheckThongTuyen
{
    partial class frmCongCuKhac_MoRong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongCuKhac_MoRong));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnTroVe = new DevExpress.XtraEditors.SimpleButton();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnTroVe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1234, 39);
            this.panelTop.TabIndex = 0;
            // 
            // btnTroVe
            // 
            this.btnTroVe.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVe.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTroVe.Appearance.Options.UseFont = true;
            this.btnTroVe.Appearance.Options.UseForeColor = true;
            this.btnTroVe.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTroVe.Image = global::O2S_InsuranceExpertise.Properties.Resources.undo_16;
            this.btnTroVe.Location = new System.Drawing.Point(31, 5);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(100, 30);
            this.btnTroVe.TabIndex = 31;
            this.btnTroVe.Text = "Trở về";
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 39);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1234, 703);
            this.panelData.TabIndex = 1;
            // 
            // frmCongCuKhac_MoRong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 742);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCongCuKhac_MoRong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra thông tuyến";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCongCuKhac_MoRong_FormClosed);
            this.Load += new System.EventHandler(this.frmCongCuKhac_MoRong_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelData;
        private DevExpress.XtraEditors.SimpleButton btnTroVe;
    }
}