namespace HidingPlaceGame
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public string DoorDescription
        { get; }

        public Location DoorLocation
        { get; set; }

        public RoomWithDoor(string name, string decoration, string description, string hidingPlace):
            base(name, decoration, hidingPlace)
        {
            DoorDescription = description;
        }
    }
}
