using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DabaiNA.Common
{
    class Runtime
    {
        public static bool m_IsRunning;
        public static bool m_IsRefreshToken;
        public static RichTextBox ServerLog;

        /// <summary>
        /// 显示软件运行日志
        /// </summary>
        /// <param name="info"></param>
        public delegate void ShowLogEventHandler(string info);
        public static void ShowLog(string info)
        {
            if (Runtime.ServerLog.InvokeRequired)
            {
                ShowLogEventHandler showLogHandler = new ShowLogEventHandler(Runtime.ShowLog);
                Runtime.ServerLog.BeginInvoke(showLogHandler, info);
            }
            else
            {
                string s = "";
                for (int i = 0; i < Runtime.ServerLog.Lines.Length; i++)
                {
                    if (i > 200)
                        break;
                    s += ("\r\n" + Runtime.ServerLog.Lines[i]);
                }
                Runtime.ServerLog.Text = (DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff") + " >>>  " + info + s);
            }
        }
    }
}
