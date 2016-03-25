using System;
using ConfigNodeParser;

namespace ConfigNodeTest
{
    public class MyClass
    {
        public static void Main()
        {
            /*
            ConfigNode cn = new ConfigNode();
            cn.AddValue("Key1", "Value1");
            cn.AddValue("Key1", "Value4");
            cn.AddValue("Key2", "Value2");
            ConfigNode newNode = new ConfigNode("Test");
            newNode.AddValue("Key3", "Value3");
            cn.AddConfigNode(newNode);
            Console.WriteLine("Key1: " + cn.GetValue("Key1"));
            Console.WriteLine("Key2: " + cn.GetValue("Key2"));
            Console.WriteLine("Key3: " + cn.GetNode("Test").GetValue("Key3"));
            Console.WriteLine("===");
            foreach (string value in cn.GetValues("Key1"))
            {
                Console.WriteLine("Key1: " + value);
            }
            */
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            ConfigNode cn = ConfigNode.Load("GDL Moho Refueller.craft");
            sw.Stop();
            Console.WriteLine("cn nodes: " + cn.CountNodes + ", values: " + cn.CountValues);
            Console.WriteLine("Load Time: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            cn.Save("GDL Moho Refueller - test.craft");
            sw.Stop();
            Console.WriteLine("Save Time: " + sw.ElapsedMilliseconds);
        }
    }
}

