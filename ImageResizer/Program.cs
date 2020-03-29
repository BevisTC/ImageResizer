using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();

            CancellationTokenSource cts = new CancellationTokenSource();


            ThreadPool.QueueUserWorkItem(x =>
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.C)
                {
                    cts.Cancel();


                }
            });



            sw.Start();

            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0, cts);

            sw.Stop();



            Console.ReadKey();
            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
        }
    }
}
