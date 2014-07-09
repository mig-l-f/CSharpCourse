using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Reflection;
using Reflections.Model;
using System.ComponentModel;


namespace Reflections
{
    public class Parser
    {
        private Assembly myAssembly = null;

        public Parser() 
        {
            myAssembly = Assembly.Load("Reflections");
        }

        public Object createInstance(String object_name)
        {
            Type typeToCreate = null;
            try
            {
                typeToCreate = myAssembly.GetType("Reflections.Model." + object_name);
                Console.WriteLine("Found {0}", typeToCreate.FullName);
            }
            catch (Exception)
            {
                Console.WriteLine("Type not found");
                return null;
            }
            try
            {                
                return myAssembly.CreateInstance(typeToCreate.FullName);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not create instance");
                return null;
            }
        }

        public void populateProperty(Object obj, string property_name, string value)
        {
            try
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(property_name);
                Console.WriteLine("Found property {0} of type {1}", propertyInfo.Name, propertyInfo.PropertyType);
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(propertyInfo.PropertyType);
                propertyInfo.SetValue(obj, converter.ConvertFrom(value));
            }
            catch (Exception)
            {
                Console.WriteLine("Property not found");
            }


        }

        public Object parseObject(XmlNode node)
        {
            string objectType = node.Name;

            Object obj = createInstance(objectType);

            if (obj != null)
            {
                XmlAttributeCollection attributes = node.Attributes;
                foreach (XmlAttribute attribute in attributes)
                {                    
                    populateProperty(obj, attribute.Name, attribute.Value);
                }
            }

            return obj;
        }

        public Object parseXml(string xml_file) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml_file);

            XmlNode node = doc.DocumentElement;

            return parseObject(node);
        }
    }
}
