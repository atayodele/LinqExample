using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLin
{
    class Program
    {
        class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            // string collection
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 20 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 18 }
            };

            var result = from std in studentList
                         where std.Age >= 15 && std.Age <= 21
                         select std;
            var m = studentList.Where(a => a.Age == 13).Where(v => v.StudentName == "John").ToList<Student>();
            Console.WriteLine("Students are:");
            foreach(Student x in result)
            {
                Console.WriteLine("StudentID => {0}, Student Name =>{1}, Age => {2}", x.StudentID, x.StudentName, x.Age);
            }
            foreach (Student d in m)
            {
                Console.WriteLine("StudentID => {0}, Student Name =>{1}, Age => {2}", d.StudentID, d.StudentName, d.Age);
            }
            Console.WriteLine("\n*********************ORDERBY****************");
            var asc = from q in studentList
                        orderby q.StudentName
                        select q;
            var desc = from w in studentList
                       orderby w.StudentName descending
                       select w;
            Console.WriteLine("ORDERBY Students are:");
            foreach (Student x in asc)
            {
                Console.WriteLine("StudentID => {0}, Student Name =>{1}, Age => {2}", x.StudentID, x.StudentName, x.Age);
            }
            Console.WriteLine("\n");
            foreach (Student d in desc)
            {
                Console.WriteLine("StudentID => {0}, Student Name =>{1}, Age => {2}", d.StudentID, d.StudentName, d.Age);
            }
            Console.WriteLine("\n*********************THEN-BY  or  THEN-BY-DESCENDING ****************");
            var denby = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);
            var desthen = studentList.OrderBy(S => S.StudentName).ThenByDescending(s => s.Age);
            Console.WriteLine("THEN-BY  or  THEN-BY-DESCENDING Students are:");
            foreach (Student x in denby)
            {
                Console.WriteLine("StudentID => {0}, Student Name =>{1}, Age => {2}", x.StudentID, x.StudentName, x.Age);
            }
            Console.WriteLine("\n");
            foreach (Student d in desthen)
            {
                Console.WriteLine("StudentID => {0}, Student Name =>{1}, Age => {2}", d.StudentID, d.StudentName, d.Age);
            }
            Console.WriteLine("\n*********************GROUP-BY OR TO-LOOK-UP  ****************\n");
            var grp = from p in studentList group p by p.Age;
            var man = studentList.ToLookup(s => s.Age);
            foreach(var agegroup in man)
            {
                Console.WriteLine("Age Group: {0}", agegroup.Key);
                foreach(Student names in agegroup)
                {
                    Console.WriteLine("Student Name => {0}", names.StudentName);
                }
            }
            Console.WriteLine("\nPress any key to exit....");
            Console.ReadKey();
        }
    }
}
