using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using System.Net;
using System.Net.Sockets;

namespace VirtualBrightPlayz.SCPSL.ClassDScanner
{
    [PluginDetails(author = "VirtualBrightPlayz",
        description = "CASSIE now scans for SCPs and D-Bois",
        id = "virtualbrightplayz.scpsl.classdscanner",
        name = "Class-D Scanner",
        version = "1.0",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0)]
    public class ClassDScanner : Plugin
    {

        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
            this.Info("Mod9 plugin enabled.");
        }

        public override void Register()
        {
            this.AddEventHandlers(new ClassDScannerEventHandler(this));
            this.AddConfig(new ConfigSetting("dscanner_time", 180f, true, "How often (in seconds) to scan for Class-D Personnel"));
            this.AddCommand("dscan", new RunCmd(this));
        }
    }
}
