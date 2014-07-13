using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Xml;
using Reflections;
using Reflections.Model;
using NUnit.Framework;
using System.Reflection;

namespace ReflectionsTest
{
    [TestFixture]
    public class ParserTest
    {
        Parser parser = null;

        [SetUp]
        public void setUp()
        {
            Assembly assembly = Assembly.Load("Reflections");
            parser = new Parser(assembly);
        }

        [Test]
        public void createInstanceTest()
        {            
            var target = parser.createInstance("Person");
            Assert.AreEqual(typeof(Person), target.GetType());
        }

        [Test]
        public void populatePropertyTest()
        {
         
            Person p = new Person();
            parser.populateProperty(p, "name", "Miguel");

            Assert.AreEqual("Miguel", p.name);
        }

        [Test]
        public void populatePropertyWithIntTest()
        {
         
            Person p = new Person();
            parser.populateProperty(p, "age", "33");

            Assert.AreEqual(33, p.age);
        }

        [Test]
        public void parseObjectTest()
        {
         
            string myXml = @"<Person name=""Bob"" age=""14"" />";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(myXml);
            XmlNode node = doc.DocumentElement;
            Person p = (Person)parser.parseObject(node);
            Assert.AreEqual("Bob", p.name);
            Assert.AreEqual(14, p.age);
        }
    }
}
