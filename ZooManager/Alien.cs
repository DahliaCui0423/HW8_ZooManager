using System;
namespace ZooManager
{
    public class Alien : Occupant, IPredator
    {
        string name = "alien";

        public int reactionTime = 1;

        public Alien()
        {
            emoji = "👽";
            species = "alien";
        }

        public void Activate()
        {
            Console.WriteLine($"Alien {name} at {location.x},{location.y} activated");
            Hunt();
        }

        public void Hunt()
        {
            for (var i = 0; i < 4; i++)
            {
                if (Game.Seek(location.x, location.y, (Direction)i, "grass"))
                {
                    Attack((Direction)i);
                    return; // end function early
                }
                if (Game.Seek(location.x, location.y, (Direction)i, "boulder"))
                {
                    Attack((Direction)i);
                    return; // end function early
                }
                if (Game.Seek(location.x, location.y, (Direction)i, "mouse"))
                {
                    Attack((Direction)i);
                    return; // end function early
                }
                if (Game.Seek(location.x, location.y, (Direction)i, "cat"))
                {
                    Attack((Direction)i);
                    return; // end function early
                }
                if (Game.Seek(location.x, location.y, (Direction)i, "elephant"))
                {
                    Attack((Direction)i);
                    return; // end function early
                }
            }
        }

        public void Attack(Direction d)
        {
            Console.WriteLine($"{this.name} is attacking {d.ToString()}");
            int x = this.location.x;
            int y = this.location.y;

            switch (d)
            {
                case Direction.up:
                    Game.animalZones[y - 1][x].occupant = this;
                    break;
                case Direction.down:
                    Game.animalZones[y + 1][x].occupant = this;
                    break;
                case Direction.left:
                    Game.animalZones[y][x - 1].occupant = this;
                    break;
                case Direction.right:
                    Game.animalZones[y][x + 1].occupant = this;
                    break;
            }
            Game.animalZones[y][x].occupant = null;
        }
    }
}
