namespace LessonsConsoleApp.OverrideEquals
{
    public class Circle
    {

        public Point Point { get; set; }
        public double Radius { get; set; }

        public Circle(double radius, Point point)
        {
            Point = point;
            Radius = radius;
        }

        public override bool Equals(object obj)
        {
            var circle = obj as Circle;
            if (circle == null)
                return false;
            return Point.Equals(circle.Point) && Radius == circle.Radius;
        }
    }
}
