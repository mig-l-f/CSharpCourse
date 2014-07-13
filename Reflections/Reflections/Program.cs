using System;
using System.Reflection;
using Reflections.Model;

namespace Reflections
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly assembly = Assembly.Load("Reflections");
            Parser parser = new Parser(assembly);
            Object obj = parser.parseXml("../../Data/types.xml");

            Console.WriteLine((Person)obj);

            Console.WriteLine("Finish");
            Console.Read();
        }
    }
}
