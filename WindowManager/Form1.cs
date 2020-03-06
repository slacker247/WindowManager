using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CoreAudioApi;
using WindowManager.Properties;

namespace WindowManager
{
    public partial class Form1 : Form
    {
        protected PInvoke.desktop.User32.WindowEnumProc windowEnumProc;
        protected bool m_LastSave = false;
        MMDevice m_DefaultDevice;
        protected bool m_MuteAudio = false;
        Dictionary<IntPtr, Window> m_Windows = new Dictionary<IntPtr, Window>();

        public Form1()
        {
            InitializeComponent();
            windowEnumProc = new PInvoke.desktop.User32.WindowEnumProc(addChildWnd);
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            m_DefaultDevice = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
        }

        protected void addWindow(String title, IntPtr hWnd)
        {
            if(!m_Windows.ContainsKey(hWnd))
                m_Windows[hWnd] = new Window(title, hWnd);
            m_Windows[hWnd].update();
            lsb_Windows.Items.Add(m_Windows[hWnd]);
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
                    //if ( ( (exstyle & PInvoke.Constants.WS_EX_APPWINDOW) != 0)
                    //    || (PInvoke.desktop.User32.GetWindow(hwnd, PInvoke.Constants.GW_OWNER) != IntPtr.Zero &&
                    //        (exstyle & PInvoke.Constants.WS_EX_TOOLWINDOW) == 0)) 
                    long style = PInvoke.desktop.User32.GetWindowLong(hwnd, PInvoke.Constants.GWL_STYLE);
                    if ((style & PInvoke.Constants.WS_MINIMIZE) == 0 &&
                        (exstyle & PInvoke.Constants.WS_EX_TOOLWINDOW) == 0)
                    {
                        addWindow(title, hwnd);
                    }
                }
            }
            return status;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            lsb_Windows.Items.Clear();
            Process[] processlist = Process.GetProcesses();
            if (PInvoke.desktop.User32.EnumDesktopWindows(IntPtr.Zero, windowEnumProc, IntPtr.Zero))
            {
                //if (!String.IsNullOrEmpty(process.MainWindowTitle))
                //{
                //    addWindow(process.MainWindowTitle, process.MainWindowHandle);
                //    PInvoke.desktop.User32.EnumChildWindows(process.MainWindowHandle, windowEnumProc, IntPtr.Zero);
                //    IntPtr pWnd = PInvoke.desktop.User32.GetWindow(process.MainWindowHandle, PInvoke.Constants.GW_OWNER);
                //    if(pWnd != IntPtr.Zero)
                //    {
                //        String title = getWindowTitle(pWnd);
                //        if(title.Length > 0)
                //            addWindow(title, pWnd);
                //    }
                //}
                lbl_WndCnt.Text = "Window Count: " + lsb_Windows.Items.Count.ToString();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
                foreach (Window wnd in lsb_Windows.Items)
                {
                    wnd.move(true);
                }
        }
        
        long lastTickCount = 0;
        DateTime lastInputTime = new DateTime();
        PInvoke.structures.LASTINPUTINFO lastInputBuffer = new PInvoke.structures.LASTINPUTINFO();
        private void tmr_UserIdle_Tick(object sender, EventArgs e)
        {
            lastInputBuffer.cbSize = (uint)Marshal.SizeOf(lastInputBuffer);
            lastInputBuffer.dwTime = 0;
            if (PInvoke.desktop.User32.GetLastInputInfo(ref lastInputBuffer) &&
                cbx_Auto.Checked)
            {
                if (lastInputBuffer.dwTime != lastTickCount)
                {
                    lastTickCount = lastInputBuffer.dwTime;
                    lastInputTime = DateTime.Now;
                    if (btn_Save.Enabled == false)
                    {
                        btn_Update_Click(sender, null);
                        tmr_LateUpdate.Enabled = true;
                    }
                    m_DefaultDevice.AudioEndpointVolume.Mute = false;
                    m_LastSave = false;
                    btn_Save.Enabled = true;
                    lbl_Status.Text = "Last move: " + DateTime.Now.ToString("h:mm:ss tt");
                }
                else if ((DateTime.Now - lastInputTime).TotalMinutes > 3 &&
                        !System.Windows.Forms.SystemInformation.TerminalServerSession)
                {
                    if (!m_LastSave)
                    {
                        m_LastSave = true;
                        btn_Save_Click(sender, null);
                        btn_Save.Enabled = false;
                    }
                    if (DateTime.Now.Hour > 21 ||
                        DateTime.Now.Hour < 6)
                        m_DefaultDevice.AudioEndpointVolume.Mute = true;
                }
            }
        }

        private void mi_AddWnd_Click(object sender, EventArgs e)
        {
            AddWindowDlg dlg = new AddWindowDlg();
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                foreach(Window wnd in dlg.lsb_Windows.SelectedItems)
                    lsb_Windows.Items.Add(wnd);
            }
        }

        private void tmr_LateUpdate_Tick(object sender, EventArgs e)
        {
            tmr_LateUpdate.Enabled = false;
            btn_Update_Click(sender, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings props = WindowManager.Properties.Settings.Default;

                props.WndLoc = this.Location;

                // Set window location
                if (this.WindowState == FormWindowState.Normal)
                {
                    props.WndSize = this.Size;
                }
                else
                {
                    props.WndSize = this.RestoreBounds.Size;
                }
                props.Save();
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
                msg += System.Environment.NewLine + ex.StackTrace;
                Utilities.Logger.log(msg,
                    Utilities.MessageSeverity.ERROR,
                    Utilities.MessageDestination.FILE);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Rectangle scrn = Screen.FromControl(this).Bounds;
                Properties.Settings props = WindowManager.Properties.Settings.Default;

                // Set window location
                if (props.WndLoc != null)
                {
                    this.Location = props.WndLoc;
                }

                // Set window size
                if (props.WndSize != null)
                {
                    this.Size = props.WndSize;
                }
                if (!scrn.Contains(this.Location))
                {
                    float scrnMidX = scrn.Width / 2.0f;
                    float scrnMidY = scrn.Height / 2.0f;
                    float wndMidX = this.Size.Width / 2.0f;
                    float wndMidY = this.Size.Height / 2.0f;

                    float posX = Math.Abs(scrnMidX - wndMidX);
                    float posY = Math.Abs(scrnMidY - wndMidY);

                    this.Location = new Point((int)posX, (int)posY);
                }
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
                msg += System.Environment.NewLine + ex.StackTrace;
                Utilities.Logger.log(msg,
                    Utilities.MessageSeverity.ERROR,
                    Utilities.MessageDestination.FILE);
            }
        }
    }
}
