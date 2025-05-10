using HomeDecor.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeDecor.Domain
{
    public class CartManager
    {
        private const string CartKey = Constants.CartKey;
        private readonly IDataRepository _repository;
        private List<CartItem> _items;

        public List<CartItem> Items => _items;

        public CartManager(IDataRepository repository)
        {
            _repository = repository;
            _items = _repository.LoadList<CartItem>(CartKey);
        }

        public void Add(Product product)
        {
            var existing = _items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (existing == null) _items.Add(new CartItem { Product = product, Quantity = 1 });

            _repository.SaveList(CartKey, _items);
        }

        public void Remove(Product product)
        {
            var item = _items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (item != null)
            {
                _items.Remove(item);
                _repository.SaveList(CartKey, _items);
            }
        }

        public void Toggle(Product product)
        {
            var existing = _items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);

            if (existing != null)
            {
                _items.Remove(existing);
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = 1 });
            }

            _repository.SaveList(CartKey, _items);
        }

        public bool Contains(Product product) =>
            _items.Any(i => i.Product.ProductId == product.ProductId);

        public float GetTotalPrice() => _items.Sum(i => i.Product.Cost * i.Quantity);
    }


}
