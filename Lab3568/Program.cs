using System;
using System.Text;

namespace Lab3568
{
    class Program
    {
        static void Main(string[] args)
        {
            Lab3Test();
            Lab56Test();
            Lab8Test();
        }
        static void Lab8Test()
        {
            // ...
            Console.WriteLine("\n\n\n");
        }

        static void Lab56Test()
        {
            var rnd = new Random(13);
            Student[] studs = new Student[13];
            studs[0] = new StudentBSUIR("Гришаев Никита", new DateTime(2001, 10, 27), StudentBSUIR.Faculties.ФКСиС, 953501);
            for (int i = 1; i < studs.Length; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append((char)(rnd.Next('А', 'Я' + 1)));
                for (int j = rnd.Next(5); j < 7; j++)
                {
                    name.Append((char)(rnd.Next('а', 'я' + 1)));
                }
                DateTime date = new DateTime(2000, 1, 1);
                date.AddDays(rnd.Next(1000));
                int univ = rnd.Next(4);
                switch (univ)
                {
                    case 0:
                    case 1:
                        studs[i] = new StudentBSUIR(name.ToString(), date, (StudentBSUIR.Faculties)(rnd.Next(5)), rnd.Next(900000, 1000000));
                        break;
                    case 2:
                        studs[i] = new StudentBSU(name.ToString(), date, (rnd.Next(3) == 0));
                        break;
                    case 3:
                        studs[i] = new StudentBNTU(name.ToString(), date);
                        break;
                }
            }
            Console.WriteLine("\nСписок студентов:");
            for (int i = 0; i < studs.Length; i++)
            {
                Console.WriteLine(studs[i].ToString());
            }
            Array.Sort(studs);
            Console.WriteLine("\nОтсортированный список студентов:");
            for (int i = 0; i < studs.Length; i++)
            {
                Console.WriteLine(studs[i].ToString());
            }
            Console.WriteLine("\nУмные студенты:");
            for (int i = 0; i < studs.Length; i++)
            {
                if (studs[i] is ISmart st)
                {
                    st.BeSmart();
                }
            }

            Console.WriteLine("\nЭкзамены:");
            string[] examNames = new string[3] { "Прогр-е", "ОАиП", "ММА" };
            Student.Exam[] BSUIRexams = new Student.Exam[3] {
                new Student.Exam(examNames[0], new DateTime(2020, 6, 29)),
                new Student.Exam(examNames[1], new DateTime(2020, 6, 12)),
                new Student.Exam(examNames[2], new DateTime(2020, 6, 25))
            };
            for (int i = 0; i < studs.Length; i++)
            {
                if (studs[i] is StudentBSUIR st)
                {
                    st.Exams = BSUIRexams;
                }
            }
            for (int i = 0; i < studs.Length; i++)
            {
                if (studs[i] is StudentBSUIR st)
                {
                    int examNum = rnd.Next(3);
                    while (studs[i].Exams[examNum].Score < 4)
                    {
                        st.PassExam(examNames[examNum], rnd.Next(11));
                    }
                }
            }

            Console.WriteLine("\n\n\n");
        }

        static void Lab3Test()
        {
            Human god = new Human(DateTime.MinValue, "God");
            god[DateTime.MinValue] = "TEST";
            god[DateTime.MinValue] += "; separation of light from darkness";
            god[DateTime.MinValue.AddDays(1)] = "creation of firmament";
            god["planting"] = DateTime.MinValue.AddDays(2);
            god.AddEvent(DateTime.MinValue.AddDays(3), "addition of luminaries");
            god[DateTime.MinValue.AddDays(4)] = "making animals";
            god[DateTime.MinValue.AddDays(5)] = "fashioning human";
            Console.Write(god.History);
            god.Say("Hello World!");

            Creation();
            GC.Collect(); GC.WaitForPendingFinalizers();

            Human norman = new Human("Norman");
            norman[DateTime.Now] = "birth";
            Console.WriteLine($"{norman.Name} hates his name!");
            norman.Name = "John Doe";
            norman.AddEvent("test");
            norman.AddEvent(DateTime.UnixEpoch, "test");
            Console.Write($"History of {norman.Name}:\n{norman.History}");
            norman.Say("pls delete test-1970 thx");
            norman.DelEvent("test");
            Console.Write($"History of {norman.Name}:\n{norman.History}");

            Console.WriteLine($"So, totally were born {god.PeopleWereBorn} humans"); ;
            Console.WriteLine($"Age of the world is {god.Age} years"); ;

            Console.WriteLine("\n\n\n");
        }
        static void Creation()
        {
            Human adam = new Human("Adam");
            Human eve = new Human("Eve");
            Console.WriteLine("God's wrath!");
        }
    }
}
