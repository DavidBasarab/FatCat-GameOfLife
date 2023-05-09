using Spectre.Console;
using Spectre.Console.Rendering;

namespace GameOfLife;

public class Program
{
	public static void Main(params string[] args)
	{
		var canvas = new Mandelbrot().Generate(32, 32);
		
		Render(canvas, "Game of Life Board");
	}
	
	private static void Render(IRenderable canvas, string title)
	{
		AnsiConsole.WriteLine();
		AnsiConsole.Write(new Rule($"[yellow]{title}[/]").LeftJustified().RuleStyle("grey"));
		AnsiConsole.WriteLine();
		AnsiConsole.Write(canvas);
	}
}