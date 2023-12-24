using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Controls.Dialogs
{
    public static class MessageBox
    {
        public enum Buttons
        {
            Ok,
            YesNo,
            YesNoCancel,
            YesNoRetry
        }

        public static DialogResult ShowDialog(string Title, string Description, Buttons buttons, Image image = null)
        {
            MessageBoxWindow window = new MessageBoxWindow(Title, Description, buttons, image);
            return window.ShowDialog();
        }
    }
}
