using System;
using System.Diagnostics;
using System.Threading;

namespace MultiprocessingInDocker
{
    class Program
    {
        static void Main(string[] args)
        {
            int processCount = 100; // Number of processes to start

            for (int i = 0; i < processCount; i++)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "/bin/bash"; // Use bash as the shell
                startInfo.Arguments = $"-c \"echo 'Process {i + 1} running in PID $$'; sleep 5;\"";
                startInfo.UseShellExecute = false; // Direct execution without shell

                new Process { StartInfo = startInfo }.Start();
            }

            Console.WriteLine("All processes started. Waiting for completion...");

            // Optionally, wait for processes to finish:
            // Process.WaitForExit();

            // Or, continue execution without waiting:
            Console.WriteLine("Main process continuing...");
        }
    }
}