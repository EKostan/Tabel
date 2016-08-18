using System;
using DevExpress.ExpressApp.Win.Utils;

namespace UserInterface.Splash
{
    public partial class MainSplashScreenForm : DevExpress.XtraSplashScreen.SplashScreen
    {
        public MainSplashScreenForm()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            UpdateSplashCommand command = (UpdateSplashCommand)cmd;
            if (command == UpdateSplashCommand.Description)
            {
                string description = Convert.ToString(arg);
                labelControlDescription.Text = description;
            }
        }

        #endregion

       
    }
}