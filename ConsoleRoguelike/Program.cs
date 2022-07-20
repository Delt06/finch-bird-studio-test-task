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
	inputSystem.ReadInput();
	gameplaySystem.Update();
	renderer.Render();
}