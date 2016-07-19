using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearn2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个发布者
            Publisher p = new Publisher();
            // 创建多个订阅者
            Subscriber s1 = new Subscriber("A");
            Subscriber s2 = new Subscriber("B");

            // 订阅者向发布者发出订阅行为
            p.RegisterEvent(s1.OnResponseEvent);
            p.RegisterEvent(s2.OnResponseEvent);

            // 触发事件
            p.RaiseEvent();

            p.RemoveEvent(s1.OnResponseEvent);
            p.RaiseEvent();

            Console.ReadLine();
        }
    }


    #region 委托实现：发布者订阅者模式
    /// <summary>
    /// 定义一个发布者类
    /// </summary>
    public class Publisher
    {
        public delegate void MyDelegate();
        private MyDelegate m_Event;

        public Publisher()
        {
            Console.WriteLine("创建发布者成功");
        }

        public void RegisterEvent(MyDelegate _handler)
        {
            Console.WriteLine("有人订阅");
            if (this.m_Event != null)
            {
                this.m_Event += _handler;
            }
            else
            {
                this.m_Event = _handler;
            }
        }
        public void RemoveEvent(MyDelegate _handler)
        {
            Console.WriteLine("有人取消订阅");
            if (this.m_Event != null)
            {
                this.m_Event -= _handler;
            }
        }
        public void RaiseEvent()
        {
            Console.WriteLine("触发事件");
            if (this.m_Event != null)
            {
                this.m_Event();
            }
        }
    }
    /// <summary>
    /// 定义一个订阅者类
    /// </summary>
    public class Subscriber
    {
        private string name = "";
        public Subscriber(string _name)
        {
            Console.WriteLine("创建订阅者成功");
            this.name = _name;
        }

        // 定义一个事件响应的方法
        public void OnResponseEvent()
        {
            Console.WriteLine(this.name + "接收到事件通知并响应事件");

        }
    }
    #endregion
}
