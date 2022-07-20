using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public interface IMoving
{
	Vector2Int MakeMove(Game game);
}