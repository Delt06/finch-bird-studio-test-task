using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class WinLoseSystem
{
	private readonly Game _game;

	public WinLoseSystem(Game game) => _game = game;

	public GameResult? Check()
	{
		if (_game.Player.Health <= 0) return GameResult.Lose;

		for (var xi = 0; xi < _game.LevelSize.X; xi++)
		{
			for (var yi = 0; yi < _game.LevelSize.Y; yi++)
			{
				var entities = _game.GetEntitiesAt(new Vector2Int(xi, yi));
				if (entities.OfType<Enemy>().Any())
					return null;
			}
		}

		return GameResult.Win;
	}
}