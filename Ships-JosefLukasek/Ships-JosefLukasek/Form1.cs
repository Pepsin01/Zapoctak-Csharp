using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ships_JosefLukasek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum ScreenState { FULLSCREEN, BORDERED };
        ScreenState screenState = ScreenState.BORDERED;
        private void fullscreenBtn_Click(object sender, EventArgs e)
        {
            if (screenState == ScreenState.BORDERED)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                screenState = ScreenState.FULLSCREEN;
            }
            else
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                screenState = ScreenState.BORDERED;
            }
        }
    }
}
