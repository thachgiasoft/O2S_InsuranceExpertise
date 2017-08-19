using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using log4net;
using System.Threading;
using AutoMapper;

namespace O2S_InsuranceExpertise
{
    static class Program
    {
        private static readonly ILog logFile = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.AppendPrivatePath(AppDomain.CurrentDomain.BaseDirectory + @"\Library");
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Mapper.AssertConfigurationIsValid();

                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                Common.Logging.LogSystem.Info("Application_Start. Time=" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            Application.Run(new O2S_InsuranceExpertise.GUI.FormCommon.frmLogin());
        }

    }
}
