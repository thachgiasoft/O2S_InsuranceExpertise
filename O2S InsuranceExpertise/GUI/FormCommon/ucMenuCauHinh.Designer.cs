namespace O2S_InsuranceExpertise.GUI.FormCommon
{
    partial class ucMenuCauHinh
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
            this.xtraTab_CHDanhMuc = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControlCaiDat = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemDM_DVKT = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDM_Thuoc = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDM_VatTu = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDM_NgayGiuong = new DevExpress.XtraNavBar.NavBarItem();
            this.panelCauHinhNoiDung = new DevExpress.XtraEditors.PanelControl();
            this.xtraTab_CHTheXML = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlCongCuKhac)).BeginInit();
            this.xtraTabControlCongCuKhac.SuspendLayout();
            this.xtraTab_CHDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlCaiDat)).BeginInit();
            this.splitContainerControlCaiDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCauHinhNoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlCongCuKhac
            // 
            this.xtraTabControlCongCuKhac.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControlCongCuKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlCongCuKhac.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlCongCuKhac.Name = "xtraTabControlCongCuKhac";
            this.xtraTabControlCongCuKhac.SelectedTabPage = this.xtraTab_CHDanhMuc;
            this.xtraTabControlCongCuKhac.Size = new System.Drawing.Size(1000, 613);
            this.xtraTabControlCongCuKhac.TabIndex = 0;
            this.xtraTabControlCongCuKhac.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTab_CHDanhMuc,
            this.xtraTab_CHTheXML});
            this.xtraTabControlCongCuKhac.TabPageWidth = 160;
            this.xtraTabControlCongCuKhac.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlCongCuKhac_SelectedPageChanged);
            this.xtraTabControlCongCuKhac.CloseButtonClick += new System.EventHandler(this.xtraTabControlCongCuKhac_CloseButtonClick);
            // 
            // xtraTab_CHDanhMuc
            // 
            this.xtraTab_CHDanhMuc.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTab_CHDanhMuc.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_CHDanhMuc.Appearance.Header.Options.UseFont = true;
            this.xtraTab_CHDanhMuc.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_CHDanhMuc.Controls.Add(this.splitContainerControlCaiDat);
            this.xtraTab_CHDanhMuc.Image = global::O2S_InsuranceExpertise.Properties.Resources.list_rich_16;
            this.xtraTab_CHDanhMuc.Name = "xtraTab_CHDanhMuc";
            this.xtraTab_CHDanhMuc.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_CHDanhMuc.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_CHDanhMuc.Size = new System.Drawing.Size(994, 582);
            this.xtraTab_CHDanhMuc.Text = "Danh Mục";
            this.xtraTab_CHDanhMuc.Tooltip = "Cấu hình - Danh mục";
            // 
            // splitContainerControlCaiDat
            // 
            this.splitContainerControlCaiDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlCaiDat.Location = new System.Drawing.Point(0, 10);
            this.splitContainerControlCaiDat.Name = "splitContainerControlCaiDat";
            this.splitContainerControlCaiDat.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControlCaiDat.Panel1.Text = "Panel1";
            this.splitContainerControlCaiDat.Panel2.Controls.Add(this.panelCauHinhNoiDung);
            this.splitContainerControlCaiDat.Panel2.Text = "Panel2";
            this.splitContainerControlCaiDat.Size = new System.Drawing.Size(994, 572);
            this.splitContainerControlCaiDat.SplitterPosition = 194;
            this.splitContainerControlCaiDat.TabIndex = 1;
            this.splitContainerControlCaiDat.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemDM_DVKT,
            this.navBarItemDM_Thuoc,
            this.navBarItemDM_VatTu,
            this.navBarItemDM_NgayGiuong});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 194;
            this.navBarControl1.Size = new System.Drawing.Size(194, 572);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.Appearance.Options.UseForeColor = true;
            this.navBarGroup1.Caption = "DANH MỤC";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_DVKT),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_Thuoc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_VatTu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_NgayGiuong)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarItemDM_DVKT
            // 
            this.navBarItemDM_DVKT.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_DVKT.Appearance.Options.UseFont = true;
            this.navBarItemDM_DVKT.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_DVKT.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_DVKT.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_DVKT.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_DVKT.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_DVKT.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_DVKT.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_DVKT.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_DVKT.Caption = "Danh mục DVKT";
            this.navBarItemDM_DVKT.Name = "navBarItemDM_DVKT";
            this.navBarItemDM_DVKT.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_DVKT_LinkClicked);
            // 
            // navBarItemDM_Thuoc
            // 
            this.navBarItemDM_Thuoc.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Thuoc.Appearance.Options.UseFont = true;
            this.navBarItemDM_Thuoc.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Thuoc.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_Thuoc.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Thuoc.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_Thuoc.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_Thuoc.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_Thuoc.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Thuoc.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_Thuoc.Caption = "Danh mục Thuốc";
            this.navBarItemDM_Thuoc.Name = "navBarItemDM_Thuoc";
            this.navBarItemDM_Thuoc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_Thuoc_LinkClicked);
            // 
            // navBarItemDM_VatTu
            // 
            this.navBarItemDM_VatTu.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.navBarItemDM_VatTu.Appearance.Options.UseFont = true;
            this.navBarItemDM_VatTu.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_VatTu.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_VatTu.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.navBarItemDM_VatTu.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_VatTu.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_VatTu.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_VatTu.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_VatTu.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_VatTu.Caption = "Danh mục Vật tư";
            this.navBarItemDM_VatTu.Name = "navBarItemDM_VatTu";
            this.navBarItemDM_VatTu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_VatTu_LinkClicked);
            // 
            // navBarItemDM_NgayGiuong
            // 
            this.navBarItemDM_NgayGiuong.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.navBarItemDM_NgayGiuong.Appearance.Options.UseFont = true;
            this.navBarItemDM_NgayGiuong.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_NgayGiuong.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_NgayGiuong.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.navBarItemDM_NgayGiuong.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_NgayGiuong.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_NgayGiuong.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_NgayGiuong.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_NgayGiuong.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_NgayGiuong.Caption = "Danh mục Ngày giường";
            this.navBarItemDM_NgayGiuong.Name = "navBarItemDM_NgayGiuong";
            this.navBarItemDM_NgayGiuong.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_NgayGiuong_LinkClicked);
            // 
            // panelCauHinhNoiDung
            // 
            this.panelCauHinhNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCauHinhNoiDung.Location = new System.Drawing.Point(0, 0);
            this.panelCauHinhNoiDung.Name = "panelCauHinhNoiDung";
            this.panelCauHinhNoiDung.Size = new System.Drawing.Size(795, 572);
            this.panelCauHinhNoiDung.TabIndex = 0;
            // 
            // xtraTab_CHTheXML
            // 
            this.xtraTab_CHTheXML.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTab_CHTheXML.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_CHTheXML.Appearance.Header.Options.UseFont = true;
            this.xtraTab_CHTheXML.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_CHTheXML.Image = global::O2S_InsuranceExpertise.Properties.Resources.xml_161;
            this.xtraTab_CHTheXML.Name = "xtraTab_CHTheXML";
            this.xtraTab_CHTheXML.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_CHTheXML.Size = new System.Drawing.Size(994, 582);
            this.xtraTab_CHTheXML.Text = "Thẻ XML";
            this.xtraTab_CHTheXML.Tooltip = "Cấu hình - Thẻ XML";
            // 
            // ucMenuCauHinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xtraTabControlCongCuKhac);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMenuCauHinh";
            this.Size = new System.Drawing.Size(1000, 613);
            this.Load += new System.EventHandler(this.ucHoSoBenhAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlCongCuKhac)).EndInit();
            this.xtraTabControlCongCuKhac.ResumeLayout(false);
            this.xtraTab_CHDanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlCaiDat)).EndInit();
            this.splitContainerControlCaiDat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCauHinhNoiDung)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControlCongCuKhac;
        private DevExpress.XtraTab.XtraTabPage xtraTab_CHDanhMuc;
        private DevExpress.XtraTab.XtraTabPage xtraTab_CHTheXML;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlCaiDat;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_DVKT;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_Thuoc;
        private DevExpress.XtraEditors.PanelControl panelCauHinhNoiDung;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_VatTu;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_NgayGiuong;
    }
}
