using System;

namespace BuildAHouse
{
    class Room: Location
    {
        private string decoration;
        public Room(string name, string decoration):
            base(name)
        {
            this.decoration = decoration;
        }

        public override string Description
        {
            get
            {
                string description = base.Description + Environment.NewLine;
                description += $"Decoration: {decoration}.";
                return description;
            }
        }
    }
}
