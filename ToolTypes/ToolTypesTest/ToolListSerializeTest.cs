using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using ToolTypes.Model.Tools;
using System.IO;

namespace ToolTypesTest
{
    [TestFixture]
    class ToolListSerializeTest
    {
        [Test]
        public void testToolJsonSerialize()
        {
            Tool t = new Tool() { toolID = 1, toolLabel = "this is a label" };
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tool));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, t);

            String target = Encoding.UTF8.GetString(stream.ToArray());
            String output = @"{""toolID"":1,""toolLabel"":""this is a label""}";
            Assert.AreEqual(output, target);
        }

        [Test]
        public void testToolJsonDeserialize()
        {
            String input = @" {
                                ""toolID"" : 1 ,
                                ""toolLabel"" : ""this is a label""
                              }";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tool));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(input));
            Tool tool = (Tool)serializer.ReadObject(stream);
            Assert.AreEqual(1, tool.toolID, "ToolID should be equal");
            Assert.AreEqual("this is a label", tool.toolLabel, "Tool Label should be equal");
        }

        [Test]
        public void testToolDeserializeFailsWithException()
        {
            String input = @" {                                
                                ""toolLabel"" : ""this is a label""
                              }";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tool));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(input));
            Assert.Throws<SerializationException>( delegate { serializer.ReadObject(stream); } );
        }

        [Test]
        public void testToolListSerialize()
        {
            ToolList list = new ToolList();

            list.toollist.Add(new Tool() { toolID = 1, toolLabel = "teste"});
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ToolList));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, list);

            String target = Encoding.UTF8.GetString(stream.ToArray());
            String output = @"{""toollist"":[{""toolID"":1,""toolLabel"":""teste""}]}";
            Assert.AreEqual(output, target);
        }

        [Test]
        public void testToolListDeserialize()
        {
            String input = @" {
                                ""toollist"" : [
                                    { ""toolID"": 4,
                                      ""toolLabel"": ""teste""
                                    },
                                    { ""toolID"": 6,
                                      ""toolLabel"": ""teste 2""
                                    }
                                ]
                              }";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ToolList));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            ToolList target = new ToolList();
            target = (ToolList)serializer.ReadObject(stream);
            Assert.IsTrue(target != null, "Should be an object");
            Assert.AreEqual(2, target.toollist.Count, "Tool list should have 2 tools");
            Assert.AreEqual(6, target.toollist[1].toolID, "Tool ID should be 6");
        }
    }
}
