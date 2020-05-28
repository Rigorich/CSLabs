using System;

namespace Lab3568
{
    abstract class Student : Human, IFormattable, IComparable
    {
        private int group;
        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                if (group < 0)
                {
                    throw new ArgumentException("Группа не может быть отрицательной");
                }
                Console.WriteLine($"Студент {Name} был переведён из группы {group} в группу {value}");
                group = value;
            }
        }

        public abstract string University { get; }

        public abstract string Faculty { get; }

        public struct Exam
        {
            public string Subject { get; private set; }
            public DateTime Date { get; set; }
            public int Retakes { get; private set; }

            const int MinScore = 4;
            int score;
            public int Score
            {
                get
                {
                    return score;
                }
                set
                {
                    if (value < MinScore)
                    {
                        Retakes++;
                    }
                    else
                    {
                        score = value;
                    }
                }
            }
            public Exam(string subject, DateTime date)
            {
                Subject = subject;
                Date = date;
                Retakes = 0;
                score = 0;
            }
        }
        Exam[] exams;
        public Exam[] Exams 
        { 
            get 
            {
                return exams;
            }
            set 
            {
                exams = new Exam[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    exams[i] = value[i];
                }
            } 
        }
        public void PassExam(string subject, int score)
        {
            for (int i = 0; i < exams.Length; i++)
            {
                if (subject == exams[i].Subject)
                {
                    exams[i].Score = score;
                    Say($"{exams[i].Date.ToShortDateString()} я сдал {exams[i].Subject} на {exams[i].Score}, пересдач - {exams[i].Retakes}");
                    return;
                }
            }
            throw new ArgumentException("Неверный предмет");
        }

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return ToString();
        }
        public override string ToString()
        {
            return String.Format($"{Name}, студент {University}, факультета {Faculty}, группы {Group}");
        }

        int IComparable.CompareTo(object obj)
        {
            Student st = obj as Student;
            if (st == null)
            {
                throw new InvalidCastException("Это не студент!");
            }
            if (University != st.University)
            {
                return University.CompareTo(st.University);
            }
            if (Faculty != st.Faculty)
            {
                return Faculty.CompareTo(st.Faculty);
            }
            if (Group != st.Group)
            {
                return Group.CompareTo(st.Group);
            }
            return Name.CompareTo(st.Name);
        }

        public Student(string name, DateTime birth, int group) : base(name, birth)
        {
            Console.WriteLine($"Привет {name}, студент {University}!");
            this.group = group;
        }
        public Student(string name, DateTime birth) : this(name, birth, 0)
        {
        }
    }
}
