namespace Lectures
{
    class Program
    {

        static List<Person> personsList = new List<Person>();
        static List<Teacher> teacherList = new List<Teacher>();
        static List<Student> StudentList = new List<Student>();
        private static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the St Johns Attendee database");
            Console.WriteLine("Enter the corresponding digit to get started");
            Console.WriteLine("1:Add a new person\n2:Add a new student\n3:Add a new teacher\n4:Display Students\n5:Display Teachers\n6:Exit Program");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    CreatePerson();
                    break;
                case 2:
                    CreateStudent();
                    break;
                case 3:
                    CreateTeacher();
                    break;
                case 4:
                    DisplayStudents();
                    break;
                case 5:
                    DisplayTeachers();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void CreatePerson()
        {
            gender personsGender = gender.unassigned;

            Console.WriteLine("Enter persons name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter persons age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter corresponding digit to gender\n1:Male\n2:Female");
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
            Console.WriteLine("New person added");

            Console.WriteLine("Would you like to add a role to a person(y/n)");
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
                ReturnToMenu();
            }
            else
            {
                Console.WriteLine("That reply is incorrect");
                ReturnToMenu();
            }
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

            if (currentPerson == null) { Console.WriteLine("Person not found!"); Menu(); }

            Student newStudent = new Student(currentPerson.name, currentPerson.age, currentPerson.gender);
            StudentList.Add(newStudent);
            Console.WriteLine("Student Added " + newStudent.name);
            ReturnToMenu();
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
            ReturnToMenu();
        }

        private static void DisplayTeachers()
        {
            if (teacherList.Count <= 0)
            {
                Console.WriteLine("List is empty");
                Task.Delay(9000);
                Menu();
                return;
            }
            Console.WriteLine("\n\nHere is a list of teachers:");
            foreach (Teacher t in teacherList)
            {
                Console.WriteLine(t.name);
            }
            ReturnToMenu();
        }

        private static void DisplayStudents()
        {
            if (StudentList.Count <= 0)
            {
                Console.WriteLine("List is empty");
                Task.Delay(9000);
                Menu();
                return;
            }
            Console.WriteLine("\n\nHere is a list of students:");
            foreach (Student s in StudentList)
            {
                Console.WriteLine(s.name);
            }

            ReturnToMenu();
        }

        private static void ReturnToMenu()
        {
            Console.WriteLine("Enter 1 to exit");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1) { Menu(); }
            else Menu();
        }

    }
}