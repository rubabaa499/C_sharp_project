using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop2Project
{
    public delegate int fareclc(int del_fare, int del_count);
    public class delfare1
    {
        static public int dld(int deefare, int deecont)
        {

            return deefare * deecont;

        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //delfare1 deleclss = new delfare1();

           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm: new Form1());
        }
    }
}
