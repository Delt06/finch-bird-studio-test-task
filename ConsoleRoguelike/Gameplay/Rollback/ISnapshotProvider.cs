namespace ConsoleRoguelike.Gameplay.Rollback;

public interface ISnapshotProvider
{
	ISnapshot Capture();
}