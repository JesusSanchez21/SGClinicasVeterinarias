using SG_ClinicasVeterinarias.pt.com.GCV.VIEWS;
using System;
using System.Windows.Forms;

namespace SG_ClinicasVeterinarias
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
