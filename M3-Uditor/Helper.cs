using M3_Uditor.Properties;
using M3Controls;
using M3U8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace M3_Uditor
{
    public static class Helper
    {
        public static Stack<StackObject> UndoStack = new Stack<StackObject>();
        public static Stack<StackObject> RedoStack = new Stack<StackObject>();

        public const string FilterAll = "All Types (*.m3, *.m3u, *.m3u8)|*.m3;*.m3u;*.m3u8|All Files (*.*)|*.*";
        public const string FilterM3 = "M3-Uditor (*.m3)|*.m3|All Files (*.*)|*.*";
        public const string FilterM3U = "Playlist File (*.m3u, *.m3u8)|*.m3u;*.m3u8|Text File (*.txt)|*.txt|All Files (*.*)|*.*";

        public static List<int> SearchStreamResults = new List<int>();
        public static int SearchStreamSelectedIndex = 0;

        //DragDrop
        public static Size dragSize = new Size(2,2);
        public static Rectangle dragBoxFromMouseDown;

        public static Dictionary<string, Image> Flags = new Dictionary<string, Image>();
        public static DialogResult MessageBoxPlaylistChanges(Playlist playlist)
        {
            return MessageBox.Show("Save changes to file?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //return M3Controls.Dialogs.MessageBox.ShowDialog(Application.ProductName, "Save changes to file?", M3Controls.Dialogs.MessageBox.Buttons.YesNoCancel, Resources.StreamUnkown);
        }
        public static void ResetControlsOnForm(Form form)
        {
            ResetControl(form.Controls);
        }
        public static void CreateDragBox(Point atLocation)
        {
            dragBoxFromMouseDown = new Rectangle(new Point(atLocation.X - dragSize.Width / 2, atLocation.Y - dragSize.Height / 2), dragSize);
        }    
        public static void StartVlcPlayer(string url)
        {
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo();

            info.FileName = Settings.Default.VlcPath;
            info.Arguments = url;

            process.StartInfo = info;
            process.Start();
        }
        public static void AddRecentFile(string filename)
        {
            if ( !Settings.Default.RecentFiles.Contains(filename) )
            {
                Settings.Default.RecentFiles.Insert(0, filename);
                Settings.Default.Save();
            }
        }
        public static void RemoveRecentFile(string filename)
        {
            Settings.Default.RecentFiles.Remove(filename);
            Settings.Default.Save();
        }

        /// <summary>
        /// Truncates a string to a given length for GDI painting and adds ellipses.
        /// </summary>
        /// <param name="text">The string to be truncated</param>
        /// <param name="font">The font for textmeasure</param>
        /// <param name="maxWidth">The maximum text length</param>
        /// <returns>Returns a new, truncated string</returns>
        public static string TruncateString(string text, Font font, int maxWidth)
        {
            string truncatedText = text;
            int descriptionLength = TextRenderer.MeasureText(truncatedText + "...", font).Width;
            int maxTextWidth = maxWidth;

            if (descriptionLength > maxTextWidth)
            {
                int i = truncatedText.Length;
                while (TextRenderer.MeasureText(truncatedText + "...", font).Width > maxTextWidth)
                {
                    truncatedText = truncatedText.Substring(0, --i);
                    if (i == 0) break;
                }
                truncatedText = truncatedText + "...";
            }
            return truncatedText;
        }

        /// <summary>
        /// Calls BeginUpdate() for the given array of ListBoxes.
        /// You must call EndUpdate()!
        /// </summary>
        /// <param name="controls">The array[] of ListBox</param>
        public static void BeginUpdate(ListBox[] controls)
        {
            foreach (var control in controls)
            {              
                control.BeginUpdate();
            }
        }

        /// <summary>
        /// Calls BeginUpdate() for each control on form, if available.
        /// You must call EndUpdate()!
        /// </summary>
        public static void BeginUpdate()
        {
            Form form = Application.OpenForms[0];
            InternalBeginUpdate(form.Controls);
        }
        
        /// <summary>
        /// Calls EndUpdate() for the given array of ListBoxes.
        /// </summary>
        /// <param name="controls">The array[] of ListBox</param>
        public static void EndUpdate(ListBox[] controls)
        {
            foreach (var control in controls)
            {
                control.EndUpdate();
                control.Update();
            }
        }

        /// <summary>
        /// Calls EndUpdate() for each control on form, if available.
        /// </summary>
        public static void EndUpdate()
        {
            Form form = Application.OpenForms[0];
            InternalEndUpdate(form.Controls);
        }

        /// <summary>
        /// Refreshes all controls on form with method invoking
        /// </summary>
        /// <param name="form">The form, which controls should be refreshed</param>
        public static void RefreshControls(Form form)
        {
            InternalRefreshControls(form.Controls);
        }

        internal static void InternalRefreshControls(Control.ControlCollection controlCollection)
        {
            foreach(Control control in controlCollection)
            {
                if (control.HasChildren)
                    InternalRefreshControls(control.Controls);

                Type type = control.GetType();
                MethodInfo methodInfo = type.GetMethod("Refresh");
                methodInfo?.Invoke(control, null);
            }
        }
        internal static void InternalBeginUpdate(Control.ControlCollection controlCollection)
        {
            foreach(Control control in controlCollection)
            {
                if (control.HasChildren)
                    InternalBeginUpdate(control.Controls);

                Type type = control.GetType();
                MethodInfo methodInfo = type.GetMethod("BeginUpdate");
                methodInfo?.Invoke(control, null);
            }
        }
        internal static void InternalEndUpdate(Control.ControlCollection controlCollection)
        {
            foreach (Control control in controlCollection)
            {
                if (control.HasChildren)
                    InternalEndUpdate(control.Controls);

                Type type = control.GetType();
                MethodInfo methodInfo = type.GetMethod("EndUpdate");
                methodInfo?.Invoke(control, null);
            }
        }
        private static void ResetControl(Control.ControlCollection control)
        {
            foreach (Control c in control)
            {
                if (c.HasChildren)
                    ResetControl(c.Controls);

                if (c.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)c;
                    if (!c.Name.Contains("textBoxSearch")) textBox.Clear();
                }
                if (c.GetType() == typeof(ExtendedListBox))
                {
                    ExtendedListBox extendedListBox = (ExtendedListBox)c;
                    extendedListBox.DataSource = null;
                }
            }
        }

        internal static void LoadFlags()
        {
            // europe
            Flags.Add("[EU]", Resources.icons8_flagge_von_europa_40);
            // turkey
            Flags.Add("[TR]", Resources.icons8_turkei_40);
            // vae
            Flags.Add("[AR]", Resources.icons8_vereinigte_arabische_emirate_40);
            // france
            Flags.Add("[FR]", Resources.icons8_frankreich_40);
            // british
            Flags.Add("[EN", Resources.icons8_großbritannien_40);
            // italy
            Flags.Add("[IT]", Resources.icons8_italien_40);
            // netherlands
            Flags.Add("[NL]", Resources.icons8_niederlande_40);
            // germany
            Flags.Add("[DE]", Resources.icons8_deutschland_40);
        }

        public static void AutoInvoke(Delegate theEvent, object[] args)
        {
            foreach (Delegate d in theEvent.GetInvocationList())
            {
                if (d.Target is ISynchronizeInvoke syncer && syncer.InvokeRequired)
                {
                    syncer.BeginInvoke(d, args);
                }
                else
                {
                    d.DynamicInvoke(args);
                }
            }
        }
    }
}
