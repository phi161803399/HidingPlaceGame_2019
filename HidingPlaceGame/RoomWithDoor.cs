namespace BuildAHouse
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public string DoorDescription
        { get; }

        public Location DoorLocation
        { get; set; }

        public RoomWithDoor(string name, string decoration, string description):
            base(name, decoration)
        {
            DoorDescription = description;
        }
    }
}
