using System;
using System.Collections.Generic;
using System.Text;

namespace DividerToTeams
{
    class Team
    {
        public List<Person> Members { get; set; }
        public int MembersCount => Members.Count;

        public Team()
        {
            Members = new List<Person>();
        }

        public bool IsPersonConflicts(Person person)
        {
            foreach (var member in Members)
                if (member.FamiliarPersons.Contains(person))
                    return true;

            return false;
        }
    }
}
