using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQSim
{
    public class Log
    {
        /// <summary>
        /// 记录bug
        /// </summary>
        /// <param name="s">bug详情</param>
        public static void LogBug(string s)
        {
            Form1.f.LogTextBox.AppendText(s + "\r\n");
            return;
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="s">信息详情</param>
        public static void LogInfo(string s)
        {
            Form1.f.LogTextBox.AppendText(s + "\r\n");
            return;
        }
    }
}
