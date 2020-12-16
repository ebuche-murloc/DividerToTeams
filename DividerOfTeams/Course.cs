using System;
using System.Collections.Generic;
using System.Text;

namespace DividerToTeams
{
    class Course
    {
        public Dictionary<int, Person> Participants { get; private set; }
        public int ParticipantsCount => Participants.Count;
        public List<Team> Teams { get; private set; }

        public Course()
        {
            Participants = new Dictionary<int, Person>();
        }

        public void AddParticipant(string surname, string name)
        {
            Participants[ParticipantsCount + 1] = new Person((ParticipantsCount + 1), surname, name);
        }

        public void CreateTeams()
        {
            Teams = new List<Team>();

            foreach (var participants in Participants)
                AssignToATeam(participants.Value);
        }

        private void AssignToATeam(Person newbie)
        {
            foreach(var team in Teams)
            {
                if (team.IsPersonConflicts(newbie) == false)
                {
                    team.Members.Add(newbie);
                    return;
                }
            }

            var newTeam = new Team();
            newTeam.Members.Add(newbie);
            Teams.Add(newTeam);
        }
    }
}
