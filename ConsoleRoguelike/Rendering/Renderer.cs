using ConsoleRoguelike.Gameplay;

namespace ConsoleRoguelike.Rendering;

public class Renderer
{
	public RenderInfo Render(Entity entity) =>
		entity switch
		{
			Player player => new RenderInfo('P', 1),
			Enemy enemy => new RenderInfo('E', 1),
			_ => throw new ArgumentException("Unknown entity type"),
		};
}