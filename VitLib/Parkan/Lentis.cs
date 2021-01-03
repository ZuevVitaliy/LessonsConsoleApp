namespace VitLib.Parkan
{
    internal class Lentis
    {
        public Sector[] Sectors { get; }

        public Lentis()
        {
            Sectors = new[]
            {
                Sector.Blue,
                Sector.Gray,
                Sector.Green,
                Sector.Purple,
                Sector.Red,
                Sector.Yellow
            };
        }
    }
}
