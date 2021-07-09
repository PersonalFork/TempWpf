using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public partial class TaskLib
    {
        public async Task<List<string>> DownloadFile(int totalParts)
        {
            List<string> strList = new List<string>();
            IEnumerable<int> parts = await GetParts(totalParts);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int partId in parts)
            {
                string part = await DownloadPart(partId);
                strList.Add(part);
            }
            stopwatch.Stop();
            System.Console.WriteLine($"Total Elapsed : {stopwatch.ElapsedMilliseconds}");
            return strList;
        }

        public async Task<List<string>> DownloadFileWhenAll(int totalParts)
        {
            List<string> strList = new List<string>();
            IEnumerable<int> parts = await GetParts(totalParts);
            List<Task> tasks = new List<Task>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int partId in parts)
            {
                Task<string> task = await Task.Factory.StartNew(() => DownloadPart(partId));
                tasks.Add(task);
            }
            await Task.WhenAll(tasks.ToArray());
            foreach (Task<string> task in tasks)
            {
                strList.Add(task.Result);
            }
            stopwatch.Stop();
            System.Console.WriteLine($"WHEN ALL : Total Elapsed : {stopwatch.ElapsedMilliseconds}");
            return strList;
        }

        private async Task<string> DownloadPart(int partId)
        {
            System.Console.WriteLine($"Downloading Part : {partId}");
            await Task.Delay(10);
            return $"Part : {partId} ";
        }

        private async Task<IEnumerable<int>> GetParts(int range)
        {
            return await Task.FromResult(Enumerable.Range(0, range));
        }

    }
}
