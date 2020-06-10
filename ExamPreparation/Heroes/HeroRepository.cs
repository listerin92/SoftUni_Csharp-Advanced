using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {


        public HeroRepository()
        {
            this.Heroes = new List<Hero>();
        }
        public List<Hero> Heroes { get; set; }
        public int Count => Heroes.Count;

        public void Add(Hero hero)
        {
            this.Heroes.Add(hero);
        }

        public void Remove(string name)
        {
            var hr = Heroes.FirstOrDefault(x => x.Name == name);
            Heroes.Remove(hr);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return Heroes.OrderByDescending(i => i.Item.Strength).First();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return Heroes.OrderByDescending(i => i.Item.Ability).First();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return Heroes.OrderByDescending(i => i.Item.Intelligence).First();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Heroes.Count > 0)
            {
                foreach (var hero in this.Heroes)
                {
                    sb.AppendLine($"{hero}");
                }
            }
            return sb.ToString();
        }
    }
}