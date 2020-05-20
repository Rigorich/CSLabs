using System;

namespace Lab3568
{
    class StudentBSUIR : Student, ISmart
    {
        public override string University => "БГУИР";

        public enum Faculties
        {
            ФКСиС,
            ФИТУ,
            ФКП,
            ФРЭ,
            ФИК
        }
        private Faculties faculty;
        public override string Faculty => faculty.ToString();

        public StudentBSUIR(string name, DateTime birth, Faculties faculty, int group) : base(name, birth, group)
        {
            this.faculty = faculty;
        }

        public void BeSmart()
        {
            if (faculty == Faculties.ФКСиС)
            {
                Console.WriteLine(ToString() + ", сдал тест Бережа");
            } 
            else
            {
                Console.WriteLine($"{Name}, студент {Faculty} БГУИР, запрограммировал калькулятор");
            }
        }

    }
    class StudentBSU : Student, ISmart
    {
        public override string University => "БГУ";

        bool fpmi;
        public override string Faculty
        {
            get
            {
                return fpmi ? "ФПМИ" : "не ФПМИ";
            }
        }

        public void BeSmart()
        {
            Console.WriteLine(Name + ", студент БГУ, просто существует");
        }

        public StudentBSU(string name, DateTime birth, bool fpmi) : base(name, birth)
        {
            this.fpmi = fpmi;
        }
    }
    class StudentBNTU : Student
    {
        public override string University => "БНТУ";
        public override string Faculty => "Автотракторный";
        public StudentBNTU(string name, DateTime birth) : base(name, birth)
        {
        }
    }
}
