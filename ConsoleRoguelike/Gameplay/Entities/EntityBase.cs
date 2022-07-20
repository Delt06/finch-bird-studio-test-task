using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay.Entities;

public abstract class EntityBase : IEntity
{
	public Vector2Int Position { get; set; }
	public abstract void Update(IGame game);
}