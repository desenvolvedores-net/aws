using System;
using System.Windows.Forms;

namespace ReadCloudWatch
{
    internal static class Program
    {
        #region Private Methods

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Main());
        }

        #endregion Private Methods
    }
}