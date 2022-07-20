using ConsoleRoguelike.Gameplay.Rollback;

namespace ConsoleRoguelike.Gameplay.Entities;

public class DeadBody : EntityBase, ISnapshotProvider
{
	public ISnapshot Capture() => new BasicEntitySnapshot<DeadBody>(Position);
	public override void Update(IGame game) { }
}