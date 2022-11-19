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
    public static class TimeChecking
    {
        // data
        private static BindingSource BindingSourceTimeChecking { get; set; }
        private static BindingList<ChamCong> ListTimeChecking { get; set; }
        private static BindingList<ChamCong> ListTimeCheckingFiltered { get; set; }

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
        private static TabPage tabTimeChecking;
        public static TabPage TabTimeChecking
        {
            private get { return tabTimeChecking; }
            set
            {
                tabTimeChecking = value;
                DataGridViewTimeChecking = tabTimeChecking.Controls.OfType<DataGridView>().Cast<DataGridView>().FirstOrDefault();

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
            TimeCheckingDB.Load();
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
            ListTimeChecking = new BindingList<ChamCong>();

            // timechecking data
            foreach (ChamCong timeCheck in TimeCheckingDB.Load())
            {
                ListTimeChecking.Add(timeCheck);
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

            // cell click -> edit time checking
            DataGridViewTimeChecking.CellDoubleClick += new DataGridViewCellEventHandler((object sender, DataGridViewCellEventArgs e) =>
            {
                if (e.RowIndex == -1)
                    return;

                // get emp with time
                string empID = DataGridViewTimeChecking.Rows[e.RowIndex].Cells[0].Value.ToString();

                ChamCong empCheck = ListTimeChecking.Where(x => x.MaNV == empID).FirstOrDefault();

                // fill emp with time data in textbox and combo box
                foreach (TextBox textBox in TextBoxes)
                {
                    string textBoxFor = textBox.Name.Substring(5, 5);
                    string name = textBox.Name.Substring(10);

                    if (textBoxFor == "Check")
                    {
                        textBox.Text = empCheck.GetType().GetProperty(name).GetValue(empCheck).ToString();
                        // enable text and combobox for time checking
                        textBox.Enabled = true;
                    }
                }

                foreach (ComboBox comboBox in ComboBoxes)
                {
                    string comboBoxFor = comboBox.Name.Substring(6, 5);
                    string name = comboBox.Name.Substring(11);

                    if (comboBoxFor == "Check")
                    {
                        string text = empCheck.GetType().GetProperty(name).GetValue(empCheck).ToString();
                        int index = comboBox.Items.IndexOf(text);
                        comboBox.SelectedIndex = index;
                        // enable text and combobox for time checking
                        comboBox.Enabled = true;
                    }
                }
            });

            // define data grid view cols
            {
                // col: Mã nhân viên
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaNV";
                column.Name = "Mã nhân viên";
                column.Width = 90;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Mã phòng ban
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaPB";
                column.Name = "Mã phòng ban";
                column.Width = 90;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Mã công việc
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaCV";
                column.Name = "Mã công việc";
                column.Width = 90;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Tên nhân viên
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenNV";
                column.Name = "Tên nhân viên";
                column.Width = 180;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Thời gian làm đơn vị
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "ThoiGianLamDonVi";
                column.Name = "Thời gian làm đơn vị";
                column.Width = 90;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Tăng ca
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TangCa";
                column.Name = "Tăng ca";
                column.Width = 90;
                DataGridViewTimeChecking.Columns.Add(column);

                // col: Đã chấm công
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "IsChecked";
                column.Name = "Đã chấm công";
                column.Width = 90;
                DataGridViewTimeChecking.Columns.Add(column);
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
                if (button.Name == "button2FilterClear")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear text box content
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 11);
                            if (textBoxFor == "text2Filter")
                            {
                                textBox.Text = "";
                            }
                        }
                        // clear combo box selected item
                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 12);
                            if (comboBoxFor == "combo2Filter")
                            {
                                comboBox.SelectedIndex = 0;
                            }
                        }

                        // clear data
                        BindingSourceTimeChecking.DataSource = ListTimeChecking;
                        ListTimeCheckingFiltered = null;
                    });
                }

                // find
                else if (button.Name == "button2FilterFind")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear old filter result if old != current
                        if (BindingSourceTimeChecking.List.Count != ListTimeChecking.Count)
                        {
                            BindingSourceTimeChecking.DataSource = ListTimeChecking;
                            ListTimeCheckingFiltered = null;
                        }

                        List<ChamCong> temp = new List<ChamCong>(ListTimeChecking);

                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 11);
                            string name = textBox.Name.Substring(11);
                            string text = textBox.Text;
                            if (textBoxFor == "text2Filter")
                            {
                                temp = temp.Where(x => x.GetType().GetProperty(name).GetValue(x).ToString().Contains(text)).ToList();
                            }
                        }

                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 12);
                            string name = comboBox.Name.Substring(12);
                            string text = comboBox.Text;

                            if (comboBoxFor == "combo2Filter")
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
                        if (BindingSourceTimeChecking.Count != temp.Count)
                        {
                            ListTimeCheckingFiltered = new BindingList<ChamCong>(temp);
                            ListTimeCheckingFiltered = ListTimeCheckingFiltered.ToSortableBindingList();
                            BindingSourceTimeChecking.DataSource = ListTimeCheckingFiltered;
                        }
                    });
                }

                //
                // CHECK BUTTONS
                //
                // check
                else if (button.Name == "button2CheckCheck")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        Dictionary<string, string> newTimeCheckingData = new Dictionary<string, string>();
                        ChamCong newTimeChecking = new ChamCong();

                        // get data
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 10);
                            string name = textBox.Name.Substring(10);
                            string text = textBox.Text;
                            if (textBoxFor == "text2Check")
                            {
                                newTimeCheckingData.Add(name, text);
                            }
                        }

                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 11);
                            string name = comboBox.Name.Substring(11);
                            string text = comboBox.Text;

                            if (comboBoxFor == "combo2Check")
                            {
                                newTimeCheckingData.Add(name, text);
                            }
                        }

                        // create new time checking
                        foreach (KeyValuePair<string, string> entry in newTimeCheckingData)
                        {
                            PropertyInfo prop = newTimeChecking.GetType().GetProperty(entry.Key);
                            if (prop.PropertyType == typeof(int))
                            {
                                prop.SetValue(newTimeChecking, int.Parse(entry.Value));
                            }
                            else
                            {
                                prop.SetValue(newTimeChecking, entry.Value);
                            }
                        }

                        // check
                        string message = TimeCheckingDB.Check(newTimeChecking);
                        if (message is null)
                        {
                            MessageBox.Show("Chấm công cho nhân viên " + newTimeChecking.MaNV + " thành công");

                            // change time check data, re bind
                            int index = ListTimeChecking.IndexOf(ListTimeChecking.Where(x => x.MaNV == newTimeChecking.MaNV).FirstOrDefault());
                            ChamCong oldTiemCheking = ListTimeChecking[index];
                            newTimeChecking.MaCV = oldTiemCheking.MaCV;
                            newTimeChecking.MaPB = oldTiemCheking.MaPB;
                            newTimeChecking.TenNV = oldTiemCheking.TenNV;
                            ListTimeChecking[index] = newTimeChecking;
                            BindingSourceTimeChecking.DataSource = ListTimeChecking;
                        }
                        else
                        {
                            MessageBox.Show(message);
                            return;

                        }

                        // success -> clear form
                        Buttons.Where(x => x.Name == "button2CheckClear").FirstOrDefault().PerformClick();
                    });
                }

                // clear
                else if (button.Name == "button2CheckClear")
                {
                    button.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // clear text box content
                        foreach (TextBox textBox in TextBoxes)
                        {
                            string textBoxFor = textBox.Name.Substring(0, 10);
                            string name = textBox.Name.Substring(10);

                            if (textBoxFor == "text2Check")
                            {
                                textBox.Text = "";
                                // disable text and combobox for time checking
                                textBox.Enabled = false;
                            }
                        }
                        // clear combo box selected item
                        foreach (ComboBox comboBox in ComboBoxes)
                        {
                            string comboBoxFor = comboBox.Name.Substring(0, 11);
                            if (comboBoxFor == "combo2Check")
                            {
                                comboBox.SelectedIndex = 0;
                                // disable text and combobox for time checking
                                comboBox.Enabled = false;
                            }
                        }
                    });
                }

            }
        }
        private static void InitComboBoxes()
        {
            List<string> workTime = Enumerable.Range(0, 17).ToList().ConvertAll<string>(x => x.ToString());

            List<string> overTime = Enumerable.Range(0, 9).ToList().ConvertAll<string>(x => x.ToString());

            foreach (ComboBox comboBox in comboBoxes)
            {
                //
                // CREATE, FILTER COMBOBOXES
                //

                string type = comboBox.Name.Substring(6, 6);
                string name = comboBox.Name.Substring(11);

                if (type == "Filter")
                {
                    comboBox.Items.Add("All");
                    name = comboBox.Name.Substring(12);
                }

                switch (name)
                {
                    // job
                    case "MaCV":
                        foreach (string job in EmployeeManagement.JobNames)
                        {
                            comboBox.Items.Add(job);
                        }
                        comboBox.SelectedIndex = 0;
                        break;
                    // is checked
                    case "IsChecked":
                        comboBox.Items.Add("True");
                        comboBox.Items.Add("False");
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
