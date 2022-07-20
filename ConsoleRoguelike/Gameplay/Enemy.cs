using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class Enemy : Entity, IOnPreDestroyHandler, IDestructibleByPlayer
{
	public void OnPreDestroy(IGame game)
	{
		var deadBody = new DeadBody();
		game.Place(deadBody, Position);
	}

	public override void Update(IGame game)
	{
		if (!game.Player.MadeMove) return;

		var offset = game.Player.Position - Position;
		var directions = new List<Vector2Int>
		{
			new(MathI.Sign(offset.X), 0),
			new(0, MathI.Sign(offset.Y)),
		};

		if (offset.ManhattanLength <= 1)
		{
			game.Player.TakeDamage(1);
			return;
		}

		foreach (var direction in directions)
		{
			if (direction == new Vector2Int(0, 0)) continue;

			var newPosition = Position + direction;
			if (game.IsPositionOutOfRange(newPosition)) continue;
			if (game.IsBusyAtPosition(newPosition)) continue;

			game.Place(this, newPosition);
			break;
		}
	}
}