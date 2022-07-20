using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay.Rollback;

public class RollbackSystem
{
    private readonly int _capacity;
    private readonly IGame _game;
    private readonly LinkedList<List<ISnapshot>> _gameSnapshots = new();

    public RollbackSystem(IGame game, int capacity)
    {
        _capacity = capacity;
        _game = game;
    }

    public void OnEarlyUpdate()
    {
        CaptureNew();
        RemoveOldIfNeeded();
    }

    private void CaptureNew()
    {
        var snapshots = new List<ISnapshot>();

        for (var xi = 0; xi < _game.LevelSize.X; xi++)
        {
            for (var yi = 0; yi < _game.LevelSize.Y; yi++)
            {
                var entities = _game.GetEntitiesAt(new Vector2Int(xi, yi));
                foreach (var entity in entities)
                {
                    if (entity is not ISnapshotProvider snapshotProvider) continue;

                    var snapshot = snapshotProvider.Capture();
                    snapshots.Add(snapshot);
                }
            }
        }

        _gameSnapshots.AddLast(snapshots);
    }

    public bool TryPickSnapshot(int movesNumber, out IEnumerable<ISnapshot> snapshot)
    {
        var index = _gameSnapshots.Count - movesNumber;
        if (index < 0)
            index = 0;
        snapshot = _gameSnapshots.ElementAtOrDefault(index)!;
        return snapshot != null;
    }

    public void Clear() => _gameSnapshots.Clear();

    private void RemoveOldIfNeeded()
    {
        if (_gameSnapshots.Count <= _capacity) return;
        _gameSnapshots.RemoveFirst();
    }
}