using System.Collections.Generic;

namespace HomeDecor.Models
{
    [System.Serializable]
    public class Category
    {
        public string Name;
        public List<Product> Products;
    }
    public class Product
    {
        public string ProductId;
        public string Name;
        public string Description;
        public float Cost;
    }

}
