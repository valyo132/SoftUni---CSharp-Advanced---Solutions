using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }
        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
                return "Invalid player's information.";
            else if (OpenPositions == 0)
                return "There are no more open positions.";
            else if (player.Rating < 80)
                return "Invalid player's rating.";
            else
            {
                this.Players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }

        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.Players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
                return false;

            this.OpenPositions++;
            this.Players.Remove(playerToRemove);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = this.Players.RemoveAll(p => p.Position == position);
            this.OpenPositions += removedPlayers;
            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            var playerToRetire = this.Players.FirstOrDefault(x => x.Name == name);

            if (playerToRetire == null)
                return null;

            playerToRetire.Retired = true;
            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            return this.Players.Where(p => p.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var item in Players)
            {
                if (item.Retired == false)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
