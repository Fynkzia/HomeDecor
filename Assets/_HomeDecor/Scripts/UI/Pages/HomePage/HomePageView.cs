using HomeDecor.Core;
using HomeDecor.Models;
using HomeDecor.Pages;
using HomeDecor.UI;
using UnityEngine;

namespace HomeDecor.Pages 
{
    public class HomePageView : Page
    {

        [SerializeField] private CardList _newCollectionList;
        [SerializeField] private CategoriesList _categoriesList;
        private AppState _state;
        public override void Init(AppState state)
        {
            _state = state;
            _newCollectionList.OnCardClicked += OnCardClicked;
            _newCollectionList.OnAddToCartClicked += OnAddToCartClicked;
            _newCollectionList.OnWishlistClicked += OnWishlistClicked;
        }
        public override void Show()
        {
            base.Show();
            var products = _state.Repository.GetProductsByCategory(Constants.NewCollection);
            _newCollectionList.Init(products,_state);
            _categoriesList.Init(_state.PageManager);
        }
        private void OnCardClicked(Product product)
        {

            var productPage = _state.PageManager.Show<ProductPage>();
            productPage.Show(product, () => _state.PageManager.Show<HomePageView>());
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
