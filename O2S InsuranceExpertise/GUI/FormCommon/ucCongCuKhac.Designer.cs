namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    partial class ucCongCuKhac
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
            this.xtraTabControlCongCuKhac = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTab_KiemTraThongTuyen = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTab_BaoCao = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDSBaoCao = new DevExpress.XtraGrid.GridControl();
            this.gridViewDSBaoCao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDSBCColumeStt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.permissioncheck1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlCongCuKhac)).BeginInit();
            this.xtraTabControlCongCuKhac.SuspendLayout();
            this.xtraTab_BaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlCongCuKhac
            // 
            this.xtraTabControlCongCuKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlCongCuKhac.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlCongCuKhac.Name = "xtraTabControlCongCuKhac";
            this.xtraTabControlCongCuKhac.SelectedTabPage = this.xtraTab_KiemTraThongTuyen;
            this.xtraTabControlCongCuKhac.Size = new System.Drawing.Size(1000, 613);
            this.xtraTabControlCongCuKhac.TabIndex = 0;
            this.xtraTabControlCongCuKhac.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTab_KiemTraThongTuyen,
            this.xtraTab_BaoCao});
            this.xtraTabControlCongCuKhac.TabPageWidth = 160;
            this.xtraTabControlCongCuKhac.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlCongCuKhac_SelectedPageChanged);
            this.xtraTabControlCongCuKhac.CloseButtonClick += new System.EventHandler(this.xtraTabControlCongCuKhac_CloseButtonClick);
            // 
            // xtraTab_KiemTraThongTuyen
            // 
            this.xtraTab_KiemTraThongTuyen.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTab_KiemTraThongTuyen.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_KiemTraThongTuyen.Appearance.Header.Options.UseFont = true;
            this.xtraTab_KiemTraThongTuyen.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_KiemTraThongTuyen.Image = global::O2S_InsuranceExpertise.Properties.Resources.checkmark_16;
            this.xtraTab_KiemTraThongTuyen.Name = "xtraTab_KiemTraThongTuyen";
            this.xtraTab_KiemTraThongTuyen.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_KiemTraThongTuyen.Size = new System.Drawing.Size(994, 582);
            this.xtraTab_KiemTraThongTuyen.Text = "Kiểm tra thông tuyến";
            // 
            // xtraTab_BaoCao
            // 
            this.xtraTab_BaoCao.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTab_BaoCao.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_BaoCao.Appearance.Header.Options.UseFont = true;
            this.xtraTab_BaoCao.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_BaoCao.Controls.Add(this.gridControlDSBaoCao);
            this.xtraTab_BaoCao.Image = global::O2S_InsuranceExpertise.Properties.Resources.excel_3_16;
            this.xtraTab_BaoCao.Name = "xtraTab_BaoCao";
            this.xtraTab_BaoCao.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_BaoCao.Size = new System.Drawing.Size(994, 582);
            this.xtraTab_BaoCao.Text = "Báo cáo";
            // 
            // gridControlDSBaoCao
            // 
            this.gridControlDSBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDSBaoCao.Location = new System.Drawing.Point(0, 0);
            this.gridControlDSBaoCao.MainView = this.gridViewDSBaoCao;
            this.gridControlDSBaoCao.Name = "gridControlDSBaoCao";
            this.gridControlDSBaoCao.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gridControlDSBaoCao.Size = new System.Drawing.Size(994, 582);
            this.gridControlDSBaoCao.TabIndex = 5;
            this.gridControlDSBaoCao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSBaoCao});
            // 
            // gridViewDSBaoCao
            // 
            this.gridViewDSBaoCao.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridViewDSBaoCao.Appearance.Row.Options.UseFont = true;
            this.gridViewDSBaoCao.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridViewDSBaoCao.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridViewDSBaoCao.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewDSBaoCao.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewDSBaoCao.ColumnPanelRowHeight = 25;
            this.gridViewDSBaoCao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridDSBCColumeStt,
            this.gridColumn7,
            this.gridColumn8,
            this.permissioncheck1,
            this.gridColumn4});
            this.gridViewDSBaoCao.GridControl = this.gridControlDSBaoCao;
            this.gridViewDSBaoCao.Name = "gridViewDSBaoCao";
            this.gridViewDSBaoCao.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDSBaoCao.OptionsView.ShowGroupPanel = false;
            this.gridViewDSBaoCao.RowHeight = 25;
            this.gridViewDSBaoCao.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewDSBaoCao_CustomDrawCell);
            this.gridViewDSBaoCao.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDSBaoCao_RowCellStyle);
            this.gridViewDSBaoCao.DoubleClick += new System.EventHandler(this.gridViewDSBaoCao_DoubleClick);
            // 
            // gridDSBCColumeStt
            // 
            this.gridDSBCColumeStt.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridDSBCColumeStt.AppearanceCell.Options.UseFont = true;
            this.gridDSBCColumeStt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridDSBCColumeStt.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridDSBCColumeStt.AppearanceHeader.Options.UseFont = true;
            this.gridDSBCColumeStt.AppearanceHeader.Options.UseForeColor = true;
            this.gridDSBCColumeStt.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDSBCColumeStt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDSBCColumeStt.Caption = "STT";
            this.gridDSBCColumeStt.FieldName = "stt";
            this.gridDSBCColumeStt.Name = "gridDSBCColumeStt";
            this.gridDSBCColumeStt.OptionsColumn.AllowEdit = false;
            this.gridDSBCColumeStt.OptionsColumn.FixedWidth = true;
            this.gridDSBCColumeStt.Visible = true;
            this.gridDSBCColumeStt.VisibleIndex = 0;
            this.gridDSBCColumeStt.Width = 45;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn7.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Mã";
            this.gridColumn7.FieldName = "permissioncode";
            this.gridColumn7.MinWidth = 100;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 141;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn8.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Tên chương trình";
            this.gridColumn8.FieldName = "permissionname";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 521;
            // 
            // permissioncheck1
            // 
            this.permissioncheck1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.permissioncheck1.AppearanceCell.Options.UseFont = true;
            this.permissioncheck1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.permissioncheck1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.permissioncheck1.AppearanceHeader.Options.UseFont = true;
            this.permissioncheck1.AppearanceHeader.Options.UseForeColor = true;
            this.permissioncheck1.AppearanceHeader.Options.UseTextOptions = true;
            this.permissioncheck1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.permissioncheck1.Caption = "Phân quyền";
            this.permissioncheck1.ColumnEdit = this.repositoryItemCheckEdit2;
            this.permissioncheck1.FieldName = "permissioncheck";
            this.permissioncheck1.Name = "permissioncheck1";
            this.permissioncheck1.OptionsColumn.AllowEdit = false;
            this.permissioncheck1.OptionsColumn.FixedWidth = true;
            this.permissioncheck1.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.permissioncheck1.Width = 70;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Ghi chú";
            this.gridColumn4.FieldName = "permissionnote";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 427;
            // 
            // ucCongCuKhac
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xtraTabControlCongCuKhac);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCongCuKhac";
            this.Size = new System.Drawing.Size(1000, 613);
            this.Load += new System.EventHandler(this.ucHoSoBenhAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlCongCuKhac)).EndInit();
            this.xtraTabControlCongCuKhac.ResumeLayout(false);
            this.xtraTab_BaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControlCongCuKhac;
        private DevExpress.XtraTab.XtraTabPage xtraTab_KiemTraThongTuyen;
        private DevExpress.XtraTab.XtraTabPage xtraTab_BaoCao;
        private DevExpress.XtraGrid.GridControl gridControlDSBaoCao;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSBaoCao;
        private DevExpress.XtraGrid.Columns.GridColumn gridDSBCColumeStt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn permissioncheck1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
