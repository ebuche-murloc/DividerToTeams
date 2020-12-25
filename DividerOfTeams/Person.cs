using System;
using System.Collections.Generic;
using System.Text;

namespace DividerToTeams
{
    class Person
    {
        public readonly int ID;
        public readonly string Name;
        public readonly string Surname;
        public List<Person> FamiliarPersons { get; private set; }

        public Person(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
            FamiliarPersons = new List<Person>();
        }

        public void AddFamiliar (Person familiar)
        {
            if (familiar != this && !FamiliarPersons.Contains(familiar))
            {
                FamiliarPersons.Add(familiar);
                familiar.AddFamiliar(this);
            }
        }

        public void RemoveFamiliar(Person familiar)
        {
            if (FamiliarPersons.Contains(familiar))
            {
                FamiliarPersons.Remove(familiar);
                familiar.RemoveFamiliar(this);
            }
        }

        public override string ToString()
        {
            StringBuilder famPersons = new StringBuilder();
            foreach (var person in FamiliarPersons)
                famPersons.Append(' ' + person.ID.ToString());

            return string.Format("{0}. {1} {2}:{3}", ID, Name, Surname, famPersons.ToString());
        }
    }
}
