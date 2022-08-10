using ApartmanYönetimSistemi.UI;

namespace ApartmanYönetimSistemi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            //Application.Run(new frmGiris());
            Application.Run(new Giris());
        }
    }
}