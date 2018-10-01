using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client_Simple_Call_Node_js_Socket
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
            Application.Run(new Main());
        }
    }
}
