using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using M3_Uditor.Properties;

namespace M3_Uditor
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Settings.Default.ShowStartDialog)
            {
                Application.Run(new Forms.FormStart());
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
    }
}
