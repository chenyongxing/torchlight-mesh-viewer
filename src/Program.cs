using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

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
            catch (Exception ex)
                
            {
                if (ex is System.Runtime.InteropServices.SEHException)
                {
                    if (OgreException.IsThrown)
                        MessageBox.Show(OgreException.LastException.FullDescription,
                                        "An Ogre exception has occurred!");
                    else
                        throw;
                }
                else
                {
                    string SourceName = "WindowsService.ExceptionLog";
                    if (!EventLog.SourceExists(SourceName))
                    {
                        EventLog.CreateEventSource(SourceName, "Application");
                    }

                    EventLog eventLog = new EventLog();
                    eventLog.Source = SourceName;
                    string message = string.Format("Exception: {0} \n\nStack: {1}", ex.Message, ex.StackTrace);
                    eventLog.WriteEntry(message, EventLogEntryType.Error);            
                }
            } 
        }
    }
}