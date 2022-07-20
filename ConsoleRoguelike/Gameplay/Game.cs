using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class Game
{
	private readonly HashSet<Entity> _destroyedEntities = new();
	private readonly HashSet<Entity>[,] _level;

	public Game(Player player, Vector2Int levelSize)
	{
		Player = player;
		_level = new HashSet<Entity>[levelSize.X, levelSize.Y];
		LevelSize = levelSize;

		for (var xi = 0; xi < levelSize.X; xi++)
		{
			for (var yi = 0; yi < levelSize.Y; yi++)
			{
				_level[xi, yi] = new HashSet<Entity>();
			}
		}

		Place(player, player.Position);
	}

	public Vector2Int LevelSize { get; }

	public Player Player { get; }

	public bool IsDestroyed(Entity entity) => _destroyedEntities.Contains(entity);

	public ICollection<Entity> GetEntitiesAt(Vector2Int position)
	{
		if (position.X < 0 || position.X >= LevelSize.X) throw new ArgumentOutOfRangeException(nameof(position.X));
		if (position.Y < 0 || position.Y >= LevelSize.Y) throw new ArgumentOutOfRangeException(nameof(position.Y));

		return _level[position.X, position.Y].ToList();
	}

	public void Place(Entity entity, Vector2Int position)
	{
		_level[entity.Position.X, entity.Position.Y].Remove(entity);
		entity.Position = position;
		_level[position.X, position.Y].Add(entity);
	}

	public void Destroy(Entity entity)
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