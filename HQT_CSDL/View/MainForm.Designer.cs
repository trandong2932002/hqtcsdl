namespace HQT_CSDL.View
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.textFilterTenNV = new System.Windows.Forms.TextBox();
            this.textFilterMaNV = new System.Windows.Forms.TextBox();
            this.comboFilterLoaiLaoDong = new System.Windows.Forms.ComboBox();
            this.textFilterMaPB = new System.Windows.Forms.TextBox();
            this.comboFilterMaCV = new System.Windows.Forms.ComboBox();
            this.textFilterSoDT = new System.Windows.Forms.TextBox();
            this.textFilterTienTheoDonVi = new System.Windows.Forms.TextBox();
            this.comboFilterGioiTinh = new System.Windows.Forms.ComboBox();
            this.buttonFilterClear = new System.Windows.Forms.Button();
            this.buttonFilterFind = new System.Windows.Forms.Button();
            this.groupCreateandEdit = new System.Windows.Forms.GroupBox();
            this.textCreateMaNV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateClear = new System.Windows.Forms.Button();
            this.textCreateTenNV = new System.Windows.Forms.TextBox();
            this.buttonCreateEdit = new System.Windows.Forms.Button();
            this.textCreateSoDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCreateTienTheoDonVi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCreateMaPB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboCreateMaCV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCreateGioiTinh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCreateLoaiLaoDong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataNhanVien = new System.Windows.Forms.DataGridView();
            this.tabChamCong = new System.Windows.Forms.TabPage();
            this.group2TimeChecking = new System.Windows.Forms.GroupBox();
            this.text2CheckMaNV = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2CheckClear = new System.Windows.Forms.Button();
            this.button2CheckCheck = new System.Windows.Forms.Button();
            this.combo2CheckThoiGianLamDonVi = new System.Windows.Forms.ComboBox();
            this.combo2CheckTangCa = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.group2Filter = new System.Windows.Forms.GroupBox();
            this.combo2FilterIsChecked = new System.Windows.Forms.ComboBox();
            this.text2FilterTenNV = new System.Windows.Forms.TextBox();
            this.text2FilterMaNV = new System.Windows.Forms.TextBox();
            this.text2FilterMaPB = new System.Windows.Forms.TextBox();
            this.combo2FilterMaCV = new System.Windows.Forms.ComboBox();
            this.text2FilterThoiGianLamDonVi = new System.Windows.Forms.TextBox();
            this.text2FilterTangCa = new System.Windows.Forms.TextBox();
            this.button2FilterClear = new System.Windows.Forms.Button();
            this.button2FilterFind = new System.Windows.Forms.Button();
            this.dataChamCong = new System.Windows.Forms.DataGridView();
            this.tabTinhLuong = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            this.groupFilter.SuspendLayout();
            this.groupCreateandEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhanVien)).BeginInit();
            this.tabChamCong.SuspendLayout();
            this.group2TimeChecking.SuspendLayout();
            this.group2Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChamCong)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabNhanVien);
            this.tabControl.Controls.Add(this.tabChamCong);
            this.tabControl.Controls.Add(this.tabTinhLuong);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1240, 657);
            this.tabControl.TabIndex = 0;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.groupFilter);
            this.tabNhanVien.Controls.Add(this.groupCreateandEdit);
            this.tabNhanVien.Controls.Add(this.dataNhanVien);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 22);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(1232, 631);
            this.tabNhanVien.TabIndex = 0;
            this.tabNhanVien.Text = "Nhân viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.textFilterTenNV);
            this.groupFilter.Controls.Add(this.textFilterMaNV);
            this.groupFilter.Controls.Add(this.comboFilterLoaiLaoDong);
            this.groupFilter.Controls.Add(this.textFilterMaPB);
            this.groupFilter.Controls.Add(this.comboFilterMaCV);
            this.groupFilter.Controls.Add(this.textFilterSoDT);
            this.groupFilter.Controls.Add(this.textFilterTienTheoDonVi);
            this.groupFilter.Controls.Add(this.comboFilterGioiTinh);
            this.groupFilter.Controls.Add(this.buttonFilterClear);
            this.groupFilter.Controls.Add(this.buttonFilterFind);
            this.groupFilter.Location = new System.Drawing.Point(4, 6);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(889, 53);
            this.groupFilter.TabIndex = 36;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Lọc nhân viên";
            // 
            // textFilterTenNV
            // 
            this.textFilterTenNV.Location = new System.Drawing.Point(186, 19);
            this.textFilterTenNV.Name = "textFilterTenNV";
            this.textFilterTenNV.Size = new System.Drawing.Size(176, 20);
            this.textFilterTenNV.TabIndex = 4;
            // 
            // textFilterMaNV
            // 
            this.textFilterMaNV.Location = new System.Drawing.Point(6, 19);
            this.textFilterMaNV.Name = "textFilterMaNV";
            this.textFilterMaNV.Size = new System.Drawing.Size(56, 20);
            this.textFilterMaNV.TabIndex = 1;
            // 
            // comboFilterLoaiLaoDong
            // 
            this.comboFilterLoaiLaoDong.FormattingEnabled = true;
            this.comboFilterLoaiLaoDong.Location = new System.Drawing.Point(546, 19);
            this.comboFilterLoaiLaoDong.Name = "comboFilterLoaiLaoDong";
            this.comboFilterLoaiLaoDong.Size = new System.Drawing.Size(116, 21);
            this.comboFilterLoaiLaoDong.TabIndex = 7;
            // 
            // textFilterMaPB
            // 
            this.textFilterMaPB.Location = new System.Drawing.Point(66, 19);
            this.textFilterMaPB.Name = "textFilterMaPB";
            this.textFilterMaPB.Size = new System.Drawing.Size(56, 20);
            this.textFilterMaPB.TabIndex = 2;
            // 
            // comboFilterMaCV
            // 
            this.comboFilterMaCV.DropDownWidth = 120;
            this.comboFilterMaCV.FormattingEnabled = true;
            this.comboFilterMaCV.Location = new System.Drawing.Point(126, 19);
            this.comboFilterMaCV.Name = "comboFilterMaCV";
            this.comboFilterMaCV.Size = new System.Drawing.Size(56, 21);
            this.comboFilterMaCV.TabIndex = 3;
            // 
            // textFilterSoDT
            // 
            this.textFilterSoDT.Location = new System.Drawing.Point(426, 19);
            this.textFilterSoDT.Name = "textFilterSoDT";
            this.textFilterSoDT.Size = new System.Drawing.Size(116, 20);
            this.textFilterSoDT.TabIndex = 6;
            // 
            // textFilterTienTheoDonVi
            // 
            this.textFilterTienTheoDonVi.Location = new System.Drawing.Point(666, 19);
            this.textFilterTienTheoDonVi.Name = "textFilterTienTheoDonVi";
            this.textFilterTienTheoDonVi.Size = new System.Drawing.Size(56, 20);
            this.textFilterTienTheoDonVi.TabIndex = 8;
            // 
            // comboFilterGioiTinh
            // 
            this.comboFilterGioiTinh.FormattingEnabled = true;
            this.comboFilterGioiTinh.Location = new System.Drawing.Point(366, 19);
            this.comboFilterGioiTinh.Name = "comboFilterGioiTinh";
            this.comboFilterGioiTinh.Size = new System.Drawing.Size(56, 21);
            this.comboFilterGioiTinh.TabIndex = 5;
            // 
            // buttonFilterClear
            // 
            this.buttonFilterClear.Location = new System.Drawing.Point(809, 18);
            this.buttonFilterClear.Name = "buttonFilterClear";
            this.buttonFilterClear.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterClear.TabIndex = 10;
            this.buttonFilterClear.Text = "Xoá bộ lọc";
            this.buttonFilterClear.UseVisualStyleBackColor = true;
            // 
            // buttonFilterFind
            // 
            this.buttonFilterFind.Location = new System.Drawing.Point(728, 18);
            this.buttonFilterFind.Name = "buttonFilterFind";
            this.buttonFilterFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterFind.TabIndex = 9;
            this.buttonFilterFind.Text = "Tìm kiếm";
            this.buttonFilterFind.UseVisualStyleBackColor = true;
            // 
            // groupCreateandEdit
            // 
            this.groupCreateandEdit.Controls.Add(this.textCreateMaNV);
            this.groupCreateandEdit.Controls.Add(this.label8);
            this.groupCreateandEdit.Controls.Add(this.buttonDelete);
            this.groupCreateandEdit.Controls.Add(this.labelStatus);
            this.groupCreateandEdit.Controls.Add(this.label1);
            this.groupCreateandEdit.Controls.Add(this.buttonCreateClear);
            this.groupCreateandEdit.Controls.Add(this.textCreateTenNV);
            this.groupCreateandEdit.Controls.Add(this.buttonCreateEdit);
            this.groupCreateandEdit.Controls.Add(this.textCreateSoDT);
            this.groupCreateandEdit.Controls.Add(this.label7);
            this.groupCreateandEdit.Controls.Add(this.textCreateTienTheoDonVi);
            this.groupCreateandEdit.Controls.Add(this.label6);
            this.groupCreateandEdit.Controls.Add(this.comboCreateMaPB);
            this.groupCreateandEdit.Controls.Add(this.label5);
            this.groupCreateandEdit.Controls.Add(this.comboCreateMaCV);
            this.groupCreateandEdit.Controls.Add(this.label4);
            this.groupCreateandEdit.Controls.Add(this.comboCreateGioiTinh);
            this.groupCreateandEdit.Controls.Add(this.label3);
            this.groupCreateandEdit.Controls.Add(this.comboCreateLoaiLaoDong);
            this.groupCreateandEdit.Controls.Add(this.label2);
            this.groupCreateandEdit.Location = new System.Drawing.Point(906, 6);
            this.groupCreateandEdit.Name = "groupCreateandEdit";
            this.groupCreateandEdit.Size = new System.Drawing.Size(317, 527);
            this.groupCreateandEdit.TabIndex = 35;
            this.groupCreateandEdit.TabStop = false;
            this.groupCreateandEdit.Text = "Thêm/Sửa nhân viên";
            // 
            // textCreateMaNV
            // 
            this.textCreateMaNV.Location = new System.Drawing.Point(140, 62);
            this.textCreateMaNV.Name = "textCreateMaNV";
            this.textCreateMaNV.Size = new System.Drawing.Size(140, 20);
            this.textCreateMaNV.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Mã Nhân viên";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(48, 443);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(74, 23);
            this.buttonDelete.TabIndex = 36;
            this.buttonDelete.Text = "Xoá";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelStatus.Location = new System.Drawing.Point(74, 30);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(182, 13);
            this.labelStatus.TabIndex = 35;
            this.labelStatus.Text = "BẠN ĐANG THÊM NHÂN VIÊN MỚI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã Phòng ban";
            // 
            // buttonCreateClear
            // 
            this.buttonCreateClear.Location = new System.Drawing.Point(145, 443);
            this.buttonCreateClear.Name = "buttonCreateClear";
            this.buttonCreateClear.Size = new System.Drawing.Size(60, 23);
            this.buttonCreateClear.TabIndex = 34;
            this.buttonCreateClear.Text = "Huỷ";
            this.buttonCreateClear.UseVisualStyleBackColor = true;
            // 
            // textCreateTenNV
            // 
            this.textCreateTenNV.Location = new System.Drawing.Point(140, 206);
            this.textCreateTenNV.Name = "textCreateTenNV";
            this.textCreateTenNV.Size = new System.Drawing.Size(140, 20);
            this.textCreateTenNV.TabIndex = 17;
            // 
            // buttonCreateEdit
            // 
            this.buttonCreateEdit.Location = new System.Drawing.Point(215, 443);
            this.buttonCreateEdit.Name = "buttonCreateEdit";
            this.buttonCreateEdit.Size = new System.Drawing.Size(60, 23);
            this.buttonCreateEdit.TabIndex = 33;
            this.buttonCreateEdit.Text = "Thêm";
            this.buttonCreateEdit.UseVisualStyleBackColor = true;
            // 
            // textCreateSoDT
            // 
            this.textCreateSoDT.Location = new System.Drawing.Point(140, 302);
            this.textCreateSoDT.Name = "textCreateSoDT";
            this.textCreateSoDT.Size = new System.Drawing.Size(140, 20);
            this.textCreateSoDT.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tiền theo đơn vị";
            // 
            // textCreateTienTheoDonVi
            // 
            this.textCreateTienTheoDonVi.Location = new System.Drawing.Point(140, 398);
            this.textCreateTienTheoDonVi.Name = "textCreateTienTheoDonVi";
            this.textCreateTienTheoDonVi.Size = new System.Drawing.Size(140, 20);
            this.textCreateTienTheoDonVi.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Loại lao động";
            // 
            // comboCreateMaPB
            // 
            this.comboCreateMaPB.FormattingEnabled = true;
            this.comboCreateMaPB.Location = new System.Drawing.Point(140, 110);
            this.comboCreateMaPB.Name = "comboCreateMaPB";
            this.comboCreateMaPB.Size = new System.Drawing.Size(140, 21);
            this.comboCreateMaPB.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Số điện thoại";
            // 
            // comboCreateMaCV
            // 
            this.comboCreateMaCV.FormattingEnabled = true;
            this.comboCreateMaCV.Location = new System.Drawing.Point(140, 158);
            this.comboCreateMaCV.Name = "comboCreateMaCV";
            this.comboCreateMaCV.Size = new System.Drawing.Size(140, 21);
            this.comboCreateMaCV.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Giới tính";
            // 
            // comboCreateGioiTinh
            // 
            this.comboCreateGioiTinh.FormattingEnabled = true;
            this.comboCreateGioiTinh.Location = new System.Drawing.Point(140, 254);
            this.comboCreateGioiTinh.Name = "comboCreateGioiTinh";
            this.comboCreateGioiTinh.Size = new System.Drawing.Size(140, 21);
            this.comboCreateGioiTinh.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Họ vả Tên";
            // 
            // comboCreateLoaiLaoDong
            // 
            this.comboCreateLoaiLaoDong.FormattingEnabled = true;
            this.comboCreateLoaiLaoDong.Location = new System.Drawing.Point(140, 350);
            this.comboCreateLoaiLaoDong.Name = "comboCreateLoaiLaoDong";
            this.comboCreateLoaiLaoDong.Size = new System.Drawing.Size(140, 21);
            this.comboCreateLoaiLaoDong.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Mã Công việc";
            // 
            // dataNhanVien
            // 
            this.dataNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNhanVien.Location = new System.Drawing.Point(6, 65);
            this.dataNhanVien.Name = "dataNhanVien";
            this.dataNhanVien.Size = new System.Drawing.Size(881, 560);
            this.dataNhanVien.TabIndex = 0;
            // 
            // tabChamCong
            // 
            this.tabChamCong.Controls.Add(this.group2TimeChecking);
            this.tabChamCong.Controls.Add(this.group2Filter);
            this.tabChamCong.Controls.Add(this.dataChamCong);
            this.tabChamCong.Location = new System.Drawing.Point(4, 22);
            this.tabChamCong.Name = "tabChamCong";
            this.tabChamCong.Padding = new System.Windows.Forms.Padding(3);
            this.tabChamCong.Size = new System.Drawing.Size(1232, 631);
            this.tabChamCong.TabIndex = 1;
            this.tabChamCong.Text = "Chấm công";
            this.tabChamCong.UseVisualStyleBackColor = true;
            // 
            // group2TimeChecking
            // 
            this.group2TimeChecking.Controls.Add(this.text2CheckMaNV);
            this.group2TimeChecking.Controls.Add(this.label9);
            this.group2TimeChecking.Controls.Add(this.label10);
            this.group2TimeChecking.Controls.Add(this.label11);
            this.group2TimeChecking.Controls.Add(this.button2CheckClear);
            this.group2TimeChecking.Controls.Add(this.button2CheckCheck);
            this.group2TimeChecking.Controls.Add(this.combo2CheckThoiGianLamDonVi);
            this.group2TimeChecking.Controls.Add(this.combo2CheckTangCa);
            this.group2TimeChecking.Controls.Add(this.label17);
            this.group2TimeChecking.Location = new System.Drawing.Point(906, 6);
            this.group2TimeChecking.Name = "group2TimeChecking";
            this.group2TimeChecking.Size = new System.Drawing.Size(317, 278);
            this.group2TimeChecking.TabIndex = 38;
            this.group2TimeChecking.TabStop = false;
            this.group2TimeChecking.Text = "Thêm/Sửa nhân viên";
            // 
            // text2CheckMaNV
            // 
            this.text2CheckMaNV.Enabled = false;
            this.text2CheckMaNV.Location = new System.Drawing.Point(140, 62);
            this.text2CheckMaNV.Name = "text2CheckMaNV";
            this.text2CheckMaNV.Size = new System.Drawing.Size(140, 20);
            this.text2CheckMaNV.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Mã Nhân viên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(129, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "CHẤM CÔNG";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Thời gian làm đơn vị";
            // 
            // button2CheckClear
            // 
            this.button2CheckClear.Location = new System.Drawing.Point(108, 203);
            this.button2CheckClear.Name = "button2CheckClear";
            this.button2CheckClear.Size = new System.Drawing.Size(60, 23);
            this.button2CheckClear.TabIndex = 34;
            this.button2CheckClear.Text = "Huỷ";
            this.button2CheckClear.UseVisualStyleBackColor = true;
            // 
            // button2CheckCheck
            // 
            this.button2CheckCheck.Location = new System.Drawing.Point(178, 203);
            this.button2CheckCheck.Name = "button2CheckCheck";
            this.button2CheckCheck.Size = new System.Drawing.Size(60, 23);
            this.button2CheckCheck.TabIndex = 33;
            this.button2CheckCheck.Text = "Chấm";
            this.button2CheckCheck.UseVisualStyleBackColor = true;
            // 
            // combo2CheckThoiGianLamDonVi
            // 
            this.combo2CheckThoiGianLamDonVi.Enabled = false;
            this.combo2CheckThoiGianLamDonVi.FormattingEnabled = true;
            this.combo2CheckThoiGianLamDonVi.Location = new System.Drawing.Point(140, 110);
            this.combo2CheckThoiGianLamDonVi.Name = "combo2CheckThoiGianLamDonVi";
            this.combo2CheckThoiGianLamDonVi.Size = new System.Drawing.Size(140, 21);
            this.combo2CheckThoiGianLamDonVi.TabIndex = 22;
            // 
            // combo2CheckTangCa
            // 
            this.combo2CheckTangCa.Enabled = false;
            this.combo2CheckTangCa.FormattingEnabled = true;
            this.combo2CheckTangCa.Location = new System.Drawing.Point(140, 158);
            this.combo2CheckTangCa.Name = "combo2CheckTangCa";
            this.combo2CheckTangCa.Size = new System.Drawing.Size(140, 21);
            this.combo2CheckTangCa.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 162);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Tăng ca";
            // 
            // group2Filter
            // 
            this.group2Filter.Controls.Add(this.combo2FilterIsChecked);
            this.group2Filter.Controls.Add(this.text2FilterTenNV);
            this.group2Filter.Controls.Add(this.text2FilterMaNV);
            this.group2Filter.Controls.Add(this.text2FilterMaPB);
            this.group2Filter.Controls.Add(this.combo2FilterMaCV);
            this.group2Filter.Controls.Add(this.text2FilterThoiGianLamDonVi);
            this.group2Filter.Controls.Add(this.text2FilterTangCa);
            this.group2Filter.Controls.Add(this.button2FilterClear);
            this.group2Filter.Controls.Add(this.button2FilterFind);
            this.group2Filter.Location = new System.Drawing.Point(4, 6);
            this.group2Filter.Name = "group2Filter";
            this.group2Filter.Size = new System.Drawing.Size(889, 53);
            this.group2Filter.TabIndex = 37;
            this.group2Filter.TabStop = false;
            this.group2Filter.Text = "Lọc nhân viên";
            // 
            // combo2FilterIsChecked
            // 
            this.combo2FilterIsChecked.DropDownWidth = 120;
            this.combo2FilterIsChecked.FormattingEnabled = true;
            this.combo2FilterIsChecked.Location = new System.Drawing.Point(636, 19);
            this.combo2FilterIsChecked.Name = "combo2FilterIsChecked";
            this.combo2FilterIsChecked.Size = new System.Drawing.Size(86, 21);
            this.combo2FilterIsChecked.TabIndex = 7;
            // 
            // text2FilterTenNV
            // 
            this.text2FilterTenNV.Location = new System.Drawing.Point(276, 19);
            this.text2FilterTenNV.Name = "text2FilterTenNV";
            this.text2FilterTenNV.Size = new System.Drawing.Size(176, 20);
            this.text2FilterTenNV.TabIndex = 4;
            // 
            // text2FilterMaNV
            // 
            this.text2FilterMaNV.Location = new System.Drawing.Point(6, 19);
            this.text2FilterMaNV.Name = "text2FilterMaNV";
            this.text2FilterMaNV.Size = new System.Drawing.Size(86, 20);
            this.text2FilterMaNV.TabIndex = 1;
            // 
            // text2FilterMaPB
            // 
            this.text2FilterMaPB.Location = new System.Drawing.Point(96, 19);
            this.text2FilterMaPB.Name = "text2FilterMaPB";
            this.text2FilterMaPB.Size = new System.Drawing.Size(86, 20);
            this.text2FilterMaPB.TabIndex = 2;
            // 
            // combo2FilterMaCV
            // 
            this.combo2FilterMaCV.DropDownWidth = 120;
            this.combo2FilterMaCV.FormattingEnabled = true;
            this.combo2FilterMaCV.Location = new System.Drawing.Point(186, 19);
            this.combo2FilterMaCV.Name = "combo2FilterMaCV";
            this.combo2FilterMaCV.Size = new System.Drawing.Size(86, 21);
            this.combo2FilterMaCV.TabIndex = 3;
            // 
            // text2FilterThoiGianLamDonVi
            // 
            this.text2FilterThoiGianLamDonVi.Location = new System.Drawing.Point(456, 19);
            this.text2FilterThoiGianLamDonVi.Name = "text2FilterThoiGianLamDonVi";
            this.text2FilterThoiGianLamDonVi.Size = new System.Drawing.Size(86, 20);
            this.text2FilterThoiGianLamDonVi.TabIndex = 5;
            // 
            // text2FilterTangCa
            // 
            this.text2FilterTangCa.Location = new System.Drawing.Point(546, 19);
            this.text2FilterTangCa.Name = "text2FilterTangCa";
            this.text2FilterTangCa.Size = new System.Drawing.Size(86, 20);
            this.text2FilterTangCa.TabIndex = 6;
            // 
            // button2FilterClear
            // 
            this.button2FilterClear.Location = new System.Drawing.Point(809, 18);
            this.button2FilterClear.Name = "button2FilterClear";
            this.button2FilterClear.Size = new System.Drawing.Size(75, 23);
            this.button2FilterClear.TabIndex = 9;
            this.button2FilterClear.Text = "Xoá bộ lọc";
            this.button2FilterClear.UseVisualStyleBackColor = true;
            // 
            // button2FilterFind
            // 
            this.button2FilterFind.Location = new System.Drawing.Point(728, 18);
            this.button2FilterFind.Name = "button2FilterFind";
            this.button2FilterFind.Size = new System.Drawing.Size(75, 23);
            this.button2FilterFind.TabIndex = 8;
            this.button2FilterFind.Text = "Tìm kiếm";
            this.button2FilterFind.UseVisualStyleBackColor = true;
            // 
            // dataChamCong
            // 
            this.dataChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataChamCong.Location = new System.Drawing.Point(6, 65);
            this.dataChamCong.Name = "dataChamCong";
            this.dataChamCong.Size = new System.Drawing.Size(881, 560);
            this.dataChamCong.TabIndex = 0;
            // 
            // tabTinhLuong
            // 
            this.tabTinhLuong.Location = new System.Drawing.Point(4, 22);
            this.tabTinhLuong.Name = "tabTinhLuong";
            this.tabTinhLuong.Padding = new System.Windows.Forms.Padding(3);
            this.tabTinhLuong.Size = new System.Drawing.Size(1232, 631);
            this.tabTinhLuong.TabIndex = 2;
            this.tabTinhLuong.Text = "Bảng Lương";
            this.tabTinhLuong.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "HQT_CSDL_NHOM_14: QUAN LY LUONG NHAN VIEN";
            this.tabControl.ResumeLayout(false);
            this.tabNhanVien.ResumeLayout(false);
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.groupCreateandEdit.ResumeLayout(false);
            this.groupCreateandEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhanVien)).EndInit();
            this.tabChamCong.ResumeLayout(false);
            this.group2TimeChecking.ResumeLayout(false);
            this.group2TimeChecking.PerformLayout();
            this.group2Filter.ResumeLayout(false);
            this.group2Filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChamCong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabChamCong;
        private System.Windows.Forms.TabPage tabTinhLuong;
        private System.Windows.Forms.DataGridView dataNhanVien;
        private System.Windows.Forms.TextBox textFilterMaNV;
        private System.Windows.Forms.TextBox textFilterMaPB;
        private System.Windows.Forms.TextBox textFilterTenNV;
        private System.Windows.Forms.TextBox textFilterSoDT;
        private System.Windows.Forms.TextBox textFilterTienTheoDonVi;
        private System.Windows.Forms.Button buttonFilterClear;
        private System.Windows.Forms.Button buttonFilterFind;
        private System.Windows.Forms.ComboBox comboFilterGioiTinh;
        private System.Windows.Forms.ComboBox comboFilterMaCV;
        private System.Windows.Forms.ComboBox comboFilterLoaiLaoDong;
        private System.Windows.Forms.ComboBox comboCreateLoaiLaoDong;
        private System.Windows.Forms.ComboBox comboCreateGioiTinh;
        private System.Windows.Forms.ComboBox comboCreateMaCV;
        private System.Windows.Forms.ComboBox comboCreateMaPB;
        private System.Windows.Forms.TextBox textCreateTienTheoDonVi;
        private System.Windows.Forms.TextBox textCreateSoDT;
        private System.Windows.Forms.TextBox textCreateTenNV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateClear;
        private System.Windows.Forms.Button buttonCreateEdit;
        private System.Windows.Forms.GroupBox groupCreateandEdit;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textCreateMaNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataChamCong;
        private System.Windows.Forms.GroupBox group2Filter;
        private System.Windows.Forms.TextBox text2FilterTenNV;
        private System.Windows.Forms.TextBox text2FilterMaNV;
        private System.Windows.Forms.TextBox text2FilterMaPB;
        private System.Windows.Forms.ComboBox combo2FilterMaCV;
        private System.Windows.Forms.TextBox text2FilterThoiGianLamDonVi;
        private System.Windows.Forms.TextBox text2FilterTangCa;
        private System.Windows.Forms.Button button2FilterClear;
        private System.Windows.Forms.Button button2FilterFind;
        private System.Windows.Forms.GroupBox group2TimeChecking;
        private System.Windows.Forms.TextBox text2CheckMaNV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2CheckClear;
        private System.Windows.Forms.Button button2CheckCheck;
        private System.Windows.Forms.ComboBox combo2CheckThoiGianLamDonVi;
        private System.Windows.Forms.ComboBox combo2CheckTangCa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox combo2FilterIsChecked;
    }
}

