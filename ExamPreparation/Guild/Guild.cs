using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = roster.Find(x => x.Name == name);
            if (playerToRemove != null)
            {
                roster.Remove(playerToRemove);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Find(x => x.Name == name) == null)
                return;
            roster.Find(x => x.Name == name).Rank = "Member";

        }

        public void DemotePlayer(string name)
        {
            if (roster.Find(x => x.Name == name) == null)
                return;
            roster.Find(x => x.Name == name).Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string classs)

        {
            var kickedPlayers = this.roster.Where(x => x.Class == classs).ToArray();
            this.roster = this.roster.Where(x => x.Class != classs).ToList();
            return kickedPlayers;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            if (roster.Count > 0)
            {
                foreach (var player in roster)
                {
                    sb.AppendLine($"{player}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
