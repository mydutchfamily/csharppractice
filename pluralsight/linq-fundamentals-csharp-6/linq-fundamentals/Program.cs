using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("****************************");
            ShowLargeFilesWithQueryLinq(path);
            Console.WriteLine("****************************");
            ShowLargeFilesWithMethodLinq(path);
        }

        private static void ShowLargeFilesWithMethodLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length)
                .Take(5);
            
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name,-20}: {item.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithQueryLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            var query = from file in files
                        orderby file.Length descending
                        select file;

            foreach (var item in query.Take(5))
            {
                Console.WriteLine($"{item.Name,-20}: {item.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name, -20}: {files[i].Length, 10:N0}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
