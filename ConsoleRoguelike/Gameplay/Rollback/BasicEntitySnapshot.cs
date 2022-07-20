using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay.Rollback;

public class BasicEntitySnapshot<TEntity> : EntitySnapshotBase where TEntity : IEntity, new()
{
    public BasicEntitySnapshot(Vector2Int position) : base(position) { }

    public override void Restore(IGame game)
    {
        game.Place(new TEntity(), Position);
    }
}