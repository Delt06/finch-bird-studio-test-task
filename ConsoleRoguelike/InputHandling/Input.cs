using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.InputHandling;

public class Input
{
	public Vector2Int Movement;
	public bool Rollback;
	public int RollbackMovesNumber;

	public void Clear()
	{
		Movement = default;
		Rollback = false;
		RollbackMovesNumber = 0;
	}
}