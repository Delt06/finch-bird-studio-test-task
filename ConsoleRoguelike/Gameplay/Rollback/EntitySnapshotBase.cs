using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay.Rollback;

public abstract class EntitySnapshotBase : ISnapshot
{
	protected readonly Vector2Int Position;

	protected EntitySnapshotBase(Vector2Int position) => Position = position;

	public abstract void Restore(IGame game);
}