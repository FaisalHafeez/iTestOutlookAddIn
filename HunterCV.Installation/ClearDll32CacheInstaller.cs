using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;


namespace HunterCV.Installation
{
    [RunInstaller(true)]
    public partial class ClearDll32CacheInstaller : System.Configuration.Install.Installer
    {
        public ClearDll32CacheInstaller()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string ApplicationName = "rundll32.exe";
            string BaseOptions = "dfshim CleanOnlineAppCache";

            //Start your loop here
            ProcessStartInfo oStartInfo = new ProcessStartInfo();
            oStartInfo.FileName = ApplicationName;
            oStartInfo.Arguments = BaseOptions ;
            Process.Start(oStartInfo);
        }

    }
}
