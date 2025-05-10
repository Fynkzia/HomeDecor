using HomeDecor.Models;
using HomeDecor.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeDecor.UI
{
    public class CartList : MonoBehaviour
    {
        [SerializeField] private CartCard _cardPf;
        [SerializeField] private RectTransform _rect;

        private List<CartCard> _cards = new List<CartCard>();
        public Action<Product> OnCardClicked;
        public Action<Product> OnRemoveFromCartClicked;
        public Action<Product> OnIncreaseQuantityClicked;
        public Action<Product> OnDecreaseQuantityClicked;

        public void Init(List<CartItem> items)
        {
            Clear();
            foreach (CartItem item in items)
            {
                var card = Instantiate(_cardPf, _rect);
                card.Init(item);
                card.transform.DoPopIn();
                card.OnCardClicked += OnCardButtonClicked;
                card.OnRemoveFromCartClicked += OnRemoveFromCartClicked;
                card.OnIncreaseQuantityClicked += OnIncreaseQuantityClicked;
                card.OnDecreaseQuantityClicked += OnDecreaseQuantityClicked;

                _cards.Add(card);
            }
        }

        private void OnCardButtonClicked(Product product)
        {
            OnCardClicked?.Invoke(product);
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
