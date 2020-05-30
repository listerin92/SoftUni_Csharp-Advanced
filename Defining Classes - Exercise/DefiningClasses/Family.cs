
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            family = new List<Person>();
        }
        public List<Person> family { get; set; }
        public void AddMember(Person member)
        {
            family.Add(member);
        }

        public Person GetOldestMember()
        {
            return family.OrderByDescending(x => x.Age).First();
        }

        public List<Person> OlderThan30Sorted()
        {
            return family.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();


        }
    }
}
