using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace FatCat.GameOfLife
{
public class Game : GameWindow
{
	private static GameWindowSettings GameSettings { get; } = new()
															{
																RenderFrequency = 0.0,
																UpdateFrequency = 0.0
															};

	private static NativeWindowSettings NativeWindowSettings { get; } = new()
																		{
																			Title = "FatCat.GameOfLife",
																			APIVersion = Version.Parse("4.1"),
																			Size = new Vector2i(1000, 1000)
																		};

	// Create the vertices for our triangle. These are listed in normalized device coordinates (NDC)
	// In NDC, (0, 0) is the center of the screen.
	// Negative X coordinates move to the left, positive X move to the right.
	// Negative Y coordinates move to the bottom, positive Y move to the top.
	// OpenGL only supports rendering in 3D, so to create a flat triangle, the Z coordinate will be kept as 0.
	private static float[] TriangleVertices { get; } =
		{
			-0.5f,
			-0.5f,
			0.0f, // Bottom-left vertex
			0.5f,
			-0.5f,
			0.0f, // Bottom-right vertex
			0.0f,
			0.5f,
			0.0f // Top vertex
		};

	private double timer;
	
	// private int vertexBufferObject;
	// private int vertexArrayObject;
	

	public Game() : base(GameSettings, NativeWindowSettings) { }

	protected override void OnLoad()
	{
		GL.ClearColor(Color.CornflowerBlue);

		base.OnLoad();
	}

	protected override void OnRenderFrame(FrameEventArgs args)
	{
		PrintFps(args);

		GL.Clear(ClearBufferMask.ColorBufferBit);

		Context.SwapBuffers();

		base.OnRenderFrame(args);
	}

	protected override void OnResize(ResizeEventArgs e)
	{
		GL.Viewport(0, 0, e.Width, e.Height);

		base.OnResize(e);
	}

	protected override void OnUpdateFrame(FrameEventArgs args)
	{
		if (KeyboardState.IsKeyDown(Keys.Escape)) Close();

		base.OnUpdateFrame(args);
	}

	private void PrintFps(FrameEventArgs args)
	{
		timer += args.Time;

		if (timer > .20)
		{
			Title = $"FatCat.GameOfLife | (Vsync: {VSync}) FPS : {1f / args.Time:0}";
			timer = 0;
		}
	}
}
}