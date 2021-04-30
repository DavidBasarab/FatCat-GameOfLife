using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;

namespace FatCat.GameOfLife
{
    public class Options
    {
    }

    internal class Program
    {
        private static readonly ManualResetEvent stopEvent = new(false);
        private static Options Options { get; set; }
        
        

        private static void Main(string[] args)
        {
            Console.CancelKeyPress += OnCancel;

            try
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(o => Options = o);

                // Going to try to get this idea working
                // https://github.com/aspnet/SignalR-samples/tree/master/ChatSample
                var _ = Task.Run(async () =>
                {
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                    }
                });

                WaitForExit();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private static void OnCancel(object sender, ConsoleCancelEventArgs e)
        {
            if (e != null) e.Cancel = true;

            stopEvent.Set();
        }

        private static void WaitForExit()
        {
            Console.WriteLine("Press Control-C to exit . . . .");

            while (!stopEvent.WaitOne(TimeSpan.FromMilliseconds(10)))
            {
            }

            Console.Write("Exiting . . . .");
        }
    }
}