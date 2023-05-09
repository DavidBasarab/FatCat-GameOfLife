using Humanizer;

namespace GameOfLife;

public class Program
{
	public static async Task Main(params string[] args)
	{
		new GameBoard().Show(32, 32);

		await Task.Delay(20.Seconds());
	}
}