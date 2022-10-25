using System;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } = "Trial";
        public string Description { get; set; } = "n/a";

        public override string ToString()
            => $"Player {Name}: {Class}" + Environment.NewLine +
                $"Rank: {Rank}" + Environment.NewLine +
                $"Description: {Description}";
    }
}
