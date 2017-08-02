using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            int start = Form1.f.LogRichTextBox.Text.Length;
            Form1.f.LogRichTextBox.AppendText(s);
            Form1.f.LogRichTextBox.Select(start, s.Length);
            Form1.f.LogRichTextBox.SelectionColor = Color.Red;
            Form1.f.LogRichTextBox.ScrollToCaret();
        }

        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="s">信息详情</param>
        public static void LogInfo(string s)
        {
            int start = Form1.f.LogRichTextBox.Text.Length;
            Form1.f.LogRichTextBox.AppendText(s + "\r\n");
            Form1.f.LogRichTextBox.Select(start, s.Length);
            Form1.f.LogRichTextBox.SelectionColor = Color.Black;
            Form1.f.LogRichTextBox.ScrollToCaret();
        }
    }
}
