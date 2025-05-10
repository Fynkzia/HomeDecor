using HomeDecor.Core;
using HomeDecor.Pages;
using UnityEngine;
using UnityEngine.UI;

namespace HomeDecor.UI
{
    public class NavigationBar : MonoBehaviour
    {

        [SerializeField] private Button _btnHome;
        [SerializeField] private Button _btnCategories;
        [SerializeField] private Button _btnCart;
        [SerializeField] private Button _btnWishlist;
        [SerializeField] private Button _btnProfile;

        public void Init(AppState state)
        {
            _btnHome.onClick.AddListener(() => state.PageManager.Show<HomePageView>());
            _btnCategories.onClick.AddListener(() => state.PageManager.Show<CategoryPage>());
            _btnCart.onClick.AddListener(() => state.PageManager.Show<CartPage>());
            _btnWishlist.onClick.AddListener(() => state.PageManager.Show<WishlistPage>());
            //_btnProfile.onClick.AddListener(() => _pageManager.Show<ProfilePage>());

        }

        private void OnDestroy()
        {
            _btnHome.onClick.RemoveAllListeners();
            _btnCategories.onClick.RemoveAllListeners();
            _btnCart.onClick.RemoveAllListeners();
            _btnWishlist.onClick.RemoveAllListeners();
            _btnProfile.onClick.RemoveAllListeners();
        }

    }
}
