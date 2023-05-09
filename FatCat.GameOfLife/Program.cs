using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using FatCat.GameOfLife.Utilities;

namespace FatCat.GameOfLife
{
	public class Options { }

	internal class Program
	{
		private static Game game;
		private static readonly ManualResetEvent stopEvent = new(false);

		private static Options Options { get; set; }

		private static void DoTestingWork()
		{
			Log.Information("Running game");

			game = new Game();

			game.Run();
		}

		private static void Main(string[] args)
		{
			Console.CancelKeyPress += OnCancel;

			try
			{
				Parser.Default.ParseArguments<Options>(args)
					.WithParsed(o => Options = o);

				DoTestingWork();
			}
			catch (Exception ex) { Console.Write(ex); }
		}

		private static void OnCancel(object sender, ConsoleCancelEventArgs e)
		{
			if (e != null) e.Cancel = true;

			stopEvent.Set();
		}
	}
}