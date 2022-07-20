using ConsoleRoguelike.Shared;

namespace ConsoleRoguelike.Gameplay;

public class Player : Entity, IMoving
{
	private readonly Input _input;

	public Player(Input input) => _input = input;

	public Vector2Int MakeMove(Game game) => _input.Movement;
}

public abstract class Entity 
{
	public Vector2Int Position { get; set; }
}