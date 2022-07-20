using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public static class GameExtensions
{
	public static bool IsPositionOutOfRange(this IGame game, Vector2Int position) =>
		position.X < 0 ||
		position.X >= game.LevelSize.X ||
		position.Y < 0 ||
		position.Y >= game.LevelSize.Y;

	public static bool IsBusyAtPosition(this IGame game, Vector2Int position) =>
		game.GetEntitiesAt(position).OfType<IBlockingMovement>().Any();
}