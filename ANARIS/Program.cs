using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
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

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string programVersion = fvi.FileVersion;
            
            
            MainWindow view = new MainWindow(programVersion);
            ANS_Model mdl = new ANS_Model();            
            ANS_Controller cnt = new ANS_Controller(mdl , view, programVersion);
            
            Application.Run(view);
            
        }
    }
}
