using System;

namespace BuildAHouse
{
    class Outside: Location
    {
        private bool hot;
        public Outside(string name, bool hot):
            base(name)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                string description = base.Description + Environment.NewLine;
                if (hot)
                {
                    description += $"It's very hot here." + Environment.NewLine;
                }
                return description;
            }
        }
    }
}
