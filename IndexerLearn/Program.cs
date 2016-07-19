using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerLearn
{
    /// <summary>
    /// 学习索引器（Indexer）
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class PropertyClass
    {
        // field
        private string name;
        // property:编译后自动生成get_Name()/set_Name(string)
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class IndexerClass
    {
        // const常量：被编译成静态static
        const int size = 10;
        private string[] nameList = new string[size];
        // 索引器：编译后会自动生成两个方法get_Item(int)/set_Item(int, string)
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < size)
                {
                    return this.nameList[index];
                }
                else
                {
                    return "";
                }
            }

            set
            {
                if (index >= 0 && index < size)
                {
                    this.nameList[index] = value;
                }
            }
        }

        // 索引器重载
        public int this[string name]
        {
            get
            {
                int index = 0;
                foreach (var v in this.nameList)
                {
                    if (v == name)
                    {
                        break;
                    }
                    index++;
                }

                return index;
            }
        }
    }
}
