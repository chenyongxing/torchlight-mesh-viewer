using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mogre.Demo.MogreForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static unsafe void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            try
            {
                string passedModel = string.Empty;
                if (args.Length > 0) passedModel = args[0];

                //var mogreform = new MogreForm(passedModel);
                //mogreform.Go();

                Application.Run(new MogreForm(passedModel));
                //Application.DoEvents();
            }
            catch (System.Runtime.InteropServices.SEHException)
            {
                if (OgreException.IsThrown)
                    MessageBox.Show(OgreException.LastException.FullDescription,
                                    "An Ogre exception has occurred!");
                else
                    throw;
            } 
        }
    }
}