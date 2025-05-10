using HomeDecor.Core;
using HomeDecor.Models;
using HomeDecor.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HomeDecor.Pages
{
    public class CategoryPage : Page
    {
        [SerializeField] private TextMeshProUGUI _categoryName;
        [SerializeField] private CardList _cards;
        [SerializeField] private CategoriesList _categoriesList;
        private AppState _state;
        private string _currCategory;

        public override void Init(AppState state)
        {
            _state = state;
            _cards.OnCardClicked += OnCardClicked;
            _cards.OnAddToCartClicked += OnAddToCartClicked;
            _cards.OnWishlistClicked += OnWishlistClicked;
            _categoriesList.Init(_state.PageManager);
            SetCategory(Constants.Bedroom);
        }

        public override void Show() 
        {
            base.Show();
            _categoryName.text = _currCategory;
            List<Product> products = _state.Repository.GetProductsByCategory(_currCategory);
            _cards.Init(products, _state);
        }

        public void SetCategory(string categoryName)
        {
            _currCategory = categoryName;
        }

        private void OnCardClicked(Product product)
        {
            var productPage = _state.PageManager.Show<ProductPage>();
            productPage.Show(product, () => _state.PageManager.Show<CategoryPage>());
        }

        private void OnAddToCartClicked(Product product)
        {
            _state.CartManager.Toggle(product);
        }

        private void OnWishlistClicked(Product product)
        {
            _state.WishlistManager.Toggle(product);
        }
    }
}
