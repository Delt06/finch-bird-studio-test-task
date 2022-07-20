using ConsoleRoguelike.Gameplay;
using ConsoleRoguelike.InputHandling;
using ConsoleRoguelike.Rendering;
using ConsoleRoguelike.Shared;

var input = new Input();
var player = new Player(input, 10);
var levelSize = new Vector2Int(10, 10);
var game = new Game(player, levelSize);

// Coordinate system:
// X+: right
// Y+: down

game.Place(new Enemy(), new Vector2Int(2, 4));
game.Place(new Enemy(), new Vector2Int(3, 7));
game.Place(new Enemy(), new Vector2Int(8, 1));


var inputSystem = new InputSystem(input);
var renderer = new Renderer(game);

renderer.Render();

while (true)
{
	inputSystem.ReadInput();
	UpdateGame(game);
	renderer.Render();
}

static void UpdateGame(Game game)
{
	var updateOrder = new List<IEntity> { game.Player };

	for (var xi = 0; xi < game.LevelSize.X; xi++)
	{
		for (var yi = 0; yi < game.LevelSize.Y; yi++)
		{
			var entities = game.GetEntitiesAt(new Vector2Int(xi, yi));
			foreach (var entity in entities)
			{
				if (entity is not Player)
					updateOrder.Add(entity);
			}
		}
	}

	foreach (var entity in updateOrder)
	{
		if (game.IsDestroyed(entity)) continue;
		entity.Update(game);
	}

	game.OnLateUpdate();
}