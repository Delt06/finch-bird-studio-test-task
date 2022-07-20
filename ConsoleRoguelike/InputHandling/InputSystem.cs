using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.InputHandling;

public class InputSystem
{
	private readonly Input _input;
	public InputSystem(Input input) => _input = input;

	public void ReadInput()
	{
		while (true)
		{
			var key = Console.ReadKey();

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
}