using HQT_CSDL.Data;
using HQT_CSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HQT_CSDL.Controller
{
    public static class TimeChecking
    {
        // data
        private static BindingSource BindingSourceTimeChecking { get; set; }
        private static BindingList<NhanVien> ListTimeChecking { get; set; }
        private static BindingList<NhanVien> ListTimeCheckingFiltered { get; set; }

        // view controls
        private static DataGridView dataGridViewTimeChecking;
        public static DataGridView DataGridViewTimeChecking
        {
            private get { return dataGridViewTimeChecking; }
            set
            {
                dataGridViewTimeChecking = value;
                InitDataGridView();
            }
        }
        private static List<TextBox> textBoxes;
        private static List<TextBox> TextBoxes
        {
            get { return textBoxes; }
            set
            {
                textBoxes = value;
                //InitTextBoxes();
            }
        }
        private static List<Button> buttons;
        private static List<Button> Buttons
        {
            get { return buttons; }
            set
            {
                buttons = value;
                //InitButtons();
            }
        }
        private static List<ComboBox> comboBoxes;
        private static List<ComboBox> ComboBoxes
        {
            get { return comboBoxes; }
            set
            {
                comboBoxes = value;
                //InitComboBoxes();
            }
        }
        private static TabPage tabTimeChecking;
        public static TabPage TabTimeChecking
        {
            private get { return tabTimeChecking; }
            set
            {
                tabTimeChecking = value;
                DataGridViewTimeChecking = tabTimeChecking.Controls.OfType<DataGridView>().Cast<DataGridView>().ToList()[0];

                TextBoxes = GetAllControlOfType<TextBox>(TabTimeChecking);
                Buttons = GetAllControlOfType<Button>(TabTimeChecking);
                ComboBoxes = GetAllControlOfType<ComboBox>(TabTimeChecking);
            }
        }

        //
        // CONSTRUCTOR
        //
        static TimeChecking()
        {
            InitData();
        }

        //
        // FUNCTION
        //

        private static List<T> GetAllControlOfType<T>(Control container)
        {
            List<T> controlList = new List<T>();
            foreach (Control control in container.Controls)
            {
                controlList.AddRange(GetAllControlOfType<T>(control));
                if (control is T)
                {
                    controlList.Add((T)Convert.ChangeType(control, typeof(T)));
                }
            }
            return controlList;
        }

        private static void InitData()
        {
            BindingSourceTimeChecking = new BindingSource();
            ListTimeChecking = new BindingList<NhanVien>();

            // employees data
            foreach (NhanVien nhanVien in EmployeeDB.Load())
            {
                ListTimeChecking.Add(nhanVien);
            }
            ListTimeChecking = ListTimeChecking.ToSortableBindingList();
            BindingSourceTimeChecking.DataSource = ListTimeChecking;
        }

        private static void InitDataGridView()
        {
            // init data grid view
            DataGridViewTimeChecking.AutoGenerateColumns = false;
            DataGridViewTimeChecking.DataSource = BindingSourceTimeChecking;

            // user cannot resize or edit anythings
            DataGridViewTimeChecking.RowHeadersVisible = false;
            DataGridViewTimeChecking.AllowUserToResizeColumns = false;
            DataGridViewTimeChecking.AllowUserToResizeRows = false;
            DataGridViewTimeChecking.AllowUserToDeleteRows = false;
            DataGridViewTimeChecking.AllowUserToAddRows = false;
            DataGridViewTimeChecking.ReadOnly = true;

            // define data grid view cols
            {
                // col: Mã nhân viên
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaNV";
                column.Name = "Mã nhân viên";
                column.Width = 60;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Mã phòng ban
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaPB";
                column.Name = "Mã phòng ban";
                column.Width = 60;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Mã công việc
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaCV";
                column.Name = "Mã công việc";
                column.Width = 60;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Tên nhân viên
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenNV";
                column.Name = "Tên nhân viên";
                column.Width = 180;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Giới tính
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "GioiTinh";
                column.Name = "Giới tính";
                column.Width = 60;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Số điện thoại
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "SoDT";
                column.Name = "Số điện thoại";
                column.Width = 120;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Loại lao động
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "LoaiLaoDong";
                column.Name = "Loại lao động";
                column.Width = 120;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Tiền theo đơn vị
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TienTheoDonVi";
                column.Name = "Tiền theo đơn vị";
                column.Width = 60;
                DataGridViewTimeChecking.Columns.Add(column);
            }
        }
    }
}
