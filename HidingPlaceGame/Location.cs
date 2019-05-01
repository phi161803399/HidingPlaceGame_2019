using System;

namespace BuildAHouse
{
    public abstract class Location
    {
        public Location(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public Location[] Exits;
        public virtual string Description
        {
            get
            {
                string description = $"You're standing in the {Name}.{Environment.NewLine}You see exits to the following places: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1)
                    {
                        description += ",";
                    }
                }
                description += ".";
                return description;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
