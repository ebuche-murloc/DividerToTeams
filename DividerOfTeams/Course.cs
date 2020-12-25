using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DividerToTeams
{
    class Course
    {
        public Dictionary<int, Person> Participants { get; private set; }
        public int IdCounter { get; private set; }
        public List<Team> Teams { get; private set; }
        public Dictionary<int, Team> memberLocation { get; private set; }

        public Course()
        {
            Participants = new Dictionary<int, Person>();
            memberLocation = new Dictionary<int, Team>();
            IdCounter = 0;
        }

        public void AddParticipant(string name, string surname)
        {
            IdCounter ++;
            Participants[IdCounter] = new Person((IdCounter), name, surname);
        }

        public void RemoveParticipant(int id)
        {
            var exParticipant = Participants[id];
            memberLocation[id].Members.Remove(exParticipant);
            Participants.Remove(id);
            foreach (var person in exParticipant.FamiliarPersons.ToList())
                person.RemoveFamiliar(exParticipant);
        }

        public void CreateTeams()
        {
            Teams = new List<Team>();

            foreach (var participants in Participants.Select(x => x.Value)
                                                     .OrderByDescending(x => x.FamiliarPersons.Count)
                                                     .ThenBy(x => x.ID).ToList())
                AssignToATeam(participants);
        }

        private void AssignToATeam(Person newbie)
        {
            foreach(var team in Teams.OrderBy(x => x.MembersCount).ToList())
            {
                if (team.IsPersonConflicts(newbie) == false)
                {
                    memberLocation[newbie.ID] = team;
                    team.Members.Add(newbie);
                    return;
                }
            }

            var newTeam = new Team();
            memberLocation[newbie.ID] = newTeam;
            newTeam.Members.Add(newbie);
            Teams.Add(newTeam);
        }
    }
}
