using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace FatCat.GameOfLife
{
	[Flags]
	public enum NewLineLocation
	{
		None = 0,
		Before = 1,
		After = 2,
		Both = Before | After
	}

	[PublicAPI]
	public static class ConsoleExtensions
	{
		private const int SwHide = 0;
		private const int SwShow = 5;

		private static FileStream fileStream;
		private static readonly object lockObj = new();
		private static bool outputToFile;
		private static StreamWriter streamWriter;

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public static bool LogMessage { get; set; }

		public static void HideConsoleWindow()
		{
			var handle = GetConsoleWindow();

			ShowWindow(handle, SwHide);
		}

		public static bool IsFlagNotSet<T>(this T value, T flag) where T : struct
		{
			var testValueNumber = Convert.ToInt64(value);
			var flagNumberValue = Convert.ToInt64(flag);

			return (testValueNumber & flagNumberValue) == 0;
		}

		public static bool IsFlagSet<T>(this T value, T flag) where T : struct
		{
			var testValueNumber = Convert.ToInt64(value);
			var flagNumberValue = Convert.ToInt64(flag);

			return (testValueNumber & flagNumberValue) != 0;
		}

		public static void PrintToConsole(this Exception ex)
		{
			var level = 0;

			var currentException = ex;

			WriteEquals(ConsoleColor.Red);

			while (currentException != null && level < 5)
			{
				level++;

				WriteExceptionToConsole(currentException, level);

				currentException = currentException.InnerException;
			}

			WriteEquals(ConsoleColor.Red, NewLineLocation.Before);
		}

		public static void ResetColor() => Console.ForegroundColor = ConsoleColor.Gray;

		public static void ResetConsole()
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void SetConsoleOutputToFile(string fullFileName)
		{
			try
			{
				outputToFile = true;

				fileStream = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.Write);

				lock (lockObj) streamWriter = new StreamWriter(fileStream);
			}
			catch (Exception ex)
			{
				ex.PrintToConsole();

				return;
			}

			Console.SetOut(streamWriter);
		}

		public static void ShowConsoleWindow()
		{
			var handle = GetConsoleWindow();

			ShowWindow(handle, SwShow);
		}

		public static void WriteEmptyLine()
		{
			if (outputToFile)
			{
				lock (lockObj) streamWriter.WriteLine(Environment.NewLine);

				return;
			}

			Console.WriteLine(Environment.NewLine);
		}

		public static void WriteLineWithColor(ConsoleColor color, string message, params object[] args)
		{
			if (outputToFile)
			{
				lock (lockObj) streamWriter.WriteLine(message, args);

				return;
			}

			lock (lockObj)
			{
				var oldColor = Console.ForegroundColor;

				Console.ForegroundColor = color;

				if (args == null || args.Length == 0) Console.WriteLine(message);
				else Console.WriteLine(message, args);

				Console.ForegroundColor = oldColor;
			}
		}

		public static void WriteWithColor(ConsoleColor color, string message, params object[] args)
		{
			if (outputToFile)
			{
				lock (lockObj) streamWriter.Write(message, args);

				return;
			}

			lock (lockObj)
			{
				var oldColor = Console.ForegroundColor;

				Console.ForegroundColor = color;

				Console.Write(message, args);

				Console.ForegroundColor = oldColor;
			}
		}

		private static string GetPrintableStackTrace(string spaces, Exception currentExpection) =>
			string.IsNullOrEmpty(currentExpection.StackTrace) ? null : currentExpection.StackTrace.Replace(Environment.NewLine, string.Format("{1}{0}                ", Environment.NewLine, spaces));

		private static void WriteEquals(ConsoleColor color, NewLineLocation lineLocation = NewLineLocation.None)
		{
			if (lineLocation.IsFlagSet(NewLineLocation.Before)) Console.WriteLine(Environment.NewLine);

			WriteLineWithColor(color, new string('=', 125));

			if (lineLocation.IsFlagSet(NewLineLocation.After)) Console.WriteLine(Environment.NewLine);
		}

		private static void WriteExceptionToConsole(Exception currentExpection, int level)
		{
			var spaces = new string(' ', level * 4);

			WriteEmptyLine();
			WriteLineWithColor(ConsoleColor.Red, "{0}Error     : {1}", spaces, currentExpection.Message);
			WriteLineWithColor(ConsoleColor.Red, "{0}StackTrace: {1}", spaces, GetPrintableStackTrace(spaces, currentExpection));
		}
	}
}