namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    partial class frmChonChucNang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonChucNang));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKiemTraThongTuyen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGiamDinhBHYT = new System.Windows.Forms.Button();
            this.timerChonChucNang = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKiemTraThongTuyen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnKiemTraThongTuyen
            // 
            this.btnKiemTraThongTuyen.BackColor = System.Drawing.Color.LightGreen;
            this.btnKiemTraThongTuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKiemTraThongTuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraThongTuyen.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTraThongTuyen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKiemTraThongTuyen.Location = new System.Drawing.Point(0, 0);
            this.btnKiemTraThongTuyen.Name = "btnKiemTraThongTuyen";
            this.btnKiemTraThongTuyen.Size = new System.Drawing.Size(394, 71);
            this.btnKiemTraThongTuyen.TabIndex = 0;
            this.btnKiemTraThongTuyen.Text = "Kiểm tra thông tuyến";
            this.btnKiemTraThongTuyen.UseVisualStyleBackColor = false;
            this.btnKiemTraThongTuyen.Click += new System.EventHandler(this.btnKiemTraThongTuyen_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGiamDinhBHYT);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 71);
            this.panel2.TabIndex = 1;
            // 
            // btnGiamDinhBHYT
            // 
            this.btnGiamDinhBHYT.BackColor = System.Drawing.Color.LightPink;
            this.btnGiamDinhBHYT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGiamDinhBHYT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiamDinhBHYT.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiamDinhBHYT.ForeColor = System.Drawing.Color.White;
            this.btnGiamDinhBHYT.Location = new System.Drawing.Point(0, 0);
            this.btnGiamDinhBHYT.Name = "btnGiamDinhBHYT";
            this.btnGiamDinhBHYT.Size = new System.Drawing.Size(394, 71);
            this.btnGiamDinhBHYT.TabIndex = 0;
            this.btnGiamDinhBHYT.Text = "Giám định Bảo hiểm y tế";
            this.btnGiamDinhBHYT.UseVisualStyleBackColor = false;
            this.btnGiamDinhBHYT.Click += new System.EventHandler(this.btnGiamDinhBHYT_Click);
            // 
            // timerChonChucNang
            // 
            this.timerChonChucNang.Interval = 10000;
            this.timerChonChucNang.Tick += new System.EventHandler(this.timerChonChucNang_Tick);
            // 
            // frmChonChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 142);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 180);
            this.Name = "frmChonChucNang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chức năng";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKiemTraThongTuyen;
        private System.Windows.Forms.Button btnGiamDinhBHYT;
        private System.Windows.Forms.Timer timerChonChucNang;
    }
}