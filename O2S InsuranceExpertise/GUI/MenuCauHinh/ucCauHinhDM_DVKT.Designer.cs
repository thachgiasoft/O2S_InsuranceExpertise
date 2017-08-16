namespace O2S_InsuranceExpertise.GUI.MenuCauHinh
{
    partial class ucCauHinhDM_DVKT
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelNoiDung = new System.Windows.Forms.Panel();
            this.btnNhapTuExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuuLai = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridViewDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.openFileDialogSelect = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panelNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLuuLai);
            this.panel1.Controls.Add(this.btnNhapTuExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 41);
            this.panel1.TabIndex = 0;
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Controls.Add(this.gridControlDichVu);
            this.panelNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoiDung.Location = new System.Drawing.Point(0, 41);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(1000, 572);
            this.panelNoiDung.TabIndex = 1;
            // 
            // btnNhapTuExcel
            // 
            this.btnNhapTuExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapTuExcel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNhapTuExcel.Appearance.Options.UseFont = true;
            this.btnNhapTuExcel.Appearance.Options.UseForeColor = true;
            this.btnNhapTuExcel.Image = global::O2S_InsuranceExpertise.Properties.Resources.excel_3_16;
            this.btnNhapTuExcel.Location = new System.Drawing.Point(18, 5);
            this.btnNhapTuExcel.Name = "btnNhapTuExcel";
            this.btnNhapTuExcel.Size = new System.Drawing.Size(120, 30);
            this.btnNhapTuExcel.TabIndex = 33;
            this.btnNhapTuExcel.Text = "Nhập từ excel";
            this.btnNhapTuExcel.Click += new System.EventHandler(this.btnNhapTuExcel_Click);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuLai.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuuLai.Appearance.Options.UseFont = true;
            this.btnLuuLai.Appearance.Options.UseForeColor = true;
            this.btnLuuLai.Image = global::O2S_InsuranceExpertise.Properties.Resources.save_16;
            this.btnLuuLai.Location = new System.Drawing.Point(515, 5);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(120, 30);
            this.btnLuuLai.TabIndex = 34;
            this.btnLuuLai.Text = "Lưu";
            // 
            // gridControlDichVu
            // 
            this.gridControlDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridControlDichVu.MainView = this.gridViewDichVu;
            this.gridControlDichVu.Name = "gridControlDichVu";
            this.gridControlDichVu.Size = new System.Drawing.Size(1000, 572);
            this.gridControlDichVu.TabIndex = 0;
            this.gridControlDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDichVu});
            // 
            // gridViewDichVu
            // 
            this.gridViewDichVu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewDichVu.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridViewDichVu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDichVu.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewDichVu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDichVu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDichVu.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewDichVu.Appearance.Row.Options.UseFont = true;
            this.gridViewDichVu.ColumnPanelRowHeight = 25;
            this.gridViewDichVu.GridControl = this.gridControlDichVu;
            this.gridViewDichVu.Name = "gridViewDichVu";
            this.gridViewDichVu.OptionsBehavior.Editable = false;
            this.gridViewDichVu.OptionsFind.AlwaysVisible = true;
            this.gridViewDichVu.OptionsFind.FindNullPrompt = "Từ khóa tìm kiếm";
            this.gridViewDichVu.OptionsFind.ShowClearButton = false;
            this.gridViewDichVu.OptionsView.ColumnAutoWidth = false;
            this.gridViewDichVu.OptionsView.ShowGroupPanel = false;
            this.gridViewDichVu.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDichVu.OptionsView.ShowIndicator = false;
            this.gridViewDichVu.RowHeight = 25;
            this.gridViewDichVu.ViewCaptionHeight = 25;
            this.gridViewDichVu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDichVu_RowCellStyle);
            // 
            // openFileDialogSelect
            // 
            this.openFileDialogSelect.Filter = "Excel 2007-2013|*.xlsx|Excel 2003|*.xls";
            this.openFileDialogSelect.Title = "Mở file Excel";
            // 
            // ucCauHinhDM_DVKT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.panel1);
            this.Name = "ucCauHinhDM_DVKT";
            this.Size = new System.Drawing.Size(1000, 613);
            this.Load += new System.EventHandler(this.ucCauHinhDM_DVKT_Load);
            this.panel1.ResumeLayout(false);
            this.panelNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelNoiDung;
        private DevExpress.XtraEditors.SimpleButton btnLuuLai;
        private DevExpress.XtraEditors.SimpleButton btnNhapTuExcel;
        private DevExpress.XtraGrid.GridControl gridControlDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDichVu;
        internal System.Windows.Forms.OpenFileDialog openFileDialogSelect;
    }
}
