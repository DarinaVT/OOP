public static class KeyInput
{
    public static Direction GetKeyDirection(ConsoleKey key)
    {
        return key switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            _ => Direction.None,
        };
    }
}
public enum Direction { Up, Down, Left, Right, None }
