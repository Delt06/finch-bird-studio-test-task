namespace ConsoleRoguelike.Rendering;

public struct RenderInfo
{
	public char Character;
	public int Order;
	public ConsoleColor Color;

	public RenderInfo(char character, int order, ConsoleColor color)
	{
		Character = character;
		Order = order;
		Color = color;
	}
}