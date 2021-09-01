using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using agoravai.Models;

namespace agoravai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AppDbcontext context = new AppDbcontext();

            var Categories = context.Categories.ToList();

            //SerializarBin(Categories);
            //SerializarXml(Categories);
            //SerializarJson(Categories);
        }

        static void SerializarBin(List<Category> Categories)
        {
            FileStream fs = new FileStream(@"C:\Users\eduar\OneDrive\Área de Trabalho\agoravai\filebinary.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Categories);
            fs.Close();
        }
        static void SerializarXML (List<Category> Categories)
        {
            FileStream fs = new FileStream(@"C:\Users\eduar\OneDrive\Área de Trabalho\agoravai\fileXML.xml", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<Category>));
            xs.Serialize(fs, Categories);
            fs.Close();

        }
        static void SerializarJson(List<Category> categories)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\eduar\OneDrive\Área de Trabalho\agoravai\fileJSON.json"))
            {
                sw.Write(JsonSerializer.Serialize(categories));
            }
        }
    }
}
