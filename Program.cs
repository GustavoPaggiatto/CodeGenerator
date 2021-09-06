using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TreasuryChallenge
{
    class Program
    {
        static Facade _facade;

        static List<char> chars = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Z' };

        const int CODELENGTH = 7;
        
        static Program()
        {
            _facade = new Facade();
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("******************** Hy!!! ********************");

            bool aux = true;
            int l = 0;

            do
            {
                Console.Write("Tell me the number of lines do you need and press enter: ");

                try
                {
                    l = int.Parse(Console.ReadLine());

                    if (l <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Number must be greater than ZERO!!!");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else
                        aux = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number, please verify...");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
            }
            while (aux);

            Console.WriteLine("Setting proccess...");

            var threadManager = _facade.GetThreadManager();

            for (int i = 1; i <= chars.Count; i++)
            {
                char prefix = chars[i - 1];
                var codeManager = _facade.GetCodeManager(l);
                var permuteManager = _facade.GetPermuteManager(codeManager);

                threadManager.NewTask(
                    prefix.ToString(),
                    chars.Where(c => c != prefix).ToArray(),
                    CODELENGTH - 2,
                    permuteManager);
            }

            var writerManager = _facade.GetWriterManager(_facade.GetCodeManager(l));
            threadManager.StartProccess(writerManager);

            Console.WriteLine("Permutation proccess...");

            var t = Stopwatch.StartNew();

            threadManager.Wait(() =>
            {
                t.Stop();
                System.Console.WriteLine(t.ElapsedMilliseconds);

                Console.WriteLine($"Finished!!! ({t.ElapsedMilliseconds} ms.)");
                Console.ReadKey();
            });
        }
    }
}