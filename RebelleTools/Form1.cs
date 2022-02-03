using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebelleTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        IntPtr _rebelleWindowHandle;

        private void Form1_Load(object sender, EventArgs e)
        {

            var rebelle = Process.GetProcessesByName("rebelle 5").FirstOrDefault();
            if (rebelle == null)
            {
                MessageBox.Show("Rebelle 5 is not running!");
                return;
            }

            _rebelleWindowHandle = rebelle.MainWindowHandle;

            var dpiScalingFactor = getDisplayScalingFactor(_rebelleWindowHandle);


            Win32.ShowWindow(_rebelleWindowHandle, Win32.ShowWindowEnum.ShowMaximized);
            Win32.SetForegroundWindow(_rebelleWindowHandle);

            Win32.RECT rect = new Win32.RECT();
            Win32.GetClientRect(_rebelleWindowHandle, out rect);

            var dpiScaledRect = new Win32.RECT();
            dpiScaledRect.Left = 0;
            dpiScaledRect.Top = 0;
            dpiScaledRect.Right = Convert.ToInt32(rect.Right * dpiScalingFactor);
            dpiScaledRect.Bottom = Convert.ToInt32(rect.Bottom * dpiScalingFactor);

            Win32.SetParent(this.Handle, _rebelleWindowHandle);
            Win32.SetWindowPos(this.Handle, Win32.HwndInsertAfter.HWND_TOPMOST, dpiScaledRect.Right - (this.Width + 10), 1, this.Width, this.Height, Win32.SetWindowPosFlags.SWP_NOZORDER | Win32.SetWindowPosFlags.SWP_SHOWWINDOW);

            //this.Top = 0;
            //this.Left = Convert.ToInt32( Screen.PrimaryScreen.Bounds.Right - this.Width ) - 40;
            //this.TopMost = true;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("^+z");
            Win32.SetForegroundWindow(this.Handle);
        }

        private decimal getDisplayScalingFactor(IntPtr hwnd)
        {
            var screen = Screen.FromHandle(hwnd);
         
            var dm = new Win32.DEVMODE();
            dm.dmSize = (short) Marshal.SizeOf(typeof(Win32.DEVMODE));
            
            Win32.EnumDisplaySettings(screen.DeviceName, -1, ref dm);

            var scalingFactor = Math.Round(Decimal.Divide(dm.dmPelsWidth, screen.Bounds.Width), 2);

            return scalingFactor;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("-");
            //Win32.SetForegroundWindow(this.Handle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("{TAB}");
            //Win32.SetForegroundWindow(this.Handle);
        }

        private void btnFastDry_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("f");
            //Win32.SetForegroundWindow(this.Handle);

        }

        private void btnDry_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("+d");
            //Win32.SetForegroundWindow(this.Handle);

        }

        private void btnRuler_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("+r");
            //Win32.SetForegroundWindow(this.Handle);

        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            Win32.SetForegroundWindow(_rebelleWindowHandle);
            SendKeys.Send("a");
            //Win32.SetForegroundWindow(this.Handle);
        }

        private void btnRecordScreen_Click(object sender, EventArgs e)
        {
            var process = Process.GetProcessesByName("WindowShot").FirstOrDefault();
            if (process != null) return;

            string windowShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WindowShot", "WindowShot.exe");
            Process.Start(windowShotPath);


        }

        private void btnTracePic_Click(object sender, EventArgs e)
        {
            var process = Process.GetProcessesByName("TracePic").FirstOrDefault();
            if (process != null) return;

            string windowShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TracePic", "TracePic.exe");
            Process.Start(windowShotPath);
        }
    }
}
