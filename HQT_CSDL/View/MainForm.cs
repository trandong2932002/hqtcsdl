using HQT_CSDL.Controller;
using System;
using System.Windows.Forms;

namespace HQT_CSDL.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            EmployeeManagement.TabEmployee = tabNhanVien;
            TimeChecking.TabTimeChecking = tabChamCong;
            //TimeChecking
        }
    }
}
