using System;
using System.Windows.Forms;

namespace HidingPlaceGame
{
    public partial class Form1 : Form
    {
        private Location currentLocation;

        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room diningRoom;
        OutsideWithDoor backYard;
        OutsideWithDoor frontYard;
        Outside garden;
        public Form1()
        {
            InitializeComponent();
            CreateLocations();
            // starting position
            MoveToANewLocation(frontYard);
        }

        public void CreateLocations()
        {
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door");
            diningRoom = new Room("Dining Room", "crystal chandelier");
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
            garden = new Outside("Garden", true);

            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { livingRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            frontYard.Exits = new Location[] { garden, backYard };
            backYard.Exits = new Location[] { garden, frontYard };
            garden.Exits = new Location[] { backYard, frontYard };

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
        }

        public void MoveToANewLocation(Location goToLocation)
        {
            currentLocation = goToLocation;
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i]);
            }
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;

            goThroughTheDoor.Visible = (currentLocation is IHasExteriorDoor) ? true : false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(exits.SelectedItem as Location);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            MoveToANewLocation((currentLocation as IHasExteriorDoor).DoorLocation);
        }
    }
}
