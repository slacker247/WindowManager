using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowManager
{
    public partial class AddWindowDlg : Form
    {
        protected PInvoke.desktop.User32.WindowEnumProc windowEnumProc;

        public AddWindowDlg()
        {
            InitializeComponent();
            windowEnumProc = new PInvoke.desktop.User32.WindowEnumProc(addChildWnd);
            PInvoke.desktop.User32.EnumDesktopWindows(IntPtr.Zero, windowEnumProc, IntPtr.Zero);
        }

        protected void addWindow(String title, IntPtr hWnd)
        {
            Window wnd = new Window(title, hWnd);
            lsb_Windows.Items.Add(wnd);
        }

        protected String getWindowTitle(IntPtr hwnd)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);

            if (PInvoke.desktop.User32.GetWindowText(hwnd, Buff, nChars) > 0)
            {
            }
            return Buff.ToString();
        }

        protected int addChildWnd(IntPtr hwnd, IntPtr lparam)
        {
            int status = -1;

            String title = getWindowTitle(hwnd);
            if (title.Contains("GetWindowLong"))
                Console.Write("");
            if (title.Length > 0)
            {
                if (PInvoke.desktop.User32.IsWindowVisible(hwnd) && string.IsNullOrEmpty(title) == false)
                {
                    long exstyle = PInvoke.desktop.User32.GetWindowLong(hwnd, PInvoke.Constants.GWL_EXSTYLE);
                    long style = PInvoke.desktop.User32.GetWindowLong(hwnd, PInvoke.Constants.GWL_STYLE);
                    //if ((style & PInvoke.Constants.WS_MINIMIZE) == 0)
                    {
                        addWindow(title, hwnd);
                    }
                }
            }
            return status;
        }
    }
}
