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
                //InitDataGridView();
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
            //InitData();
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


    }
}
