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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            btn_Login.MouseDown += (s, e) => {
                btn_Login.BackgroundImage = Properties.Resources.c_button1;
            };
    
            btn_Login.MouseUp += (s, e) => {
                btn_Login.BackgroundImage = Properties.Resources.button1;
            };
        }
    }
}
