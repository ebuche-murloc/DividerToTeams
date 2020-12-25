using System;
using System.Collections.Generic;

namespace DividerToTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new[] { "Солман", "Шамиль", "Руслан", "Рулон", "Отряд", "Поджог", "Камаз", "Развод", "Улов", "Отряд", "Налог", "Захват",
                "Запой", "Барак", "Рожок", "Прыжок" };
            var surnames = new[] { "Радуев", "Басаев", "Гилаев", "Обоев", "Ковбоев", "Сараев", "Отходов", "Супругов", "Кальмаров", "Кретинов", "Сдоходов", "Покоев", 
                "Гусаров", "Монголов", "Патронов", "Гибонов" };

            var rnd = new Random(133);
            var nms = new HashSet<string>();
            string n;
            string s;

            var course = new Course();
            for (int i = 0; i < 50; i++)
            {
                n = names[rnd.Next(0, names.Length)];
                s = surnames[rnd.Next(0, names.Length)];
                if (nms.Contains(n+s))
                {
                    i--;
                    continue;
                }
                course.AddParticipant(n, s);
                nms.Add(n+s);
            }


            foreach (var part1 in course.Participants)
                foreach (var part2 in course.Participants)
                    if (rnd.Next(0, 4) == 0)
                        part1.Value.AddFamiliar(part2.Value);
            //course.Participants[1].AddFamiliar(course.Participants[2]);
            //course.Participants[3].AddFamiliar(course.Participants[4]);
            //course.Participants[3].AddFamiliar(course.Participants[5]);
            //course.Participants[4].AddFamiliar(course.Participants[5]);
            //var app = new Application();
            //app.Course = course;
            //app.Course.CreateTeams();
            //app.ShowTeams();
            //app.ShowParticipants();
            var a = new Application();
            a.Course = course;
            a.StartApp();
        }
    }
}
