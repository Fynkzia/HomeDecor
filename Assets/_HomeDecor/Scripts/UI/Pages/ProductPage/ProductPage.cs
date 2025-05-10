using HomeDecor.Core;
using HomeDecor.Models;
using HomeDecor.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HomeDecor.Pages
{
    public class ProductPage : Page
    {
        [SerializeField] private TextMeshProUGUI _txtTitle;
        [SerializeField] private TextMeshProUGUI _txtDescription;
        [SerializeField] private TextMeshProUGUI _txtCost;
        [SerializeField] private ObjectRotation _objectContainer;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _addToCartButton;
        [SerializeField] private TextMeshProUGUI _cartText;
        [SerializeField] private Button _wishlistButton;


        private AppState _state;
        private Product _product;
        private bool isInWishlist;
        private bool isInCart;
        public override void Init(AppState state)
        {
            _state = state;
        }
        public void Show(Product product, UnityAction onBack)
        {
            base.Show();
            _product = product;

            _txtTitle.text = product.Name;
            _txtDescription.text = product.Description;
            _txtCost.text = "$" + product.Cost;

            _objectContainer.Init(product.ProductId);

            _backButton.onClick.AddListener(onBack);
            
            _addToCartButton.onClick.AddListener(UpdateCart);
            _wishlistButton.onClick.AddListener(UpdateWishlist);

            isInWishlist = _state.WishlistManager.Contains(_product);
            isInCart = _state.CartManager.Contains(_product);
            SetWishlistIcon();
            SetCartText();
        }

        public override void Hide()
        {
            base.Hide();
            _backButton.onClick.RemoveAllListeners();
            _addToCartButton.onClick.RemoveAllListeners();
            _wishlistButton.onClick.RemoveAllListeners();

            _objectContainer.Clear();
        }

        private void UpdateWishlist()
        {
            _wishlistButton.transform.DoClickEffect();
            _state.WishlistManager.Toggle(_product);
            isInWishlist = !isInWishlist;
            SetWishlistIcon();
        }

        private void UpdateCart() 
        {
            _addToCartButton.transform.DoClickEffect();
            _state.CartManager.Toggle(_product);
            isInCart = !isInCart;
            SetCartText();
        }

        private void SetWishlistIcon()
        {
            var child = _wishlistButton.transform.GetChild(0).gameObject;
            child.SetActive(isInWishlist);
        }

        private void SetCartText()
        {
            _cartText.text = isInCart ? "Remove from Cart" : "Add to Cart";
        }

    }
}
