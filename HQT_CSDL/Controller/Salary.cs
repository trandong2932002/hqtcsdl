using HQT_CSDL.Data;
using HQT_CSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace HQT_CSDL.Controller
{
    public static class Salary
    {
        // data
        private static BindingSource BindingSourceSalary { get; set; }
        private static BindingList<TinhLuong> ListSalary { get; set; }
        private static BindingList<TinhLuong> ListSalaryFiltered { get; set; }

        // view controls
        private static DataGridView dataGridViewSalary;
        public static DataGridView DataGridViewSalary
        {
            private get { return dataGridViewSalary; }
            set
            {
                dataGridViewSalary = value;
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
        private static TabPage tabSalary;
        public static TabPage TabSalary
        {
            private get { return tabSalary; }
            set
            {
                tabSalary = value;
                DataGridViewSalary = tabSalary.Controls.OfType<DataGridView>().Cast<DataGridView>().FirstOrDefault();

                TextBoxes = GetAllControlOfType<TextBox>(TabSalary);
                Buttons = GetAllControlOfType<Button>(TabSalary);
                ComboBoxes = GetAllControlOfType<ComboBox>(TabSalary);
            }
        }

        //
        // CONSTRUCTOR
        //
        static Salary()
        {
            InitData();
            SalaryDB.Load();
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
            BindingSourceSalary = new BindingSource();
            ListSalary = new BindingList<TinhLuong>();

            // Salary data
            foreach (TinhLuong salary in SalaryDB.Load())
            {
                ListSalary.Add(salary);
            }
            ListSalary = ListSalary.ToSortableBindingList();
            BindingSourceSalary.DataSource = ListSalary;
        }
        private static void InitDataGridView()
        {
            // init data grid view
            DataGridViewSalary.AutoGenerateColumns = false;
            DataGridViewSalary.DataSource = BindingSourceSalary;

            // user cannot resize or edit anythings
            DataGridViewSalary.RowHeadersVisible = false;
            DataGridViewSalary.AllowUserToResizeColumns = false;
            DataGridViewSalary.AllowUserToResizeRows = false;
            DataGridViewSalary.AllowUserToDeleteRows = false;
            DataGridViewSalary.AllowUserToAddRows = false;
            DataGridViewSalary.ReadOnly = true;

            // define data grid view cols
            {
                // col: Mã nhân viên
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaNV";
                column.Name = "Mã nhân viên";
                column.Width = 90;
                DataGridViewSalary.Columns.Add(column);

                // col:Tiền theo đơn vị
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TienTheoDonVi";
                column.Name = "Tiền theo đơn vị";
                column.Width = 90;
                DataGridViewSalary.Columns.Add(column);

                // col: Loại lao động
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "LoaiLaoDong";
                column.Name = "Loại lao động";
                column.Width = 90;
                DataGridViewSalary.Columns.Add(column);

                // col: Thời gian làm đơn vị
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "ThoiGianLamDonVi";
                column.Name = "Thời gian làm đơn vị";
                column.Width = 90;
                DataGridViewSalary.Columns.Add(column);

                // col: Tăng ca
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TangCa";
                column.Name = "Tăng ca";
                column.Width = 90;
                DataGridViewSalary.Columns.Add(column);

                // col: Tiền lương
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TienLuong";
                column.Name = "Tiền lương";
                column.Width = 90;
                DataGridViewSalary.Columns.Add(column);
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
                if (button.Name == "button3FilterClear")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear text box content
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 11);
                            if (textBoxFor == "text3Filter")
                            {
                                textBox.Text = "";
                            }
                        }
                        // clear combo box selected item
                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 12);
                            if (comboBoxFor == "combo3Filter")
                            {
                                comboBox.SelectedIndex = 0;
                            }
                        }

                        // clear data
                        BindingSourceSalary.DataSource = ListSalary;
                        ListSalaryFiltered = null;
                    });
                }

                // find
                else if (button.Name == "button3FilterFind")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear old filter result if old != current
                        if (BindingSourceSalary.List.Count != ListSalary.Count)
                        {
                            BindingSourceSalary.DataSource = ListSalary;
                            ListSalaryFiltered = null;
                        }

                        List<TinhLuong> temp = new List<TinhLuong>(ListSalary);

                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 11);
                            string name = textBox.Name.Substring(11);
                            string text = textBox.Text;
                            if (textBoxFor == "text3Filter")
                            {
                                temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                            }
                        }

                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 12);
                            string name = comboBox.Name.Substring(12);
                            string text = comboBox.Text;

                            if (comboBoxFor == "combo3Filter")
                            {
                                if (text != "All")
                                {
                                    if (name == "ThoiGianLamDonVi" || name == "TangCa")
                                    {
                                        temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString() == text).ToList();
                                    }
                                    else
                                    {
                                        temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                                    }
                                }
                            }
                        }

                        // if result != current => change list
                        if (BindingSourceSalary.Count != temp.Count)
                        {
                            ListSalaryFiltered = new BindingList<TinhLuong>(temp);
                            ListSalaryFiltered = ListSalaryFiltered.ToSortableBindingList();
                            BindingSourceSalary.DataSource = ListSalaryFiltered;
                        }
                    });
                }
            }
        }
        private static void InitComboBoxes()
        {
            int maxWorkTime = ListSalary.Max(x => x.ThoiGianLamDonVi);
            int maxOverTime = ListSalary.Max(x => x.TangCa);

            List<string> employmentTypes = EmployeeManagement.EmploymentTypes;

            List<string> workTime = Enumerable.Range(0, maxWorkTime).ToList().ConvertAll<string>(x => x.ToString());

            List<string> overTime = Enumerable.Range(0, maxOverTime).ToList().ConvertAll<string>(x => x.ToString());


            foreach (ComboBox comboBox in comboBoxes)
            {
                //
                // FILTER COMBOBOXES
                //

                string type = comboBox.Name.Substring(6, 6);
                string name = comboBox.Name.Substring(12);

                comboBox.Items.Add("All");

                switch (name)
                {
                    // employment type
                    case "LoaiLaoDong":
                        foreach (string employmentType in employmentTypes)
                        {
                            comboBox.Items.Add(employmentType);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                    case "ThoiGianLamDonVi":
                        foreach (string item in workTime)
                        {
                            comboBox.Items.Add(item);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                    case "TangCa":
                        foreach (string item in overTime)
                        {
                            comboBox.Items.Add(item);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                }
            }
        }
    }
}
