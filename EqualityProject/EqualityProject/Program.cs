using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Expected behaviour with value types
            var numList = new List<int>() { 4, 5 };
            var numbers = new List<int>() { 3, 4 };
            var result = numList.Intersect(numbers);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
            //Problem with object comparison
            var students = new List<Student>();
            var girl = new Student() { Name = "Simran", StudentId = 4 };
            var sameGirl = new Student() { Name = "Simran", StudentId = 4 };
            students.Add(girl);
            Console.WriteLine("Default equality : {0}", students.Contains(sameGirl));

            //Equality using overridden methods - Equal and GetHashCode of Object
            var emp1 = new Employee() { Id = 1, Name = "John" };
            var emp2 = new Employee() { Id = 1, Name = "John" };
            Console.WriteLine(emp1.Equals(emp2));

            var empList = new List<Employee>();
            empList.Add(emp1);
            Console.WriteLine(empList.Contains(emp2));

            var employees = new HashSet<Employee>();
            employees.Add(emp2);
            Console.WriteLine(employees.Contains(emp1));

            //Equality using IEqualityComparer
            var studentList = new List<Student>();
            studentList.Add(girl);
            var stuList = new List<Student>();
            stuList.Add(sameGirl);
            var commonStudents = studentList.Intersect(stuList, new StudentComparer()).ToList();

            foreach (var student in commonStudents)
            {
                Console.WriteLine("Id: {0} , Name: {1}", student.StudentId, student.Name);
            }

            Console.WriteLine(studentList.Contains(sameGirl, new StudentComparer()));

            //Equality using IEquatable
            var person1 = new Person() { Age = 21, Name = "Alice" };
            var person2 = new Person() { Age = 21, Name = "Alice" };
            Console.WriteLine(person1.Equals(person2));

            Console.ReadKey();
        }
    }
}
