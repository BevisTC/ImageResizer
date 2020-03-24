﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var task = imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            task.Wait();
            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
        }
    }
}
