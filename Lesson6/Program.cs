using System;
using System.Diagnostics;
using static System.Console;

namespace Lesson6
{
    public class CommandLineHelp
    {
        public static void Handler(string[] args)
        {
            if (args.Length == 0)
                throw new Exception($"No argument is defined");
            if (args.Length > 2)
                throw new Exception($"There are no commands that can take more than 2 arguments");
            var command = args[0];
                switch (command)
                {
                    case "h":
                        Help();
                        break;
                    case "p":
                        Print();
                        break;
                    case "k" when (int.TryParse(args[1], out int id) && args[1] != null):
                        KillProcessByID(id);
                        break;
                    case "k" when (!String.IsNullOrEmpty(args[1]) && (!String.IsNullOrWhiteSpace(args[1]))):
                        KillProcessByName(args[1]);
                        break;
                    default:
                        throw new Exception($"Argument {command} is not defined");
                }           
        }
        private static void Help()
        {
            var help = $@"h           -   help
p           -   print processes (ID,Name)
k ID        -   kill process by ID (ID = int)
k name      -   kill process by name";
            WriteLine(help);
        }
        private static void Print()
        {
            var processes = Process.GetProcesses();
            foreach(var process in processes)
            {
                WriteLine($"{process.ProcessName}  |   {process.Id}");
            }
        }
        private static bool IsRun(Process process)
        {
            var all = Process.GetProcesses();
            foreach (var pr in all)
            {
                if (pr.Id == process.Id)
                {
                    return true;
                }
            }
            return false;
        }
        private static void KillProcessByID(int id)
        {
            var process = Process.GetProcessById(id);
            if (!IsRun(process))
            {
                throw new Exception($"processes {process.Id} not found");
            }

            try
            {
                process.Kill();
            }
            catch
            {
                throw;
            }
        }
        private static void KillProcessByName(string name)
        {
            var processes = Process.GetProcessesByName(name);
            if(processes==null || processes.Length == 0)
            {
                throw new Exception($"processes {name} not found");
            }
            try
            {
                foreach (var process in processes)
                {
                    process.Kill();
                    WriteLine($"process {process.ProcessName} was closed");
                }
            }
            catch
            {
                throw;
            }

        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                CommandLineHelp.Handler(args);
                return 0;
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
                return -1;
            }
        }
    }
}
