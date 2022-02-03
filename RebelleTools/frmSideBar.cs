using InputSimulatorStandard;
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
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RebelleTools
{
    public partial class frmSideBar : Form
    {

        InputSimulator _simulator = new InputSimulator();
        MyButton _btnCtrlKey = new MyButton();
        MyButton _btnColorPicker = new MyButton();
        MyButton _btnBlend = new MyButton();
        MyButton _btnTab = new MyButton();

        MyLabel _lblCtrlKey = new MyLabel();


        public frmSideBar()
        {
            InitializeComponent();


            const int btnWidth = 98;
            const int btnTop = 40;


            _lblCtrlKey.AutoSize = false;
            _lblCtrlKey.Text = "O";
            _lblCtrlKey.Left = 1;
            _lblCtrlKey.Top = btnTop;
            _lblCtrlKey.Width = btnWidth;
            _lblCtrlKey.Height = btnWidth;
            _lblCtrlKey.BackColor = SystemColors.Control;
            _lblCtrlKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _lblCtrlKey.PointerUp += _lblCtrlKey_PointerUp; ;
            _lblCtrlKey.PointerDown += _lblCtrlKey_PointerDown; ;
            //this.Controls.Add(this._lblCtrlKey);

            _btnCtrlKey.Text = "O";
            _btnCtrlKey.Left = 1;
            _btnCtrlKey.Top = btnTop;
            _btnCtrlKey.Width = btnWidth;
            _btnCtrlKey.Height = btnWidth;
            _btnCtrlKey.BackColor = SystemColors.Control;
            _btnCtrlKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _btnCtrlKey.PointerUp += _btnCtrlKey_PointerUp;
            _btnCtrlKey.PointerDown += _btnCtrlKey_PointerDown;
            //this.Controls.Add(this._btnCtrlKey);

            _btnColorPicker.Text = "*";
            _btnColorPicker.Left = _btnCtrlKey.Width + 2;
            _btnColorPicker.Top = _btnCtrlKey.Top;
            _btnColorPicker.Width = btnWidth;
            _btnColorPicker.Height = btnWidth;
            _btnColorPicker.BackColor = SystemColors.Control;
            _btnColorPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _btnColorPicker.PointerUp += _btnColorPicker_PointerUp;
            _btnColorPicker.PointerDown += _btnColorPicker_PointerDown; ;
            //this.Controls.Add(this._btnColorPicker);


            _btnBlend.Text = "B";
            _btnBlend.Left = 1;
            _btnBlend.Top = btnTop + _btnCtrlKey.Height;
            _btnBlend.Width = btnWidth;
            _btnBlend.Height = btnWidth;
            _btnBlend.BackColor = SystemColors.Control;
            _btnBlend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _btnBlend.PointerUp += _btnBlend_PointerUp;
            _btnBlend.PointerDown += _btnBlend_PointerDown; ; ;
            //this.Controls.Add(this._btnBlend);

            _btnTab.Text = "Tab";
            _btnTab.Left = _btnBlend.Width + 2;
            _btnTab.Top = _btnBlend.Top;
            _btnTab.Width = btnWidth;
            _btnTab.Height = btnWidth;
            _btnTab.BackColor = SystemColors.Control;
            _btnTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _btnTab.PointerUp += _btnTab_PointerUp;
            _btnTab.PointerDown += _btnTab_PointerDown; ; ;
            //this.Controls.Add(this._btnTab);
        }

        private void _lblCtrlKey_PointerDown(object sender, EventArgs e)
        {
            var thisControl = ((MyLabel)sender);
            thisControl.BackColor = SystemColors.Highlight;
            _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
        }

        private void _lblCtrlKey_PointerUp(object sender, EventArgs e)
        {
            var thisControl = ((MyLabel)sender);
            thisControl.BackColor = SystemColors.Control;
            _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
        }

        private void _btnTab_PointerDown(object sender, EventArgs e)
        {
            var thisControl = ((MyButton)sender);
            thisControl.BackColor = SystemColors.Highlight;
            thisControl.Refresh();

            _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.TAB);
        }

        private void _btnTab_PointerUp(object sender, EventArgs e)
        {
            var thisControl = ((MyButton)sender);
            thisControl.BackColor = SystemColors.Control;
            thisControl.Refresh();

            _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.TAB);
        }

        private void _btnBlend_PointerDown(object sender, EventArgs e)
        {
            var thisControl = ((MyButton)sender);
            thisControl.BackColor = SystemColors.Highlight;
            thisControl.Refresh();

            _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.NUMPAD3);
        }

        private void _btnBlend_PointerUp(object sender, EventArgs e)
        {
            var thisControl = ((MyButton)sender);
            thisControl.BackColor = SystemColors.Control;
            thisControl.Refresh();

            _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.NUMPAD3);
        }

        private void _btnColorPicker_PointerDown(object sender, EventArgs e)
        {
            var thisControl = ((MyButton)sender);
            thisControl.BackColor = SystemColors.Highlight;
            thisControl.Refresh();

            _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.MULTIPLY);
            //label1.Text = "pointer down";
        }

        private void _btnColorPicker_PointerUp(object sender, EventArgs e)
        {
            var thisControl = ((MyButton)sender);
            thisControl.BackColor = SystemColors.Control;
            thisControl.Refresh();

            _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.MULTIPLY);

        }

        private void _btnCtrlKey_PointerDown(object sender, EventArgs e)
        {
            _btnCtrlKey.BackColor = SystemColors.Highlight;
            _btnCtrlKey.Refresh();
            _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
       
            //label1.Text = "pointer down";
        }

        private void _btnCtrlKey_PointerUp(object sender, EventArgs e)
        {
            _btnCtrlKey.BackColor = SystemColors.Control;
            _btnCtrlKey.Refresh();
            _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
            this.Focus();
            //label1.Text = "pointer up";
        }

        private void frmSideBar_Load(object sender, EventArgs e)
        {

            // 333Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            //Application.RenderWithVisualStyles = false;
            this.Left = 0;
            this.Top = 0;
            this.Width = 200;
            this.Height = 240;
            this.BackColor = SystemColors.ControlDarkDark;


            var curExStyle = Win32.GetWindowLong(this.Handle, Win32.GWL.GWL_EXSTYLE);
            Win32.SetWindowLong(this.Handle, (int) Win32.GWL.GWL_EXSTYLE, curExStyle | (int) Win32.WindowStyles.WS_EX_NOACTIVATE);


            //Win32.SetWindowLong(this.Handle, Win32.GWL.GWL_STYLE, Win32.WindowStyles.WS_POPUP | Win32.WindowStyles.WS_VISIBLE | Win32.WindowStyles.WS_CLIPSIBLINGS);
            //Win32.SetWindowLong(this.Handle, Win32.GWL.GWL_EXSTYLE, Win32.WindowStyles.WS_EX_LEFT | Win32.WindowStyles.WS_EX_LTRREADING |
            //                                                        Win32.WindowStyles.WS_EX_RIGHTSCROLLBAR | Win32.WindowStyles.WS_EX_TOPMOST |
            //                                                        Win32.WindowStyles.WS_EX_TOOLWINDOW | Win32.WindowStyles.WS_EX_LAYERED | Win32.WindowStyles.WS_EX_NOACTIVATE);



            //AppBar.RegisterFormAsAppBar(this);
            //AppBar.SetAppBarPosition(this, AppBar.AppBarPosition.Left);


            btnClose.Top = 0;
            btnClose.Width = 30;
            btnClose.Height = 30;
            btnClose.Left = this.Width - btnClose.Width;

            btnRecord.Top = btnClose.Top;
            btnRecord.Width = btnClose.Width;
            btnRecord.Height = btnClose.Height;
            btnRecord.Left = btnClose.Left - btnRecord.Width;

            btnTrace.Top = btnRecord.Top;
            btnTrace.Width = btnRecord.Width;
            btnTrace.Height = btnRecord.Height;
            btnTrace.Left = btnRecord.Left - btnTrace.Width;

            

            this.TopMost = true;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSideBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppBar.UnRegisterFormAsAppBar(this);
        }

        private void frmSideBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            var process = Process.GetProcessesByName("WindowShot").FirstOrDefault();
            if (process != null) return;

            string windowShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WindowShot", "WindowShot.exe");
            Process.Start(windowShotPath);
        }

        private void btnTrace_Click(object sender, EventArgs e)
        {
            var process = Process.GetProcessesByName("TracePic").FirstOrDefault();
            if (process != null) return;

            string windowShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TracePic", "TracePic.exe");
            Process.Start(windowShotPath);
        }

        protected override void WndProc(ref Message m)
        {
            
            switch ((Win32.WindowMessages)m.Msg)
            {
                
                case Win32.WindowMessages.WM_POINTERDOWN:
                    this.BackColor = SystemColors.Highlight;        
                    sendMessage(unchecked((short)m.LParam) - this.Left, unchecked((short)((uint)m.LParam >> 16)) - this.Top, true);
                    break;

                case Win32.WindowMessages.WM_POINTERUP:
                    this.BackColor = SystemColors.ControlDarkDark;
                    sendMessage(unchecked((short)m.LParam) - this.Left, unchecked((short)((uint)m.LParam >> 16)) - this.Top, false);
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }

        void sendMessage(int x, int y, bool isDown)
        {
            if (x < (this.Width / 2) && y < (this.Height / 2))
            {
                label1.Text = x.ToString() + ", " + y.ToString() + " - size";
                if(isDown)
                    _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
                else
                    _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.LCONTROL);
            }
            else if (x < (this.Width / 2) && y > (this.Height / 2))
            {
                label1.Text = x.ToString() + ", " + y.ToString() + " - blend";
                if(isDown)
                    _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.NUMPAD3);
                else
                    _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.NUMPAD3);
            }
            else if (x > (this.Width / 2) && y < (this.Height / 2))
            {
                label1.Text = x.ToString() + ", " + y.ToString() + " - pick color";

                if(isDown)
                    _simulator.Keyboard.KeyDown(InputSimulatorStandard.Native.VirtualKeyCode.MULTIPLY);
                else
                    _simulator.Keyboard.KeyUp(InputSimulatorStandard.Native.VirtualKeyCode.MULTIPLY);
            }
            else if (x > (this.Width / 2) && y > (this.Height / 2))
            {
                label1.Text = x.ToString() + ", " + y.ToString() + " - fast dry";
             
                if(isDown)
                    _simulator.Keyboard.KeyPress(InputSimulatorStandard.Native.VirtualKeyCode.NUMPAD4);
            }
            else
            {

            }
        }

        void drawRegions()
        {
            using (var frmGraphics = this.CreateGraphics())
            {

                using (var myPen = new Pen(System.Drawing.Color.White, 1))
                {
                    frmGraphics.DrawLine(myPen, this.Width / 2, 0, this.Width / 2, this.Bottom);
                    frmGraphics.DrawLine(myPen, 0, this.Height / 2, this.Width, this.Height / 2);

                    using (var myBrush = new SolidBrush(System.Drawing.Color.Orange))
                    {
                        frmGraphics.DrawString("O", new Font(FontFamily.GenericSansSerif, 12), myBrush, this.Left + 40, this.Top + 50);
                        frmGraphics.DrawString("*", new Font(FontFamily.GenericSansSerif, 12), myBrush, this.Width - 50, this.Top + 60);
                        frmGraphics.DrawString("B", new Font(FontFamily.GenericSansSerif, 12), myBrush, this.Left + 40, this.Bottom - 70);
                        frmGraphics.DrawString("D", new Font(FontFamily.GenericSansSerif, 12), myBrush, this.Width - 60, this.Height - 70);

                    }


                }
            }
        }

        private void frmSideBar_Activated(object sender, EventArgs e)
        {
            //drawRegions();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            drawRegions();
            base.OnPaint(e);
        }
    }


    class MyButton : Button
    {
        public event EventHandler PointerDown;
        public event EventHandler PointerUp;
        protected override void WndProc(ref Message m)
        {
            switch ((Win32.WindowMessages)m.Msg)
            {
                case Win32.WindowMessages.WM_POINTERDOWN:
                    PointerDown(this, new EventArgs());
                    break;
                case Win32.WindowMessages.WM_POINTERUP:
                    PointerUp(this, new EventArgs());
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }
    }


    class MyLabel : Label
    {
        public event EventHandler PointerDown;
        public event EventHandler PointerUp;
        protected override void WndProc(ref Message m)
        {
            switch ((Win32.WindowMessages)m.Msg)
            {
                case Win32.WindowMessages.WM_POINTERDOWN:
                    PointerDown(this, new EventArgs());
                    break;
                case Win32.WindowMessages.WM_POINTERUP:
                    PointerUp(this, new EventArgs());
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }
    }
}

