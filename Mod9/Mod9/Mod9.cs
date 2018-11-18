using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using System.Net;
using System.Net.Sockets;

namespace VirtualBrightPlayz.SCPSL.Mod9
{
    [PluginDetails(author = "VirtualBrightPlayz",
        description = "Mod9 desc",
        id = "virtualbrightplayz.scpsl.mod9",
        name = "Mod9",
        version = "1.0",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0)]
    public class Mod9 : Plugin
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
            this.AddEventHandlers(new Mod9EventHandler(this));
            this.AddConfig(new ConfigSetting("dscanner_time", 180f, SettingType.FLOAT, true, "How often (in seconds) to scan for Class-D Personnel"));
            this.AddCommand("dscan", new RunCmd(this));
        }
    }
}
