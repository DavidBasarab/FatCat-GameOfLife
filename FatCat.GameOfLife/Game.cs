using FatCat.GameOfLife.Utilities;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace FatCat.GameOfLife
{
	public class Game : GameWindow
	{
		public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) { }

		protected override void OnUpdateFrame(FrameEventArgs args)
		{
			Log.Debug($"In OnUpdate Frame Escape Down = <{KeyboardState.IsKeyDown(Keys.Escape)}>");
			
			if (KeyboardState.IsKeyDown(Keys.Escape)) Close();

			base.OnUpdateFrame(args);
		}
	}
}