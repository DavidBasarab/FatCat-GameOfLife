using Spectre.Console;

namespace GameOfLife;

public static class Mandelbrot
{
	private const double MaxValueExtent = 2.0;

	public static Canvas Generate(int width, int height)
	{
		var canvas = new Canvas(width, height);

		var number = 0;

		for (var row = 0; row < height; row++)
		{
			for (var column = 0; column < width; column++)
			{
				number++;

				var color = number % 2 == 0 ? Color.Green : Color.Black;

				canvas.SetPixel(column, row, color);
			}
		}

		return canvas;
	}

	private static double Calculate(ComplexNumber c)
	{
		const int MaxIterations = 1000;
		const double MaxNorm = MaxValueExtent * MaxValueExtent;

		var iteration = 0;
		var z = new ComplexNumber();

		do
		{
			z = z * z + c;
			iteration++;
		} while (z.Abs() < MaxNorm && iteration < MaxIterations);

		return iteration < MaxIterations
					? (double)iteration / MaxIterations
					: 0;
	}

	private static Color GetColor(double value)
	{
		const double MaxColor = 256;
		const double ContrastValue = 0.2;
		return new Color(0, 0, (byte)(MaxColor * Math.Pow(value, ContrastValue)));
	}

	private struct ComplexNumber
	{
		public double Real { get; }

		public double Imaginary { get; }

		public ComplexNumber(double real, double imaginary)
		{
			Real = real;
			Imaginary = imaginary;
		}

		public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y) => new(x.Real + y.Real, x.Imaginary + y.Imaginary);

		public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y) => new(x.Real * y.Real - x.Imaginary * y.Imaginary,
																						x.Real * y.Imaginary + x.Imaginary * y.Real);

		public double Abs() => Real * Real + Imaginary * Imaginary;
	}
}