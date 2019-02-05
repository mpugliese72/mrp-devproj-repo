using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain.Core
{
    public class Products
    {
        public string _jsonFile;
       
        private IEnumerable<Product> _items;

        public IEnumerable<Product> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Products(string dataPath)
        {
            _jsonFile = dataPath;
            _items = LoadProducts();
        }

        private IEnumerable<Product> LoadProducts()
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(_jsonFile));

            return products;
        }

    }
}
