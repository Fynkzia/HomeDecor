using HomeDecor.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeDecor.Domain 
{
    public class WishlistManager 
    {
        private const string WishlistKey = Constants.WishlistKey;
        public List<Product> Items => _items;

        private List<Product> _items;
        private readonly IDataRepository _repository;

        public WishlistManager(IDataRepository repository)
        {
            _repository = repository;
            _items = _repository.LoadList<Product>(WishlistKey);
        }

        public void Toggle(Product product) 
        {
            var existing = _items.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (existing != null)
            {
                _items.Remove(existing);
            }
            else
            {
                _items.Add(product);
            }

            _repository.SaveList(WishlistKey, _items);
        }

        public bool Contains(Product product)
        {
            return _items.Any(p => p.ProductId == product.ProductId);
        }
    }

}
