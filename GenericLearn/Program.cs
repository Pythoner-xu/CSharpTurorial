using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLearn
{
    /// <summary>
    /// 泛型Generic学习
    /// </summary>
    class Program
    {
        // 3、泛型委托和泛型事件
        private delegate void MyDelegate<T>(T m);
        private event MyDelegate<int> m_Event;

        static void Main(string[] args)
        {

            Console.ReadLine();
        }

        // 4、泛型方法
        void Sort<T>(ref T m, ref T n)
        {
            T temp = m;
            m = n;
            n = temp;
        }
    }

    // 1、泛型接口
    public interface IGenericInterface<T>
    {

    }

    // 2、泛型类
    public class GenericClass<T>
    {
        private T[] m_Array;
    }

    // 5、泛型委托
    public delegate void GenericDelegate<T>(T m);
}
