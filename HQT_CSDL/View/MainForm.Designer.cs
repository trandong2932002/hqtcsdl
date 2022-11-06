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
            this.textFilterTienTheoDonVi = new System.Windows.Forms.TextBox();
            this.textFilterSoDT = new System.Windows.Forms.TextBox();
            this.textFilterTenNV = new System.Windows.Forms.TextBox();
            this.textFilterMaPB = new System.Windows.Forms.TextBox();
            this.textFilterMaNV = new System.Windows.Forms.TextBox();
            this.dataNhanVien = new System.Windows.Forms.DataGridView();
            this.tabChamCong = new System.Windows.Forms.TabPage();
            this.tabTinhLuong = new System.Windows.Forms.TabPage();
            this.buttonFilterClear = new System.Windows.Forms.Button();
            this.buttonFilterFind = new System.Windows.Forms.Button();
            this.comboFilterGioiTinh = new System.Windows.Forms.ComboBox();
            this.buttonFilterReset = new System.Windows.Forms.Button();
            this.comboFilterMaCV = new System.Windows.Forms.ComboBox();
            this.comboFilterLoaiLaoDong = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhanVien)).BeginInit();
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
            this.tabNhanVien.Controls.Add(this.comboFilterLoaiLaoDong);
            this.tabNhanVien.Controls.Add(this.comboFilterMaCV);
            this.tabNhanVien.Controls.Add(this.buttonFilterReset);
            this.tabNhanVien.Controls.Add(this.comboFilterGioiTinh);
            this.tabNhanVien.Controls.Add(this.buttonFilterFind);
            this.tabNhanVien.Controls.Add(this.buttonFilterClear);
            this.tabNhanVien.Controls.Add(this.textFilterTienTheoDonVi);
            this.tabNhanVien.Controls.Add(this.textFilterSoDT);
            this.tabNhanVien.Controls.Add(this.textFilterTenNV);
            this.tabNhanVien.Controls.Add(this.textFilterMaPB);
            this.tabNhanVien.Controls.Add(this.textFilterMaNV);
            this.tabNhanVien.Controls.Add(this.dataNhanVien);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 22);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(1232, 631);
            this.tabNhanVien.TabIndex = 0;
            this.tabNhanVien.Text = "Nhân viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // textFilterTienTheoDonVi
            // 
            this.textFilterTienTheoDonVi.Location = new System.Drawing.Point(669, 63);
            this.textFilterTienTheoDonVi.Name = "textFilterTienTheoDonVi";
            this.textFilterTienTheoDonVi.Size = new System.Drawing.Size(56, 20);
            this.textFilterTienTheoDonVi.TabIndex = 8;
            // 
            // textFilterSoDT
            // 
            this.textFilterSoDT.Location = new System.Drawing.Point(429, 63);
            this.textFilterSoDT.Name = "textFilterSoDT";
            this.textFilterSoDT.Size = new System.Drawing.Size(116, 20);
            this.textFilterSoDT.TabIndex = 6;
            // 
            // textFilterTenNV
            // 
            this.textFilterTenNV.Location = new System.Drawing.Point(189, 63);
            this.textFilterTenNV.Name = "textFilterTenNV";
            this.textFilterTenNV.Size = new System.Drawing.Size(176, 20);
            this.textFilterTenNV.TabIndex = 4;
            // 
            // textFilterMaPB
            // 
            this.textFilterMaPB.Location = new System.Drawing.Point(69, 63);
            this.textFilterMaPB.Name = "textFilterMaPB";
            this.textFilterMaPB.Size = new System.Drawing.Size(56, 20);
            this.textFilterMaPB.TabIndex = 2;
            // 
            // textFilterMaNV
            // 
            this.textFilterMaNV.Location = new System.Drawing.Point(9, 63);
            this.textFilterMaNV.Name = "textFilterMaNV";
            this.textFilterMaNV.Size = new System.Drawing.Size(56, 20);
            this.textFilterMaNV.TabIndex = 1;
            // 
            // dataNhanVien
            // 
            this.dataNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNhanVien.Location = new System.Drawing.Point(6, 89);
            this.dataNhanVien.Name = "dataNhanVien";
            this.dataNhanVien.Size = new System.Drawing.Size(784, 536);
            this.dataNhanVien.TabIndex = 0;
            // 
            // tabChamCong
            // 
            this.tabChamCong.Location = new System.Drawing.Point(4, 22);
            this.tabChamCong.Name = "tabChamCong";
            this.tabChamCong.Padding = new System.Windows.Forms.Padding(3);
            this.tabChamCong.Size = new System.Drawing.Size(1232, 631);
            this.tabChamCong.TabIndex = 1;
            this.tabChamCong.Text = "Chấm công";
            this.tabChamCong.UseVisualStyleBackColor = true;
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
            // buttonFilterClear
            // 
            this.buttonFilterClear.Location = new System.Drawing.Point(731, 31);
            this.buttonFilterClear.Name = "buttonFilterClear";
            this.buttonFilterClear.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterClear.TabIndex = 9;
            this.buttonFilterClear.Text = "Clear";
            this.buttonFilterClear.UseVisualStyleBackColor = true;
            // 
            // buttonFilterFind
            // 
            this.buttonFilterFind.Location = new System.Drawing.Point(731, 60);
            this.buttonFilterFind.Name = "buttonFilterFind";
            this.buttonFilterFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterFind.TabIndex = 10;
            this.buttonFilterFind.Text = "Find";
            this.buttonFilterFind.UseVisualStyleBackColor = true;
            // 
            // comboFilterGioiTinh
            // 
            this.comboFilterGioiTinh.FormattingEnabled = true;
            this.comboFilterGioiTinh.Location = new System.Drawing.Point(369, 62);
            this.comboFilterGioiTinh.Name = "comboFilterGioiTinh";
            this.comboFilterGioiTinh.Size = new System.Drawing.Size(56, 21);
            this.comboFilterGioiTinh.TabIndex = 11;
            // 
            // buttonFilterReset
            // 
            this.buttonFilterReset.Location = new System.Drawing.Point(731, 2);
            this.buttonFilterReset.Name = "buttonFilterReset";
            this.buttonFilterReset.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterReset.TabIndex = 12;
            this.buttonFilterReset.Text = "Reset";
            this.buttonFilterReset.UseVisualStyleBackColor = true;
            // 
            // comboFilterMaCV
            // 
            this.comboFilterMaCV.DropDownWidth = 120;
            this.comboFilterMaCV.FormattingEnabled = true;
            this.comboFilterMaCV.Location = new System.Drawing.Point(129, 62);
            this.comboFilterMaCV.Name = "comboFilterMaCV";
            this.comboFilterMaCV.Size = new System.Drawing.Size(56, 21);
            this.comboFilterMaCV.TabIndex = 13;
            // 
            // comboFilterLoaiLaoDong
            // 
            this.comboFilterLoaiLaoDong.FormattingEnabled = true;
            this.comboFilterLoaiLaoDong.Location = new System.Drawing.Point(549, 62);
            this.comboFilterLoaiLaoDong.Name = "comboFilterLoaiLaoDong";
            this.comboFilterLoaiLaoDong.Size = new System.Drawing.Size(116, 21);
            this.comboFilterLoaiLaoDong.TabIndex = 14;
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
            this.tabNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhanVien)).EndInit();
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
        private System.Windows.Forms.Button buttonFilterReset;
        private System.Windows.Forms.ComboBox comboFilterMaCV;
        private System.Windows.Forms.ComboBox comboFilterLoaiLaoDong;
    }
}

