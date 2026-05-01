using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWindows.Forms.Systems
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            btn_LogOut.MouseDown += (s, e) => {
                btn_LogOut.BackgroundImage = Properties.Resources.button_c;
            };

            btn_LogOut.MouseUp += (s, e) => {
                btn_LogOut.BackgroundImage = Properties.Resources.button;
            };

            btn_Exit.MouseDown += (s, e) =>
            {
                btn_Exit.BackgroundImage = Properties.Resources.button_c;
            };

            btn_Exit.MouseUp += (s, e) => {
                btn_Exit.BackgroundImage = Properties.Resources.button;
            };
        }
    }
}
