using HQT_CSDL.Controller;
using HQT_CSDL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQT_CSDL.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            EmployeeManagement.TabEmployee = tabNhanVien;
        }
    }
}
