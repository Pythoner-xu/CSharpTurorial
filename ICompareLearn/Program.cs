using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompareLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>();
            stuList.Add(new Student() { Name = "a", Id = 1 });
            
            stuList.Add(new Student() { Name = "c", Id = 3 });

            stuList.Add(new Student() { Name = "b", Id = 2 });

            stuList.Sort(new StudengCompare());

            foreach (var st in stuList)
            {
                Console.WriteLine(st.ToString());
            }

            Console.ReadLine();
        }
    }


    /// <summary>
    /// 让对象可以进行比较：sort
    /// </summary>
    class Student : IComparable
    {
        public string Name;
        public int Id;

        public override string ToString()
        {
            return Id + ":" + Name;
        }

        public int CompareTo(object obj)
        {
            Console.WriteLine(obj);
            Student s = obj as Student;
            //if (this.Id > s.Id)
            //{
            //    return 1;
            //}
            //else if (this.Id == s.Id)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return -1;
            //}

            return this.Id.CompareTo(s.Id);
        }
    }

    /// <summary>
    /// 比较器的实现
    /// </summary>
    class StudengCompare : IComparer<Student>
    {

        public int Compare(Student x, Student y)
        {
            Console.WriteLine(x + "--" + y);
            //if (x.Id > y.Id)
            //{
            //    return 1;
            //}
            //else if (x.Id == y.Id)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return -1;
            //}

            //return x.Name.CompareTo(y.Name);
            return x.CompareTo(y);
        }
    }
}
