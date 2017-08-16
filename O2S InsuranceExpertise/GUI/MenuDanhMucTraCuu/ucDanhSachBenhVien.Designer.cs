namespace O2S_InsuranceExpertise.GUI.MenuDanhMucTraCuu
{
    partial class ucDanhSachBenhVien
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
            this.panelControlNV_DT = new DevExpress.XtraEditors.PanelControl();
            this.gridControlDSBenhVien = new DevExpress.XtraGrid.GridControl();
            this.gridViewDSBenhVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.stt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.manv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tennv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialogSelect = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlNV_DT)).BeginInit();
            this.panelControlNV_DT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSBenhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSBenhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlNV_DT
            // 
            this.panelControlNV_DT.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlNV_DT.Controls.Add(this.gridControlDSBenhVien);
            this.panelControlNV_DT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlNV_DT.Location = new System.Drawing.Point(0, 0);
            this.panelControlNV_DT.Name = "panelControlNV_DT";
            this.panelControlNV_DT.Size = new System.Drawing.Size(1096, 613);
            this.panelControlNV_DT.TabIndex = 2;
            // 
            // gridControlDSBenhVien
            // 
            this.gridControlDSBenhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDSBenhVien.Location = new System.Drawing.Point(0, 0);
            this.gridControlDSBenhVien.MainView = this.gridViewDSBenhVien;
            this.gridControlDSBenhVien.Name = "gridControlDSBenhVien";
            this.gridControlDSBenhVien.Size = new System.Drawing.Size(1096, 613);
            this.gridControlDSBenhVien.TabIndex = 0;
            this.gridControlDSBenhVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSBenhVien});
            // 
            // gridViewDSBenhVien
            // 
            this.gridViewDSBenhVien.ColumnPanelRowHeight = 25;
            this.gridViewDSBenhVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.stt,
            this.gridColumn2,
            this.manv,
            this.tennv,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6});
            this.gridViewDSBenhVien.GridControl = this.gridControlDSBenhVien;
            this.gridViewDSBenhVien.Name = "gridViewDSBenhVien";
            this.gridViewDSBenhVien.OptionsFind.AlwaysVisible = true;
            this.gridViewDSBenhVien.OptionsFind.FindNullPrompt = "Từ khóa tìm kiếm...";
            this.gridViewDSBenhVien.OptionsFind.ShowClearButton = false;
            this.gridViewDSBenhVien.OptionsView.ColumnAutoWidth = false;
            this.gridViewDSBenhVien.OptionsView.ShowGroupPanel = false;
            this.gridViewDSBenhVien.OptionsView.ShowIndicator = false;
            this.gridViewDSBenhVien.RowHeight = 25;
            this.gridViewDSBenhVien.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDSOption_RowCellStyle);
            // 
            // stt
            // 
            this.stt.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.stt.AppearanceCell.Options.UseFont = true;
            this.stt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.stt.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stt.AppearanceHeader.Options.UseFont = true;
            this.stt.AppearanceHeader.Options.UseForeColor = true;
            this.stt.AppearanceHeader.Options.UseTextOptions = true;
            this.stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.stt.Caption = "STT";
            this.stt.FieldName = "stt";
            this.stt.Name = "stt";
            this.stt.OptionsColumn.AllowEdit = false;
            this.stt.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.stt.Visible = true;
            this.stt.VisibleIndex = 0;
            this.stt.Width = 45;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Nơi ĐKKCBBĐ";
            this.gridColumn2.FieldName = "benhvienkcbbd";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 113;
            // 
            // manv
            // 
            this.manv.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.manv.AppearanceCell.Options.UseFont = true;
            this.manv.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.manv.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.manv.AppearanceHeader.Options.UseFont = true;
            this.manv.AppearanceHeader.Options.UseForeColor = true;
            this.manv.AppearanceHeader.Options.UseTextOptions = true;
            this.manv.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.manv.Caption = "Tên bệnh viện";
            this.manv.FieldName = "benhvienname";
            this.manv.Name = "manv";
            this.manv.OptionsColumn.AllowEdit = false;
            this.manv.Visible = true;
            this.manv.VisibleIndex = 3;
            this.manv.Width = 362;
            // 
            // tennv
            // 
            this.tennv.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tennv.AppearanceCell.Options.UseFont = true;
            this.tennv.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.tennv.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tennv.AppearanceHeader.Options.UseFont = true;
            this.tennv.AppearanceHeader.Options.UseForeColor = true;
            this.tennv.AppearanceHeader.Options.UseTextOptions = true;
            this.tennv.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tennv.Caption = "Địa chỉ";
            this.tennv.FieldName = "benhvienaddress";
            this.tennv.Name = "tennv";
            this.tennv.OptionsColumn.AllowEdit = false;
            this.tennv.Visible = true;
            this.tennv.VisibleIndex = 6;
            this.tennv.Width = 425;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Mã bệnh viện";
            this.gridColumn4.FieldName = "benhviencode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tuyến bệnh viện";
            this.gridColumn3.FieldName = "benhvientuyen";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 116;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Hạng bệnh viện";
            this.gridColumn1.FieldName = "benhvienhang";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 135;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "benhvienid";
            this.gridColumn5.FieldName = "benhvienid";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn6.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "ghichu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 196;
            // 
            // openFileDialogSelect
            // 
            this.openFileDialogSelect.Filter = "Excel 2003|*.xls|Excel 2007-2013|*.xlsx";
            this.openFileDialogSelect.Title = "Mở file Excel";
            // 
            // ucDanhSachBenhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControlNV_DT);
            this.Name = "ucDanhSachBenhVien";
            this.Size = new System.Drawing.Size(1096, 613);
            this.Load += new System.EventHandler(this.ucDanhSachBenhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlNV_DT)).EndInit();
            this.panelControlNV_DT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSBenhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSBenhVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControlNV_DT;
        private DevExpress.XtraGrid.GridControl gridControlDSBenhVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSBenhVien;
        private DevExpress.XtraGrid.Columns.GridColumn manv;
        private DevExpress.XtraGrid.Columns.GridColumn tennv;
        protected internal DevExpress.XtraGrid.Columns.GridColumn stt;
        internal System.Windows.Forms.OpenFileDialog openFileDialogSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}
