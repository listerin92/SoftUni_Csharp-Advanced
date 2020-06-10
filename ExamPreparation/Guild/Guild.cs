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
            if (roster.Count < this.Capacity && roster.All(x => x.Name != player.Name))
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player playerToRemove = roster.Where(x => x.Name == name).FirstOrDefault();
                roster.Remove(playerToRemove);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player promotedPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                promotedPlayer.Rank = "Member";
            }

        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player demotedPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                demotedPlayer.Rank = "Trial";
            }
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
            sb.AppendLine($"roster in the guild: {this.Name}");
            if (roster.Count > 0)
            {
                foreach (var player in roster)
                {
                    sb.AppendLine($"{player}");
                }
            }
            return sb.ToString();
        }
    }
}
