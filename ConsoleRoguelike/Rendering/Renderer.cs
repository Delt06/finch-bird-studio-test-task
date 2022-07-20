using ConsoleRoguelike.Gameplay;

namespace ConsoleRoguelike.Rendering;

public class Renderer
{
	public RenderInfo Render(IEntity entity) =>
		entity switch
		{
			Player => new RenderInfo('P', 1, ConsoleColor.Green),
			Enemy => new RenderInfo('E', 1, ConsoleColor.Red),
			DeadBody => new RenderInfo('X', 0, ConsoleColor.DarkRed),
			_ => throw new ArgumentException("Unknown entity type"),
		};
}