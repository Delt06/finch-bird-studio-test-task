using ConsoleRoguelike.Gameplay;
using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Rendering;

public class Renderer
{
	private readonly IGame _game;

	public Renderer(IGame game) => _game = game;

	public void Render()
	{
		Console.Clear();
		Console.ResetColor();

		Console.WriteLine("Health: " + _game.Player.Health);

		var emptyCell = new RenderInfo('■', 0, ConsoleColor.DarkGray);


		for (var yi = 0; yi < _game.LevelSize.Y; yi++)
		{
			for (var xi = 0; xi < _game.LevelSize.X; xi++)
			{
				var entities = _game.GetEntitiesAt(new Vector2Int(xi, yi));
				var renderInfo = entities.Select(Render)
					.OrderByDescending(ri => ri.Order)
					.FirstOrDefault(emptyCell);
				Console.BackgroundColor = renderInfo.Color;
				Console.Write(renderInfo.Character);
			}

			Console.WriteLine();
		}

		Console.ResetColor();
		Thread.Sleep(100);
	}

	private static RenderInfo Render(IEntity entity) =>
		entity switch
		{
			Player => new RenderInfo('P', 1, ConsoleColor.Green),
			Enemy => new RenderInfo('E', 1, ConsoleColor.Red),
			DeadBody => new RenderInfo('X', 0, ConsoleColor.DarkRed),
			_ => throw new ArgumentException("Unknown entity type"),
		};
}