using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebelleTools
{
    internal static class AppBar
    {
        private static int uCallBack;

        public enum AppBarPosition
        {
            Left = 0, Top, Right, Bottom    
        }

        public static void RegisterFormAsAppBar(Form frm)
        {
            var appBarData = new Win32.APPBARDATA();
            appBarData.cbSize = Marshal.SizeOf(appBarData);
            appBarData.hWnd = frm.Handle;

            uCallBack = Win32.RegisterWindowMessage("RebelleToolsAppBarMessage");

            if (uCallBack == 0)
                throw new Exception("Failed to register the app bar message");

            appBarData.uCallbackMessage = uCallBack;

            var ret = Win32.SHAppBarMessage((int)Win32.ABMsg.ABM_NEW, ref appBarData);

            if (ret == 0)
                throw new Exception("Failed to (re)register the app bar");

        }

        public static void UnRegisterFormAsAppBar(Form frm)
        {
            var appBarData = new Win32.APPBARDATA();
            appBarData.cbSize = Marshal.SizeOf(appBarData);
            appBarData.hWnd = frm.Handle;

            Win32.SHAppBarMessage((int)Win32.ABMsg.ABM_REMOVE, ref appBarData);
        }


        public static void SetAppBarPosition(Form frm, AppBarPosition proposedPosition)
        {
            var appBarData = new Win32.APPBARDATA();
            appBarData.cbSize = Marshal.SizeOf(appBarData);
            appBarData.hWnd = frm.Handle;
            
            var screen = Screen.FromHandle(frm.Handle);
            var screenDpiScalingFactor = DpiFunctions.GetScreenScalingFactor(screen);

            //send message to Windows with the bounds we want.  When the func returns, the structure will contain the approved bounds.
            switch (proposedPosition)
            {
                case AppBarPosition.Left:
                    appBarData.uEdge = (int)Win32.ABEdge.ABE_LEFT;
                    appBarData.rcRectangle.Left = 0;
                    appBarData.rcRectangle.Top = 0;
                    appBarData.rcRectangle.Bottom = screen.Bounds.Height;
                    appBarData.rcRectangle.Right = DpiFunctions.MultiplyByDpi(frm.Bounds.Width, screenDpiScalingFactor);

                    Win32.SHAppBarMessage((int)Win32.ABMsg.ABM_QUERYPOS, ref appBarData);
                    Win32.SHAppBarMessage((int)Win32.ABMsg.ABM_SETPOS, ref appBarData);

                    Win32.SetWindowPos(appBarData.hWnd, Win32.HwndInsertAfter.HWND_TOPMOST, 
                                                      DpiFunctions.DivideByDpi(appBarData.rcRectangle.Left, screenDpiScalingFactor),
                                                      DpiFunctions.DivideByDpi(appBarData.rcRectangle.Top, screenDpiScalingFactor),
                                                      DpiFunctions.DivideByDpi(appBarData.rcRectangle.Right, screenDpiScalingFactor),
                                                      DpiFunctions.DivideByDpi(appBarData.rcRectangle.Bottom, screenDpiScalingFactor), Win32.SetWindowPosFlags.SWP_FRAMECHANGED);

                    break;
                case AppBarPosition.Top:
                    break;
                case AppBarPosition.Right:
                    break;
                case AppBarPosition.Bottom:
                    break;
                default:
                    break;
            }

            
        }


    }
}
