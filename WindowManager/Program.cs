using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WindowManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(catchAll);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void catchAll(object sender, ThreadExceptionEventArgs t)
        {
            Exception ex = t.Exception;
            String msg = ex.Message;
            msg += System.Environment.NewLine + ex.StackTrace;
            Utilities.Logger.log(msg,
                Utilities.MessageSeverity.ERROR,
                Utilities.MessageDestination.FILE);
        }
    }
}
