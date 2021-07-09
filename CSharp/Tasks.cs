using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharp
{
    public partial class TaskLib
    {
        public async void Run()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await Task.Factory.StartNew(DoStart);
            stopwatch.Stop();
            Console.WriteLine($"Task finished in {stopwatch.ElapsedMilliseconds} milliseconds.");

            stopwatch.Start();
            await Task.Run(() => { DoStart(); });
            stopwatch.Stop();
            Console.WriteLine($"Task finished in {stopwatch.ElapsedMilliseconds} milliseconds.");
        }

        private void DoStart()
        {
            Console.WriteLine("Hello from task..");
        }
    }
}
