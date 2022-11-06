using HQT_CSDL.Data;
using HQT_CSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace HQT_CSDL.Controller
{
    public static class EmployeeManagement
    {
        private static BindingSource BindingSourceEmployee { get; set; }
        private static BindingList<NhanVien> ListEmployee { get; set; }
        private static BindingList<NhanVien> ListEmployeeFiltered { get; set; }
        public static List<CongViec> ListJob { get; set; }
        private static DataGridView dataGridViewEmployee;
        public static DataGridView DataGridViewEmployee
        {
            private get { return dataGridViewEmployee; }
            set
            {
                dataGridViewEmployee = value;
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
                InitFilterTextBoxes();
            }
        }
        private static List<Button> buttons;
        private static List<Button> Buttons
        {
            get { return buttons; }
            set
            {
                buttons = value;
                InitFilterButtons();
            }
        }
        private static List<ComboBox> comboBoxes;
        private static List<ComboBox> ComboBoxes
        {
            get { return comboBoxes; }
            set
            {
                comboBoxes = value;
                InitFilterComboBoxes();
            }
        }

        private static TabPage tabEmployee;
        public static TabPage TabEmployee
        {
            private get { return tabEmployee; }
            set
            {
                tabEmployee = value;
                DataGridViewEmployee = tabEmployee.Controls.OfType<DataGridView>().Cast<DataGridView>().ToList()[0];
                TextBoxes = tabEmployee.Controls.OfType<TextBox>().Cast<TextBox>().ToList();
                Buttons = tabEmployee.Controls.OfType<Button>().Cast<Button>().ToList();
                ComboBoxes = tabEmployee.Controls.OfType<ComboBox>().Cast<ComboBox>().ToList();

            }
        }

        private static bool[] Sorted { get; set; }

        static EmployeeManagement()
        {
            InitData();
        }

        private static void InitData()
        {
            BindingSourceEmployee = new BindingSource();
            ListEmployee = new BindingList<NhanVien>();
            ListJob = new List<CongViec>();

            // employees data
            foreach (NhanVien nhanVien in EmployeeDB.Load())
            {
                ListEmployee.Add(nhanVien);
            }
            ListEmployee = ListEmployee.ToSortableBindingList();
            BindingSourceEmployee.DataSource = ListEmployee;

            // jobs data
            foreach (CongViec congViec in JobDB.Load())
            {
                ListJob.Add(congViec);
            }
        }
        private static void InitDataGridView()
        {

            // init data grid view
            DataGridViewEmployee.AutoGenerateColumns = false;
            DataGridViewEmployee.RowHeadersVisible = false;
            DataGridViewEmployee.DataSource = BindingSourceEmployee;

            // define data grid view cols
            {
                // col: Mã nhân viên
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaNV";
                column.Name = "Mã nhân viên";
                column.Width = 60;
                DataGridViewEmployee.Columns.Add(column);

                // col: Mã phòng ban
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaPB";
                column.Name = "Mã phòng ban";
                column.Width = 60;
                DataGridViewEmployee.Columns.Add(column);

                // col: Mã công việc
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaCV";
                column.Name = "Mã công việc";
                column.Width = 60;
                DataGridViewEmployee.Columns.Add(column);

                // col: Tên nhân viên
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenNV";
                column.Name = "Tên nhân viên";
                column.Width = 180;
                DataGridViewEmployee.Columns.Add(column);

                // col: Giới tính
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "GioiTinh";
                column.Name = "Giới tính";
                column.Width = 60;
                DataGridViewEmployee.Columns.Add(column);

                // col: Số điện thoại
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "SoDT";
                column.Name = "Số điện thoại";
                column.Width = 120;
                DataGridViewEmployee.Columns.Add(column);

                // col: Loại lao động
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "LoaiLaoDong";
                column.Name = "Loại lao động";
                column.Width = 120;
                DataGridViewEmployee.Columns.Add(column);

                // col: Tiền theo đơn vị
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TienTheoDonVi";
                column.Name = "Tiền theo đơn vị";
                column.Width = 60;
                DataGridViewEmployee.Columns.Add(column);
            }
        }
        private static void InitFilterTextBoxes()
        {

        }
        private static void InitFilterButtons()
        {
            foreach (Button button in Buttons)
            {
                // clear button
                if (button.Name == "buttonFilterClear")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear text box content
                        foreach (TextBox textBox in TextBoxes)
                        {
                            textBox.Text = "";
                        }
                        // clear combo box selected item
                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            comboBox.SelectedIndex = 0;
                        }
                    });
                }
                else if (button.Name == "buttonFilterFind")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear old filter result if old != current
                        if (BindingSourceEmployee.List.Count != ListEmployee.Count)
                        {
                            ((Button)(Buttons.Where(x => x.Name == "buttonFilterReset").ToList()[0])).PerformClick();
                        }

                        List<NhanVien> temp = new List<NhanVien>(ListEmployee);

                        foreach (TextBox textBox in TextBoxes)
                        {
                            string name = textBox.Name.Substring(10);
                            string text = textBox.Text;

                            temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                        }

                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string name = comboBox.Name.Substring(11);
                            string text = comboBox.Text;

                            if (text != "All")
                            {
                                if (name == "MaCV")
                                {
                                    text = ListJob.Where(x => x.TenCV == text).Select(x => x.MaCV).ToList()[0].ToString();
                                }

                                temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                            }
                        }

                        // if result != current => change list
                        if (BindingSourceEmployee.Count != temp.Count)
                        {
                            ListEmployeeFiltered = new BindingList<NhanVien>(temp);
                            ListEmployeeFiltered = ListEmployeeFiltered.ToSortableBindingList();
                            BindingSourceEmployee.DataSource = ListEmployeeFiltered;
                        }
                    });
                }
                else if (button.Name == "buttonFilterReset")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        BindingSourceEmployee.DataSource = ListEmployee;
                        ListEmployeeFiltered = null;
                    });
                }
            }
        }

        private static void InitFilterComboBoxes()
        {
            List<String> sexs = ListEmployee.Select(x => x.GioiTinh).Distinct().ToList();
            sexs.Insert(0, "All");

            List<String> jobIDs = ListJob.OrderBy(x => x.MaCV).Select(x => x.TenCV).Distinct().ToList();
            jobIDs.Insert(0, "All");

            List<String> employmentTypes = ListEmployee.Select(x => x.LoaiLaoDong).Distinct().ToList();
            employmentTypes.Insert(0, "All");

            foreach (ComboBox comboBox in ComboBoxes)
            {
                // filter sex
                if (comboBox.Name == "comboFilterGioiTinh")
                {
                    foreach (String sex in sexs)
                    {
                        comboBox.Items.Add(sex);
                    }
                    comboBox.SelectedIndex = 0;
                }
                // filter job
                else if (comboBox.Name == "comboFilterMaCV")
                {
                    foreach (String jobID in jobIDs)
                    {
                        comboBox.Items.Add(jobID);
                    }
                    comboBox.SelectedIndex = 0;
                }
                // filter employment type
                else if (comboBox.Name == "comboFilterLoaiLaoDong")
                {
                    foreach (String employmentType in employmentTypes)
                    {
                        comboBox.Items.Add(employmentType);
                    }
                    comboBox.SelectedIndex = 0;
                }
            }
        }
    }
}
