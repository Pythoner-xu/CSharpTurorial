using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 引用反射的命名空间
using System.Reflection;

namespace ReflectionLearn
{
    /// <summary>
    /// 学习C#反射
    /// 功能：反射用于在运行时获取类型信息,可以访问一个正在运行的程序的元数据
    /// 1、运行时查看特性（attribute）信息
    /// 2、延迟绑定方法和属性（property）
    /// 3、运行时创建新类型，然后使用新类型执行一些任务
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //MemberInfo memInfo = typeof(MyClass);
            //object[] attributes = memInfo.GetCustomAttributes(true);


            MyClass mClass = new MyClass();
            // 1、获取类实例的类型
            //Type cType = mClass.GetType();
            Type cType = typeof(MyClass);
            // 2、获取从类型反射出所有的属性信息
            System.Reflection.PropertyInfo[] propertyInfos = cType.GetProperties();
            // 3、获取从类型反射出的指定的属性信息
            System.Reflection.PropertyInfo propertyInfo = cType.GetProperty("Property1");
            if (propertyInfo != null)
            {
                // 4、属性信息中包含了该实例的属性值等信息(获取值数据)
                int property1 = (int)propertyInfo.GetValue(mClass, null);
                Console.WriteLine("=====" + property1);
            }          

            Console.ReadLine();
        }
    }

    class MyClass
    {
        private int property1;

        public int Property1
        {
            get { return property1; }
            set { property1 = value; }
        }

    }


    class Util
    {
        // 泛型+反射：获取泛型的指定属性值
        public static string GetObjectPropertyValue<T>(T t, string propertyName)
        {
            Type type = t.GetType();
            //Type type = typeof(T);
            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
            {
                return string.Empty;                
            }

            object o = property.GetValue(t, null);
            if(o == null)
            {
                return string.Empty;
            }

            return o.ToString();
        }
    }
}
