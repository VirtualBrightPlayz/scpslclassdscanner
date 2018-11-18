using Smod2.Commands;

namespace VirtualBrightPlayz.SCPSL.Mod9
{
    internal class RunCmd : ICommandHandler
    {
        private Mod9 mod9;

        public RunCmd(Mod9 mod9)
        {
            this.mod9 = mod9;
        }

        string ICommandHandler.GetCommandDescription()
        {
            return "Scans for all Class-D's";
        }

        string ICommandHandler.GetUsage()
        {
            return "dscan";
        }

        string[] ICommandHandler.OnCall(ICommandSender sender, string[] args)
        {
            Mod9EventHandler.pTime = 0;
            return new string[] { "Scanning for Class-D" };
        }
    }
}