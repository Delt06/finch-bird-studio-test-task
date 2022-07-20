using ConsoleRoguelike.Shared;
using static System.Console;

namespace ConsoleRoguelike.InputHandling;

public class InputSystem
{
	private readonly Input _input;
	private readonly int _rollbackCapacity;

	public InputSystem(Input input, int rollbackCapacity)
	{
		_rollbackCapacity = rollbackCapacity;
		_input = input;
	}

	public void ReadInput()
	{
		_input.Clear();

		Write("Input your move (m - move, r - rollback): ");

		while (true)
		{
			var line = ReadLine();

			switch (line)
			{
				case "m":
					ReadMovement();
					return;
				case "r":
					ReadRollback();
					return;
				default:
					WriteLine("Invalid input. Try again.");
					break;
			}
		}
	}

	private void ReadMovement()
	{
		Write("Use arrow keys to move.");

		while (true)
		{
			var key = ReadKey();

			var inputMovement = key switch
			{
				{ Key: ConsoleKey.UpArrow } => new Vector2Int(0, -1),
				{ Key: ConsoleKey.DownArrow } => new Vector2Int(0, 1),
				{ Key: ConsoleKey.LeftArrow } => new Vector2Int(-1, 0),
				{ Key: ConsoleKey.RightArrow } => new Vector2Int(1, 0),
				_ => (Vector2Int?)null,
			};

			if (inputMovement == null) continue;

			_input.Movement = inputMovement.Value;
			break;
		}
	}

	private void ReadRollback()
	{
		Write("Input the number of moves to rollback:");

		while (true)
		{
			var line = ReadLine();
			if (line != null && int.TryParse(line, out var moves))
			{
				if (moves > 0)
				{
					if (moves <= _rollbackCapacity)
					{
						_input.Rollback = true;
						_input.RollbackMovesNumber = moves;
						return;
					}

					WriteLine($"Too many moves. Maximum is {_rollbackCapacity}.");
				}
				else
				{
					WriteLine("Moves number must be positive.");
				}
			}
			else
			{
				WriteLine("Invalid input. Try again.");
			}
		}
	}
}