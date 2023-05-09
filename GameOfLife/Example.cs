using FatCat.Toolkit.Logging;
using FatCat.Toolkit.Threading;
using Spectre.Console;
using Thread = FatCat.Toolkit.Threading.Thread;

namespace GameOfLife;

public class GameBoard
{
	private Canvas canvas;

	private IThread Thread { get; set; } = new Thread(new ToolkitLogger());

	public void Show(int width, int height)
	{
		canvas = new Canvas(width, height);

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

		Render();
	}

	private void Render()
	{
		AnsiConsole.WriteLine();
		AnsiConsole.Write(new Rule("[yellow]Game Board[/]").LeftJustified().RuleStyle("grey"));
		AnsiConsole.WriteLine();
		AnsiConsole.Write(canvas);
	}
}