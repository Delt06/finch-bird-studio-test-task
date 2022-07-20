using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public abstract class Entity : IEntity
{
	public Vector2Int Position { get; set; }
	public abstract void Update(IGame game);
}