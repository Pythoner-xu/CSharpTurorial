using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLearn2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个发布者（唯一）
            Publisher p = new Publisher("publiser");
            // 创建多个订阅接受者
            Subscriber s1 = new Subscriber("A");
            Subscriber s2 = new Subscriber("B");

            // 订阅者向发布者发出订阅行为
            p.RegisterEvent(s1.onResponseEvent);
            p.RegisterEvent(s2.onResponseEvent);

            // 发布行为
            p.RaiseEvent();

            p.RemoveEvent(s1.onResponseEvent);

            p.RaiseEvent();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 定义一个发布者类
    /// </summary>
    public class Publisher
    {
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private event EventHandler m_Event;

        public Publisher(string _name)
        {
            this.name = _name;
            Console.WriteLine("发布者创建完成");
        }

        // 注册事件
        public void RegisterEvent(EventHandler _handler)
        {
            // 
            Console.WriteLine("有人订阅");
            this.m_Event += _handler;
        }

        // 取消注册事件
        public void RemoveEvent(EventHandler _handler)
        {
            Console.WriteLine("有人取消订阅");
            this.m_Event -= _handler;
        }

        // 触发事件1：不支持事件参数
        public void RaiseEvent()
        {
            if (this.m_Event != null)
            {
                EventArgs e = new EventArgs();
                this.m_Event(this, e);
            }
        }
        // 触发事件2：支持事件参数
        public void RaiseEvent(EventArgs e)
        {
            if (this.m_Event != null)
            {
                this.m_Event(this, e);
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
            this.name = _name;
            Console.WriteLine("创建一个订阅者成功");
        }

        // 定义响应事件的函数
        public void onResponseEvent(object sender, EventArgs e)
        {
            Console.WriteLine(this.name + "订阅者接收到事件" + ((Publisher)sender).Name);
        }
    }
}
