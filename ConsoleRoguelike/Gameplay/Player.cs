using ConsoleRoguelike.InputHandling;

namespace ConsoleRoguelike.Gameplay;

public class Player : Entity
{
	private readonly Input _input;

	public Player(Input input, int initialHealth)
	{
		_input = input;
		Health = initialHealth;
	}

	public bool MadeMove { get; private set; }
	public int Health { get; private set; }

	public override void Update(IGame game)
	{
		MadeMove = false;

		var movement = _input.Movement;
		if (movement.X == 0 && movement.Y == 0) return;

		var newPosition = Position + movement;
		if (game.IsPositionOutOfRange(newPosition)) return;

		if (game.IsBusyAtPosition(newPosition))
		{
			var entities = game.GetEntitiesAt(newPosition);

			foreach (var entity in entities)
			{
				if (entity is IDestructibleByPlayer)
					game.Destroy(entity);
			}
		}

		game.Place(this, newPosition);
		MadeMove = true;
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
	}
}