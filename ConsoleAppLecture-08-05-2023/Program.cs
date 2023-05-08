using System.Collections;
using System.Security;

namespace Lectures
{
    class Program
    {

        static List<Person> personsList = new List<Person>();
        static List<Teacher> teacherList = new List<Teacher>();
        static List<Student> StudentList = new List<Student>();
        private static void Main(string[] args)
        {
            CreatePerson();
            //Person created and added
            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("Would you like to add a role to the person(y/n)");
            string reply = Console.ReadLine();

            if (reply == "y")
            {
                Console.WriteLine("What role:\n1:Teacher\n2:student");

                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    CreateTeacher();
                }
                else if (answer == "2")
                {
                    CreateStudent();
                }
            }
            else if (reply == "n")
            {
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That reply is incorrect");
            }

            Console.ReadKey();
        }

        private static void CreatePerson()
        {
            gender personsGender = gender.unassigned;

            Console.WriteLine("Enter persons name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter persons age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter corresponding digit to gender");
            Console.WriteLine("1:Male\n2:Female");
            int result = Convert.ToInt32(Console.ReadLine());

            if (result == 1)
            {
                personsGender = gender.male;
            }
            else if (result == 2)
            {
                personsGender = gender.female;
            }

            Person newPerson = new Person(name, age, personsGender);
            personsList.Add(newPerson);
        }

        private static void CreateStudent()
        {
            Person currentPerson = null;
            Console.WriteLine("Enter persons name to be student");
            string name = Console.ReadLine();

            foreach (Person person in personsList)
            {
                if (person.name == name)
                {
                    currentPerson = person;
                }
            }

            if (currentPerson == null) { Console.WriteLine("Person not found!"); return; }

            Student newStudent = new Student(currentPerson.name, currentPerson.age, currentPerson.gender);
            StudentList.Add(newStudent);
            Console.WriteLine("Student Added " + newStudent.name);
        }

        private static void CreateTeacher()
        {
            Person currentPerson = null;
            Console.WriteLine("Enter persons name to be teacher");
            string name = Console.ReadLine();

            foreach (Person person in personsList)
            {
                if (person.name == name)
                {
                    currentPerson = person;
                }
            }

            if (currentPerson == null) { Console.WriteLine("Person not found!"); return; }

            Console.WriteLine("Enter teachers salary");
            double salary = Convert.ToDouble(Console.ReadLine());
            Teacher newTeacher = new Teacher(currentPerson.name, currentPerson.age, currentPerson.gender, salary);
            teacherList.Add(newTeacher);
            Console.WriteLine("Teacher Added " + newTeacher.name);
        }

    }
}