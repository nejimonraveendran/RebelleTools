using InputSimulatorStandard;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RebelleTools
{
    public partial class frmToolbar : Form
    {
        public frmToolbar()
        {
            InitializeComponent();

            this.MouseDown += (sndr, evt) =>
            {
                if (evt.Button == MouseButtons.Left)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
                }
            };

        }

        public enum ButtonFunction
        {
            Close = 1,
            Tab,
        }


        List<ButtonInfo> _buttonList = new List<ButtonInfo>
        {
            new ButtonInfo{ Caption = "T",  Function = ButtonFunction.Tab, Color = Color.Aqua  }
        };

        private void frmToolbar_Load(object sender, EventArgs e)
        {
            var computerInfo = new ComputerInfo();
            

            setupUi();
        }

        private void setupUi()
        {
            var controlHeightWidth = 40;
            var btnFont = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) - 10;
            this.Top = 1;
            this.Height = controlHeightWidth;

            //close button
            var btnClose = new Button();
            btnClose.Text = "X";
            btnClose.Font = btnFont;
            btnClose.Left = this.ClientRectangle.Left;
            btnClose.Top = this.ClientRectangle.Top;
            btnClose.Height = this.ClientRectangle.Height;
            btnClose.Width = controlHeightWidth;
            btnClose.Tag = ButtonFunction.Close;
            btnClose.BackColor = System.Drawing.Color.OrangeRed;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);

            


            var curLeft = this.ClientRectangle.Width;
            foreach (var btnInfo in _buttonList)
            {
                curLeft = curLeft - controlHeightWidth;

                var btn = new MyButton();
                btn.Text = btnInfo.Caption;
                btn.Font = btnFont;
                btn.Left = curLeft;
                btn.Top = this.ClientRectangle.Top;
                btn.Height = this.ClientRectangle.Height;
                btn.Width = controlHeightWidth;
                btn.Tag = btnInfo.Function;
                btn.BackColor = btnInfo.Color;
                btn.PointerDown += Btn_PointerDown;
                btn.PointerUp += Btn_PointerUp;
                this.Controls.Add(btn);


            }


            var curExStyle = Win32.GetWindowLong(this.Handle, Win32.GWL.GWL_EXSTYLE);
            Win32.SetWindowLong(this.Handle, (int)Win32.GWL.GWL_EXSTYLE, curExStyle | (int)Win32.WindowStyles.WS_EX_NOACTIVATE);
            this.TopMost = true;


        }


        InputSimulator _simulator = new InputSimulator();

        private void Btn_PointerUp(object sender, EventArgs e)
        {
            var btnFunction = (ButtonFunction)((MyButton)sender).Tag;
            switch (btnFunction)
            {
                case ButtonFunction.Close:
                    this.Close();
                    break;
                case ButtonFunction.Tab:
                    _simulator.Keyboard.KeyPress(InputSimulatorStandard.Native.VirtualKeyCode.TAB);
                    break;
                default:
                    break;
            }

        }

        private void Btn_PointerDown(object sender, EventArgs e)
        {
            var btnFunction = (ButtonFunction) ((MyButton)sender).Tag;

            switch (btnFunction)
            {
                case ButtonFunction.Close:
                    break;
                default:
                    break;
            }
        }
    }

    class ButtonInfo
    {
        public frmToolbar.ButtonFunction Function { get; internal set; }
        public string Caption { get; internal set; }
        public Color Color { get; internal set; }
    }
}
