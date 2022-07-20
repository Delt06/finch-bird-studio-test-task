using ConsoleRoguelike.Gameplay;
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


var renderer = new Renderer();

RenderGame(game, renderer);

while (true)
{
	ReadInput(input);
	UpdateGame(game);
	RenderGame(game, renderer);
}

static void ReadInput(Input input)
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

		input.Movement = inputMovement.Value;
		break;
	}
}

static void UpdateGame(Game game)
{
	var updateOrder = new List<Entity> { game.Player };

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

static void RenderGame(Game game, Renderer renderer)
{
	Console.Clear();
	Console.ResetColor();

	Console.WriteLine("Health: " + game.Player.Health);

	var emptyCell = new RenderInfo('■', 0, ConsoleColor.DarkGray);


	for (var yi = 0; yi < game.LevelSize.Y; yi++)
	{
		for (var xi = 0; xi < game.LevelSize.X; xi++)
		{
			var entities = game.GetEntitiesAt(new Vector2Int(xi, yi));
			var renderInfo = entities.Select(renderer.Render)
				.OrderByDescending(ri => ri.Order)
				.FirstOrDefault(emptyCell);
			Console.BackgroundColor = renderInfo.Color;
			Console.Write(renderInfo.Character);
		}

		Console.WriteLine();
	}

	Thread.Sleep(100);
}