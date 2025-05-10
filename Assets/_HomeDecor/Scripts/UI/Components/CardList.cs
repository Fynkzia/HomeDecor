using HomeDecor.Core;
using HomeDecor.Models;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HomeDecor.UI 
{
    public class CardList : MonoBehaviour
    {
        [SerializeField] private ProductCard _cardPf;
        [SerializeField] private RectTransform _rect;

        public Action<Product> OnCardClicked;
        public Action<Product> OnAddToCartClicked;
        public Action<Product> OnWishlistClicked;

        private List<ProductCard> _cards = new List<ProductCard>();

        public void Init(List<Product> products, AppState state)
        {
            Clear();
            foreach (Product product in products)
            {
                var card = Instantiate(_cardPf, _rect);

                bool isInCart = state.CartManager.Contains(product);
                bool isInWishlist = state.WishlistManager.Contains(product);

                card.Init(product, isInCart, isInWishlist);
                card.transform.DoPopIn();
                card.OnCardClicked += OnCardButtonClicked;
                card.OnAddToCartClicked += OnAddToCartButtonClicked;
                card.OnWishlistClicked += OnWishlistButtonClicked;
                _cards.Add(card);
            }
        }

        private void OnCardButtonClicked(Product product)
        {
            OnCardClicked?.Invoke(product);
        }

        private void OnAddToCartButtonClicked(Product product)
        {
            OnAddToCartClicked?.Invoke(product);
        }
        private void OnWishlistButtonClicked(Product product)
        {
            OnWishlistClicked?.Invoke(product);
        }

        public void Clear()
        {
            foreach (var card in _cards)
            {
                Destroy(card.gameObject);
            }
            _cards.Clear();
        }
    }
}
