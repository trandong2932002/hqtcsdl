using HQT_CSDL.Controller;
using System;
using System.Windows.Forms;
using HQT_CSDL.Data;
namespace HQT_CSDL.View
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            EmployeeManagement.TabEmployee = tabNhanVien;
            TimeChecking.TabTimeChecking = tabChamCong;
            Salary.TabSalary = tabTinhLuong;
            //tabControl.SelectedIndex = 2;
            
            //Chi Nhánh
            LoadDataChiNhanh();


            //Phòng Ban
            LoadDataPhongBan();

            //Công Việc
            LoadDataCongViec();
            

        }
        #region ChiNhanh
        public void LoadDataChiNhanh()
        {
            clearBindingChiNhanh();
            dataChiNhanh.DataSource = ChiNhanhData.Load();
            dataChiNhanh.ReadOnly = true;
            dataChiNhanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataChiNhanh.Columns[0].HeaderText = "Mã Chi Nhánh";
            dataChiNhanh.Columns[1].HeaderText = "Địa chỉ";
            dataChiNhanh.Columns[2].HeaderText = "Số Điện thoại";
            addBindingChiNhanh();
        }
        public void addBindingChiNhanh()
        {
            MaCNBox.DataBindings.Add(new Binding("Text", dataChiNhanh.DataSource, "MaCN", true, DataSourceUpdateMode.Never));
            DiaChiBox.DataBindings.Add(new Binding("Text", dataChiNhanh.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            SoDTBox.DataBindings.Add(new Binding("Text", dataChiNhanh.DataSource, "SoDT", true, DataSourceUpdateMode.Never));
        }

        public void clearBindingChiNhanh()
        {
            MaCNBox.DataBindings.Clear();
            DiaChiBox.DataBindings.Clear();
            SoDTBox.DataBindings.Clear();
        }

        private void addChiNhanhbutton_Click(object sender, EventArgs e)
        {
            string message = ChiNhanhData.AddChiNhanh(MaCNBox.Text, DiaChiBox.Text, SoDTBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataChiNhanh();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
        private void updateChiNhanhbutton_Click(object sender, EventArgs e)
        {
            string message = ChiNhanhData.UpdateChiNhanh(MaCNBox.Text, DiaChiBox.Text, SoDTBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataChiNhanh();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void deleteChiNhanhbutton_Click(object sender, EventArgs e)
        {
            string message = ChiNhanhData.DeleteChiNhanh(MaCNBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataChiNhanh();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        #endregion

        #region PhongBan
        public void LoadDataPhongBan()
        {
            clearBindingPhongBan();
            dataPhongBan.DataSource = PhongBanData.Load();
            dataPhongBan.ReadOnly = true;
            dataPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataPhongBan.Columns[0].HeaderText = "Mã Phòng Ban";
            dataPhongBan.Columns[1].HeaderText = "Mã Chi Nhánh";
            dataPhongBan.Columns[2].HeaderText = "Tên Phòng Ban";
            addBindingPhongBan();
        }

        public void addBindingPhongBan()
        {
            MaPBBox.DataBindings.Add(new Binding("Text", dataPhongBan.DataSource, "MaPB", true, DataSourceUpdateMode.Never));
            MaCN_PBBox.DataBindings.Add(new Binding("Text", dataPhongBan.DataSource, "MaCN", true, DataSourceUpdateMode.Never));
            TenPBBox.DataBindings.Add(new Binding("Text", dataPhongBan.DataSource, "TenPB", true, DataSourceUpdateMode.Never));
        }

        public void clearBindingPhongBan()
        {
            MaPBBox.DataBindings.Clear();
            MaCN_PBBox.DataBindings.Clear();
            TenPBBox.DataBindings.Clear();
        }
        private void addPhongBanbutton_Click(object sender, EventArgs e)
        {
            string message = PhongBanData.AddPhongBan(MaPBBox.Text, MaCN_PBBox.Text, TenPBBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataPhongBan();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void updatePhongBanbutton_Click(object sender, EventArgs e)
        {
            string message = PhongBanData.UpdatePhongBan(MaPBBox.Text, MaCN_PBBox.Text, TenPBBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataPhongBan();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void deletePhongBanbutton_Click(object sender, EventArgs e)
        {
            string message = PhongBanData.DeletePhongBan(MaCNBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataChiNhanh();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        #endregion

        #region Công Việc
        public void LoadDataCongViec()
        {
            clearBindingCongViec();
            dataCongViec.DataSource = CongViecData.Load();
            dataCongViec.ReadOnly = true;
            dataCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataCongViec.Columns[0].HeaderText = "Mã Công Việc";
            dataCongViec.Columns[1].HeaderText = "Tên Công Việc";
            dataCongViec.Columns[2].HeaderText = "Mô tả Công Việc";
            addBindingCongViec();
        }
        public void addBindingCongViec()
        {
            MaCVBox.DataBindings.Add(new Binding("Text", dataCongViec.DataSource, "MaCV", true, DataSourceUpdateMode.Never));
            TenCVBox.DataBindings.Add(new Binding("Text", dataCongViec.DataSource, "TenCV", true, DataSourceUpdateMode.Never));
            MoTaBox.DataBindings.Add(new Binding("Text", dataCongViec.DataSource, "MoTaCV", true, DataSourceUpdateMode.Never));
        }

        public void clearBindingCongViec()
        {
            MaCVBox.DataBindings.Clear();
            TenCVBox.DataBindings.Clear();
            MoTaBox.DataBindings.Clear();
        }

        private void addCongViecbutton_Click(object sender, EventArgs e)
        {
            string message = CongViecData.AddCongViec(MaCVBox.Text, TenCVBox.Text, MoTaBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataCongViec();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
        private void updateCongViecbutton_Click(object sender, EventArgs e)
        {
            string message = CongViecData.UpdateCongViec(MaCVBox.Text, TenCVBox.Text, MoTaBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataCongViec();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void deleteCongViecbutton_Click(object sender, EventArgs e)
        {
            string message = CongViecData.DeleteCongViec(MaCVBox.Text);
            if (message == null)
            {
                MessageBox.Show("Thành Công");
                LoadDataCongViec();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
        #endregion

    }
}
