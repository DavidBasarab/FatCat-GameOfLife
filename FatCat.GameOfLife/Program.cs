using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using FatCat.GameOfLife.Utilities;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

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

			game = new Game(GameWindowSettings.Default, new NativeWindowSettings
														{
															Title = "FatCat.GameOfLife",
															APIVersion = Version.Parse("4.1"),
															Size = new Vector2i(800, 600)
														});

			game.Closed += () => OnCancel(null, null);

			game.Run();
		}

		private static void Main(string[] args)
		{
			Console.CancelKeyPress += OnCancel;

			try
			{
				Parser.Default.ParseArguments<Options>(args)
					.WithParsed(o => Options = o);

				// Going to try to get this idea working
				// https://github.com/aspnet/SignalR-samples/tree/master/ChatSample
				var _ = Task.Run(() =>
								{
									try { DoTestingWork(); }
									catch (Exception ex) { Console.Write(ex); }
								});

				WaitForExit();

				game?.Dispose();
			}
			catch (Exception ex) { Console.Write(ex); }
		}

		private static void OnCancel(object sender, ConsoleCancelEventArgs e)
		{
			if (e != null) e.Cancel = true;

			stopEvent.Set();
		}

		private static void WaitForExit()
		{
			Console.WriteLine("Press Control-C to exit . . . .");

			while (!stopEvent.WaitOne(TimeSpan.FromMilliseconds(10))) { }

			Console.Write("Exiting . . . .");
		}
	}
}