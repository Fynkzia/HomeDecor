using HomeDecor.Models;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HomeDecor.UI
{
    public class CartCard : MonoBehaviour
    {
        [SerializeField] private Image _imgPreview;
        [SerializeField] private TextMeshProUGUI _header;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private TextMeshProUGUI _quantityText;

        [SerializeField] private Button _cardButton;
        [SerializeField] private Button _btnPlus;
        [SerializeField] private Button _btnMinus;
        [SerializeField] private Button _btnRemove;

        private CartItem _cartItem;

        public Action<Product> OnCardClicked;
        public Action<Product> OnRemoveFromCartClicked;
        public Action<Product> OnIncreaseQuantityClicked;
        public Action<Product> OnDecreaseQuantityClicked;

        public async void Init(CartItem cartItem)
        {
            _cartItem = cartItem;
            Product product = cartItem.Product;

            _imgPreview.sprite = await DataRepository.GetSpriteById(product.ProductId);
            _header.text = product.Name;
            _cost.text = "$" + product.Cost;
            UpdateQuantityUI();

            _cardButton.onClick.AddListener(() => OnCardClicked?.Invoke(product));
            _btnRemove.onClick.AddListener(() => OnRemoveFromCartClicked?.Invoke(product));
            _btnPlus.onClick.AddListener(OnPlusButtonClicked);
            _btnMinus.onClick.AddListener(OnMinusButtonClicked);

        }

        private void OnPlusButtonClicked()
        {
            _cartItem.Quantity++;
            UpdateQuantityUI();
            OnIncreaseQuantityClicked?.Invoke(_cartItem.Product);
        }

        private void OnMinusButtonClicked()
        {
            _cartItem.Quantity--;
            UpdateQuantityUI();
            OnDecreaseQuantityClicked?.Invoke(_cartItem.Product);
        }

        private void UpdateQuantityUI()
        {
            _quantityText.text = _cartItem.Quantity.ToString();
            _btnPlus.interactable = _cartItem.Quantity < 99;
            _btnMinus.interactable = _cartItem.Quantity > 1;
        }
    }
}
