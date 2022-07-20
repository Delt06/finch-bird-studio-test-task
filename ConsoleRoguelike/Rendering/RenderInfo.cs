namespace ConsoleRoguelike.Rendering;

public struct RenderInfo
{
	public char Character;
	public int Order;

	public RenderInfo(char character, int order)
	{
		Character = character;
		Order = order;
	}
}