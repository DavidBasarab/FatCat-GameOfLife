using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace FatCat.GameOfLife.Utilities
{
	[PublicAPI]
	public static class StringExtensions
	{
		public static bool Contains(this string source, string toCheck, StringComparison comp) => source.IndexOf(toCheck, comp) >= 0;

		public static string FirstLetterToUpper(this string input, char delimiter = ' ')
		{
			if (string.IsNullOrEmpty(input)) return string.Empty;

			var words = input.Split(' ');

			var cleanWords = words.Select(word => CapitalizeFirstLetterOfWord(word)).ToList();

			return string.Join(delimiter.ToString(), cleanWords);
		}

		public static string FixedLength(this string text, int length)
		{
			if (text.Length > length) text = text.Substring(0, length);

			return text.PadRight(length);
		}

		public static string FormatWith(this string formatString, params object[] formatArgs) => string.Format(formatString, formatArgs);

		public static string FromBase64Encoded(this string base64EncodedData)
		{
			if (base64EncodedData.IsNullOrEmpty()) return string.Empty;

			var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

			return Encoding.UTF8.GetString(base64EncodedBytes);
		}

		public static string InsertSafeFileDate(this string stringWithFormat, DateTime dateTimeToInsert) => stringWithFormat.FormatWith($"{dateTimeToInsert:yyyy-MM-ddTHH.mm.ss}");

		public static string InsertSafeFileDate(this string stringWithFormat) => stringWithFormat.InsertSafeFileDate(DateTime.Now);

		public static bool IsNotNullOrEmpty(this string value) => !string.IsNullOrWhiteSpace(value);

		public static bool IsNullOrEmpty(this string value) => string.IsNullOrWhiteSpace(value);

		public static string MakeSafeFileName(this string fileName)
		{
			var sb = new StringBuilder();
			var invalidFileNameChars = Path.GetInvalidFileNameChars();

			foreach (var character in fileName)
			{
				if (invalidFileNameChars.Contains(character)) sb.Append("-");
				else sb.Append(character);
			}

			return sb.ToString();
		}

		public static string RemoveAllWhitespace(this string value) => Regex.Replace(value, @"\s+", "");

		public static string RemoveSuffix(this string item, string suffix)
		{
			if (suffix == null) return item;

			return !item.EndsWith(suffix) ? item : item.Remove(item.Length - suffix.Length, suffix.Length);
		}

		public static string ReplaceAllWhitespace(this string value, string replacement) => Regex.Replace(value, @"\s+", replacement);

		public static IEnumerable<string> SplitByLine(this string data) => SplitByString(data, Environment.NewLine);

		public static string[] SplitByString(this string data, string separator)
		{
			if (data == null) return new[] { string.Empty };

			return data.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
		}

		public static byte[] ToASCIIByteArray(this string value) => Encoding.ASCII.GetBytes(value);

		public static string ToBase64Encoded(this string plainText)
		{
			if (plainText.IsNullOrEmpty()) return string.Empty;

			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

			return Convert.ToBase64String(plainTextBytes);
		}

		public static bool ToBool(this string value)
		{
			if (value == null) return false;

			var lowerValue = value.ToLower();

			return lowerValue == "t" || lowerValue == "1" || lowerValue == "y" || lowerValue == "true" || lowerValue == "yes";
		}

		public static byte ToByte(this string value, byte? defaultValue = null)
		{
			if (!defaultValue.HasValue) return byte.Parse(value);

			byte parsedNumber;

			return byte.TryParse(value, out parsedNumber) ? parsedNumber : defaultValue.Value;
		}

		/// <param name="value">String to convert to bytes</param>
		/// <param name="encoding">
		///  Encoding type, UTF8, Unicode, etc. If unspecified, the default is UTF8.
		///  And really, that's what we should be using everywhere. Seriously.
		/// </param>
		public static byte[] ToByteArray(this string value, Encoding encoding = null) => encoding?.GetBytes(value) ?? Encoding.UTF8.GetBytes(value);

		public static double ToDouble(this string value, double? defaultValue = null)
		{
			if (!defaultValue.HasValue) return value == null ? default : double.Parse(value);

			double parsedNumber;

			return double.TryParse(value, out parsedNumber) ? parsedNumber : defaultValue.Value;
		}

		public static Guid ToGuid(this string value) => Guid.Parse(value);

		public static int ToInt(this string value, int? defaultValue = null)
		{
			if (!defaultValue.HasValue) return value == null ? default : int.Parse(value);

			int parsedNumber;

			return int.TryParse(value, out parsedNumber) ? parsedNumber : defaultValue.Value;
		}

		public static long ToLong(this string value, long? defaultValue = null)
		{
			if (!defaultValue.HasValue) return value == null ? default : long.Parse(value);

			long parsedNumber;

			return long.TryParse(value, out parsedNumber) ? parsedNumber : defaultValue.Value;
		}

		public static Stream ToStream(this string value) => new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));

		public static ushort ToUShort(this string value, ushort? defaultValue = null)
		{
			if (!defaultValue.HasValue) return value == null ? default : ushort.Parse(value);

			ushort parsedNumber;

			return ushort.TryParse(value, out parsedNumber) ? parsedNumber : defaultValue.Value;
		}

		public static string TruncateString(this string value, int maxLength) => value.IsNullOrEmpty() ? string.Empty : value.Substring(0, Math.Min(value.Length, maxLength));

		/// <summary>
		///  Allows a string such as "0x02AB÷0x04" to be transformed into a byte array. Wacky, no?
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static byte[] WithEmbeddedHexCodesToByteArray(this string value)
		{
			if (value == null) return new byte[0];

			var returnValue = new List<byte>();

			for (var currentPosition = 0; currentPosition < value.Length; currentPosition++)
			{
				var possibleValueToAdd = Convert.ToByte(value[currentPosition]);
				var startingHereWithHexDoesNotGoPastEndOfString = currentPosition + 3 < value.Length;

				if (startingHereWithHexDoesNotGoPastEndOfString)
				{
					var nextTwoCharactersPossiblyIndicateHex = value[currentPosition] == '0' && value[currentPosition + 1] == 'x';

					if (nextTwoCharactersPossiblyIndicateHex)
					{
						var twoCharactersAfterIndicator = value.Substring(currentPosition + 2, 2);
						int hexValue;
						var twoCharactersAfterIndicatorAreHexValues = int.TryParse(twoCharactersAfterIndicator, NumberStyles.HexNumber, null, out hexValue);

						if (twoCharactersAfterIndicatorAreHexValues)
						{
							possibleValueToAdd = Convert.ToByte(hexValue);
							currentPosition += 3;
						}
					}
				}

				returnValue.Add(possibleValueToAdd);
			}

			return returnValue.ToArray();
		}

		private static string CapitalizeFirstLetterOfWord(this string word) => word.First().ToString().ToUpper() + string.Join("", word.ToLower().Skip(1));
	}
}