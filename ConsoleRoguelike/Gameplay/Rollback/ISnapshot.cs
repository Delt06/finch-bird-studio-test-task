namespace ConsoleRoguelike.Gameplay.Rollback;

public interface ISnapshot
{
	void Restore(IGame game);
}