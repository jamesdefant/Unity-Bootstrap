namespace Com.SoulSki.Common
{
    public struct Vector2Int
    {
        int _x;
        int _y;

        public int X => _x;
        public int Y => _y;

        public Vector2Int(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}