using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class Game : IGame
{
	private readonly HashSet<IEntity> _destroyedEntities = new();
	private readonly HashSet<IEntity>[,] _level;

	public Game(Player player, Vector2Int levelSize)
	{
		Player = player;
		_level = new HashSet<IEntity>[levelSize.X, levelSize.Y];
		LevelSize = levelSize;

		for (var xi = 0; xi < levelSize.X; xi++)
		{
			for (var yi = 0; yi < levelSize.Y; yi++)
			{
				_level[xi, yi] = new HashSet<IEntity>();
			}
		}

		Place(player, player.Position);
	}

	public Vector2Int LevelSize { get; }

	public Player Player { get; }

	public bool IsDestroyed(IEntity entity) => _destroyedEntities.Contains(entity);

	public ICollection<IEntity> GetEntitiesAt(Vector2Int position)
	{
		if (position.X < 0 || position.X >= LevelSize.X) throw new ArgumentOutOfRangeException(nameof(position.X));
		if (position.Y < 0 || position.Y >= LevelSize.Y) throw new ArgumentOutOfRangeException(nameof(position.Y));

		return _level[position.X, position.Y].ToList();
	}

	public void Place(IEntity entity, Vector2Int position)
	{
		_level[entity.Position.X, entity.Position.Y].Remove(entity);
		entity.Position = position;
		_level[position.X, position.Y].Add(entity);
	}

	public void Destroy(IEntity entity)
	{
		if (entity is IOnPreDestroyHandler handler)
			handler.OnPreDestroy(this);
		_level[entity.Position.X, entity.Position.Y].Remove(entity);
		_destroyedEntities.Add(entity);
	}

	public void OnLateUpdate()
	{
		_destroyedEntities.Clear();
	}
}