using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaatBasiEx
{
    public class AppContext: ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon = null;
        private MainForm _sbmfrm = null;
        public AppContext()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.clock,
                
                Visible = true,
                Text = "Guguk...",
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Çıkış", AppExit)
                })
            };
            _notifyIcon.DoubleClick += NotifyIconDoubleClick;

            var timerCheckClock = new Timer {Interval = 1000};
            timerCheckClock.Tick += SaateBak_Tick;
            timerCheckClock.Enabled = true;
        }

        private void SaateBak_Tick(object sender, EventArgs e)
        {
            DateTime an = DateTime.Now;
            if ((an.Minute == 0) && (an.Second == 00))
            {
                if (_sbmfrm == null)
                {
                    _sbmfrm = new MainForm();
                    _sbmfrm.ShowDialog();
                    _sbmfrm.Dispose();
                    _sbmfrm = null;
                }
            }
        }

        private void AppExit(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void NotifyIconDoubleClick(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.ShowDialog();
        }
    }
}
