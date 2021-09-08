using System.Xml; // XmlWriter
using System.IO; // FileStream
using System.Linq; // IQueryable<T>
using System.Text.Json; // 
using Microsoft.EntityFrameworkCore; // Include extension method
using Packt.Shared; // Northwind, Category, Product

using static System.Console;
using static System.IO.Path;
using static System.Environment;

namespace Exercise02
{
  class Program
  {
    static void Main(string[] args)
    {

      using (var db = new Northwind())
      {
        IQueryable<Category> categories = db.Categories.Include(c => c.Products);

        SerializeXml(categories);
        SerializeXml(categories, useAttributes: false);
        SerializeCsv(categories);
        SerializeJson(categories);
      }
    }

    private delegate void WriteDataDelegate(string name, string value);

    private static void SerializeXml(IQueryable<Category> categories, bool useAttributes = true)
    {
      string which = useAttributes ? "attibutes" : "elements";

      string xmlFile = $"Serialize-XML-{which}.xml";

      using (FileStream xmlStream = File.Create(
        Combine(CurrentDirectory, xmlFile)))
      {
        using (XmlWriter xml = XmlWriter.Create(xmlStream,
          new XmlWriterSettings { Indent = true }))
        {

          WriteDataDelegate writeMethod;

          if (useAttributes)
          {
            writeMethod = xml.WriteAttributeString;
          }
          else 
          {
            writeMethod = xml.WriteElementString;
          }

          xml.WriteStartDocument();
          xml.WriteStartElement("categories");

          foreach (Category c in categories)
          {
            xml.WriteStartElement("category");
            writeMethod("id", c.CategoryID.ToString());
            writeMethod("name", c.CategoryName);
            writeMethod("desc", c.Description);
            writeMethod("product_count", c.Products.Count.ToString());
            xml.WriteStartElement("products");

            foreach (Product p in c.Products)
            {
              xml.WriteStartElement("product");

              writeMethod("id", p.ProductID.ToString());
              writeMethod("name", p.ProductName);
              writeMethod("cost", p.Cost.Value.ToString());
              writeMethod("stock", p.Stock.ToString());
              writeMethod("discontinued", p.Discontinued.ToString());

              xml.WriteEndElement(); // </product>
            }
            xml.WriteEndElement(); // </products>
            xml.WriteEndElement(); // </category>
          }
          xml.WriteEndElement(); // </categories>
        }
      }

      WriteLine("{0} contains {1:N0} bytes.",
        arg0: xmlFile,
        arg1: new FileInfo(xmlFile).Length);
    }

    private static void SerializeCsv(IQueryable<Category> categories)
    {
      string csvFile = "Serialize-CSV.csv";

      using (FileStream csvStream = File.Create(Combine(CurrentDirectory, csvFile)))
      {
        using (var csv = new StreamWriter(csvStream))
        {

          csv.WriteLine("CategoryID,CategoryName,Description,ProductID,ProductName,Cost,Stock,Discontinued");

          foreach (Category c in categories)
          {
            foreach (Product p in c.Products)
            {
              csv.Write("{0},\"{1}\",\"{2}\",",
                arg0: c.CategoryID.ToString(),
                arg1: c.CategoryName,
                arg2: c.Description);

              csv.Write("{0},\"{1}\",{2},",
                arg0: p.ProductID.ToString(),
                arg1: p.ProductName,
                arg2: p.Cost.Value.ToString());

              csv.WriteLine("{0},{1}",
                arg0: p.Stock.ToString(),
                arg1: p.Discontinued.ToString());
            }
          }
        }
      }

      WriteLine("{0} contains {1:N0} bytes.",
        arg0: csvFile,
        arg1: new FileInfo(csvFile).Length);
    }

    private static void SerializeJson(IQueryable<Category> categories)
    {
      string JsonFile = "Serialize-Json.json";

      using (FileStream fs = File.Create(Combine(CurrentDirectory, JsonFile)))
      {
        using (var jw = new Utf8JsonWriter(fs,
          new JsonWriterOptions { Indented = true }))
        {
          jw.WriteStartObject();
          jw.WriteStartArray("categories");

          foreach (Category c in categories)
          {
            jw.WriteStartObject();

            jw.WriteNumber("id", c.CategoryID);
            jw.WriteString("name", c.CategoryName);
            jw.WriteString("desc", c.Description);
            jw.WriteNumber("product_count", c.Products.Count);

            jw.WriteStartArray("products");

            foreach (Product p in c.Products)
            {
              jw.WriteStartObject();

              jw.WriteNumber("id", p.ProductID);
              jw.WriteString("name", p.ProductName);
              jw.WriteNumber("cost", p.Cost.Value);
              jw.WriteNumber("stock", p.Stock.Value);
              jw.WriteBoolean("discontinued", p.Discontinued);

              jw.WriteEndObject(); // product
            }
            jw.WriteEndArray(); // products
            jw.WriteEndObject(); // category
          }
          jw.WriteEndArray(); // categories
          jw.WriteEndObject();
        }
      }

      WriteLine("{0} contains {1:N0} bytes.",
        arg0: JsonFile,
        arg1: new FileInfo(JsonFile).Length);
    }
  }
}