using HQT_CSDL.Data;
using HQT_CSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HQT_CSDL.Controller
{
    public static class EmployeeManagement
    {
        // data
        private static BindingSource BindingSourceEmployee { get; set; }
        private static BindingList<NhanVien> ListEmployee { get; set; }
        private static BindingList<NhanVien> ListEmployeeFiltered { get; set; }
        public static List<CongViec> ListJob { get; set; }

        // view controls
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
                InitTextBoxes();
            }
        }
        private static List<Button> buttons;
        private static List<Button> Buttons
        {
            get { return buttons; }
            set
            {
                buttons = value;
                InitButtons();
            }
        }
        private static List<ComboBox> comboBoxes;
        private static List<ComboBox> ComboBoxes
        {
            get { return comboBoxes; }
            set
            {
                comboBoxes = value;
                InitComboBoxes();
            }
        }
        private static Label Status { get; set; }
        private static TabPage tabEmployee;
        public static TabPage TabEmployee
        {
            private get { return tabEmployee; }
            set
            {
                tabEmployee = value;
                DataGridViewEmployee = tabEmployee.Controls.OfType<DataGridView>().Cast<DataGridView>().ToList()[0];
                Status = tabEmployee.Controls.OfType<GroupBox>().Cast<GroupBox>().ToList().Where(x => x.Name == "groupCreateandEdit").ToList()[0]
                    .Controls.OfType<Label>().Cast<Label>().ToList().Where(x => x.Name == "labelStatus").ToList()[0];

                TextBoxes = GetAllControlOfType<TextBox>(TabEmployee);
                Buttons = GetAllControlOfType<Button>(TabEmployee);
                ComboBoxes = GetAllControlOfType<ComboBox>(TabEmployee);
            }
        }

        //
        // CONSTRUCTOR
        //
        static EmployeeManagement()
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
            DataGridViewEmployee.DataSource = BindingSourceEmployee;

            // user cannot resize or edit anythings
            DataGridViewEmployee.RowHeadersVisible = false;
            DataGridViewEmployee.AllowUserToResizeColumns = false;
            DataGridViewEmployee.AllowUserToResizeRows = false;
            DataGridViewEmployee.AllowUserToDeleteRows = false;
            DataGridViewEmployee.AllowUserToAddRows = false;
            DataGridViewEmployee.ReadOnly = true;

            // cell click -> edit emp
            DataGridViewEmployee.CellDoubleClick += new DataGridViewCellEventHandler((object sender, DataGridViewCellEventArgs e) =>
            {
                if (e.RowIndex == -1)
                    return;

                // get emp
                string empID = DataGridViewEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();

                NhanVien emp = ListEmployee.Where(x => x.MaNV == empID).ToList()[0];

                // fill emp data in textbox and combo box
                foreach (TextBox textBox in TextBoxes)
                {
                    string textBoxFor = textBox.Name.Substring(0, 10);
                    string name = textBox.Name.Substring(10);

                    if (textBoxFor == "textCreate")
                    {
                        textBox.Text = emp.GetType().GetProperty(name).GetValue(emp).ToString();
                    }
                }

                foreach (ComboBox comboBox in ComboBoxes)
                {
                    string comboBoxFor = comboBox.Name.Substring(0, 11);
                    string name = comboBox.Name.Substring(11);

                    if (comboBoxFor == "comboCreate")
                    {
                        string text = emp.GetType().GetProperty(name).GetValue(emp).ToString();
                        if (name == "MaCV")
                        {
                            text = text + " - " + ListJob.Where(x => x.MaCV == text).ToList()[0].TenCV;
                        }
                        int index = comboBox.Items.IndexOf(text);
                        comboBox.SelectedIndex = index;
                    }
                }

                // change status and button text
                Status.Text = "BẠN ĐANG SỬA NHÂN VIÊN " + empID;
                Buttons.Where(x => x.Name == "buttonCreateEdit").ToList()[0].Text = "Sửa";
                Buttons.Where(x => x.Name == "buttonDelete").ToList()[0].Enabled = true;
            });

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
        private static void InitTextBoxes()
        {

        }
        private static void InitButtons()
        {
            foreach (Button button in Buttons)
            {
                //
                // FILTER BUTTONS
                //
                // clear
                if (button.Name == "buttonFilterClear")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (BindingSourceEmployee.List.Count == ListEmployee.Count)
                        {
                            return;
                        }
                        // clear text box content
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 10);
                            if (textBoxFor == "textFilter")
                            {
                                textBox.Text = "";
                            }
                        }
                        // clear combo box selected item
                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 11);
                            if (comboBoxFor == "comboFilter")
                            {
                                comboBox.SelectedIndex = 0;
                            }
                        }

                        // clear data
                        BindingSourceEmployee.DataSource = ListEmployee;
                        ListEmployeeFiltered = null;
                    });
                }

                // find
                else if (button.Name == "buttonFilterFind")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear old filter result if old != current
                        if (BindingSourceEmployee.List.Count != ListEmployee.Count)
                        {
                            BindingSourceEmployee.DataSource = ListEmployee;
                            ListEmployeeFiltered = null;
                        }

                        List<NhanVien> temp = new List<NhanVien>(ListEmployee);

                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 10);
                            string name = textBox.Name.Substring(10);
                            string text = textBox.Text;
                            if (textBoxFor == "textFilter")
                            {
                                temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                            }
                        }

                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 11);
                            string name = comboBox.Name.Substring(11);
                            string text = comboBox.Text;

                            if (comboBoxFor == "comboFilter")
                            {
                                if (text != "All")
                                {
                                    if (name == "MaCV")
                                    {
                                        text = text.Substring(0, 5);
                                    }

                                    temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                                }
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

                //
                // CREATE EDIT DELETE BUTTONS
                //
                // create and edit
                else if (button.Name == "buttonCreateEdit")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        Dictionary<string, string> newEmployeeData = new Dictionary<string, string>();
                        NhanVien newEmployee = new NhanVien();

                        // get data
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 10);
                            string name = textBox.Name.Substring(10);
                            string text = textBox.Text;
                            if (textBoxFor == "textCreate")
                            {
                                newEmployeeData.Add(name, text);
                            }
                        }

                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 11);
                            string name = comboBox.Name.Substring(11);
                            string text = comboBox.Text;

                            if (comboBoxFor == "comboCreate")
                            {
                                if (name == "MaCV")
                                {
                                    text = text.Substring(0, 5);
                                }
                                newEmployeeData.Add(name, text);
                            }
                        }

                        // create new emp
                        foreach (KeyValuePair<string, string> entry in newEmployeeData)
                        {
                            if (entry.Key == "TienTheoDonVi")
                            {
                                int value;
                                if (!int.TryParse(entry.Value, out value))
                                {
                                    MessageBox.Show("Tiền mỗi đơn vị phải là số");
                                    return;
                                }
                                newEmployee.GetType().GetProperty(entry.Key).SetValue(newEmployee, value);
                            }
                            else
                            {
                                newEmployee.GetType().GetProperty(entry.Key).SetValue(newEmployee, entry.Value);
                            }
                        }

                        // save new emp/edited emp
                        if (Status.Text == "BẠN ĐANG THÊM NHÂN VIÊN MỚI")
                        {
                            string message = EmployeeDB.AddEmployee(newEmployee);
                            if (message is null)
                            {
                                MessageBox.Show("Thêm nhân viên " + newEmployee.MaNV + " thành công");

                                // add new emp, re bind
                                ListEmployee.Add(newEmployee);
                                BindingSourceEmployee.DataSource = ListEmployee;
                            }
                            else
                            {
                                MessageBox.Show(message);
                                return;
                            }
                        }
                        else
                        {
                            string message = EmployeeDB.UpdateEmployee(newEmployee);
                            if (message is null)
                            {
                                MessageBox.Show("Sửa nhân viên " + newEmployee.MaNV + " thành công");

                                // change emp data, re bind
                                int index = ListEmployee.IndexOf(ListEmployee.Where(x => x.MaNV == newEmployee.MaNV).ToList()[0]);
                                ListEmployee[index] = newEmployee;
                                BindingSourceEmployee.DataSource = ListEmployee;
                            }
                            else
                            {
                                MessageBox.Show(message);
                                return;
                            }
                        }

                        // success -> clear form
                        Buttons.Where(x => x.Name == "buttonCreateClear").ToList()[0].PerformClick();
                    });
                }

                // delete
                else if (button.Name == "buttonDelete")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (Status.Text != "BẠN ĐANG THÊM NHÂN VIÊN MỚI")
                        {
                            string empID = TextBoxes.Where(x => x.Name == "textCreateMaNV").ToList()[0].Text;
                            string message = EmployeeDB.DeleteEmployee(empID);
                            if (message is null)
                            {
                                MessageBox.Show("Xoá nhân viên " + empID + " thành công");

                                // delete emp, re bind
                                int index = ListEmployee.IndexOf(ListEmployee.Where(x => x.MaNV == empID).ToList()[0]);
                                ListEmployee.RemoveAt(index);
                                BindingSourceEmployee.DataSource = ListEmployee;
                            }
                            else
                            {
                                MessageBox.Show(message);
                                return;
                            }

                            // success -> clear form
                            Buttons.Where(x => x.Name == "buttonCreateClear").ToList()[0].PerformClick();
                        }
                    });
                }

                // clear
                else if (button.Name == "buttonCreateClear")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear text box content
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 10);
                            if (textBoxFor == "textCreate")
                            {
                                textBox.Text = "";
                            }
                        }
                        // clear combo box selected item
                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 11);
                            if (comboBoxFor == "comboCreate")
                            {
                                comboBox.SelectedIndex = 0;
                            }
                        }

                        Status.Text = "BẠN ĐANG THÊM NHÂN VIÊN MỚI";
                        Buttons.Where(x => x.Name == "buttonCreateEdit").ToList()[0].Text = "Thêm";
                        Buttons.Where(x => x.Name == "buttonDelete").ToList()[0].Enabled = false;
                    });
                }
            }
        }
        private static void InitComboBoxes()
        {
            List<string> sexs = ListEmployee.Select(x => x.GioiTinh).Distinct().ToList();

            List<string> jobIDs = ListJob.OrderBy(x => x.MaCV).Select(x => string.Concat(x.MaCV, " - ", x.TenCV)).Distinct().ToList();

            List<string> employmentTypes = ListEmployee.Select(x => x.LoaiLaoDong).Distinct().ToList();

            List<string> departmentIDs = ListEmployee.Select(x => x.MaPB).Distinct().OrderBy(x => x).ToList();

            foreach (ComboBox comboBox in ComboBoxes)
            {
                //
                // CREATE, FILTER COMBOBOXS
                //

                string type = comboBox.Name.Substring(5, 6);
                // add default "All" for filter combo box
                if (type == "Filter")
                {
                    comboBox.Items.Add("All");
                }

                string name = comboBox.Name.Substring(11);

                switch (name)
                {
                    // sex
                    case "GioiTinh":
                        foreach (string sex in sexs)
                        {
                            comboBox.Items.Add(sex);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                    // job
                    case "MaCV":
                        foreach (string jobID in jobIDs)
                        {
                            comboBox.Items.Add(jobID);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                    // employment type
                    case "LoaiLaoDong":
                        foreach (string employmentType in employmentTypes)
                        {
                            comboBox.Items.Add(employmentType);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                    // department
                    case "MaPB":
                        foreach (string departmentID in departmentIDs)
                        {
                            comboBox.Items.Add(departmentID);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                }
            }
        }
    }
}
