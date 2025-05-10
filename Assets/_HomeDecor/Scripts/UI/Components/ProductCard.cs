using HomeDecor.Models;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HomeDecor.UI 
{
    public class ProductCard : MonoBehaviour
    {
        [SerializeField] private Image _imgPreview;
        [SerializeField] private TextMeshProUGUI _header;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private Button _cardButton;
        [SerializeField] private Button _addToCartButton;
        [SerializeField] private Button _wishlistButton;
        private Product _product;

        public Action<Product> OnCardClicked;
        public Action<Product> OnAddToCartClicked;
        public Action<Product> OnWishlistClicked;

        private void Start()
        {
            _cardButton.onClick.AddListener(OnCardButtonClicked);
            _addToCartButton.onClick.AddListener(OnAddToCartButtonClicked);
            _wishlistButton.onClick.AddListener(OnWishlistButtonClicked);
        }
        public async void Init(Product product,bool isInCart, bool isInWishlist)
        {
            _product = product;
            _imgPreview.sprite = await DataRepository.GetSpriteById(product.ProductId);
            _header.text = product.Name;
            _description.text = product.Description;
            _cost.text = "$" + product.Cost;
            SetButtonIconState(_addToCartButton, isInCart);
            SetButtonIconState(_wishlistButton, isInWishlist);
        }

        private void OnCardButtonClicked()
        {
            OnCardClicked?.Invoke(_product);
        }

        private void OnAddToCartButtonClicked()
        {
            _addToCartButton.transform.DoClickEffect();
            OnAddToCartClicked?.Invoke(_product);
            UpdateButtonSprite(_addToCartButton);
        }

        private void OnWishlistButtonClicked()
        {
            _wishlistButton.transform.DoClickEffect();
            OnWishlistClicked?.Invoke(_product);
            UpdateButtonSprite(_wishlistButton);
        }

        private void SetButtonIconState(Button button, bool state)
        {
            var child = button.transform.GetChild(0).gameObject;
            child.SetActive(state);
        }

        private void UpdateButtonSprite(Button button) 
        {
            var child = button.transform.GetChild(0).gameObject;
            child.SetActive(!child.activeSelf);
        }
    }
}
