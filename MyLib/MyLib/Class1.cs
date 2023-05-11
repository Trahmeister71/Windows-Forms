using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person() { }
        public Person(string n, int a)
        {
            Name = n;
            Age = a;
        }

    }
    namespace Student
    {
        public class Student : Person
        {
            public string Academy { get; set; }
            public Student() { }
            public Student(string n, int a, string ac): base(n,a)
            {
                Academy = ac;
            }
        }

    }
}
