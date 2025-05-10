using HomeDecor.Core;
using HomeDecor.Models;
using HomeDecor.UI;
using System.Linq;
using TMPro;
using UnityEngine;

namespace HomeDecor.Pages
{
    public class CartPage : Page
    {

        [SerializeField] private CartList _cartList;
        [SerializeField] private GameObject _emptyView;
        [SerializeField] private TextMeshProUGUI _totalPrice;

        private AppState _state;
        public override void Init(AppState state)
        {
            _state = state;
            _cartList.OnCardClicked += OnCardButtonClicked;
            _cartList.OnRemoveFromCartClicked += OnRemoveClicked;
            _cartList.OnIncreaseQuantityClicked += OnIncreaseQuantity;
            _cartList.OnDecreaseQuantityClicked += OnDecreaseQuantity;
        }

        public override void Show()
        {
            base.Show();
            RefreshCartList();
        }

        private void RefreshCartList()
        {
            var items = _state.CartManager.Items;
            bool hasItems = items.Count > 0;

            _cartList.gameObject.SetActive(hasItems);
            _emptyView.gameObject.SetActive(!hasItems);

            if (hasItems)
            {
                _cartList.Init(items);
                UpdateTotal();
            }
        }

        private void OnCardButtonClicked(Product product) 
        {
            var productPage = _state.PageManager.Show<ProductPage>();
            productPage.Show(product, () => _state.PageManager.Show<CartPage>());
        }
        private void OnRemoveClicked(Product product)
        {
            _state.CartManager.Remove(product);
            RefreshCartList();
        }
        private void OnIncreaseQuantity(Product product)
        {
            _state.CartManager.Add(product);
            UpdateTotal();
        }

        private void OnDecreaseQuantity(Product product)
        {
            var item = _state.CartManager.Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            _state.Repository.SaveList(Constants.CartKey, _state.CartManager.Items);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            _totalPrice.text = "$"+_state.CartManager.GetTotalPrice();
        }
    }

}
