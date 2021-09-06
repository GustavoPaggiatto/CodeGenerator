using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TreasuryChallenge
{
    public sealed class ThreadManager
    {
        static List<Task> _tasks;

        WriterManager _writerManager;

        static ThreadManager()
        {
            _tasks = new List<Task>();
        }

        public ThreadManager()
        {
        }

        public void NewTask(string prefix, char[] letters, int length, PermuteManager permuteManager)
        {
            var task = new Task(() =>
            {
                permuteManager.Permute(letters, prefix, length);
            });

            _tasks.Add(task);
        }

        public void StartProccess(WriterManager writerManager)
        {
            foreach (var task in _tasks)
            {
                task.Start();
            }

            this._writerManager = writerManager;

            var writer = new Task(() =>
                        {
                            Thread.Sleep(3);
                            
                            while (this._writerManager.Write())
                            {
                            }
                        });

            _tasks.Add(writer);
            writer.Start();
        }

        public int GetQtdProccess(int codesLength, long permutations)
        {
            return (int)Math.Ceiling((double)codesLength / permutations);
        }

        public void Wait(Action action)
        {
            Task.WaitAll(_tasks.ToArray());
            action();
        }
    }
}