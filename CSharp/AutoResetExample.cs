using System.Threading;

namespace CSharp
{
    public partial class AutoResetManualReset
    {
        private readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public void AutoReset()
        {
            Thread p1 = new Thread(EnterTurnstile)
            {
                Name = "Person 1"
            };
            Thread p2 = new Thread(EnterTurnstile)
            {
                Name = "Person 2"
            };
            Thread p3 = new Thread(EnterTurnstile)
            {
                Name = "Person 3"
            };

            p1.Start();
            p2.Start();
            p3.Start();
            StartTurnstile();

            p1.Join();
            p2.Join();
            p3.Join();

            System.Console.WriteLine("All persons have crossed..");
        }

        private void StartTurnstile()
        {
            System.Console.WriteLine("Turnstile is starting..");
            Thread.Sleep(5000);
            autoResetEvent.Set();
            System.Console.WriteLine("Turnstile has started.");
        }

        private void EnterTurnstile()
        {
            string personId = Thread.CurrentThread.Name;
            System.Console.WriteLine($"Person {personId} is waiting for entry.");
            autoResetEvent.WaitOne();
            System.Console.WriteLine($"Person {personId} has entered.");
            Thread.Sleep(2000);
            CrossTurnstile(personId);
        }

        private void CrossTurnstile(string personId)
        {
            System.Console.WriteLine($"Person {personId} is crossing.");
            Thread.Sleep(2000);
            System.Console.WriteLine($"Person {personId} has crossed.");
            autoResetEvent.Set();
        }
    }
}
