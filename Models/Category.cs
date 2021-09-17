using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable

namespace agoravai.Models
{
    [Serializable]
    public partial class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        //[XmlArray("Products")] 
        public virtual List<Product> Products { get; set; }
    }
}
