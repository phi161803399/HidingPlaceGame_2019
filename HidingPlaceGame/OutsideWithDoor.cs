namespace HidingPlaceGame
{
    class OutsideWithDoor: Outside, IHasExteriorDoor
    {
        // Doorlocation: Location where the door leads
        public Location DoorLocation { get; set; }
        // Doordescription
        public string DoorDescription { get; }

        public OutsideWithDoor(string name, bool hot, string doorDescription):
            base(name, hot)
        {
            DoorDescription = doorDescription;
        }

        public override string Description
        {
            get
            {
                return base.Description + "You see " + DoorDescription;
            }
        }
    }
}
