using System;

namespace CSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TaskLib taskLib = new TaskLib();
            //taskLib.DownloadFile(10).GetAwaiter().GetResult();
            //taskLib.DownloadFileWhenAll(10).GetAwaiter().GetResult();

            AutoResetManualReset autoResetManualReset = new AutoResetManualReset();
            Console.WriteLine("Auto Reset");
            autoResetManualReset.AutoReset();

            Console.WriteLine("\nManual Reset");
            autoResetManualReset.ManulReset();
            Console.ReadLine();
        }
    }
}
