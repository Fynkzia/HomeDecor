using HomeDecor.Core;
using HomeDecor.Models;
using HomeDecor.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeDecor.Pages 
{
    public class WishlistPage : Page
    {
        [SerializeField] private CardList _wishList;
        [SerializeField] private GameObject _emptyView;
        private AppState _state;
        public override void Init(AppState state)
        {
            _state = state;
            _wishList.OnCardClicked += OnCardClicked;
            _wishList.OnAddToCartClicked += OnAddToCartClicked;
            _wishList.OnWishlistClicked += OnWishlistClicked;
        }

        public override void Show() 
        {
            base.Show();
            RefreshWishlist();
        }

        private void RefreshWishlist()
        {
            var items = _state.WishlistManager.Items;
            bool hasItems = items.Count > 0;

            _wishList.gameObject.SetActive(hasItems);
            _emptyView.gameObject.SetActive(!hasItems);

            if (hasItems)
            {
                _wishList.Init(items,_state);
            }
        }

        private void OnCardClicked(Product product)
        {

            var productPage = _state.PageManager.Show<ProductPage>();
            productPage.Show(product, () => _state.PageManager.Show<WishlistPage>());
        }

        private void OnAddToCartClicked(Product product)
        {
            _state.CartManager.Toggle(product);
        }

        private void OnWishlistClicked(Product product)
        {
            _state.WishlistManager.Toggle(product);
            RefreshWishlist();
        }
    }
}
