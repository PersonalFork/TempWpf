using System;
using System.Threading;

namespace CSharp
{
    public partial class AutoResetManualReset
    {
        private readonly ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        public void ManulReset()
        {
            Thread p1 = new Thread(EnterDoor)
            {
                Name = "Person 1"
            };
            Thread p2 = new Thread(EnterDoor)
            {
                Name = "Person 2"
            };
            Thread p3 = new Thread(EnterDoor)
            {
                Name = "Person 3"
            };

            p1.Start();
            p2.Start();
            p3.Start();
            UnlockDoor();

            p1.Join();
            p2.Join();
            p3.Join();

            Console.WriteLine("All persons have crossed..");
        }

        private void EnterDoor()
        {
            string personId = Thread.CurrentThread.Name;
            Console.WriteLine($"Person {personId} is waiting for Door-Entry.");
            manualResetEvent.WaitOne();
            Console.WriteLine($"Person {personId} has entered the door.");
            Thread.Sleep(2000);
            CrossDoor(personId);
        }

        private void CrossDoor(string personId)
        {
            Console.WriteLine($"Person {personId} is going inside.");
            Thread.Sleep(2000);
            Console.WriteLine($"Person {personId} is inside.");
            manualResetEvent.Set();
        }

        private void UnlockDoor()
        {
            Console.WriteLine("Door is waiting to be unlocked..");
            Thread.Sleep(5000);
            manualResetEvent.Set();
            Console.WriteLine("Door has unlocked..");
        }
    }
}
