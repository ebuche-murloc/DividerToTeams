using System;
using System.Collections.Generic;
using System.Text;

namespace DividerToTeams
{
    class ApplicationModel
    {
        private Course Course { get; set; }

        public ApplicationModel()
        {
            Course = new Course();
        }

        public void StartApp()
        {
            AddAllPartiipants();
        }

        private void AddAllPartiipants()
        {
            Console.WriteLine(@"Внесите имена всех участников курса в следующем виде: фамилия имя
Для прекращения ввода введите: стоп");

            var userInput = Console.ReadLine();

            while (userInput.ToLower() != "стоп")
            {
                if (userInput.Split(" ").Length != 2) continue;

                var info = userInput.Split(" ");
                Course.AddParticipant(info[0], info[1]);
            }

            if (Course.ParticipantsCount == 0)
            {
                Console.WriteLine("Вы решили не вводить участников и мы вам инчего не покажем");
                return; 
            }

            ShowParticipants();
        }

        private void ShowParticipants()
        {
            foreach (var participant in Course.Participants)
                Console.WriteLine(string.Format("{0}. {1} {2}", p));
        }
    }
}
