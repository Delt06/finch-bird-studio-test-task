using ConsoleRoguelike.Gameplay;
using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Generation;

public class LevelGenerator
{
	private readonly Game _game;

	public LevelGenerator(Game game) => _game = game;

	public int MinEnemiesCount { get; set; }
	public int MaxEnemiesCount { get; set; }

	public void Generate()
	{
		var random = new Random();
		var enemiesCount = random.Next(MinEnemiesCount, MaxEnemiesCount + 1);

		for (var i = 0; i < enemiesCount; i++)
		{
			var position = new Vector2Int(
				random.Next(_game.LevelSize.X),
				random.Next(_game.LevelSize.Y)
			);
			if (_game.IsBusyAtPosition(position)) continue;

			_game.Place(new Enemy(), position);
		}
	}
}