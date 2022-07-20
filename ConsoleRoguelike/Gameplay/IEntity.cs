using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public interface IEntity
{
	Vector2Int Position { get; set; }
	void Update(IGame game);
}