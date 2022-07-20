using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class GameplaySystem
{
	private readonly Game _game;
	public GameplaySystem(Game game) => _game = game;

	public void Update()
	{
		var updateOrder = new List<IEntity> { _game.Player };

		for (var xi = 0; xi < _game.LevelSize.X; xi++)
		{
			for (var yi = 0; yi < _game.LevelSize.Y; yi++)
			{
				var entities = _game.GetEntitiesAt(new Vector2Int(xi, yi));
				foreach (var entity in entities)
				{
					if (entity is not Player)
						updateOrder.Add(entity);
				}
			}
		}

		foreach (var entity in updateOrder)
		{
			if (_game.IsDestroyed(entity)) continue;
			entity.Update(_game);
		}

		_game.OnLateUpdate();
	}
}