using FatCat.Toolkit.Logging;
using FatCat.Toolkit.Threading;
using Spectre.Console;
using Thread = FatCat.Toolkit.Threading.Thread;

namespace GameOfLife;

public class Mandelbrot
{
	private IThread Thread { get; set; } = new Thread(new ToolkitLogger());

	public Canvas Generate(int width, int height)
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
}