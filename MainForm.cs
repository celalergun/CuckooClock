using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaatBasiEx
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var printClockTimer = new Timer();
            printClockTimer.Interval = 1000;
            printClockTimer.Tick += PrintClockTimerTick;
            printClockTimer.Enabled = true;
        }

        private void PrintClockTimerTick(object sender, EventArgs e)
        {
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void SaatBasiMainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.clock;
            UpdateScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
