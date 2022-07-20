namespace ConsoleRoguelike.Shared;

public struct Vector2Int : IEquatable<Vector2Int>
{
	public int X;
	public int Y;

	public Vector2Int(int x, int y)
	{
		X = x;
		Y = y;
	}

	public int ManhattanLength => MathI.Abs(X) + MathI.Abs(Y);

	public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new(a.X + b.X, a.Y + b.Y);

	public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new(a.X - b.X, a.Y - b.Y);

	public bool Equals(Vector2Int other) => X == other.X && Y == other.Y;

	public override bool Equals(object? obj) => obj is Vector2Int other && Equals(other);

	public override int GetHashCode() => HashCode.Combine(X, Y);

	public static bool operator ==(Vector2Int left, Vector2Int right) => left.Equals(right);

	public static bool operator !=(Vector2Int left, Vector2Int right) => !(left == right);
}