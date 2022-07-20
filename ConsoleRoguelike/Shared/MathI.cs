namespace ConsoleRoguelike.Shared;

public static class MathI
{
	public static int Abs(int value) => value < 0 ? -value : value;
	public static int Sign(int value) => value > 0 ? 1 : value < 0 ? -1 : 0;
}