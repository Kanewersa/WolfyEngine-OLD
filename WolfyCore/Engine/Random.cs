namespace WolfyShared.Engine
{
    public static class Random
    {
        public static Direction GetRandomDirection()
        {
            var random = new System.Random();
            var values = new[] {Direction.Up, Direction.Down, Direction.Left, Direction.Right};
            return values[random.Next(values.Length)];
        }
    }
}
