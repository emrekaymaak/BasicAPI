using System;

namespace BasicApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string KeyWord { get; set; }
        public string DetailContent { get; set; }
        public string ShortContent { get; set; }

    }
}
