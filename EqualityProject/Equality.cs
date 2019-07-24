using System;
using System.Collections.Generic;

namespace EqualityProject
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Allows to override method with argument type as Object only
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            var emp = (Employee)obj;
            return emp.Id == Id && emp.Name == Name;
        }
    
        //For hash based comparison
        public override int GetHashCode() => new { Id, Name }.GetHashCode();
    }

    public class Person : IEquatable<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }

        //Flexibility to use argument type other than Object
        public bool Equals(Person otherPerson)
        {
            if (otherPerson != null
                && otherPerson.Age == Age && otherPerson.Name == Name)
            {
                return true;
            }
            return false;
        }

        //GetHashCode() method of Object base class is implemented for hash based comparison
        public override int GetHashCode() => new { Age, Name }.GetHashCode();
    }

    /// <summary>
    /// External Class which implements IEqualityComparer to compare equality of two objects of a type.
    /// </summary>
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x != null && y != null)
            {
                if (x.StudentId == y.StudentId && x.Name == y.Name)
                {
                    return true;
                }
            }

            return false;
        }
        public int GetHashCode(Student obj) => new { obj.StudentId, obj.Name }.GetHashCode();
    }
}
