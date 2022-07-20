using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public interface IGame
{
    Vector2Int LevelSize { get; }
    Player Player { get; }
    bool IsDestroyed(IEntity entity);
    ICollection<IEntity> GetEntitiesAt(Vector2Int position);
    void Place(IEntity entity, Vector2Int position);
    void Destroy(IEntity entity);
    void OnLateUpdate();
    void Clear();
}