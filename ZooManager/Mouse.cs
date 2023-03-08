using System;
namespace ZooManager
{
    public class Mouse : Animal, IPrey, IPredator
    {
        bool isHunt = false;
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             Mouse*/
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            Hunt();
            if (!isHunt) Flee();
        }

        /* Updated to work like Elephant Flee */
        public bool Flee()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat"))
            {
                if (Game.Retreat(this, Direction.down)) return true;
            }
            if (Game.Seek(location.x, location.y, Direction.down, "cat"))
            {
                if (Game.Retreat(this, Direction.up)) return true;
            }
            if (Game.Seek(location.x, location.y, Direction.left, "cat"))
            {
                if (Game.Retreat(this, Direction.right)) return true;
            }
            if (Game.Seek(location.x, location.y, Direction.right, "cat"))
            {
                if (Game.Retreat(this, Direction.left)) return true;
            }
            return false;
        }

        /* Updated to check if hunt was successful */
        public void Hunt()
        {
            isHunt = false;
            if (Game.Seek(location.x, location.y, Direction.up, "grass"))
            {
                Game.Attack(this, Direction.up);
                isHunt = true;
                return;
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "grass"))
            {
                Game.Attack(this, Direction.down);
                isHunt = true;
                return;
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "grass"))
            {
                Game.Attack(this, Direction.left);
                isHunt = true;
                return;
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "grass"))
            {
                Game.Attack(this, Direction.right);
                isHunt = true;
                return;
            }
            return;
        }
    }
}

