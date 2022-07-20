using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay.Rollback;

public class PlayerSnapshot : EntitySnapshotBase
{
    private readonly int _health;

    public PlayerSnapshot(Vector2Int position, int health) : base(position) => _health = health;

    public override void Restore(IGame game)
    {
        game.Player.Health = _health;
        game.Place(game.Player, Position);
    }
}