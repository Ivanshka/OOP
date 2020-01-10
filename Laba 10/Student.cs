namespace Laba_10
{
    class Student
    {
        string Name { get; }
        int Number { get; }

        public override string ToString()
        {
            return "Студент: " + Name + ". Номер билета: " + Number + ".";
        }

        public Student(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
