namespace LessonsConsoleApp.OverrideEquals
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            if (point == null)
                return false;

            return X == point.X && Y == point.Y;

        }
    }
}
