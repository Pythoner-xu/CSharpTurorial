using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearn
{
    /// <summary>
    /// 学习委托：
    /// session 1: 委托是如何诞生的（编程语言中每一中数据结构的存在，都必然有其存在的理由）；
    /// session 2: 委托是个什么东西，它有什么作用，能给我们编码带来什么便利；
    /// session 3: 委托的应用场景，我们什么时候能够用到委托；
    /// session 4: 利用委托构建自己的框架；
    /// session 5: 委托的高级使用：分析委托的源代码，了解它的工作原理是什么！！！内部是如何运行的！！！
    /// 
    /// 
    /// 
    /// 1、委托是一种类型：与类同级（属于引用类型）--直观点理解：委托也是一个类
    /// 2、委托特点：能够持有方法引用
    /// 3、委托拥有一个签名：参数和返回值；只能够持有与签名相匹配的方法引用
    /// 4、委托的功能：与C/C++中的函数指针十分类似，但又有区别
    /// 5、考虑到委托的作用：我们可以把委托理解成一个持有一个或多个方法的对象（就是一个委托实例对象，拥有一个列表成员来存储方法的引用）
    /// 6、委托的使用：【1】定义委托类型；【2】声明委托变量；【3】创建委托对象；【4】委托对象引用赋值给委托变量；【5】调用委托（对象执行）
    /// 
    /// </summary>
    class Program
    {
        // 定义一个委托的类型（注意：跟方法的声明比较类似）---C#编译器会自动将这行代码编译为类的IL
        public delegate void MyDelegate();
        static void Main(string[] args)
        {
            //string a = Math.Round(100f/100f, 2).ToString("#0.00");
            //Console.WriteLine(a);

            Test t = new Test();
            #region 实例调用
            t.Add();
            t.Sub();
            t.Multi();
            #endregion

            #region 委托调用
            // 定义一个委托变量（引用类型）
            MyDelegate myDel;
            // 创建一个委托的实例对象（参数必须是一个方法；可以是类方法（静态方法），实例方法）
            myDel = new MyDelegate(t.Add);
           
            // 委托多播机制（为委托添加方法）
            myDel += new MyDelegate(t.Sub); // +=运算符被重载了，其功能是：生成一个新委托，追加一个新的方法到这个新委托中
            //myDel += t.Add; // 简写方式
            //myDel = new MyDelegate(t.Sub); // 这行代码会生成新的委托对象引用并覆盖旧的（画图更明白）
            Console.WriteLine(myDel.GetInvocationList().Length); // 可以打印出委托对象持有的方法列表
            Console.WriteLine(myDel.Target); // 可以打印出委托对象持有方法的调用着
            // 为委托移除方法
            myDel -= new MyDelegate(t.Sub);
            myDel();

            // 合并委托（组合委托）
            MyDelegate myDel1;
            myDel1 = new MyDelegate(t.Multi);
            MyDelegate myDel2;
            myDel2 = new MyDelegate(t.Multi);
            myDel = myDel1 + myDel2; // +运算符被重载了，其功能是，合并两个委托持有的方法列表，生成一个新委托
            myDel();


            #endregion

            Console.ReadLine();
        }
    }

    //定义一个Test的类来测试委托
    class Test
    {
        public void Add()
        {
            Console.WriteLine("------执行Add");
        }

        public void Sub()
        {
            Console.WriteLine("------执行Sub");
        }

        public void Multi()
        {
            Console.WriteLine("-----执行Multi");
        }
    }
}
