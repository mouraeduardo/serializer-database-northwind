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
            Products = new HashSet<Product>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        [XmlIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
