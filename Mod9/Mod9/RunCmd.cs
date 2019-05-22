using Smod2.Commands;

namespace VirtualBrightPlayz.SCPSL.ClassDScanner
{
    internal class RunCmd : ICommandHandler
    {
        private ClassDScanner mod9;

        public RunCmd(ClassDScanner mod9)
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
            ClassDScannerEventHandler.pTime = 0;
            return new string[] { "Scanning for Class-D" };
        }
    }
}