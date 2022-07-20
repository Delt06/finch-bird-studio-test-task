using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Gameplay.Rollback;
using ConsoleRoguelike.InputHandling;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class GameplaySystem
{
	private readonly IGame _game;
	private readonly Input _input;
	private readonly RollbackSystem _rollbackSystem;

	public GameplaySystem(IGame game, RollbackSystem rollbackSystem, Input input)
	{
		_rollbackSystem = rollbackSystem;
		_game = game;
		_input = input;
	}

	public void Update()
	{
		if (TryRollback()) return;

		_rollbackSystem.OnEarlyUpdate();

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

	private bool TryRollback()
	{
		if (!_input.Rollback) return false;
		if (!_rollbackSystem.TryPickSnapshot(_input.RollbackMovesNumber, out var snapshots)) return true;

		_game.Clear();

		foreach (var snapshot in snapshots)
		{
			snapshot.Restore(_game);
		}

		_rollbackSystem.Clear();
		return true;
	}
}