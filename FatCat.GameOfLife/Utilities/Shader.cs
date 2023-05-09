using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using FatCat.Toolkit;
using OpenTK.Graphics.OpenGL4;

namespace FatCat.GameOfLife.Utilities;

public class Shader
{
	private readonly int handle;

	private readonly Dictionary<string, int> uniformLocations = new();

	private IFileSystemTools FileSystemTools { get; } = new FileSystemTools(new FileSystem());

	public Shader(string vertexPath, string fragmentPath)
	{
		var vertexShader = LoadShader(vertexPath, ShaderType.VertexShader);
		var fragmentShader = LoadShader(fragmentPath, ShaderType.FragmentShader);

		handle = GL.CreateProgram();

		GL.AttachShader(handle, vertexShader);
		GL.AttachShader(handle, fragmentShader);

		LinkProgram();

		GL.DetachShader(handle, vertexShader);
		GL.DetachShader(handle, fragmentShader);
		GL.DeleteShader(fragmentShader);
		GL.DeleteShader(vertexShader);

		GL.GetProgram(handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

		for (var i = 0; i < numberOfUniforms; i++)
		{
			var key = GL.GetActiveUniform(handle, i, out _, out _);

			var location = GL.GetUniformLocation(handle, key);

			uniformLocations.Add(key, location);
		}
	}

	public void Use() => GL.UseProgram(handle);

	private void CompileShader(int shader)
	{
		GL.CompileShader(shader);

		GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);

		if (code != (int)All.True)
		{
			var infoLog = GL.GetShaderInfoLog(shader);

			throw new Exception($"Error occurred while compiling Shader({shader})\n{infoLog}");
		}
	}

	private void LinkProgram()
	{
		GL.LinkProgram(handle);

		GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out var code);

		if (code != (int)All.True)
		{
			var infoLog = GL.GetProgramInfoLog(handle);

			throw new Exception($"Error occurred while linking Program({handle})\n{infoLog}");
		}
	}

	private int LoadShader(string shaderPath, ShaderType shaderType)
	{
		var source = FileSystemTools.ReadAllText(shaderPath).Result;

		var shader = GL.CreateShader(shaderType);

		GL.ShaderSource(shader, source);

		CompileShader(shader);

		return shader;
	}
}