using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay.Entities;

public interface IEntity
{
    Vector2Int Position { get; set; }
    void Update(IGame game);
}