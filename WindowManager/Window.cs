using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowManager
{
    public class Window
    {
        protected IntPtr m_Handle = IntPtr.Zero;
        protected String m_Title = "";
        protected Point m_Location = new Point(0, 0);
        protected int m_Width = -1;
        protected int m_Height = -1;
        protected bool m_SetSize = false;
        protected Thread m_ActiveThread = null;
        protected Timer m_ThreadCheck;

        public Window(String title, IntPtr hWnd)
        {
            setHandle(hWnd);
            setTitle(title);
        }

        public IntPtr getHandle()
        {
            return this.m_Handle;
        }

        public int setHandle(IntPtr hWnd)
        {
            int status = -1;
            this.m_Handle = hWnd;
            this.update();
            return status;
        }

        public String getTitle()
        {
            return this.m_Title;
        }

        public int setTitle(String title)
        {
            int status = -1;
            this.m_Title = title;
            return status;
        }

        public Point getLocation()
        {
            return this.m_Location;
        }

        public int setLocation(Point loc)
        {
            int status = -1;
            this.m_Location = loc;
            return status;
        }

        public int getWidth()
        {
            return this.m_Width;
        }

        public int setWidth(int width)
        {
            int status = -1;
            this.m_Width = width;
            return status;
        }

        public int getHeight()
        {
            return this.m_Height;
        }

        public int setHeight(int height)
        {
            int status = -1;
            this.m_Height = height;
            return status;
        }

        public void checkThread(object state)
        {
            Timer t = (Timer)state;
            t.Dispose();
            if (m_ActiveThread.IsAlive)
            {
                m_ActiveThread.Abort();
            }
        }

        public void moveAsync()
        {
            short resize = PInvoke.Constants.SWP_NOSIZE;
            if (m_SetSize)
                resize = 0;
            PInvoke.desktop.User32.SetWindowPos(getHandle(),
                         0,  // HWND_TOP
                         getLocation().X,
                         getLocation().Y,
                         getWidth(),
                         getHeight(),
                         resize | PInvoke.Constants.SWP_NOZORDER | PInvoke.Constants.SWP_SHOWWINDOW);
        }

        public int move(bool setSize = false)
        {
            int status = -1;
            m_SetSize = setSize;
            ThreadStart ts = new ThreadStart(moveAsync);
            Thread th = new Thread(ts);
            th.Name = this.m_Title;
            th.Start();
            m_ActiveThread = th;

            m_ThreadCheck = new Timer(this.checkThread);
            m_ThreadCheck.Change(new TimeSpan(0, 0, 15), new TimeSpan(System.Threading.Timeout.Infinite));
            return status;
        }

        PInvoke.structures.RECT rct = new PInvoke.structures.RECT();
        public int update()
        {
            int status = -1;
            PInvoke.desktop.User32.GetWindowRect(getHandle(), ref rct);
            this.setHeight(rct.Bottom - rct.Top);
            this.setWidth(rct.Right - rct.Left);
            this.setLocation(new Point(rct.Left, rct.Top));
            return status;
        }

        public override string ToString()
        {
            String str = "";
            str = getTitle();
            str += " (" + getLocation().X + ", " + getLocation().Y + ")";
            return str;
        }
    }
}
