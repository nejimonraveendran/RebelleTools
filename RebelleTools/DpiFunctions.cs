using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebelleTools
{
    internal static class DpiFunctions
    {

        public static int MultiplyByDpi(int val, decimal scalingFactor)
        {
            return Convert.ToInt32(val * scalingFactor);
        }

        public static int DivideByDpi(int val, decimal scalingFactor)
        {
            if (val == 0) return val;

            return Convert.ToInt32(val / scalingFactor);
        }

        public static decimal GetScreenScalingFactor(Screen screen)
        {
            var dm = new Win32.DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(Win32.DEVMODE));

            Win32.EnumDisplaySettings(screen.DeviceName, -1, ref dm);

            var scalingFactor = Math.Round(Decimal.Divide(dm.dmPelsWidth, screen.Bounds.Width), 2);

            return scalingFactor;
        }
    }
}
