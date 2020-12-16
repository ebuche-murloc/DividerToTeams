using System;
using System.Collections.Generic;
using System.Text;

namespace DividerToTeams
{
    class Person
    {
        public readonly int ID;
        public readonly string Surname;
        public readonly string Name;
        public List<Person> FamiliarPersons { get; private set; }

        public Person(int id, string surname, string name)
        {
            ID = id;
            Surname = surname;
            Name = name;
            FamiliarPersons = new List<Person>();
        }

        public void AddFamiliar (Person familiar)
        {
            if (familiar != this)
                FamiliarPersons.Add(familiar);
        }

        public void RemoveFamiliar(Person familiar)
        {
            if (FamiliarPersons.Contains(familiar))
                FamiliarPersons.Remove(familiar);
        }
    }
}
