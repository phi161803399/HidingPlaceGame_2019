using System;
using System.Windows.Forms;

namespace HidingPlaceGame
{
    public partial class Form1 : Form
    {
        private Location currentLocation;
        private Opponent opponent;

        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room diningRoom;
        Room stairs;
        RoomWithHidingPlace upstairsHallway;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathroom;
        OutsideWithDoor backYard;
        OutsideWithDoor frontYard;
        OutsideWithHidingPlace garden;
        OutsideWithHidingPlace driveway;
        public Form1()
        {
            InitializeComponent();
            CreateLocations();
            // starting position
            MoveToANewLocation(frontYard);
            opponent = new Opponent(frontYard);
        }

        public void CreateLocations()
        {
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob", "a closet");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door", "a cabinet");
            diningRoom = new Room("Dining Room", "crystal chandelier");
            stairs = new Room("Stairs", "wooden bannister");
            upstairsHallway = new RoomWithHidingPlace("Upstairs Hallway", "picture of a dog", "a closet");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "sink and a toilet", "in the shower");
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
            garden = new OutsideWithHidingPlace("Garden", false, "in the shed");
            driveway = new OutsideWithHidingPlace("Driveway", false, "the garage");

            livingRoom.Exits = new Location[] { diningRoom, stairs };
            kitchen.Exits = new Location[] { livingRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            frontYard.Exits = new Location[] { garden, backYard, driveway };
            backYard.Exits = new Location[] { garden, frontYard, driveway };
            garden.Exits = new Location[] { backYard, frontYard };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            upstairsHallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };
            driveway.Exits = new Location[] { frontYard, backYard };

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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}
