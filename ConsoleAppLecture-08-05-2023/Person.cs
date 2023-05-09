namespace Lectures
{
    public enum gender
    {
        male,
        female,
        notChosen,
    }

    class Person
    {
        internal string name = "";
        internal int age;
        internal gender gender;

        public Person(string name, int age, gender gender)
        {
            
            this.name = name;
            this.age = age;
            this.gender = gender;
        }
    }

    class Student : Person
    {
        
        internal Student(string name, int age, gender myGender) : base(name, age, myGender)
        {
            
        }
    }

    class Teacher : Person
    {
        double salary;

        internal Teacher(string name, int age, gender myGender, double salary) : base(name, age, myGender)
        {

        }
    }
}