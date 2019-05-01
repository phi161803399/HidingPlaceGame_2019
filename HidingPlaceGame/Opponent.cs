using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidingPlaceGame
{
    public class Opponent
    {
        private Location myLocation;
        private Random random;

        public Opponent(Location startLocation)
        {
            myLocation = startLocation; // front yard
            random = new Random();
        }
        
        public void Move()
        {
            // move 10 times
            for (int i = 0; i < 10; i++)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    if (random.Next(2) == 1) // go through door
                    {
                        myLocation = (myLocation as IHasExteriorDoor).DoorLocation;
                    }
                }
                // choose random exit until location has a hiding place
                // infinite loop if no exit has a hiding place
                while (true)
                {
                    Location newLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                    if (newLocation is IHidingPlace)
                    {
                        myLocation = newLocation;
                        break;
                    }
                }
            }                                    
        }

        public bool Check(Location locationToCheck)
        {
            return (locationToCheck == myLocation);
        }
    }
}
