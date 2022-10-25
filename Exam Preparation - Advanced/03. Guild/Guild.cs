using System.Collections.Generic;
using System.Linq;
using System;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Roster.Count; } }

        private List<Player> roster;

        public List<Player> Roster
        {
            get { return roster; }
            set { roster = value; }
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
                Roster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            var player = Roster.FirstOrDefault(x => x.Name == name);
            if (player == null)
                return false;

            Roster.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            var player = Roster.FirstOrDefault(x => x.Name == name);
            if (player.Rank == "Trial") // !=
                player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            var player = Roster.FirstOrDefault(x => x.Name == name);
            if (player.Rank == "Member") // !=
                player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var players = Roster.FindAll(x => x.Class == @class).ToArray();
            Roster.RemoveAll(x => x.Class == @class);
            return players;
        }

        public string Report()
        {
            return $"Players in the guild: {Name}" + Environment.NewLine +
                string.Join(Environment.NewLine, Roster);
        }
    }
}
