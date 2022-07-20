using ConsoleRoguelike.Gameplay;
using ConsoleRoguelike.Gameplay.Entities;
using ConsoleRoguelike.Gameplay.Rollback;
using ConsoleRoguelike.Generation;
using ConsoleRoguelike.InputHandling;
using ConsoleRoguelike.Rendering;
using ConsoleRoguelike.Shared;

var input = new Input();
var player = new Player(input, 10);
var levelSize = new Vector2Int(10, 10);
var game = new Game(player, levelSize);

const int rollbackCapacity = 10;

var inputSystem = new InputSystem(input, rollbackCapacity);
var rollbackSystem = new RollbackSystem(game, rollbackCapacity);
var winLoseSystem = new WinLoseSystem(game);
var gameplaySystem = new GameplaySystem(game, rollbackSystem, input);

var levelGenerator = new LevelGenerator(game)
{
	MinEnemiesCount = 4,
	MaxEnemiesCount = 6,
};
levelGenerator.Generate();

var renderer = new Renderer(game);
renderer.Render();

while (true)
{
	var gameResult = winLoseSystem.Check();
	if (gameResult != null)
	{
		game.Finish(gameResult.Value);
		break;
	}

	inputSystem.ReadInput();
	gameplaySystem.Update();
	renderer.Render();
}

switch (game.Result)
{
	case GameResult.Win:
		Console.WriteLine("You won!");
		break;
	case GameResult.Lose:
		Console.WriteLine("You died!");
		break;
	default:
		throw new ArgumentOutOfRangeException();
}