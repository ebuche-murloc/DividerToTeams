using System;
using System.Collections.Generic;
using System.Text;

namespace DividerToTeams
{
    class Application
    {
        private Dictionary<int, Action> ActionDict = new Dictionary<int, Action>();
        public Course Course { get; set; }

        public Application()
        {
            Course = new Course();
            ActionDict = new Dictionary<int, Action>();
            ActionDict[1] = AddPartiсipants;
            ActionDict[2] = AddFamiliarPersons;
            ActionDict[3] = CreateTeams;
            ActionDict[4] = ShowParticipants;
            ActionDict[5] = ShowTeams;
            ActionDict[6] = RemovePartiсipant;
        }


        public void StartApp()
        {
            SelectAction();
        }

        private void SelectAction()
        {
            string userInput;

            do
            {
                Console.WriteLine(@"Выберите одно из следующих действий:
1. Внести имена участников
2. Добавить людей, с которыми знакомы участники
3. Сформировать команды
4. Показать участников
5. Показать команды
6. Удалить участника
Для прекращения ввода введите: стоп \n");
                userInput = Console.ReadLine();

                int command;
                int.TryParse(userInput, out command);

                if (IsUserInputWrong(x => !ActionDict.ContainsKey(x), command, "Некорректный ввод \n"))
                    continue;

                ActionDict[command]();
            }
            while (userInput.ToLower() != "стоп");
        }

        private void CreateTeams()
        {
            Course.CreateTeams();
            Console.WriteLine("Распределение по командам завершено \n");
        }
        private void AddPartiсipants()
        {
            Console.WriteLine(@"Внесите имена всех участников курса в следующем виде: имя фамилия
Для прекращения ввода введите: стоп "+"\n");

            string userInput;
            string[] info;

            do
            {
                Console.Write(@"Ввод: ");
                userInput = Console.ReadLine();
                info = userInput.Split(" ");

                if (IsUserInputWrong(x => x != 2, info.Length, "Некорректный ввод \n"))
                    return;

                Course.AddParticipant(info[0], info[1]);
                userInput = Console.ReadLine();
            }
            while (userInput.ToLower() != "стоп");

            if (IsUserInputWrong(x => x == 0, Course.Participants.Count, "Вы решили не вводить участников и мы вам ничего не покажем \n"))
                return;

            ShowParticipants();
        }

        private void RemovePartiсipant()
        {
            ShowParticipants();
            Console.Write(@"Введите id удаляемого человека:");

            var userInput = Console.ReadLine();
            int id;
            int.TryParse(userInput.Trim(), out id);

            if (IsUserInputWrong(x => x == 0 || !Course.Participants.ContainsKey(x) || Course.Participants[id] == null, id, "Некорректный ввод \n"))
                return;

            Course.RemoveParticipant(id);
        }

        private void AddFamiliarPersons()
        {
            ShowParticipants();

            Console.Write(@"Внесите имена всех участников курса в следующем виде: id_участника: id_знакомого_1 id_знакомого_2....
Для прекращения ввода введите: стоп \n");
            string userInput;
            string[] info;

            do 
            {
                Console.Write(@"Ввод: ");
                userInput = Console.ReadLine();


                info = userInput.Split(':');

                if (IsUserInputWrong(x => x < 2, info.Length, "Некорректный ввод \n"))
                    continue;

                int main;
                int.TryParse(info[0], out main);

                if (IsUserInputWrong(x => x == 0 || !Course.Participants.ContainsKey(x), main, "Некорректный ввод \n"))
                    continue;

                foreach (var person in info[1].TrimStart().Split(' '))
                {
                    int curPerson;
                    int.TryParse(person, out curPerson);

                    if (IsUserInputWrong(x => x == 0 || !Course.Participants.ContainsKey(x), curPerson, "Некорректный ввод \n"))
                        continue;

                    Course.Participants[main].AddFamiliar(Course.Participants[curPerson]);
                }
                userInput = Console.ReadLine();
            }
            while (userInput.ToLower() != "стоп") ;
        }

        public void ShowParticipants()
        {
            if (IsUserInputWrong(x => x == 0 || Course.Participants == null, Course.Participants.Count, "А участников пока нет \n"))
                return;

           foreach (var participant in Course.Participants)
               Console.WriteLine(participant.Value.ToString());
        }

        public void ShowTeams()
        {
            if (IsUserInputWrong(x => x == 0 || Course.Teams == null, Course.Teams.Count, "А команд пока нет \n"))
                return;

            Console.WriteLine("-------------------");
            foreach (var team in Course.Teams)
            {
                foreach (var member in team.Members)
                    Console.WriteLine(member.ToString());
                Console.WriteLine("-------------------");
            }
        }

        private bool IsUserInputWrong(Func<int, bool> checker, int valueToCheck, string mistakeMassage)
        {
            if (checker(valueToCheck))
            {
                Console.WriteLine(mistakeMassage);
                return true;
            }
            else
                return false;
        }
    }
}
