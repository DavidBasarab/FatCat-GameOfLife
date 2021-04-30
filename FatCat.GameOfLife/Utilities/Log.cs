using System;
using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace FatCat.GameOfLife.Utilities
{
	[PublicAPI]
	public static class Log
	{
		public static void Debug(string message,
								[CallerMemberName] string memberName = "",
								[CallerFilePath] string sourceFilePath = "",
								[CallerLineNumber] int sourceLineNumber = 0) => Write(message, memberName, sourceFilePath, sourceLineNumber);

		public static void Error(string message,
								[CallerMemberName] string memberName = "",
								[CallerFilePath] string sourceFilePath = "",
								[CallerLineNumber] int sourceLineNumber = 0) => WriteRed(message, memberName, sourceFilePath, sourceLineNumber);

		public static void Exception(Exception exception) => exception.PrintToConsole();

		public static void Information(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => WriteGreen(message, memberName, sourceFilePath, sourceLineNumber);

		public static void Warning(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => WriteYellow(message, memberName, sourceFilePath, sourceLineNumber);

		public static void Write(string message,
								[CallerMemberName] string memberName = "",
								[CallerFilePath] string sourceFilePath = "",
								[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Gray, message, memberName, sourceFilePath, sourceLineNumber);

		public static void Write(ConsoleColor color, string message,
								[CallerMemberName] string memberName = "",
								[CallerFilePath] string sourceFilePath = "",
								[CallerLineNumber] int sourceLineNumber = 0)
		{
			var messageToLog = $"{Path.GetFileName(sourceFilePath)} @ {sourceLineNumber} {memberName} | {message}";

			if (messageToLog.IsNullOrEmpty()) return;

			ConsoleExtensions.WriteLineWithColor(color, messageToLog);
		}

		public static void WriteBlue(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Blue, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteCyan(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Cyan, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkBlue(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkBlue, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkCyan(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkCyan, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkGray(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkGray, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkGreen(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkGreen, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkMagenta(string message,
											[CallerMemberName] string memberName = "",
											[CallerFilePath] string sourceFilePath = "",
											[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkMagenta, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkRed(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkRed, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteDarkYellow(string message,
											[CallerMemberName] string memberName = "",
											[CallerFilePath] string sourceFilePath = "",
											[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.DarkYellow, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteGray(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Gray, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteGreen(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Green, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteMagenta(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Magenta, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteRed(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Red, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteWhite(string message,
									[CallerMemberName] string memberName = "",
									[CallerFilePath] string sourceFilePath = "",
									[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.White, message, memberName, sourceFilePath, sourceLineNumber);

		public static void WriteYellow(string message,
										[CallerMemberName] string memberName = "",
										[CallerFilePath] string sourceFilePath = "",
										[CallerLineNumber] int sourceLineNumber = 0) => Write(ConsoleColor.Yellow, message, memberName, sourceFilePath, sourceLineNumber);
	}
}