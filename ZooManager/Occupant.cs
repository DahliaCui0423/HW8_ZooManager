using System;
namespace ZooManager
{
    public class Occupant
    {
        public string emoji;
        public string species;
        public bool move = false;

        public Point location;

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }
    }
}
