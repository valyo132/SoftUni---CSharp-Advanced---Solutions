using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            this.Name = name;
            this.Position = position;
            this.Rating = rating;
            this.Games = games;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; } = false;

        public override string ToString()
         => $"-Player: {this.Name}" + Environment.NewLine +
            $"--Position: {this.Position}" + Environment.NewLine +
            $"--Rating: {this.Rating}" + Environment.NewLine +
            $"--Games played: {this.Games}";
    }
}
