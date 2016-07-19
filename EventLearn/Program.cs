using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLearn
{
    /// <summary>
    /// 学习事件：
    /// session 1: 事件是如何诞生的；
    /// session 2: 事件是个什么东西，它有什么作用，能给我们编码带来什么便利；
    /// session 3: 事件的应用场景，我们什么时候能够用到事件；
    /// session 4: 利用事件构建自己的框架；
    /// session 5: 事件的高级使用：分析事件的源代码，了解它的工作原理是什么！！！内部是如何运行的！！！
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个发布者对象
            Publisher p = new Publisher();
            // 创建多个订阅者对象
            Subscriber s1 = new Subscriber("A");
            Subscriber s2 = new Subscriber("B");

            // 事件注册暴露在外面          
            p.m_Event += s1.OnResponseEvent;
            p.m_Event += s2.OnResponseEvent;

            p.RaiseEvent();

            Console.ReadLine();
        }
    }


    /// <summary>
    /// 发布者类
    /// 
    /// </summary>
    public class Publisher
    {
        #region 访问修饰符必须一致
        // 声明一个委托类型，用来实现事件
        public delegate void MyEventHandler();
        // 声明一个用于发布的事件
        public event MyEventHandler m_Event;
        #endregion

        // 类构造方法
        public Publisher()
        {
            Console.WriteLine("发布者构造完成");
        }

        // 注册事件
        //public void RegisterEvent()
        //{
            
        //}

        // 触发事件
        public void RaiseEvent()
        {
            if (this.m_Event != null)
            {
                m_Event();
            }
        }
    }
    
    /// <summary>
    /// 订阅者类
    /// </summary>
    public class Subscriber
    {
        private string name = "";

        // 类构造方法
        public Subscriber(string _name)
        {
            this.name = _name;
            Console.WriteLine(this.name + "订阅者构造完成");
        }

        // 定义一个方法（响应事件）
        public void OnResponseEvent()
        {
            Console.WriteLine(this.name + "接收事件");
        }
    }
}
