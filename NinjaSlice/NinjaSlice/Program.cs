using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NinjaSlice
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MainGame game = new MainGame())
            {
                game.Run();
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Launcher());
        }
    }
#endif
}
