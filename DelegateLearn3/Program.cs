using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearn3
{
   
    #region 自定义泛型委托<>中定义泛型占位符T(可以是T1...)
    // 参数，返回值都用泛型表示，并且都是同一类型
    public delegate T MyGenericDelegate1<T>(T n);
    // 单个参数用泛型表示，返回值明确
    public delegate void MyGenericDelegate2<T>(T n);
    // 多个参数用泛型表示，返回值明确
    public delegate void MyGenericDelegate3<T1, T2>(T1 m, T2 n);
    // 参数，返回值都用泛型表示，并且参数和返回值的泛型不一样
    public delegate TResult MyGenericDelegate4<T, TResult>(T n);
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region C#预定义的泛型委托
            // 原型：public delegate TResult Func<in T, out TResult>(T arg);  
            // Func<>是一个泛型委托类型（有返回值，最后一个为委托方法的返回值类型）
            Func<int, bool> myDelegate = (a) => { return a > 1; };

            // 原型：public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
            // Action<>是一个泛型委托类型（没有返回值，全为委托方法的参数类型）
            Action<int, int> myDelegate2 = (a, b) => {
                Console.WriteLine("");
            };
            #endregion

            #region C#预定义的委托类型
            // 原型：public delegate void Action();
            // actiong是一个没有返回值，没有参数的委托类型（c#内部定义的一个委托类型）
            Action myDelegate3 = () => {
                Console.WriteLine("");
            };
            #endregion


            Console.WriteLine(19980 / 10000f);

            Console.WriteLine((19980 * 1.0f / 10000f).ToString("#0.00"));

            // 保留
            Console.WriteLine(Math.Floor(1.33f * 1000) / 1000f);

            Console.ReadLine();
        }
    }
}
